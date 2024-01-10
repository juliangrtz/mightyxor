namespace MightyXOR.GUI.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        infoLbl = new MetroFramework.Controls.MetroLabel();
        decryptTile = new MetroFramework.Controls.MetroTile();
        encryptTile = new MetroFramework.Controls.MetroTile();
        menuTabControl = new MetroFramework.Controls.MetroTabControl();
        aboutTabPage = new TabPage();
        aboutLbl = new MetroFramework.Controls.MetroLabel();
        pictureBox1 = new PictureBox();
        otpTabPage = new TabPage();
        secretSharingTabPage = new TabPage();
        distributeTile = new MetroFramework.Controls.MetroTile();
        reconstructTile = new MetroFramework.Controls.MetroTile();
        toolsTabPage = new TabPage();
        entropyUtilTile = new MetroFramework.Controls.MetroTile();
        fileWiperTile = new MetroFramework.Controls.MetroTile();
        settingsTabPage = new TabPage();
        openLogDirectoryBtn = new MetroFramework.Controls.MetroButton();
        logLevelCbo = new MetroFramework.Controls.MetroComboBox();
        logLevelLbl = new MetroFramework.Controls.MetroLabel();
        loggingSettingsLbl = new MetroFramework.Controls.MetroLabel();
        licenseTabPage = new TabPage();
        licenseTxt = new RichTextBox();
        metroStyleManager = new MetroFramework.Components.MetroStyleManager(components);
        metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(components);
        toolTip = new ToolTip(components);
        menuTabControl.SuspendLayout();
        aboutTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        otpTabPage.SuspendLayout();
        secretSharingTabPage.SuspendLayout();
        toolsTabPage.SuspendLayout();
        settingsTabPage.SuspendLayout();
        licenseTabPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)metroStyleManager).BeginInit();
        SuspendLayout();
        // 
        // infoLbl
        // 
        infoLbl.Dock = DockStyle.Bottom;
        infoLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        infoLbl.Location = new Point(20, 297);
        infoLbl.Name = "infoLbl";
        infoLbl.Size = new Size(434, 29);
        infoLbl.TabIndex = 1;
        infoLbl.Text = "Info";
        infoLbl.TextAlign = ContentAlignment.MiddleCenter;
        infoLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // decryptTile
        // 
        decryptTile.ActiveControl = null;
        decryptTile.Location = new Point(239, 14);
        decryptTile.Name = "decryptTile";
        decryptTile.Size = new Size(135, 160);
        decryptTile.TabIndex = 5;
        decryptTile.Text = "Decrypt";
        decryptTile.TextAlign = ContentAlignment.BottomCenter;
        decryptTile.Theme = MetroFramework.MetroThemeStyle.Dark;
        decryptTile.TileImage = (Image)resources.GetObject("decryptTile.TileImage");
        decryptTile.TileImageAlign = ContentAlignment.MiddleCenter;
        decryptTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
        decryptTile.UseCustomBackColor = true;
        decryptTile.UseSelectable = true;
        decryptTile.UseTileImage = true;
        // 
        // encryptTile
        // 
        encryptTile.ActiveControl = null;
        encryptTile.Location = new Point(38, 14);
        encryptTile.Name = "encryptTile";
        encryptTile.Size = new Size(135, 160);
        encryptTile.TabIndex = 4;
        encryptTile.Text = "Encrypt";
        encryptTile.TextAlign = ContentAlignment.BottomCenter;
        encryptTile.Theme = MetroFramework.MetroThemeStyle.Dark;
        encryptTile.TileImage = (Image)resources.GetObject("encryptTile.TileImage");
        encryptTile.TileImageAlign = ContentAlignment.MiddleCenter;
        encryptTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
        encryptTile.UseCustomBackColor = true;
        encryptTile.UseSelectable = true;
        encryptTile.UseTileImage = true;
        // 
        // menuTabControl
        // 
        menuTabControl.Controls.Add(aboutTabPage);
        menuTabControl.Controls.Add(otpTabPage);
        menuTabControl.Controls.Add(secretSharingTabPage);
        menuTabControl.Controls.Add(toolsTabPage);
        menuTabControl.Controls.Add(settingsTabPage);
        menuTabControl.Controls.Add(licenseTabPage);
        menuTabControl.Dock = DockStyle.Fill;
        menuTabControl.Location = new Point(20, 60);
        menuTabControl.Name = "menuTabControl";
        menuTabControl.Padding = new Point(6, 8);
        menuTabControl.SelectedIndex = 0;
        menuTabControl.Size = new Size(434, 237);
        menuTabControl.TabIndex = 6;
        menuTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
        menuTabControl.UseSelectable = true;
        // 
        // aboutTabPage
        // 
        aboutTabPage.BackColor = Color.Black;
        aboutTabPage.Controls.Add(aboutLbl);
        aboutTabPage.Controls.Add(pictureBox1);
        aboutTabPage.Location = new Point(4, 38);
        aboutTabPage.Name = "aboutTabPage";
        aboutTabPage.Size = new Size(426, 195);
        aboutTabPage.TabIndex = 3;
        aboutTabPage.Text = "About";
        // 
        // aboutLbl
        // 
        aboutLbl.AutoSize = true;
        aboutLbl.Dock = DockStyle.Bottom;
        aboutLbl.Location = new Point(0, 62);
        aboutLbl.Name = "aboutLbl";
        aboutLbl.Size = new Size(439, 133);
        aboutLbl.TabIndex = 1;
        aboutLbl.Text = resources.GetString("aboutLbl.Text");
        aboutLbl.TextAlign = ContentAlignment.MiddleCenter;
        aboutLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        aboutLbl.UseCustomBackColor = true;
        // 
        // pictureBox1
        // 
        pictureBox1.Dock = DockStyle.Top;
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(426, 62);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // otpTabPage
        // 
        otpTabPage.BackColor = Color.Black;
        otpTabPage.Controls.Add(encryptTile);
        otpTabPage.Controls.Add(decryptTile);
        otpTabPage.Location = new Point(4, 35);
        otpTabPage.Name = "otpTabPage";
        otpTabPage.Size = new Size(426, 198);
        otpTabPage.TabIndex = 0;
        otpTabPage.Text = "OTP";
        otpTabPage.ToolTipText = "Allows encryption and decryption of files using a one-time pad (OTP).";
        // 
        // secretSharingTabPage
        // 
        secretSharingTabPage.BackColor = Color.Black;
        secretSharingTabPage.Controls.Add(distributeTile);
        secretSharingTabPage.Controls.Add(reconstructTile);
        secretSharingTabPage.Location = new Point(4, 35);
        secretSharingTabPage.Name = "secretSharingTabPage";
        secretSharingTabPage.Size = new Size(426, 198);
        secretSharingTabPage.TabIndex = 5;
        secretSharingTabPage.Text = "Secret sharing";
        // 
        // distributeTile
        // 
        distributeTile.ActiveControl = null;
        distributeTile.Location = new Point(45, 17);
        distributeTile.Name = "distributeTile";
        distributeTile.Size = new Size(135, 160);
        distributeTile.TabIndex = 6;
        distributeTile.Text = "Distribute";
        distributeTile.TextAlign = ContentAlignment.BottomCenter;
        distributeTile.Theme = MetroFramework.MetroThemeStyle.Dark;
        distributeTile.TileImage = (Image)resources.GetObject("distributeTile.TileImage");
        distributeTile.TileImageAlign = ContentAlignment.MiddleCenter;
        distributeTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
        distributeTile.UseCustomBackColor = true;
        distributeTile.UseSelectable = true;
        distributeTile.UseTileImage = true;
        // 
        // reconstructTile
        // 
        reconstructTile.ActiveControl = null;
        reconstructTile.Location = new Point(246, 17);
        reconstructTile.Name = "reconstructTile";
        reconstructTile.Size = new Size(135, 160);
        reconstructTile.TabIndex = 7;
        reconstructTile.Text = "Reconstruct";
        reconstructTile.TextAlign = ContentAlignment.BottomCenter;
        reconstructTile.Theme = MetroFramework.MetroThemeStyle.Dark;
        reconstructTile.TileImage = (Image)resources.GetObject("reconstructTile.TileImage");
        reconstructTile.TileImageAlign = ContentAlignment.MiddleCenter;
        reconstructTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
        reconstructTile.UseCustomBackColor = true;
        reconstructTile.UseSelectable = true;
        reconstructTile.UseTileImage = true;
        // 
        // toolsTabPage
        // 
        toolsTabPage.BackColor = Color.Black;
        toolsTabPage.Controls.Add(entropyUtilTile);
        toolsTabPage.Controls.Add(fileWiperTile);
        toolsTabPage.Location = new Point(4, 35);
        toolsTabPage.Name = "toolsTabPage";
        toolsTabPage.Size = new Size(426, 198);
        toolsTabPage.TabIndex = 1;
        toolsTabPage.Text = "Tools";
        // 
        // entropyUtilTile
        // 
        entropyUtilTile.ActiveControl = null;
        entropyUtilTile.Location = new Point(239, 14);
        entropyUtilTile.Name = "entropyUtilTile";
        entropyUtilTile.Size = new Size(135, 160);
        entropyUtilTile.TabIndex = 6;
        entropyUtilTile.Text = "Entropy utility";
        entropyUtilTile.TextAlign = ContentAlignment.BottomCenter;
        entropyUtilTile.Theme = MetroFramework.MetroThemeStyle.Dark;
        entropyUtilTile.TileImage = (Image)resources.GetObject("entropyUtilTile.TileImage");
        entropyUtilTile.TileImageAlign = ContentAlignment.MiddleCenter;
        entropyUtilTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
        entropyUtilTile.UseCustomBackColor = true;
        entropyUtilTile.UseSelectable = true;
        entropyUtilTile.UseTileImage = true;
        // 
        // fileWiperTile
        // 
        fileWiperTile.ActiveControl = null;
        fileWiperTile.Location = new Point(38, 14);
        fileWiperTile.Name = "fileWiperTile";
        fileWiperTile.Size = new Size(135, 160);
        fileWiperTile.TabIndex = 5;
        fileWiperTile.Text = "File wiper";
        fileWiperTile.TextAlign = ContentAlignment.BottomCenter;
        fileWiperTile.Theme = MetroFramework.MetroThemeStyle.Dark;
        fileWiperTile.TileImage = (Image)resources.GetObject("fileWiperTile.TileImage");
        fileWiperTile.TileImageAlign = ContentAlignment.MiddleCenter;
        fileWiperTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
        fileWiperTile.UseCustomBackColor = true;
        fileWiperTile.UseSelectable = true;
        fileWiperTile.UseTileImage = true;
        // 
        // settingsTabPage
        // 
        settingsTabPage.BackColor = Color.Black;
        settingsTabPage.Controls.Add(openLogDirectoryBtn);
        settingsTabPage.Controls.Add(logLevelCbo);
        settingsTabPage.Controls.Add(logLevelLbl);
        settingsTabPage.Controls.Add(loggingSettingsLbl);
        settingsTabPage.Location = new Point(4, 35);
        settingsTabPage.Name = "settingsTabPage";
        settingsTabPage.Size = new Size(426, 198);
        settingsTabPage.TabIndex = 4;
        settingsTabPage.Text = "Settings";
        // 
        // openLogDirectoryBtn
        // 
        openLogDirectoryBtn.Location = new Point(231, 40);
        openLogDirectoryBtn.Name = "openLogDirectoryBtn";
        openLogDirectoryBtn.Size = new Size(181, 30);
        openLogDirectoryBtn.TabIndex = 5;
        openLogDirectoryBtn.Text = "Open log directory";
        openLogDirectoryBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        openLogDirectoryBtn.UseSelectable = true;
        // 
        // logLevelCbo
        // 
        logLevelCbo.FormattingEnabled = true;
        logLevelCbo.ItemHeight = 23;
        logLevelCbo.Location = new Point(104, 41);
        logLevelCbo.Name = "logLevelCbo";
        logLevelCbo.Size = new Size(114, 29);
        logLevelCbo.TabIndex = 4;
        logLevelCbo.Theme = MetroFramework.MetroThemeStyle.Dark;
        logLevelCbo.UseSelectable = true;
        // 
        // logLevelLbl
        // 
        logLevelLbl.AutoSize = true;
        logLevelLbl.Location = new Point(31, 46);
        logLevelLbl.Name = "logLevelLbl";
        logLevelLbl.Size = new Size(64, 19);
        logLevelLbl.TabIndex = 2;
        logLevelLbl.Text = "Log level:";
        logLevelLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        logLevelLbl.UseCustomBackColor = true;
        // 
        // loggingSettingsLbl
        // 
        loggingSettingsLbl.AutoSize = true;
        loggingSettingsLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        loggingSettingsLbl.Location = new Point(12, 10);
        loggingSettingsLbl.Name = "loggingSettingsLbl";
        loggingSettingsLbl.Size = new Size(74, 25);
        loggingSettingsLbl.Style = MetroFramework.MetroColorStyle.Teal;
        loggingSettingsLbl.TabIndex = 0;
        loggingSettingsLbl.Text = "Logging";
        loggingSettingsLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        loggingSettingsLbl.UseCustomBackColor = true;
        loggingSettingsLbl.UseStyleColors = true;
        // 
        // licenseTabPage
        // 
        licenseTabPage.BackColor = Color.Black;
        licenseTabPage.Controls.Add(licenseTxt);
        licenseTabPage.Location = new Point(4, 35);
        licenseTabPage.Name = "licenseTabPage";
        licenseTabPage.Size = new Size(426, 198);
        licenseTabPage.TabIndex = 2;
        licenseTabPage.Text = "License";
        // 
        // licenseTxt
        // 
        licenseTxt.BackColor = Color.Black;
        licenseTxt.Dock = DockStyle.Fill;
        licenseTxt.ForeColor = Color.White;
        licenseTxt.Location = new Point(0, 0);
        licenseTxt.Name = "licenseTxt";
        licenseTxt.ReadOnly = true;
        licenseTxt.Size = new Size(426, 198);
        licenseTxt.TabIndex = 0;
        licenseTxt.Text = "";
        // 
        // metroStyleManager
        // 
        metroStyleManager.Owner = this;
        metroStyleManager.Style = MetroFramework.MetroColorStyle.Teal;
        metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // toolTip
        // 
        toolTip.ToolTipIcon = ToolTipIcon.Info;
        toolTip.ToolTipTitle = "Explanation";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(474, 346);
        Controls.Add(menuTabControl);
        Controls.Add(infoLbl);
        KeyPreview = true;
        MaximizeBox = false;
        Name = "MainForm";
        Resizable = false;
        Style = MetroFramework.MetroColorStyle.Teal;
        Text = "MightyXOR";
        TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
        Theme = MetroFramework.MetroThemeStyle.Dark;
        KeyDown += MainForm_KeyDown;
        menuTabControl.ResumeLayout(false);
        aboutTabPage.ResumeLayout(false);
        aboutTabPage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        otpTabPage.ResumeLayout(false);
        secretSharingTabPage.ResumeLayout(false);
        toolsTabPage.ResumeLayout(false);
        settingsTabPage.ResumeLayout(false);
        settingsTabPage.PerformLayout();
        licenseTabPage.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)metroStyleManager).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private MetroFramework.Controls.MetroLabel infoLbl;
    private MetroFramework.Controls.MetroTile decryptTile;
    private MetroFramework.Controls.MetroTile encryptTile;
    private MetroFramework.Controls.MetroTabControl menuTabControl;
    private TabPage otpTabPage;
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private MetroFramework.Components.MetroStyleExtender metroStyleExtender;
    private TabPage toolsTabPage;
    private MetroFramework.Controls.MetroTile fileWiperTile;
    private MetroFramework.Controls.MetroTile entropyUtilTile;
    private TabPage licenseTabPage;
    private RichTextBox licenseTxt;
    private TabPage aboutTabPage;
    private PictureBox pictureBox1;
    private MetroFramework.Controls.MetroLabel aboutLbl;
    private TabPage settingsTabPage;
    private MetroFramework.Controls.MetroLabel loggingSettingsLbl;
    private MetroFramework.Controls.MetroButton openLogDirectoryBtn;
    private MetroFramework.Controls.MetroComboBox logLevelCbo;
    private MetroFramework.Controls.MetroLabel logLevelLbl;
    private ToolTip toolTip;
    private TabPage secretSharingTabPage;
    private MetroFramework.Controls.MetroTile distributeTile;
    private MetroFramework.Controls.MetroTile reconstructTile;
}