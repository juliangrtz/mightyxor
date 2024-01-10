namespace MightyXOR.Common
{
    /// <summary>
    /// Extends various objects with useful methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Deletes a file if it exists under the specified path.
        /// </summary>
        public static void DeleteIfExists(this FileInfo file)
        {
            if (file.Exists)
                File.Delete(file.FullName);
        }
    }
}