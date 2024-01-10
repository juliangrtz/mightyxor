using MightyXOR.Core.Crypto.OTP;
using MightyXOR.Core.Models;
using MightyXOR.GUI.Utils;
using MetroFramework.Forms;

namespace MightyXOR.GUI.Forms.OTP;

public partial class DecryptForm : MetroForm
{
    // Reduce flickering
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;
            return cp;
        }
    }

    public DecryptForm()
    {
        InitializeComponent();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        decryptBtn.Click += DecryptBtn_Click;
        ciphertextFileSelectBtn.Click += CiphertextFileSelectBtn_Click;
        keySelectBtn.Click += KeySelectBtn_Click;
        outputDirSelectBtn.Click += OutputDirSelectBtn_Click;
        overrideCiphertextChk.CheckedChanged += OverrideCiphertextChk_CheckedChanged;
    }

    private void UpdateDecryptBtnStatus()
    {
        decryptBtn.Enabled = File.Exists(ciphertextPathLbl.Text)
                             && File.Exists(keyPathLbl.Text);
    }

    private void DecryptBtn_Click(object? sender, EventArgs? e)
    {
        if (MessageBox.Show("Is everything configured correctly?", "Confirm decryption", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        try
        {
            var ciphertextPath = ciphertextPathLbl.Text;
            var keyPath = keyPathLbl.Text;
            var outputDirectory = Directory.Exists(outputDirLbl.Text)
                ? outputDirLbl.Text
                : Path.GetDirectoryName(ciphertextPath) ?? Environment.CurrentDirectory;
            var settings = new MightyXorSettings
            {
                OverrideFile = overrideCiphertextChk.Checked,
                DeleteKeyAfterDecryption = deleteKeyChk.Checked,
                CompareHashesInHeader = compareHashesChk.Checked,
                OutputDirectory = outputDirectory,
            };

            var otp = new OneTimePad(settings, keyPath);

            otp.DecryptFile(ciphertextPath);
            MessageBox.Show("Decryption successful.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            if (MessageBox.Show(ex.ToString(), "Error during decryption", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error)
                == DialogResult.Retry)
            {
                DecryptBtn_Click(null, null);
            }
        }
    }

    private void CiphertextFileSelectBtn_Click(object? sender, EventArgs e)
    {
        openFileDialog = new OpenFileDialog
        {
            Title = "Choose a ciphertext file",
            Filter = "Encrypted file|*.encrypted|All files|*.*",
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
            LabelUtil.UpdateLabel(ciphertextPathLbl, openFileDialog.FileName);

        UpdateDecryptBtnStatus();
    }

    private void KeySelectBtn_Click(object? sender, EventArgs e)
    {
        openFileDialog = new OpenFileDialog
        {
            Title = "Choose a key file",
            Filter = "Key file|*.key|Binary file|*.bin|All files|*.*",
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
            LabelUtil.UpdateLabel(keyPathLbl, openFileDialog.FileName);

        UpdateDecryptBtnStatus();
    }

    private void OutputDirSelectBtn_Click(object? sender, EventArgs e)
    {
        folderBrowserDialog = new FolderBrowserDialog()
        {
            Description = "Choose an output directory",
            ShowNewFolderButton = true,
            UseDescriptionForTitle = true,
        };

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            LabelUtil.UpdateLabel(outputDirLbl, folderBrowserDialog.SelectedPath);
    }

    private void OverrideCiphertextChk_CheckedChanged(object? sender, EventArgs? e)
    {
        var isChecked = !overrideCiphertextChk.Checked;
        outputDirSelectBtn.Enabled = isChecked;

        if (!isChecked)
        {
            outputDirLbl.Text = "Output directory of the plaintext";
        }
    }
}