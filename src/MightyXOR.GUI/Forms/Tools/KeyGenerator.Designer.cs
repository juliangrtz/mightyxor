namespace MightyXOR.GUI.Forms.Tools;

partial class KeyGenerator
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretSharing.Distributor));
        this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
        this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
        this.bytesNumericUpDown = new System.Windows.Forms.NumericUpDown();
        this.bytesLbl = new MetroFramework.Controls.MetroLabel();
        this.rngCbo = new MetroFramework.Controls.MetroComboBox();
        this.generateKeyBtn = new MetroFramework.Controls.MetroButton();
        this.algoLbl = new MetroFramework.Controls.MetroLabel();
        this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
        this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
        this.rngExplanationLbl = new MetroFramework.Controls.MetroLabel();
        this.pcgLink = new MetroFramework.Controls.MetroLink();
        this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        this.progressBar = new MetroFramework.Controls.MetroPanel();
        ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.bytesNumericUpDown)).BeginInit();
        this.SuspendLayout();
        // 
        // metroStyleManager
        // 
        this.metroStyleManager.Owner = this;
        this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // metroLabel1
        // 
        this.metroLabel1.AutoSize = true;
        this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.metroLabel1.Location = new System.Drawing.Point(122, 54);
        this.metroLabel1.Name = "metroLabel1";
        this.metroLabel1.Size = new System.Drawing.Size(410, 25);
        this.metroLabel1.Style = MetroFramework.MetroColorStyle.White;
        this.metroLabel1.TabIndex = 0;
        this.metroLabel1.Text = "This tool is intended for development purposes only!";
        this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.metroLabel1.UseStyleColors = true;
        // 
        // bytesNumericUpDown
        // 
        this.bytesNumericUpDown.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
        this.bytesNumericUpDown.ForeColor = System.Drawing.Color.White;
        this.bytesNumericUpDown.Location = new System.Drawing.Point(134, 117);
        this.bytesNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
        this.bytesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.bytesNumericUpDown.Name = "bytesNumericUpDown";
        this.bytesNumericUpDown.Size = new System.Drawing.Size(100, 23);
        this.bytesNumericUpDown.TabIndex = 1;
        this.toolTip.SetToolTip(this.bytesNumericUpDown, "The number of bytes the key is supposed to have.\r\nMin: 1, Max: 2147483647\r\n");
        this.bytesNumericUpDown.Value = new decimal(new int[] {
            10485760,
            0,
            0,
            0});
        this.bytesNumericUpDown.ValueChanged += new System.EventHandler(this.BytesNumericUpDown_ValueChanged);
        // 
        // bytesLbl
        // 
        this.bytesLbl.AutoSize = true;
        this.bytesLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.bytesLbl.Location = new System.Drawing.Point(239, 115);
        this.bytesLbl.Name = "bytesLbl";
        this.bytesLbl.Size = new System.Drawing.Size(51, 25);
        this.bytesLbl.Style = MetroFramework.MetroColorStyle.White;
        this.bytesLbl.TabIndex = 2;
        this.bytesLbl.Text = "bytes";
        this.bytesLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.bytesLbl.UseStyleColors = true;
        // 
        // rngCbo
        // 
        this.rngCbo.FormattingEnabled = true;
        this.rngCbo.ItemHeight = 23;
        this.rngCbo.Location = new System.Drawing.Point(417, 116);
        this.rngCbo.Name = "rngCbo";
        this.rngCbo.Size = new System.Drawing.Size(161, 29);
        this.rngCbo.TabIndex = 2;
        this.rngCbo.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.toolTip.SetToolTip(this.rngCbo, "See below");
        this.rngCbo.UseSelectable = true;
        // 
        // generateKeyBtn
        // 
        this.generateKeyBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
        this.generateKeyBtn.Location = new System.Drawing.Point(23, 235);
        this.generateKeyBtn.Name = "generateKeyBtn";
        this.generateKeyBtn.Size = new System.Drawing.Size(266, 42);
        this.generateKeyBtn.TabIndex = 3;
        this.generateKeyBtn.Text = "Generate key";
        this.generateKeyBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.generateKeyBtn.UseSelectable = true;
        this.generateKeyBtn.Click += new System.EventHandler(this.GenerateKeyBtn_Click);
        // 
        // algoLbl
        // 
        this.algoLbl.AutoSize = true;
        this.algoLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.algoLbl.Location = new System.Drawing.Point(324, 115);
        this.algoLbl.Name = "algoLbl";
        this.algoLbl.Size = new System.Drawing.Size(87, 25);
        this.algoLbl.Style = MetroFramework.MetroColorStyle.White;
        this.algoLbl.TabIndex = 5;
        this.algoLbl.Text = "Algorithm";
        this.algoLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.algoLbl.UseStyleColors = true;
        // 
        // openFileDialog
        // 
        this.openFileDialog.FileName = "openFileDialog1";
        // 
        // metroLabel2
        // 
        this.metroLabel2.AutoSize = true;
        this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
        this.metroLabel2.Location = new System.Drawing.Point(10, 79);
        this.metroLabel2.Name = "metroLabel2";
        this.metroLabel2.Size = new System.Drawing.Size(679, 25);
        this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
        this.metroLabel2.TabIndex = 6;
        this.metroLabel2.Text = "Do NOT use it to encrypt sensitive data. A hardware-based RNG should be used inst" +
