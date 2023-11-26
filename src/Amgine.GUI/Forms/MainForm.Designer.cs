namespace Amgine.GUI.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.infoLbl = new MetroFramework.Controls.MetroLabel();
            this.decryptTile = new MetroFramework.Controls.MetroTile();
            this.encryptTile = new MetroFramework.Controls.MetroTile();
            this.menuTabControl = new MetroFramework.Controls.MetroTabControl();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.aboutLbl = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.otpTabPage = new System.Windows.Forms.TabPage();
            this.secretSharingTabPage = new System.Windows.Forms.TabPage();
            this.distributeTile = new MetroFramework.Controls.MetroTile();
            this.reconstructTile = new MetroFramework.Controls.MetroTile();
            this.toolsTabPage = new System.Windows.Forms.TabPage();
            this.entropyUtilTile = new MetroFramework.Controls.MetroTile();
            this.fileWiperTile = new MetroFramework.Controls.MetroTile();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.openLogDirectoryBtn = new MetroFramework.Controls.MetroButton();
            this.logLevelCbo = new MetroFramework.Controls.MetroComboBox();
            this.logLevelLbl = new MetroFramework.Controls.MetroLabel();
            this.loggingSettingsLbl = new MetroFramework.Controls.MetroLabel();
            this.licenseTabPage = new System.Windows.Forms.TabPage();
            this.licenseTxt = new System.Windows.Forms.RichTextBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuTabControl.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.otpTabPage.SuspendLayout();
            this.secretSharingTabPage.SuspendLayout();
            this.toolsTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.licenseTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // infoLbl
            // 
            this.infoLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.infoLbl.Location = new System.Drawing.Point(20, 297);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(434, 29);
            this.infoLbl.TabIndex = 1;
            this.infoLbl.Text = "Info";
            this.infoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // decryptTile
            // 
            this.decryptTile.ActiveControl = null;
            this.decryptTile.Location = new System.Drawing.Point(239, 14);
            this.decryptTile.Name = "decryptTile";
            this.decryptTile.Size = new System.Drawing.Size(135, 160);
            this.decryptTile.TabIndex = 5;
            this.decryptTile.Text = "Decrypt";
            this.decryptTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.decryptTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.decryptTile.TileImage = ((System.Drawing.Image)(resources.GetObject("decryptTile.TileImage")));
            this.decryptTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.decryptTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.decryptTile.UseCustomBackColor = true;
            this.decryptTile.UseSelectable = true;
            this.decryptTile.UseTileImage = true;
            // 
            // encryptTile
            // 
            this.encryptTile.ActiveControl = null;
            this.encryptTile.Location = new System.Drawing.Point(38, 14);
            this.encryptTile.Name = "encryptTile";
            this.encryptTile.Size = new System.Drawing.Size(135, 160);
            this.encryptTile.TabIndex = 4;
            this.encryptTile.Text = "Encrypt";
            this.encryptTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.encryptTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.encryptTile.TileImage = ((System.Drawing.Image)(resources.GetObject("encryptTile.TileImage")));
            this.encryptTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.encryptTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.encryptTile.UseCustomBackColor = true;
            this.encryptTile.UseSelectable = true;
            this.encryptTile.UseTileImage = true;
            // 
            // menuTabControl
            // 
            this.menuTabControl.Controls.Add(this.aboutTabPage);
            this.menuTabControl.Controls.Add(this.otpTabPage);
            this.menuTabControl.Controls.Add(this.secretSharingTabPage);
            this.menuTabControl.Controls.Add(this.toolsTabPage);
            this.menuTabControl.Controls.Add(this.settingsTabPage);
            this.menuTabControl.Controls.Add(this.licenseTabPage);
            this.menuTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTabControl.Location = new System.Drawing.Point(20, 60);
            this.menuTabControl.Name = "menuTabControl";
            this.menuTabControl.Padding = new System.Drawing.Point(6, 8);
            this.menuTabControl.SelectedIndex = 0;
            this.menuTabControl.Size = new System.Drawing.Size(434, 237);
            this.menuTabControl.TabIndex = 6;
            this.menuTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.menuTabControl.UseSelectable = true;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.BackColor = System.Drawing.Color.Black;
            this.aboutTabPage.Controls.Add(this.aboutLbl);
            this.aboutTabPage.Controls.Add(this.pictureBox1);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 38);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(426, 195);
            this.aboutTabPage.TabIndex = 3;
            this.aboutTabPage.Text = "About";
            // 
            // aboutLbl
            // 
            this.aboutLbl.AutoSize = true;
            this.aboutLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aboutLbl.Location = new System.Drawing.Point(0, 62);
            this.aboutLbl.Name = "aboutLbl";
            this.aboutLbl.Size = new System.Drawing.Size(430, 133);
            this.aboutLbl.TabIndex = 1;
            this.aboutLbl.Text = resources.GetString("aboutLbl.Text");
            this.aboutLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.aboutLbl.UseCustomBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(426, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // otpTabPage
            // 
            this.otpTabPage.BackColor = System.Drawing.Color.Black;
            this.otpTabPage.Controls.Add(this.encryptTile);
            this.otpTabPage.Controls.Add(this.decryptTile);
            this.otpTabPage.Location = new System.Drawing.Point(4, 35);
            this.otpTabPage.Name = "otpTabPage";
            this.otpTabPage.Size = new System.Drawing.Size(426, 198);
            this.otpTabPage.TabIndex = 0;
            this.otpTabPage.Text = "OTP";
            this.otpTabPage.ToolTipText = "Allows encryption and decryption of files using a one-time pad (OTP).";
            // 
            // secretSharingTabPage
            // 
            this.secretSharingTabPage.BackColor = System.Drawing.Color.Black;
            this.secretSharingTabPage.Controls.Add(this.distributeTile);
            this.secretSharingTabPage.Controls.Add(this.reconstructTile);
            this.secretSharingTabPage.Location = new System.Drawing.Point(4, 35);
            this.secretSharingTabPage.Name = "secretSharingTabPage";
            this.secretSharingTabPage.Size = new System.Drawing.Size(426, 198);
            this.secretSharingTabPage.TabIndex = 5;
            this.secretSharingTabPage.Text = "Secret sharing";
            // 
            // distributeTile
            // 
            this.distributeTile.ActiveControl = null;
            this.distributeTile.Location = new System.Drawing.Point(45, 17);
            this.distributeTile.Name = "distributeTile";
            this.distributeTile.Size = new System.Drawing.Size(135, 160);
            this.distributeTile.TabIndex = 6;
            this.distributeTile.Text = "Distribute";
            this.distributeTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.distributeTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.distributeTile.TileImage = ((System.Drawing.Image)(resources.GetObject("distributeTile.TileImage")));
            this.distributeTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.distributeTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.distributeTile.UseCustomBackColor = true;
            this.distributeTile.UseSelectable = true;
            this.distributeTile.UseTileImage = true;
            // 
            // reconstructTile
            // 
            this.reconstructTile.ActiveControl = null;
            this.reconstructTile.Location = new System.Drawing.Point(246, 17);
            this.reconstructTile.Name = "reconstructTile";
            this.reconstructTile.Size = new System.Drawing.Size(135, 160);
            this.reconstructTile.TabIndex = 7;
            this.reconstructTile.Text = "Reconstruct";
            this.reconstructTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.reconstructTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.reconstructTile.TileImage = ((System.Drawing.Image)(resources.GetObject("reconstructTile.TileImage")));
            this.reconstructTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reconstructTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.reconstructTile.UseCustomBackColor = true;
            this.reconstructTile.UseSelectable = true;
            this.reconstructTile.UseTileImage = true;
            // 
            // toolsTabPage
            // 
            this.toolsTabPage.BackColor = System.Drawing.Color.Black;
            this.toolsTabPage.Controls.Add(this.entropyUtilTile);
            this.toolsTabPage.Controls.Add(this.fileWiperTile);
            this.toolsTabPage.Location = new System.Drawing.Point(4, 35);
            this.toolsTabPage.Name = "toolsTabPage";
            this.toolsTabPage.Size = new System.Drawing.Size(426, 198);
            this.toolsTabPage.TabIndex = 1;
            this.toolsTabPage.Text = "Tools";
            // 
            // entropyUtilTile
            // 
            this.entropyUtilTile.ActiveControl = null;
            this.entropyUtilTile.Location = new System.Drawing.Point(239, 14);
            this.entropyUtilTile.Name = "entropyUtilTile";
            this.entropyUtilTile.Size = new System.Drawing.Size(135, 160);
            this.entropyUtilTile.TabIndex = 6;
            this.entropyUtilTile.Text = "Entropy utility";
            this.entropyUtilTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.entropyUtilTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.entropyUtilTile.TileImage = ((System.Drawing.Image)(resources.GetObject("entropyUtilTile.TileImage")));
            this.entropyUtilTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.entropyUtilTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.entropyUtilTile.UseCustomBackColor = true;
            this.entropyUtilTile.UseSelectable = true;
            this.entropyUtilTile.UseTileImage = true;
            // 
            // fileWiperTile
            // 
            this.fileWiperTile.ActiveControl = null;
            this.fileWiperTile.Location = new System.Drawing.Point(38, 14);
            this.fileWiperTile.Name = "fileWiperTile";
            this.fileWiperTile.Size = new System.Drawing.Size(135, 160);
            this.fileWiperTile.TabIndex = 5;
            this.fileWiperTile.Text = "File wiper";
            this.fileWiperTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fileWiperTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.fileWiperTile.TileImage = ((System.Drawing.Image)(resources.GetObject("fileWiperTile.TileImage")));
            this.fileWiperTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileWiperTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.fileWiperTile.UseCustomBackColor = true;
            this.fileWiperTile.UseSelectable = true;
            this.fileWiperTile.UseTileImage = true;
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.BackColor = System.Drawing.Color.Black;
            this.settingsTabPage.Controls.Add(this.openLogDirectoryBtn);
            this.settingsTabPage.Controls.Add(this.logLevelCbo);
            this.settingsTabPage.Controls.Add(this.logLevelLbl);
            this.settingsTabPage.Controls.Add(this.loggingSettingsLbl);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 35);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Size = new System.Drawing.Size(426, 198);
            this.settingsTabPage.TabIndex = 4;
            this.settingsTabPage.Text = "Settings";
            // 
            // openLogDirectoryBtn
            // 
            this.openLogDirectoryBtn.Location = new System.Drawing.Point(231, 40);
            this.openLogDirectoryBtn.Name = "openLogDirectoryBtn";
            this.openLogDirectoryBtn.Size = new System.Drawing.Size(181, 30);
            this.openLogDirectoryBtn.TabIndex = 5;
            this.openLogDirectoryBtn.Text = "Open log directory";
            this.openLogDirectoryBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.openLogDirectoryBtn.UseSelectable = true;
            // 
            // logLevelCbo
            // 
            this.logLevelCbo.FormattingEnabled = true;
            this.logLevelCbo.ItemHeight = 23;
            this.logLevelCbo.Location = new System.Drawing.Point(104, 41);
            this.logLevelCbo.Name = "logLevelCbo";
            this.logLevelCbo.Size = new System.Drawing.Size(114, 29);
            this.logLevelCbo.TabIndex = 4;
            this.logLevelCbo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logLevelCbo.UseSelectable = true;
            // 
            // logLevelLbl
            // 
            this.logLevelLbl.AutoSize = true;
            this.logLevelLbl.Location = new System.Drawing.Point(31, 46);
            this.logLevelLbl.Name = "logLevelLbl";
            this.logLevelLbl.Size = new System.Drawing.Size(64, 19);
            this.logLevelLbl.TabIndex = 2;
            this.logLevelLbl.Text = "Log level:";
            this.logLevelLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logLevelLbl.UseCustomBackColor = true;
            // 
            // loggingSettingsLbl
            // 
            this.loggingSettingsLbl.AutoSize = true;
            this.loggingSettingsLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.loggingSettingsLbl.Location = new System.Drawing.Point(12, 10);
            this.loggingSettingsLbl.Name = "loggingSettingsLbl";
            this.loggingSettingsLbl.Size = new System.Drawing.Size(74, 25);
            this.loggingSettingsLbl.Style = MetroFramework.MetroColorStyle.Teal;
            this.loggingSettingsLbl.TabIndex = 0;
            this.loggingSettingsLbl.Text = "Logging";
            this.loggingSettingsLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loggingSettingsLbl.UseCustomBackColor = true;
            this.loggingSettingsLbl.UseStyleColors = true;
            // 
            // licenseTabPage
            // 
            this.licenseTabPage.BackColor = System.Drawing.Color.Black;
            this.licenseTabPage.Controls.Add(this.licenseTxt);
            this.licenseTabPage.Location = new System.Drawing.Point(4, 35);
            this.licenseTabPage.Name = "licenseTabPage";
            this.licenseTabPage.Size = new System.Drawing.Size(426, 198);
            this.licenseTabPage.TabIndex = 2;
            this.licenseTabPage.Text = "License";
            // 
            // licenseTxt
            // 
            this.licenseTxt.BackColor = System.Drawing.Color.Black;
            this.licenseTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.licenseTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licenseTxt.ForeColor = System.Drawing.Color.White;
            this.licenseTxt.Location = new System.Drawing.Point(0, 0);
            this.licenseTxt.Name = "licenseTxt";
            this.licenseTxt.ReadOnly = true;
            this.licenseTxt.Size = new System.Drawing.Size(426, 198);
            this.licenseTxt.TabIndex = 0;
            this.licenseTxt.Text = "";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Explanation";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 346);
            this.Controls.Add(this.menuTabControl);
            this.Controls.Add(this.infoLbl);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Amgine";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuTabControl.ResumeLayout(false);
            this.aboutTabPage.ResumeLayout(false);
            this.aboutTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.otpTabPage.ResumeLayout(false);
            this.secretSharingTabPage.ResumeLayout(false);
            this.toolsTabPage.ResumeLayout(false);
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            this.licenseTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

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