using Amgine.Common.Exceptions;
using Amgine.Common.Logging;
using LogLevel = Amgine.Common.Logging.LogLevel;

namespace Amgine.Core.IO;

/// <summary>
/// Serves as a I/O utility class to read files used for en- and decryption.
/// It can read files up to ~2.1 GB.
/// </summary>
public class FileReader
{
    private readonly string _filePath;

    public FileReader(string path)
    {
        _filePath = path;
    }

    private void CheckEmptiness(IEnumerable<byte> fileContent)
    {
        if (!fileContent.Any())
        {
            throw new InvalidFileException($"{_filePath} is empty.");
        }
    }

    private void CheckFileExistence()
    {
        if (!File.Exists(_filePath))
        {
            throw new InvalidFileException(
                $"The provided file path {_filePath} does not point to an existing file.");
        }
    }

    /// <summary>
    /// Returns a <see cref="FileInfo"/> and file contents as a byte array for a given file path.
    /// Several checks are performed beforehand.
    /// </summary>
    /// <exception cref="InvalidFileException"></exception>
    /// <exception cref="IOException"></exception>
    public (FileInfo, byte[]) ReadFileData()
    {
        Log($"Performing file checks for {_filePath}...", LogType.Debug, LogLevel.Detailed);

        try
        {
            CheckFileExistence();

            var fileInfo = new FileInfo(_filePath);
            var fileContent = File.ReadAllBytes(_filePath); // ToDo: Use MemoryMappedFile for large files

            CheckEmptiness(fileContent);

            Log($"File {_filePath} successfully read.", LogType.Debug, LogLevel.Detailed);
            return (fileInfo, fileContent);
        }
        catch (Exception)
        {
            Log($"Failed to read {_filePath}! Please make sure the file is not locked.", LogType.Error);
            throw;
        }
    }
}