"ead.";
        this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.metroLabel2.UseStyleColors = true;
        // 
        // rngExplanationLbl
        // 
        this.rngExplanationLbl.AutoSize = true;
        this.rngExplanationLbl.Location = new System.Drawing.Point(79, 150);
        this.rngExplanationLbl.Name = "rngExplanationLbl";
        this.rngExplanationLbl.Size = new System.Drawing.Size(553, 76);
        this.rngExplanationLbl.TabIndex = 7;
        this.rngExplanationLbl.Text = resources.GetString("rngExplanationLbl.Text");
        this.rngExplanationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.rngExplanationLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // pcgLink
        // 
        this.pcgLink.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pcgLink.ForeColor = System.Drawing.Color.RoyalBlue;
        this.pcgLink.Location = new System.Drawing.Point(261, 206);
        this.pcgLink.Name = "pcgLink";
        this.pcgLink.Size = new System.Drawing.Size(244, 23);
        this.pcgLink.TabIndex = 8;
        this.pcgLink.Text = "https://www.pcg-random.org/index.html";
        this.pcgLink.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.pcgLink.UseCustomForeColor = true;
        this.pcgLink.UseSelectable = true;
        this.pcgLink.Click += new System.EventHandler(this.PcgLink_Click);
        // 
        // toolTip
        // 
        this.toolTip.BackColor = System.Drawing.SystemColors.GrayText;
        this.toolTip.ForeColor = System.Drawing.Color.White;
        this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        this.toolTip.ToolTipTitle = "Explanation";
        // 
        // progressBar
        // 
        this.progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.progressBar.HorizontalScrollbarBarColor = true;
        this.progressBar.HorizontalScrollbarHighlightOnWheel = false;
        this.progressBar.HorizontalScrollbarSize = 10;
        this.progressBar.Location = new System.Drawing.Point(307, 235);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(362, 42);
        this.progressBar.TabIndex = 9;
        this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.progressBar.VerticalScrollbarBarColor = true;
        this.progressBar.VerticalScrollbarHighlightOnWheel = false;
        this.progressBar.VerticalScrollbarSize = 10;
        // 
        // KeyGenerator
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(692, 292);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.pcgLink);
        this.Controls.Add(this.rngExplanationLbl);
        this.Controls.Add(this.metroLabel2);
        this.Controls.Add(this.algoLbl);
        this.Controls.Add(this.generateKeyBtn);
        this.Controls.Add(this.rngCbo);
        this.Controls.Add(this.bytesLbl);
        this.Controls.Add(this.bytesNumericUpDown);
        this.Controls.Add(this.metroLabel1);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.Name = "KeyGenerator";
        this.Opacity = 0.95D;
        this.Resizable = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Generate PRNG-based key";
        this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
        this.Theme = MetroFramework.MetroThemeStyle.Dark;
        ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.bytesNumericUpDown)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private MetroFramework.Controls.MetroLabel metroLabel1;
    private NumericUpDown bytesNumericUpDown;
    private MetroFramework.Controls.MetroLabel bytesLbl;
    private MetroFramework.Controls.MetroComboBox rngCbo;
    private MetroFramework.Controls.MetroButton generateKeyBtn;
    private MetroFramework.Controls.MetroLabel algoLbl;
    private OpenFileDialog openFileDialog;
    private MetroFramework.Controls.MetroLabel metroLabel2;
    private MetroFramework.Controls.MetroLabel rngExplanationLbl;
    private MetroFramework.Controls.MetroLink pcgLink;
    private ToolTip toolTip;
    private MetroFramework.Controls.MetroPanel progressBar;
}