namespace Amgine.GUI.Forms.SecretSharing;

partial class Distributor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Distributor));
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.participantsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bytesLbl = new MetroFramework.Controls.MetroLabel();
            this.distributeBtn = new MetroFramework.Controls.MetroButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.requiredParticipantsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.outputDirLbl = new MetroFramework.Controls.MetroLabel();
            this.progressBar = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.secretPathLbl = new MetroFramework.Controls.MetroLabel();
            this.fileSelectBtn = new MetroFramework.Controls.MetroButton();
            this.outputDirSelectBtn = new MetroFramework.Controls.MetroButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.useHeaderChk = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.participantsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredParticipantsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // participantsNumericUpDown
            // 
            this.participantsNumericUpDown.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.participantsNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.participantsNumericUpDown.Location = new System.Drawing.Point(133, 167);
            this.participantsNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.participantsNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.participantsNumericUpDown.Name = "participantsNumericUpDown";
            this.participantsNumericUpDown.Size = new System.Drawing.Size(56, 23);
            this.participantsNumericUpDown.TabIndex = 1;
            this.toolTip.SetToolTip(this.participantsNumericUpDown, "This is the total amount of shares you intend to generate.\r\nMore shares take more" +
        " generation time.");
            this.participantsNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // bytesLbl
            // 
            this.bytesLbl.AutoSize = true;
            this.bytesLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.bytesLbl.Location = new System.Drawing.Point(198, 163);
            this.bytesLbl.Name = "bytesLbl";
            this.bytesLbl.Size = new System.Drawing.Size(104, 25);
            this.bytesLbl.Style = MetroFramework.MetroColorStyle.White;
            this.bytesLbl.TabIndex = 2;
            this.bytesLbl.Text = "participants.";
            this.bytesLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bytesLbl.UseStyleColors = true;
            // 
            // distributeBtn
            // 
            this.distributeBtn.Enabled = false;
            this.distributeBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.distributeBtn.Location = new System.Drawing.Point(23, 272);
            this.distributeBtn.Name = "distributeBtn";
            this.distributeBtn.Size = new System.Drawing.Size(266, 42);
            this.distributeBtn.TabIndex = 3;
            this.distributeBtn.Text = "Distribute file";
            this.distributeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.distributeBtn.UseSelectable = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.SystemColors.GrayText;
            this.toolTip.ForeColor = System.Drawing.Color.White;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Explanation";
            // 
            // requiredParticipantsNumericUpDown
            // 
            this.requiredParticipantsNumericUpDown.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.requiredParticipantsNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.requiredParticipantsNumericUpDown.Location = new System.Drawing.Point(540, 203);
            this.requiredParticipantsNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.requiredParticipantsNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.requiredParticipantsNumericUpDown.Name = "requiredParticipantsNumericUpDown";
            this.requiredParticipantsNumericUpDown.Size = new System.Drawing.Size(56, 23);
            this.requiredParticipantsNumericUpDown.TabIndex = 11;
            this.toolTip.SetToolTip(this.requiredParticipantsNumericUpDown, "A certain number of shares is needed to recover the secret.");
            this.requiredParticipantsNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // outputDirLbl
            // 
            this.outputDirLbl.AutoEllipsis = true;
            this.outputDirLbl.AutoSize = true;
            this.outputDirLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.outputDirLbl.Location = new System.Drawing.Point(109, 114);
            this.outputDirLbl.MaximumSize = new System.Drawing.Size(560, 0);
            this.outputDirLbl.Name = "outputDirLbl";
            this.outputDirLbl.Size = new System.Drawing.Size(317, 25);
            this.outputDirLbl.TabIndex = 16;
            this.outputDirLbl.Text = "Output directory of the shares (optional)";
            this.outputDirLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.outputDirLbl, "If no output directory is selected, the directory of the plaintext file is chosen" +
        ".");
            // 
            // progressBar
            // 
            this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBar.HorizontalScrollbarBarColor = true;
            this.progressBar.HorizontalScrollbarHighlightOnWheel = false;
            this.progressBar.HorizontalScrollbarSize = 10;
            this.progressBar.Location = new System.Drawing.Point(307, 272);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(362, 42);
            this.progressBar.TabIndex = 9;
            this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressBar.VerticalScrollbarBarColor = true;
            this.progressBar.VerticalScrollbarHighlightOnWheel = false;
            this.progressBar.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(21, 163);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Distribute to";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(21, 200);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(514, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "The required number of shares to reconstruct the secret should be";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(595, 201);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(16, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = ".";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // secretPathLbl
            // 
            this.secretPathLbl.AutoEllipsis = true;
            this.secretPathLbl.AutoSize = true;
            this.secretPathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.secretPathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.secretPathLbl.Location = new System.Drawing.Point(109, 75);
            this.secretPathLbl.MaximumSize = new System.Drawing.Size(560, 0);
            this.secretPathLbl.Name = "secretPathLbl";
            this.secretPathLbl.Size = new System.Drawing.Size(149, 25);
            this.secretPathLbl.TabIndex = 15;
            this.secretPathLbl.Text = "Path to the secret";
            this.secretPathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // fileSelectBtn
            // 
            this.fileSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.fileSelectBtn.Location = new System.Drawing.Point(26, 76);
            this.fileSelectBtn.Name = "fileSelectBtn";
            this.fileSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.fileSelectBtn.TabIndex = 17;
            this.fileSelectBtn.Text = "Choose...";
            this.fileSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.fileSelectBtn.UseSelectable = true;
            // 
            // outputDirSelectBtn
            // 
            this.outputDirSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.outputDirSelectBtn.Location = new System.Drawing.Point(26, 117);
            this.outputDirSelectBtn.Name = "outputDirSelectBtn";
            this.outputDirSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.outputDirSelectBtn.TabIndex = 18;
            this.outputDirSelectBtn.Text = "Choose...";
            this.outputDirSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.outputDirSelectBtn.UseSelectable = true;
            // 
            // useHeaderChk
            // 
            this.useHeaderChk.AutoSize = true;
            this.useHeaderChk.Checked = true;
            this.useHeaderChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useHeaderChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.useHeaderChk.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.useHeaderChk.Location = new System.Drawing.Point(131, 234);
            this.useHeaderChk.Name = "useHeaderChk";
            this.useHeaderChk.Size = new System.Drawing.Size(424, 25);
            this.useHeaderChk.TabIndex = 19;
            this.useHeaderChk.Text = "Generate file header to retain metadata of the secret";
            this.useHeaderChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.useHeaderChk, "If enabled, Amgine retains the secret\'s metadata (file name, access date etc.).");
            this.useHeaderChk.UseSelectable = true;
            // 
            // Distributor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 325);
            this.Controls.Add(this.useHeaderChk);
            this.Controls.Add(this.secretPathLbl);
            this.Controls.Add(this.fileSelectBtn);
            this.Controls.Add(this.outputDirLbl);
            this.Controls.Add(this.outputDirSelectBtn);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.requiredParticipantsNumericUpDown);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.distributeBtn);
            this.Controls.Add(this.bytesLbl);
            this.Controls.Add(this.participantsNumericUpDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Distributor";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Distribute a file with the Shamir secret sharing scheme";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.participantsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredParticipantsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private NumericUpDown participantsNumericUpDown;
    private MetroFramework.Controls.MetroLabel bytesLbl;
    private MetroFramework.Controls.MetroButton distributeBtn;
    private OpenFileDialog openFileDialog;
    private ToolTip toolTip;
    private MetroFramework.Controls.MetroPanel progressBar;
    private MetroFramework.Controls.MetroLabel metroLabel1;
    private MetroFramework.Controls.MetroLabel metroLabel2;
    private NumericUpDown requiredParticipantsNumericUpDown;
    private MetroFramework.Controls.MetroLabel metroLabel3;
    private MetroFramework.Controls.MetroLabel secretPathLbl;
    private MetroFramework.Controls.MetroButton fileSelectBtn;
    private MetroFramework.Controls.MetroLabel outputDirLbl;
    private MetroFramework.Controls.MetroButton outputDirSelectBtn;
    private FolderBrowserDialog folderBrowserDialog;
    private MetroFramework.Controls.MetroCheckBox useHeaderChk;
}