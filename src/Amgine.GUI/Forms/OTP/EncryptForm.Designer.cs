namespace Amgine.GUI.Forms.OTP;

partial class EncryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptForm));
            this.generateHeaderChk = new MetroFramework.Controls.MetroCheckBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.encryptBtn = new MetroFramework.Controls.MetroButton();
            this.progressBar = new MetroFramework.Controls.MetroPanel();
            this.plaintextFileSelectBtn = new MetroFramework.Controls.MetroButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.plaintextPathLbl = new MetroFramework.Controls.MetroLabel();
            this.outputDirLbl = new MetroFramework.Controls.MetroLabel();
            this.outputDirSelectBtn = new MetroFramework.Controls.MetroButton();
            this.overridePlaintextChk = new MetroFramework.Controls.MetroCheckBox();
            this.ciphertextReadOnlyChk = new MetroFramework.Controls.MetroCheckBox();
            this.keyPathLbl = new MetroFramework.Controls.MetroLabel();
            this.keySelectBtn = new MetroFramework.Controls.MetroButton();
            this.warningToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.keySizeInfoLbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // generateHeaderChk
            // 
            this.generateHeaderChk.AutoSize = true;
            this.generateHeaderChk.Checked = true;
            this.generateHeaderChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateHeaderChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.generateHeaderChk.Location = new System.Drawing.Point(232, 288);
            this.generateHeaderChk.Name = "generateHeaderChk";
            this.generateHeaderChk.Size = new System.Drawing.Size(185, 25);
            this.generateHeaderChk.TabIndex = 5;
            this.generateHeaderChk.Text = "Generate file header";
            this.generateHeaderChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.infoToolTip.SetToolTip(this.generateHeaderChk, resources.GetString("generateHeaderChk.ToolTip"));
            this.generateHeaderChk.UseSelectable = true;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // encryptBtn
            // 
            this.encryptBtn.Enabled = false;
            this.encryptBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.encryptBtn.Location = new System.Drawing.Point(28, 328);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(188, 42);
            this.encryptBtn.TabIndex = 7;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.encryptBtn.UseSelectable = true;
            // 
            // progressBar
            // 
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBar.HorizontalScrollbarBarColor = true;
            this.progressBar.HorizontalScrollbarHighlightOnWheel = false;
            this.progressBar.HorizontalScrollbarSize = 10;
            this.progressBar.Location = new System.Drawing.Point(229, 328);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(411, 42);
            this.progressBar.TabIndex = 0;
            this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressBar.VerticalScrollbarBarColor = true;
            this.progressBar.VerticalScrollbarHighlightOnWheel = false;
            this.progressBar.VerticalScrollbarSize = 10;
            // 
            // plaintextFileSelectBtn
            // 
            this.plaintextFileSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.plaintextFileSelectBtn.Location = new System.Drawing.Point(28, 149);
            this.plaintextFileSelectBtn.Name = "plaintextFileSelectBtn";
            this.plaintextFileSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.plaintextFileSelectBtn.TabIndex = 1;
            this.plaintextFileSelectBtn.Text = "Choose...";
            this.plaintextFileSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.plaintextFileSelectBtn.UseSelectable = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // plaintextPathLbl
            // 
            this.plaintextPathLbl.AutoEllipsis = true;
            this.plaintextPathLbl.AutoSize = true;
            this.plaintextPathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.plaintextPathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.plaintextPathLbl.Location = new System.Drawing.Point(111, 147);
            this.plaintextPathLbl.MaximumSize = new System.Drawing.Size(535, 0);
            this.plaintextPathLbl.Name = "plaintextPathLbl";
            this.plaintextPathLbl.Size = new System.Drawing.Size(198, 25);
            this.plaintextPathLbl.TabIndex = 4;
            this.plaintextPathLbl.Text = "Path of the plaintext file";
            this.plaintextPathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // outputDirLbl
            // 
            this.outputDirLbl.AutoEllipsis = true;
            this.outputDirLbl.AutoSize = true;
            this.outputDirLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.outputDirLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.outputDirLbl.Location = new System.Drawing.Point(111, 259);
            this.outputDirLbl.MaximumSize = new System.Drawing.Size(535, 0);
            this.outputDirLbl.Name = "outputDirLbl";
            this.outputDirLbl.Size = new System.Drawing.Size(316, 25);
            this.outputDirLbl.TabIndex = 6;
            this.outputDirLbl.Text = "Output directory of the cipher (optional)";
            this.outputDirLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.infoToolTip.SetToolTip(this.outputDirLbl, "If no output directory is selected, the directory of the plaintext file is chosen" +
        ".");
            this.outputDirLbl.UseCompatibleTextRendering = true;
            // 
            // outputDirSelectBtn
            // 
            this.outputDirSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.outputDirSelectBtn.Location = new System.Drawing.Point(28, 261);
            this.outputDirSelectBtn.Name = "outputDirSelectBtn";
            this.outputDirSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.outputDirSelectBtn.TabIndex = 3;
            this.outputDirSelectBtn.Text = "Choose...";
            this.outputDirSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.outputDirSelectBtn.UseSelectable = true;
            // 
            // overridePlaintextChk
            // 
            this.overridePlaintextChk.AutoSize = true;
            this.overridePlaintextChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.overridePlaintextChk.Location = new System.Drawing.Point(28, 287);
            this.overridePlaintextChk.Name = "overridePlaintextChk";
            this.overridePlaintextChk.Size = new System.Drawing.Size(196, 25);
            this.overridePlaintextChk.TabIndex = 4;
            this.overridePlaintextChk.Text = "Override plaintext file";
            this.overridePlaintextChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.warningToolTip.SetToolTip(this.overridePlaintextChk, "This setting causes the selected plaintext file to be overridden.\r\nWithout the ke" +
        "y, it cannot be restored!");
            this.overridePlaintextChk.UseSelectable = true;
            // 
            // ciphertextReadOnlyChk
            // 
            this.ciphertextReadOnlyChk.AutoSize = true;
            this.ciphertextReadOnlyChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.ciphertextReadOnlyChk.Location = new System.Drawing.Point(424, 288);
            this.ciphertextReadOnlyChk.Name = "ciphertextReadOnlyChk";
            this.ciphertextReadOnlyChk.Size = new System.Drawing.Size(216, 25);
            this.ciphertextReadOnlyChk.TabIndex = 6;
            this.ciphertextReadOnlyChk.Text = "Set ciphertext read-only";
            this.ciphertextReadOnlyChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.infoToolTip.SetToolTip(this.ciphertextReadOnlyChk, "To make it harder for an attacker to tamper with the ciphertext, it is possible t" +
        "o set it read-only.");
            this.ciphertextReadOnlyChk.UseSelectable = true;
            // 
            // keyPathLbl
            // 
            this.keyPathLbl.AutoEllipsis = true;
            this.keyPathLbl.AutoSize = true;
            this.keyPathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.keyPathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.keyPathLbl.Location = new System.Drawing.Point(111, 188);
            this.keyPathLbl.MaximumSize = new System.Drawing.Size(535, 0);
            this.keyPathLbl.Name = "keyPathLbl";
            this.keyPathLbl.Size = new System.Drawing.Size(130, 25);
            this.keyPathLbl.TabIndex = 11;
            this.keyPathLbl.Text = "Path of the key";
            this.keyPathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // keySelectBtn
            // 
            this.keySelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.keySelectBtn.Location = new System.Drawing.Point(28, 188);
            this.keySelectBtn.Name = "keySelectBtn";
            this.keySelectBtn.Size = new System.Drawing.Size(75, 23);
            this.keySelectBtn.TabIndex = 2;
            this.keySelectBtn.Text = "Choose...";
            this.keySelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.keySelectBtn.UseSelectable = true;
            // 
            // warningToolTip
            // 
            this.warningToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.warningToolTip.ToolTipTitle = "Warning";
            // 
            // infoToolTip
            // 
            this.infoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.infoToolTip.ToolTipTitle = "Explanation";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(8, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(651, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "You must ensure the key stems from a cryptographically secure source, e.g. a HRNG" +
    ".";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // keySizeInfoLbl
            // 
            this.keySizeInfoLbl.AutoSize = true;
            this.keySizeInfoLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.keySizeInfoLbl.Location = new System.Drawing.Point(28, 222);
            this.keySizeInfoLbl.Name = "keySizeInfoLbl";
            this.keySizeInfoLbl.Size = new System.Drawing.Size(549, 25);
            this.keySizeInfoLbl.TabIndex = 13;
            this.keySizeInfoLbl.Text = "The key must be slightly larger than the plaintext file due to the header.";
            this.keySizeInfoLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(21, 108);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(622, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "Also, the key may not be reused afterwards. It is your responsibility to assure t" +
    "his.";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(35, 83);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(590, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "The key must be exchanged using information-theoretically secure methods.";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 374);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.keySizeInfoLbl);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.keyPathLbl);
            this.Controls.Add(this.keySelectBtn);
            this.Controls.Add(this.ciphertextReadOnlyChk);
            this.Controls.Add(this.overridePlaintextChk);
            this.Controls.Add(this.outputDirLbl);
            this.Controls.Add(this.outputDirSelectBtn);
            this.Controls.Add(this.plaintextPathLbl);
            this.Controls.Add(this.plaintextFileSelectBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.generateHeaderChk);
            this.MaximizeBox = false;
            this.Name = "EncryptForm";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Encrypt a file using one-time pad";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MetroFramework.Controls.MetroCheckBox generateHeaderChk;
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private MetroFramework.Controls.MetroPanel progressBar;
    private MetroFramework.Controls.MetroButton encryptBtn;
    private MetroFramework.Controls.MetroButton plaintextFileSelectBtn;
    private OpenFileDialog openFileDialog;
    private FolderBrowserDialog folderBrowserDialog;
    private MetroFramework.Controls.MetroLabel plaintextPathLbl;
    private MetroFramework.Controls.MetroLabel outputDirLbl;
    private MetroFramework.Controls.MetroButton outputDirSelectBtn;
    private MetroFramework.Controls.MetroCheckBox overridePlaintextChk;
    private MetroFramework.Controls.MetroCheckBox ciphertextReadOnlyChk;
    private MetroFramework.Controls.MetroLabel keyPathLbl;
    private MetroFramework.Controls.MetroButton keySelectBtn;
    private ToolTip warningToolTip;
    private ToolTip infoToolTip;
    private MetroFramework.Controls.MetroLabel metroLabel1;
    private MetroFramework.Controls.MetroLabel keySizeInfoLbl;
    private MetroFramework.Controls.MetroLabel metroLabel2;
    private MetroFramework.Controls.MetroLabel metroLabel3;
}