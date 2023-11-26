using System.IO;

namespace Amgine.UnitTests
{
    /// <summary>
    /// Utility class for unit tests.
    /// </summary>
    internal static class Util
    {
        /// <summary>
        /// Replaces bytes in a given file.
        /// </summary>
        /// <param name="filename">Path to the file</param>
        /// <param name="position">Offset</param>
        /// <param name="data">Data that is written</param>
        public static void ReplaceData(string filename, int position, byte[] data)
        {
            using Stream stream = File.Open(filename, FileMode.Open);
            stream.Position = position;
            stream.Write(data, 0, data.Length);
        }
    }
}