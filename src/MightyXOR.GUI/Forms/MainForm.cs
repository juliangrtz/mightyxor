using MightyXOR.Common.Logging;
using MightyXOR.GUI.Forms.Tools;
using MightyXOR.GUI.Utils;
using MetroFramework.Forms;
using System.Diagnostics;
using System.Text;
using MightyXOR.GUI.Forms.OTP;
using MightyXOR.GUI.Forms.SecretSharing;

namespace MightyXOR.GUI.Forms;

public partial class MainForm : MetroForm
{
    public static readonly Color DarkThemeColor = Color.FromArgb(34, 34, 34);

    // Reduce flickering
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;
            return cp;
        }
    }

    public MainForm()
    {
        InitializeComponent();
        SetBackColors();
        RegisterClickEvents();
        SetupSettings();

        infoLbl.Text = $@"MightyXOR {Constants.Version}{(BetaVersion ? "-beta" : "")}";
        licenseTxt.Text = Encoding.UTF8.GetString(Properties.Resources.LICENSE);
    }

    private void SetupSettings()
    {
        var logLevels = Enum.GetNames(typeof(LogLevel));
        logLevelCbo.Items.AddRange(logLevels.ToArray<object>());
        logLevelCbo.SelectedIndex = Array.IndexOf(logLevels, Program.DefaultLogLevel.ToString());
        logLevelCbo.SelectedIndexChanged += LogLevelCbo_SelectedIndexChanged;
    }

    private void SetBackColors()
    {
        foreach (TabPage tabPage in menuTabControl.TabPages)
            tabPage.BackColor = DarkThemeColor;

        licenseTxt.BackColor = DarkThemeColor;
        aboutLbl.BackColor = DarkThemeColor;
        loggingSettingsLbl.BackColor = DarkThemeColor;
        logLevelLbl.BackColor = DarkThemeColor;
    }

    private void RegisterClickEvents()
    {
        encryptTile.Click += EncryptTile_Click;
        decryptTile.Click += DecryptTile_Click;
        distributeTile.Click += DistributeTile_Click;
        reconstructTile.Click += ReconstructTile_Click;
        entropyUtilTile.Click += EntropyUtilTile_Click;
        fileWiperTile.Click += FileWiperTile_Click;
        openLogDirectoryBtn.Click += OpenLogDirectoryBtn_Click;
    }

    private void LogLevelCbo_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var selectedLogLevel = logLevelCbo.SelectedItem as string ?? Program.DefaultLogLevel.ToString();
        Logger.LogLevel = Enum.Parse<LogLevel>(selectedLogLevel);
    }

    /*
     * Tiles
     * ToDo: Find better way of showing forms (currently too redundant)
     */

    private static void EncryptTile_Click(object? sender, EventArgs e)
        => new EncryptForm().Show();

    private static void DecryptTile_Click(object? sender, EventArgs e)
        => new DecryptForm().Show();

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
        => KeyEventUtil.HandleKeyDownEvent(e);

    private static void FileWiperTile_Click(object? sender, EventArgs e)
        => new FileWiper().Show();

    private static void EntropyUtilTile_Click(object? sender, EventArgs e)
        => new EntropyUtility().Show();

    private void OpenLogDirectoryBtn_Click(object? sender, EventArgs e)
        => Process.Start("explorer.exe", $"{Environment.CurrentDirectory}\\Logs");

    private void DistributeTile_Click(object? sender, EventArgs e)
        => new Distributor().Show();

    private void ReconstructTile_Click(object? sender, EventArgs e)
        => new Reconstructor().Show();
}