namespace MightyXOR.Common.Utility;

/// <summary>
/// Serves as a utility class to measure entropy.
/// Helpful when assessing the entropy of cryptographic keys.
/// </summary>
public static class EntropyUtil
{
    private static Dictionary<byte, int> CreateOccurenceDictionary(IEnumerable<byte> bytes)
    {
        var map = new Dictionary<byte, int>();
        foreach (var b in bytes)
        {
            if (!map.ContainsKey(b))
                map.Add(b, 1);
            else
                map[b] += 1;
        }

        return map;
    }

    /// <summary>
    /// Returns the Shannon entropy of a byte array (see <see href="https://en.wikipedia.org/wiki/Entropy_(information_theory)#Definition"></see>)
    /// </summary>
    /// <param name="bytes">Bytes to be measured</param>
    public static double ShannonEntropy(byte[] bytes)
    {
        var map = CreateOccurenceDictionary(bytes);

        var entropy = 0.0;
        var len = bytes.Length;

        foreach (var item in map)
        {
            var frequency = (double)item.Value / len;
            entropy -= frequency * (Math.Log(frequency) / Math.Log(2));
        }
        return entropy;
    }
}