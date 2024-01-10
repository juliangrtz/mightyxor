using MetroFramework.Forms;

namespace MightyXOR.GUI.Forms.OTP;

partial class DecryptForm
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
        keyPathLbl = new MetroFramework.Controls.MetroLabel();
        keySelectBtn = new MetroFramework.Controls.MetroButton();
        deleteKeyChk = new MetroFramework.Controls.MetroCheckBox();
        overrideCiphertextChk = new MetroFramework.Controls.MetroCheckBox();
        outputDirLbl = new MetroFramework.Controls.MetroLabel();
        outputDirSelectBtn = new MetroFramework.Controls.MetroButton();
        ciphertextPathLbl = new MetroFramework.Controls.MetroLabel();
        ciphertextFileSelectBtn = new MetroFramework.Controls.MetroButton();
        progressBar = new MetroFramework.Controls.MetroPanel();
        decryptBtn = new MetroFramework.Controls.MetroButton();
        compareHashesChk = new MetroFramework.Controls.MetroCheckBox();
        openFileDialog = new OpenFileDialog();
        folderBrowserDialog = new FolderBrowserDialog();
        metroStyleManager = new MetroFramework.Components.MetroStyleManager(components);
        toolTip = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)metroStyleManager).BeginInit();
        SuspendLayout();
        // 
        // keyPathLbl
        // 
        keyPathLbl.AutoEllipsis = true;
        keyPathLbl.AutoSize = true;
        keyPathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        keyPathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        keyPathLbl.Location = new Point(114, 115);
        keyPathLbl.MaximumSize = new Size(535, 0);
        keyPathLbl.Name = "keyPathLbl";
        keyPathLbl.Size = new Size(130, 25);
        keyPathLbl.TabIndex = 0;
        keyPathLbl.Text = "Path of the key";
        keyPathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // keySelectBtn
        // 
        keySelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
        keySelectBtn.Location = new Point(31, 115);
        keySelectBtn.Name = "keySelectBtn";
        keySelectBtn.Size = new Size(75, 23);
        keySelectBtn.TabIndex = 2;
        keySelectBtn.Text = "Choose...";
        keySelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        keySelectBtn.UseSelectable = true;
        // 
        // deleteKeyChk
        // 
        deleteKeyChk.AutoSize = true;
        deleteKeyChk.Checked = true;
        deleteKeyChk.CheckState = CheckState.Checked;
        deleteKeyChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
        deleteKeyChk.Location = new Point(415, 190);
        deleteKeyChk.Name = "deleteKeyChk";
        deleteKeyChk.Size = new Size(228, 25);
        deleteKeyChk.TabIndex = 6;
        deleteKeyChk.Text = "Delete the key afterwards";
        deleteKeyChk.Theme = MetroFramework.MetroThemeStyle.Dark;
        toolTip.SetToolTip(deleteKeyChk, "Permanently deletes the key after the decryption in a secure manner.\r\nThis is strongly recommended to ensure the key is only used once.");
        deleteKeyChk.UseSelectable = true;
        // 
        // overrideCiphertextChk
        // 
        overrideCiphertextChk.AutoSize = true;
        overrideCiphertextChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
        overrideCiphertextChk.Location = new Point(31, 190);
        overrideCiphertextChk.Name = "overrideCiphertextChk";
        overrideCiphertextChk.Size = new Size(206, 25);
        overrideCiphertextChk.TabIndex = 4;
        overrideCiphertextChk.Text = "Override ciphertext file";
        overrideCiphertextChk.Theme = MetroFramework.MetroThemeStyle.Dark;
        toolTip.SetToolTip(overrideCiphertextChk, "This setting causes the selected ciphertext file to be overridden.\r\nIt should be used if the plaintext was overridden in the encryption before.\r\n");
        overrideCiphertextChk.UseSelectable = true;
        // 
        // outputDirLbl
        // 
        outputDirLbl.AutoEllipsis = true;
        outputDirLbl.AutoSize = true;
        outputDirLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        outputDirLbl.Location = new Point(114, 151);
        outputDirLbl.MaximumSize = new Size(535, 0);
        outputDirLbl.Name = "outputDirLbl";
        outputDirLbl.Size = new Size(333, 25);
        outputDirLbl.TabIndex = 0;
        outputDirLbl.Text = "Output directory of the plaintext (optional)";
        outputDirLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        toolTip.SetToolTip(outputDirLbl, "If no output directory is selected, the directory of the plaintext file is chosen.");
        // 
        // outputDirSelectBtn
        // 
        outputDirSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
        outputDirSelectBtn.Location = new Point(31, 153);
        outputDirSelectBtn.Name = "outputDirSelectBtn";
        outputDirSelectBtn.Size = new Size(75, 23);
        outputDirSelectBtn.TabIndex = 3;
        outputDirSelectBtn.Text = "Choose...";
        outputDirSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        outputDirSelectBtn.UseSelectable = true;
        // 
        // ciphertextPathLbl
        // 
        ciphertextPathLbl.AutoEllipsis = true;
        ciphertextPathLbl.AutoSize = true;
        ciphertextPathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
        ciphertextPathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
        ciphertextPathLbl.Location = new Point(114, 74);
        ciphertextPathLbl.MaximumSize = new Size(535, 0);
        ciphertextPathLbl.Name = "ciphertextPathLbl";
        ciphertextPathLbl.Size = new Size(208, 25);
        ciphertextPathLbl.TabIndex = 0;
        ciphertextPathLbl.Text = "Path of the ciphertext file";
        ciphertextPathLbl.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // ciphertextFileSelectBtn
        // 
        ciphertextFileSelectBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
        ciphertextFileSelectBtn.Location = new Point(31, 76);
        ciphertextFileSelectBtn.Name = "ciphertextFileSelectBtn";
        ciphertextFileSelectBtn.Size = new Size(75, 23);
        ciphertextFileSelectBtn.TabIndex = 1;
        ciphertextFileSelectBtn.Text = "Choose...";
        ciphertextFileSelectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        ciphertextFileSelectBtn.UseSelectable = true;
        // 
        // progressBar
        // 
        progressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        progressBar.HorizontalScrollbarBarColor = true;
        progressBar.HorizontalScrollbarHighlightOnWheel = false;
        progressBar.HorizontalScrollbarSize = 10;
        progressBar.Location = new Point(232, 237);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(411, 42);
        progressBar.TabIndex = 0;
        progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
        progressBar.VerticalScrollbarBarColor = true;
        progressBar.VerticalScrollbarHighlightOnWheel = false;
        progressBar.VerticalScrollbarSize = 10;
        // 
        // decryptBtn
        // 
        decryptBtn.Enabled = false;
        decryptBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
        decryptBtn.Location = new Point(31, 237);
        decryptBtn.Name = "decryptBtn";
        decryptBtn.Size = new Size(188, 42);
        decryptBtn.TabIndex = 7;
        decryptBtn.Text = "Decrypt";
        decryptBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
        decryptBtn.UseSelectable = true;
        // 
        // compareHashesChk
        // 
        compareHashesChk.AutoSize = true;
        compareHashesChk.Checked = true;
        compareHashesChk.CheckState = CheckState.Checked;
        compareHashesChk.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
        compareHashesChk.Location = new Point(245, 190);
        compareHashesChk.Name = "compareHashesChk";
        compareHashesChk.Size = new Size(160, 25);
        compareHashesChk.TabIndex = 5;
        compareHashesChk.Text = "Compare hashes";
        compareHashesChk.Theme = MetroFramework.MetroThemeStyle.Dark;
        toolTip.SetToolTip(compareHashesChk, "Performs an integrity check by comparing the hash in the header with the actual hash of the plaintext.\r\nIf the cipher does not contain a header, this setting is ineffective.");
        compareHashesChk.UseSelectable = true;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog1";
        // 
        // metroStyleManager
        // 
        metroStyleManager.Owner = null;
        metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
        // 
        // toolTip
        // 
        toolTip.ToolTipIcon = ToolTipIcon.Info;
        toolTip.ToolTipTitle = "Explanation";
        // 
        // DecryptForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(663, 301);
        Controls.Add(keyPathLbl);
        Controls.Add(keySelectBtn);
        Controls.Add(deleteKeyChk);
        Controls.Add(overrideCiphertextChk);
        Controls.Add(outputDirLbl);
        Controls.Add(outputDirSelectBtn);
        Controls.Add(ciphertextPathLbl);
        Controls.Add(ciphertextFileSelectBtn);
        Controls.Add(progressBar);
        Controls.Add(decryptBtn);
        Controls.Add(compareHashesChk);
        MaximizeBox = false;
        Name = "DecryptForm";
        Opacity = 0.95D;
        Resizable = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Decrypt a file using one-time pad";
        TextAlign = MetroFormTextAlign.Center;
        Theme = MetroFramework.MetroThemeStyle.Dark;
        ((System.ComponentModel.ISupportInitialize)metroStyleManager).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private MetroFramework.Controls.MetroLabel keyPathLbl;
    private MetroFramework.Controls.MetroButton keySelectBtn;
    private MetroFramework.Controls.MetroCheckBox deleteKeyChk;
    private MetroFramework.Controls.MetroCheckBox overrideCiphertextChk;
    private MetroFramework.Controls.MetroLabel outputDirLbl;
    private MetroFramework.Controls.MetroButton outputDirSelectBtn;
    private MetroFramework.Controls.MetroLabel ciphertextPathLbl;
    private MetroFramework.Controls.MetroButton ciphertextFileSelectBtn;
    private MetroFramework.Controls.MetroPanel progressBar;
    private MetroFramework.Controls.MetroButton decryptBtn;
    private MetroFramework.Controls.MetroCheckBox compareHashesChk;
    private OpenFileDialog openFileDialog;
    private FolderBrowserDialog folderBrowserDialog;
    private MetroFramework.Components.MetroStyleManager metroStyleManager;
    private ToolTip toolTip;
}