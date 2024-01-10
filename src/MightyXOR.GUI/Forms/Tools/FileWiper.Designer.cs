namespace MightyXOR.GUI.Forms.Tools;

partial class FileWiper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileWiper));
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.overridesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.bytesLbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.deleteBtn = new MetroFramework.Controls.MetroButton();
            this.filePathLbl = new MetroFramework.Controls.MetroLabel();
            this.fileSelectBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overridesNumericUpDown)).BeginInit();
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
            // overridesNumericUpDown
            // 
            this.overridesNumericUpDown.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.overridesNumericUpDown.ForeColor = System.Drawing.Color.White;
            this.overridesNumericUpDown.Location = new System.Drawing.Point(303, 157);
            this.overridesNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.overridesNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.overridesNumericUpDown.Name = "overridesNumericUpDown";
            this.overridesNumericUpDown.Size = new System.Drawing.Size(45, 23);
            this.overridesNumericUpDown.TabIndex = 2;
            this.toolTip.SetToolTip(this.overridesNumericUpDown, "A high number of overrides makes it harder to recover the file.");
            this.overridesNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(5, 57);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(623, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroLabel1.TabIndex = 14;
            this.metroLabel1.Text = "This tool permanently and securely deletes files by overriding them several times" +
    ".";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // bytesLbl
            // 
            this.bytesLbl.AutoSize = true;
            this.bytesLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.bytesLbl.Location = new System.Drawing.Point(356, 155);
            this.bytesLbl.Name = "bytesLbl";
            this.bytesLbl.Size = new System.Drawing.Size(52, 25);
            this.bytesLbl.Style = MetroFramework.MetroColorStyle.White;
            this.bytesLbl.TabIndex = 16;
            this.bytesLbl.Text = "times";
            this.bytesLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bytesLbl.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(221, 154);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(78, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 17;
            this.metroLabel2.Text = "Override";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.deleteBtn.Location = new System.Drawing.Point(219, 199);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(188, 31);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.deleteBtn.UseSelectable = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // filePathLbl
            // 
            this.filePathLbl.AutoEllipsis = true;
            this.filePathLbl.AutoSize = true;
            this.filePathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.filePathLbl.Location = new System.Drawing.Point(166, 114);
            this.filePathLbl.MaximumSize = new System.Drawing.Size(450, 0);
            this.filePathLbl.Name = "filePathLbl";
            this.filePathLbl.Size = new System.Drawing.Size(376, 25);
            this.filePathLbl.TabIndex = 20;
            this.filePathLbl.Text = "Path of the file that is to be deleted permanently";
            this.filePathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // fileSelectBtn
            // 
            this.fileSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.fileSelectBtn.Location = new System.Drawing.Point(84, 116);
            this.fileSelectBtn.Name = "fileSelectBtn";
            this.fileSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.fileSelectBtn.TabIndex = 1;
            this.fileSelectBtn.Text = "Choose...";
            this.fileSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.fileSelectBtn.UseSelectable = true;
            this.fileSelectBtn.Click += new System.EventHandler(this.FileSelectBtn_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(166, 82);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(293, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "The deleted file cannot be recovered.";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // FileWiper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 241);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.filePathLbl);
            this.Controls.Add(this.fileSelectBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.bytesLbl);
            this.Controls.Add(this.overridesNumericUpDown);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FileWiper";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wipe a file securely";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overridesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private OpenFileDialog openFileDialog;
    private ToolTip toolTip;
    private MetroFramework.Controls.MetroLabel metroLabel1;
    private MetroFramework.Controls.MetroLabel metroLabel2;
    private MetroFramework.Controls.MetroLabel bytesLbl;
    private NumericUpDown overridesNumericUpDown;
    private MetroFramework.Controls.MetroButton deleteBtn;
    private MetroFramework.Controls.MetroLabel filePathLbl;
    private MetroFramework.Controls.MetroButton fileSelectBtn;
    private MetroFramework.Controls.MetroLabel metroLabel3;
}