namespace Amgine.GUI.Forms.Tools;

partial class EntropyUtility
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntropyUtility));
        this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
        this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
        this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        this.filePictureBox = new System.Windows.Forms.PictureBox();
        this.entropyLbl = new MetroFramework.Controls.MetroLabel();
        ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // metroStyleManager
        // 
        this.metroStyleManager.Owner = this;
        this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
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
        // filePictureBox
        // 
        this.filePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("filePictureBox.Image")));
        this.filePictureBox.Location = new System.Drawing.Point(108, 63);
        this.filePictureBox.Name = "filePictureBox";
        this.filePictureBox.Size = new System.Drawing.Size(306, 205);
        this.filePictureBox.TabIndex = 0;
        this.filePictureBox.TabStop = false;
        this.filePictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilePictureBox_DragDrop);
        this.filePictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilePictureBox_DragEnter);
        // 
        // entropyLbl
        // 
        this.entropyLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.entropyLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.entropyLbl.ForeColor = System.Drawing.Color.White;
        this.entropyLbl.Location = new System.Drawing.Point(20, 280);
        this.entropyLbl.Name = "entropyLbl";
        this.entropyLbl.Size = new System.Drawing.Size(499, 25);
        this.entropyLbl.TabIndex = 1;
        this.entropyLbl.Text = "Drag a file onto the rectangle to calculate its entropy.";
        this.entropyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.entropyLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.entropyLbl.UseCustomForeColor = true;
        // 
        // EntropyUtility
        // 
        this.AllowDrop = true;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(539, 325);
        this.Controls.Add(this.entropyLbl);
        this.Controls.Add(this.filePictureBox);
        this.MaximizeBox = false;
        this.Name = "EntropyUtility";
        this.Opacity = 0.95D;
        this.Resizable = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Calculate the Shannon entropy of a file";
        this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
        this.Theme = MetroFramework.MetroThemeStyle.Dark;
        ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.filePictureBox)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private OpenFileDialog openFileDialog;
    private ToolTip toolTip;
    private PictureBox filePictureBox;
    private MetroFramework.Controls.MetroLabel entropyLbl;
}