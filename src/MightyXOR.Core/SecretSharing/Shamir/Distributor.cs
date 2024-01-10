using MightyXOR.Common.Logging;
using MightyXOR.Common.Serialization;
using MightyXOR.Core.Models;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.Core.SecretSharing.Shamir
{
    /// <summary>
    /// This class helps distributing a secret via the Shamir secret sharing scheme.
    /// The split secret can be recovered with the <see cref="Reconstructor"/>.
    /// </summary>
    public class Distributor
    {
        public const string ShareFileExtension = ".share";
        private readonly string _pathToSecret = null!;
        private readonly MightyXorFile _mightyXorFile = null!;

        /// <summary>
        /// Constructs a Distributor using a file path.
        /// </summary>
        /// <param name="pathToSecret">The path to the secret that is to be distributed</param>>
        public Distributor(string pathToSecret)
        {
            _pathToSecret = pathToSecret;
        }

        /// <summary>
        /// Constructs a Distributor using an MightyXOR file that stores metadata of the secret.
        /// </summary>
        /// <param name="mightyXorFile">The MightyXOR file</param>
        public Distributor(MightyXorFile mightyXorFile)
        {
            _mightyXorFile = mightyXorFile;
        }

        /// <summary>
        /// Generates file shares for the specified input.
        /// </summary>
        /// <param name="n">Number of participants</param>
        /// <param name="k">Number of shares needed to reconstruct the secret</param>
        /// <param name="outputDirectory">Optional output directory of the shares</param>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<string> GenerateFileShares(byte n, byte k, string outputDirectory = "")
        {
            CheckParameters(n, k);

            try
            {
                var fileArr = _mightyXorFile == null
                    ? File.ReadAllBytes(_pathToSecret)
                    : new BsonSerializer().SerializeObject(_mightyXorFile).ToArray();

                var byteShares = new byte[n][];

                for (byte i = 0; i < n; i++)
                    byteShares[i] = new byte[fileArr.Length + 1];

                // byteShares[j][i] => share i-1 of player j
                // byteShares[j][0] => the absissca (X value) of player j
                for (var i = 0; i < fileArr.Length; i++)
                {
                    var currentShares = GenerateShares(fileArr[i], n, k);
                    for (byte j = 0; j < n; j++)
                    {
                        if (i == 0)
                            byteShares[j][0] = (byte)currentShares[j].X;

                        byteShares[j][i + 1] = (byte)currentShares[j].Y;
                    }
                }

                var shares = WriteShares(n, byteShares, outputDirectory);
                return shares;
            }
            catch (Exception ex)
            {
                Log($"Failed to distribute the secret: {ex}", LogType.Error);
                return Array.Empty<string>();
            }
        }

        private IEnumerable<string> WriteShares(byte n, byte[][] byteShares, string outputDirectory)
        {
            var shares = new List<string>();
            for (byte i = 0; i < n; i++)
            {
                var directory = outputDirectory.Equals(string.Empty)
                    ? Environment.CurrentDirectory
                    : outputDirectory;
                var fileName = _pathToSecret == null ? _mightyXorFile.Header?.Name : new FileInfo(_pathToSecret).Name;
                var shareFileName = $"{directory}\\{fileName}_{i + 1}{ShareFileExtension}";

                using var fsWrite = new FileStream(shareFileName, FileMode.Create, FileAccess.Write);
                fsWrite.Write(byteShares[i], 0, byteShares[i].Length);

                Log($"Generated share {shareFileName}.", LogLevel.Detailed);
                shares.Add(shareFileName);
            }

            return shares;
        }

        private static void CheckParameters(byte n, byte k)
        {
            if (n <= 0)
            {
                throw new ArgumentException("The number of participants may not be 0!", nameof(n));
            }

            if (k <= 0)
            {
                throw new ArgumentException("The number of required shares may not be 0!", nameof(k));
            }

            if (k > n)
            {
                throw new ArgumentException("The number of required shares must be less than or equal to the number of participants!");
            }
        }

        private static Share[] GenerateShares(byte s, byte n, byte k)
        {
            var shares = new Share[n];
            var randomPolynomial = MathUtil.GeneratePolynomial(k, s);

            for (byte i = 0; i < n; i++)
            {
                var x = new Field((byte)(i + 1));
                var y = new Field(0);

                // Iterate coefficients
                for (byte j = 0; j < k; j++)
                    y += randomPolynomial[j] * Field.Pow((Field)(i + 1), j);

                shares[i] = new Share(x, y);
            }

            return shares;
        }
    }
}