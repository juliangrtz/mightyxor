using Amgine.Common.Logging;
using Amgine.GUI.Forms;

namespace Amgine.GUI;

internal static class Program
{
    public const LogLevel DefaultLogLevel = LogLevel.Detailed;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Logger.LogLevel = DefaultLogLevel;
        Logger.Initialize();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}