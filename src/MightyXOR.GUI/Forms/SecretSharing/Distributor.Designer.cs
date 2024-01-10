namespace MightyXOR.GUI.Forms.SecretSharing;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Distributor));
        metroStyleManager = new MetroFramework.Components.MetroStyleManager(components);
        participantsNumericUpDown = new NumericUpDown();
        bytesLbl = new MetroFramework.Controls.MetroLabel();
        distributeBtn = new MetroFramework.Controls.MetroButton();
        openFileDialog = new OpenFileDialog();
        toolTip = new ToolTip(components);
        requiredParticipantsNumericUpDown = new NumericUpDown();
        outputDirLbl = new MetroFramework.Controls.MetroLabel();
        useHeaderChk = new MetroFramework.Controls.MetroCheckBox();
        progressBar = new MetroFramework.Controls.MetroPanel();
        metroLabel1 = new MetroFramework.Controls.MetroLabel();
        metroLabel2 = new MetroFramework.Controls.MetroLabel();
        metroLabel3 = new MetroFramework.Controls.MetroLabel();
        secretPathLbl = new MetroFramework.Controls.MetroLabel();
        fileSelectBtn = new MetroFramework.Controls.MetroButton();
        outputDirSelectBtn = new MetroFramework.Controls.MetroButton();
        folderBrowserDialog = new FolderBrowserDialog();
        ((System.ComponentModel.ISupportInitialize)metroStyleManager).BeginInit();
        ((System.ComponentModel.ISupportInitialize)participantsNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)requiredParticipantsNumericUpDown).BeginInit();
        SuspendLayout();
        // 
        // metroStyleManager
        // 
        metroStyleManager.Owner = this;
        metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // participantsNumericUpDown
        // 
        participantsNumericUpDown.BackColor = SystemColors.InactiveCaptionText;
        participantsNumericUpDown.ForeColor = Color.White;
        participantsNumericUpDown.Location = new Point(133, 167);
        participantsNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
        participantsNumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
        participantsNumericUpDown.Name = "participantsNumericUpDown";
        participantsNumericUpDown.Size = new Size(56, 23);
        participantsNumericUpDown.TabIndex = 1;
        toolTip.SetToolTip(participantsNumericUpDown, "This is the total amount of shares you intend to generate.\r\nMore shares take more generation time.");
        participantsNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
        // 
        // bytesLbl
        // 
        bytesLbl.AutoSize = true;
        bytesLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        bytesLbl.Location = new Point(198, 163);
        bytesLbl.Name = "bytesLbl";
        bytesLbl.Size = new Size(104, 25);
        bytesLbl.Style = MetroFramework.MetroColorStyle.White;
        bytesLbl.TabIndex = 2;
        bytesLbl.Text = "participants.";
        bytesLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        bytesLbl.UseStyleColors = true;
        // 
        // distributeBtn
        // 
        distributeBtn.Enabled = false;
        distributeBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
        distributeBtn.Location = new Point(23, 272);
        distributeBtn.Name = "distributeBtn";
        distributeBtn.Size = new Size(266, 42);
        distributeBtn.TabIndex = 3;
        distributeBtn.Text = "Distribute file";
        distributeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        distributeBtn.UseSelectable = true;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog1";
        // 
        // toolTip
        // 
        toolTip.BackColor = SystemColors.GrayText;
        toolTip.ForeColor = Color.White;
        toolTip.ToolTipIcon = ToolTipIcon.Info;
        toolTip.ToolTipTitle = "Explanation";
        // 
        // requiredParticipantsNumericUpDown
        // 
        requiredParticipantsNumericUpDown.BackColor = SystemColors.InactiveCaptionText;
        requiredParticipantsNumericUpDown.ForeColor = Color.White;
        requiredParticipantsNumericUpDown.Location = new Point(540, 203);
        requiredParticipantsNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
        requiredParticipantsNumericUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
        requiredParticipantsNumericUpDown.Name = "requiredParticipantsNumericUpDown";
        requiredParticipantsNumericUpDown.Size = new Size(56, 23);
        requiredParticipantsNumericUpDown.TabIndex = 11;
        toolTip.SetToolTip(requiredParticipantsNumericUpDown, "A certain number of shares is needed to recover the secret.");
        requiredParticipantsNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // outputDirLbl
        // 
        outputDirLbl.AutoEllipsis = true;
        outputDirLbl.AutoSize = true;
        outputDirLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        outputDirLbl.Location = new Point(109, 114);
        outputDirLbl.MaximumSize = new Size(560, 0);
        outputDirLbl.Name = "outputDirLbl";
        outputDirLbl.Size = new Size(317, 25);
        outputDirLbl.TabIndex = 16;
        outputDirLbl.Text = "Output directory of the shares (optional)";
        outputDirLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        toolTip.SetToolTip(outputDirLbl, "If no output directory is selected, the directory of the plaintext file is chosen.");
        // 
        // useHeaderChk
        // 
        useHeaderChk.AutoSize = true;
        useHeaderChk.Checked = true;
        useHeaderChk.CheckState = CheckState.Checked;
        useHeaderChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
        useHeaderChk.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
        useHeaderChk.Location = new Point(131, 234);
        useHeaderChk.Name = "useHeaderChk";
        useHeaderChk.Size = new Size(424, 25);
        useHeaderChk.TabIndex = 19;
        useHeaderChk.Text = "Generate file header to retain metadata of the secret";
        useHeaderChk.Theme = MetroFramework.MetroThemeStyle.Dark;
        toolTip.SetToolTip(useHeaderChk, "If enabled, MightyXOR retains the secret's metadata (file name, access date etc.).");
        useHeaderChk.UseSelectable = true;
        // 
        // progressBar
        // 
        //progressBar.BorderStyle = BorderStyle.FixedSingle;
        progressBar.HorizontalScrollbarBarColor = true;
        progressBar.HorizontalScrollbarHighlightOnWheel = false;
        progressBar.HorizontalScrollbarSize = 10;
        progressBar.Location = new Point(307, 272);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(362, 42);
        progressBar.TabIndex = 9;
        progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
        progressBar.VerticalScrollbarBarColor = true;
        progressBar.VerticalScrollbarHighlightOnWheel = false;
        progressBar.VerticalScrollbarSize = 10;
        // 
        // metroLabel1
        // 
        metroLabel1.AutoSize = true;
        metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
        metroLabel1.Location = new Point(21, 163);
        metroLabel1.Name = "metroLabel1";
        metroLabel1.Size = new Size(104, 25);
        metroLabel1.Style = MetroFramework.MetroColorStyle.White;
        metroLabel1.TabIndex = 10;
        metroLabel1.Text = "Distribute to";
        metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
        metroLabel1.UseStyleColors = true;
        // 
        // metroLabel2
        // 
        metroLabel2.AutoSize = true;
        metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
        metroLabel2.Location = new Point(21, 200);
        metroLabel2.Name = "metroLabel2";
        metroLabel2.Size = new Size(514, 25);
        metroLabel2.Style = MetroFramework.MetroColorStyle.White;
        metroLabel2.TabIndex = 13;
        metroLabel2.Text = "The required number of shares to reconstruct the secret should be";
        metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
        metroLabel2.UseStyleColors = true;
        // 
        // metroLabel3
        // 
        metroLabel3.AutoSize = true;
        metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
        metroLabel3.Location = new Point(595, 201);
        metroLabel3.Name = "metroLabel3";
        metroLabel3.Size = new Size(16, 25);
        metroLabel3.Style = MetroFramework.MetroColorStyle.White;
        metroLabel3.TabIndex = 14;
        metroLabel3.Text = ".";
        metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
        metroLabel3.UseStyleColors = true;
        // 
        // secretPathLbl
        // 
        secretPathLbl.AutoEllipsis = true;
        secretPathLbl.AutoSize = true;
        secretPathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        secretPathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        secretPathLbl.Location = new Point(109, 75);
        secretPathLbl.MaximumSize = new Size(560, 0);
        secretPathLbl.Name = "secretPathLbl";
        secretPathLbl.Size = new Size(149, 25);
        secretPathLbl.TabIndex = 15;
        secretPathLbl.Text = "Path to the secret";
        secretPathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // fileSelectBtn
        // 
        fileSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
        fileSelectBtn.Location = new Point(26, 76);
        fileSelectBtn.Name = "fileSelectBtn";
        fileSelectBtn.Size = new Size(75, 23);
        fileSelectBtn.TabIndex = 17;
        fileSelectBtn.Text = "Choose...";
        fileSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        fileSelectBtn.UseSelectable = true;
        // 
        // outputDirSelectBtn
        // 
        outputDirSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
        outputDirSelectBtn.Location = new Point(26, 117);
        outputDirSelectBtn.Name = "outputDirSelectBtn";
        outputDirSelectBtn.Size = new Size(75, 23);
        outputDirSelectBtn.TabIndex = 18;
        outputDirSelectBtn.Text = "Choose...";
        outputDirSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        outputDirSelectBtn.UseSelectable = true;
        // 
        // Distributor
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(689, 325);
        Controls.Add(useHeaderChk);
        Controls.Add(secretPathLbl);
        Controls.Add(fileSelectBtn);
        Controls.Add(outputDirLbl);
        Controls.Add(outputDirSelectBtn);
        Controls.Add(metroLabel3);
        Controls.Add(metroLabel2);
        Controls.Add(requiredParticipantsNumericUpDown);
        Controls.Add(metroLabel1);
        Controls.Add(progressBar);
        Controls.Add(distributeBtn);
        Controls.Add(bytesLbl);
        Controls.Add(participantsNumericUpDown);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "Distributor";
        Opacity = 0.95D;
        Resizable = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Distribute a file with the Shamir secret sharing scheme";
        TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
        Theme = MetroFramework.MetroThemeStyle.Dark;
        ((System.ComponentModel.ISupportInitialize)metroStyleManager).EndInit();
        ((System.ComponentModel.ISupportInitialize)participantsNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)requiredParticipantsNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
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