namespace MightyXOR.Core.SecretSharing.Shamir
{
    /// <summary>
    /// Utility class specifically for the Shamir secret sharing algorithm.
    /// </summary>
    internal static class MathUtil
    {
        /// <summary>
        /// Generates a polynomial with random coefficients of degree k-1.
        /// </summary>
        public static Field[] GeneratePolynomial(byte k, byte s)
        {
            if (k == 0)
                throw new ArgumentException("k may not be zero.", nameof(k));

            var rng = new Random();
            var fields = new Field[k];
            fields[0] = new Field(s);

            for (byte i = 1; i < k; i++)
            {
                // ToDo: Enforce quantum randomness
                var current = (byte)rng.Next(1, Field.Order);
                var field = new Field(current);

                fields[i] = field;
            }
            return fields;
        }
    }
}