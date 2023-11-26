using Amgine.Common.Logging;
using Amgine.Common.Serialization;
using Amgine.Core.Models;

namespace Amgine.Core.SecretSharing.Shamir
{
    /// <summary>
    /// Reconstructs secrets that were split with the <see cref="Distributor"/>.
    /// </summary>
    public class Reconstructor
    {
        private const string DefaultSecretFilename = "secret.bin";
        private readonly List<string> _shares;

        /// <summary>
        /// Constructs the class with a variable number of arguments representing the paths to the shares.
        /// </summary>
        /// <param name="shares">The previously distributed shares</param>
        public Reconstructor(params string[] shares)
        {
            if (shares.Length < 2)
                throw new ArgumentException("Cannot reconstruct a secret with less than two shares!", nameof(shares));

            _shares = shares.ToList();
        }

        /// <summary>
        /// Constructs the class with a list of paths to the shares.
        /// </summary>
        /// <param name="shares">The previously distributed shares</param>
        public Reconstructor(List<string> shares)
        {
            _shares = shares;
        }

        private void CheckParameters(byte k)
        {
            if (k == 0)
            {
                throw new ArgumentException("k cannot be 0!", nameof(k));
            }

            if (_shares.Count < k)
            {
                throw new ArgumentException("The number of share files cannot be less than k!", nameof(k));
            }
        }

        /// <summary>
        /// Reconstructs the secret frin the first k share files
        /// </summary>
        /// <param name="k">Number of files to use</param>
        /// <param name="isAmgineFile">Is the secret an Amgine file?</param>
        /// <param name="outputDirectory">Output directory of the secret</param>
        public void Reconstruct(byte k, bool isAmgineFile, string outputDirectory)
        {
            CheckParameters(k);

            try
            {
                Share[][] shares = RetrieveSharesFromFiles(k);

                // Iterate shares
                var secretBytes = RetrieveSecretFromShares(k, shares);

                // Write secret
                if (isAmgineFile)
                {
                    var amgineFile = new BsonSerializer().DeserializeObject<AmgineFile>(secretBytes);
                    amgineFile?.PersistContent($"{outputDirectory}\\{amgineFile.Header?.Name}");
                }
                else
                    File.WriteAllBytes($"{outputDirectory}\\{DefaultSecretFilename}", secretBytes);
            }
            catch (Exception ex)
            {
                var shares = string.Join(", ", _shares);
                Log($"Failed to reconstruct {{{shares}}}: {ex}", LogType.Error);
            }
        }

        private static byte[] RetrieveSecretFromShares(byte k, Share[][] shares)
        {
            var secret = new Field[shares[0].Length];
            var secretBytes = new byte[secret.Length];

            for (var i = 0; i < shares[0].Length; i++)
            {
                var currentShares = new Share[k];
                for (var j = 0; j < k; j++)
                {
                    currentShares[j] = shares[j][i];
                }

                secret[i] = ReconstructSecret(currentShares, k);
                secretBytes[i] = (byte)secret[i];
            }

            return secretBytes;
        }

        private Share[][] RetrieveSharesFromFiles(byte k)
        {
            var shares = new Share[k][];

            for (var i = 0; i < k; i++)
            {
                using FileStream fs = new(_shares[i], FileMode.Open, FileAccess.Read);
                var xValue = (byte)i;
                var curShares = new Share[fs.Length - 1];

                for (var j = 0; j < fs.Length; j++)
                {
                    if (j == 0)
                        xValue = (byte)fs.ReadByte();
                    else
                        curShares[j - 1] = new Share((Field)xValue, (Field)fs.ReadByte());
                }

                shares[i] = curShares;
                fs.Close();
            }

            return shares;
        }

        private static Field ReconstructSecret(Share[] shares, byte k)
        {
            var secret = new Field(0);

            for (byte i = 0; i < k; i++)
            {
                var currentShare = shares[i].Y;
                for (byte j = 0; j < k; j++)
                {
                    if (j != i)
                        currentShare *= (shares[j].X / (shares[j].X - shares[i].X));
                }
                secret += currentShare;
            }

            return secret;
        }
    }
}