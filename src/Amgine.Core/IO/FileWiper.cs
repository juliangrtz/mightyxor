using Amgine.Common.Logging;
using Amgine.Core.Crypto.KeyGenerators;

namespace Amgine.Core.IO;

/// <summary>
/// ToDo: Reference better file shredding software
/// Serves as a I/O utility class to wipe files permanently by overwriting them.
/// </summary>
public class FileWiper
{
    private readonly string _filePath;

    public FileWiper(string filePath)
    {
        _filePath = filePath;
    }

    private void ChangeDates(DateTime date)
    {
        File.SetCreationTime(_filePath, date);
        File.SetLastAccessTime(_filePath, date);
        File.SetLastWriteTime(_filePath, date);

        File.SetCreationTimeUtc(_filePath, date);
        File.SetLastAccessTimeUtc(_filePath, date);
        File.SetLastWriteTimeUtc(_filePath, date);
    }

    private void OverrideFile(int timesToWrite)
    {
        // Calculate the total number of sectors in the file.
        var sectors = Math.Ceiling(new FileInfo(_filePath).Length / 512.0);

        // Create a dummy-buffer the size of a sector.
        var dummyBuffer = new byte[512];

        // Create a cryptographic RNG
        var rng = new PRNG();

        // Open a FileStream to the file.
        FileStream inputStream = new(_filePath, FileMode.Open);
        for (var currentPass = 0; currentPass < timesToWrite; currentPass++)
        {
            // Go to the beginning of the stream
            inputStream.Position = 0;

            // Loop all sectors
            for (var sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
            {
                // Fill the dummy-buffer with random data
                dummyBuffer = rng.GenerateKey(dummyBuffer.Length);

                // Write it to the stream
                inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
            }
        }

        // Truncate the file to 0 bytes.
        // This will hide the original file-length if you try to recover the file.
        inputStream.SetLength(0);

        // Close the stream.
        inputStream.Close();
    }

    /// <summary>
    /// Deletes the specified file in a secure way by overwriting it
    /// with random garbage data n times.
    /// </summary>
    /// <param name="timesToWrite">Specifies the number of times the file should be overwritten</param>
    public void WipeFile(int timesToWrite)
    {
        try
        {
            if (!File.Exists(_filePath))
                return;

            // Set the files attributes to normal in case it's read-only.
            File.SetAttributes(_filePath, FileAttributes.Normal);

            // Override the file sector-wise
            OverrideFile(timesToWrite);

            // As an extra precaution the dates of the file are changed so the
            // original dates are hidden if one tries to recover the file.
            ChangeDates(new DateTime(2042, 1, 1, 1, 1, 1));

            // Finally, delete the file
            File.Delete(_filePath);
        }
        catch (Exception ex)
        {
            Log($"Failed to wipe {_filePath}: {ex}", LogType.Error);
        }
    }
}