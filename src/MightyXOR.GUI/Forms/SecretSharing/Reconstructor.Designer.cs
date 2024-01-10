namespace MightyXOR.GUI.Forms.SecretSharing;

partial class Reconstructor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reconstructor));
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.reconstructBtn = new MetroFramework.Controls.MetroButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.outputDirLbl = new MetroFramework.Controls.MetroLabel();
            this.progressBar = new MetroFramework.Controls.MetroPanel();
            this.outputDirSelectBtn = new MetroFramework.Controls.MetroButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileListView = new System.Windows.Forms.CheckedListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.deleteAllRowsBtn = new MetroFramework.Controls.MetroButton();
            this.deleteSharesChk = new MetroFramework.Controls.MetroCheckBox();
            this.headerUsedChk = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // reconstructBtn
            // 
            this.reconstructBtn.Enabled = false;
            this.reconstructBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.reconstructBtn.Location = new System.Drawing.Point(12, 386);
            this.reconstructBtn.Name = "reconstructBtn";
            this.reconstructBtn.Size = new System.Drawing.Size(266, 42);
            this.reconstructBtn.TabIndex = 3;
            this.reconstructBtn.Text = "Reconstruct secret";
            this.reconstructBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.reconstructBtn.UseSelectable = true;
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
            // outputDirLbl
            // 
            this.outputDirLbl.AutoEllipsis = true;
            this.outputDirLbl.AutoSize = true;
            this.outputDirLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.outputDirLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.outputDirLbl.Location = new System.Drawing.Point(96, 285);
            this.outputDirLbl.MaximumSize = new System.Drawing.Size(560, 0);
            this.outputDirLbl.Name = "outputDirLbl";
            this.outputDirLbl.Size = new System.Drawing.Size(247, 25);
            this.outputDirLbl.TabIndex = 16;
            this.outputDirLbl.Text = "Output directory of the secret";
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
            this.progressBar.Location = new System.Drawing.Point(296, 386);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(362, 42);
            this.progressBar.TabIndex = 9;
            this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressBar.VerticalScrollbarBarColor = true;
            this.progressBar.VerticalScrollbarHighlightOnWheel = false;
            this.progressBar.VerticalScrollbarSize = 10;
            // 
            // outputDirSelectBtn
            // 
            this.outputDirSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.outputDirSelectBtn.Location = new System.Drawing.Point(13, 286);
            this.outputDirSelectBtn.Name = "outputDirSelectBtn";
            this.outputDirSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.outputDirSelectBtn.TabIndex = 18;
            this.outputDirSelectBtn.Text = "Choose...";
            this.outputDirSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.outputDirSelectBtn.UseSelectable = true;
            // 
            // fileListView
            // 
            this.fileListView.BackColor = System.Drawing.Color.Black;
            this.fileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileListView.ForeColor = System.Drawing.Color.White;
            this.fileListView.Location = new System.Drawing.Point(12, 96);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(643, 168);
            this.fileListView.TabIndex = 19;
            this.fileListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FileListView_ItemCheck);
            this.fileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListView_DragDrop);
            this.fileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileListView_DragEnter);
            this.fileListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileListView_KeyDown);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(264, 25);
            this.metroLabel1.TabIndex = 20;
            this.metroLabel1.Text = "Drag the share files onto the box.";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // deleteAllRowsBtn
            // 
            this.deleteAllRowsBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.deleteAllRowsBtn.Location = new System.Drawing.Point(310, 60);
            this.deleteAllRowsBtn.Name = "deleteAllRowsBtn";
            this.deleteAllRowsBtn.Size = new System.Drawing.Size(345, 25);
            this.deleteAllRowsBtn.TabIndex = 21;
            this.deleteAllRowsBtn.Text = "Clear file list";
            this.deleteAllRowsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.deleteAllRowsBtn.UseSelectable = true;
            // 
            // deleteSharesChk
            // 
            this.deleteSharesChk.AutoSize = true;
            this.deleteSharesChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.deleteSharesChk.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.deleteSharesChk.Location = new System.Drawing.Point(68, 341);
            this.deleteSharesChk.Name = "deleteSharesChk";
            this.deleteSharesChk.Size = new System.Drawing.Size(531, 25);
            this.deleteSharesChk.TabIndex = 22;
            this.deleteSharesChk.Text = "Delete the share files after a successful reconstruction permanently";
            this.deleteSharesChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.deleteSharesChk, "Can be useful if the shares are of no use for you anymore after the reconstructio" +
        "n.");
            this.deleteSharesChk.UseSelectable = true;
            // 
            // headerUsedChk
            // 
            this.headerUsedChk.AutoSize = true;
            this.headerUsedChk.Checked = true;
            this.headerUsedChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headerUsedChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.headerUsedChk.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.headerUsedChk.Location = new System.Drawing.Point(183, 313);
            this.headerUsedChk.Name = "headerUsedChk";
            this.headerUsedChk.Size = new System.Drawing.Size(281, 25);
            this.headerUsedChk.TabIndex = 23;
            this.headerUsedChk.Text = "The secret was split with a header";
            this.headerUsedChk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolTip.SetToolTip(this.headerUsedChk, "Only disable this if you also disabled the respective option when you distributed" +
        " the secret.");
            this.headerUsedChk.UseSelectable = true;
            // 
            // Reconstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 441);
            this.Controls.Add(this.headerUsedChk);
            this.Controls.Add(this.deleteSharesChk);
            this.Controls.Add(this.deleteAllRowsBtn);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.outputDirLbl);
            this.Controls.Add(this.outputDirSelectBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.reconstructBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Reconstructor";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reconstruct a secret with the Shamir secret sharing scheme";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private MetroFramework.Controls.MetroButton reconstructBtn;
    private OpenFileDialog openFileDialog;
    private ToolTip toolTip;
    private MetroFramework.Controls.MetroPanel progressBar;
    private MetroFramework.Controls.MetroLabel outputDirLbl;
    private MetroFramework.Controls.MetroButton outputDirSelectBtn;
    private FolderBrowserDialog folderBrowserDialog;
    private CheckedListBox fileListView;
    private MetroFramework.Controls.MetroLabel metroLabel1;
    private MetroFramework.Controls.MetroButton deleteAllRowsBtn;
    private MetroFramework.Controls.MetroCheckBox deleteSharesChk;
    private MetroFramework.Controls.MetroCheckBox headerUsedChk;
}