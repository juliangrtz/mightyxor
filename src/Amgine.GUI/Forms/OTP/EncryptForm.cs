using Amgine.Core.Crypto.OTP;
using Amgine.Core.Models;
using Amgine.GUI.Utils;
using MetroFramework.Forms;

namespace Amgine.GUI.Forms.OTP;

public partial class EncryptForm : MetroForm
{
    private int _minimumKeySize;

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

    public EncryptForm()
    {
        InitializeComponent();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        encryptBtn.Click += EncryptBtn_Click;
        keySelectBtn.Click += KeySelectBtn_Click;
        outputDirSelectBtn.Click += OutputDirSelectBtn_Click;
        plaintextFileSelectBtn.Click += PlaintextFileSelectBtn_Click;
        overridePlaintextChk.CheckedChanged += OverridePlaintextChk_CheckedChanged;
    }

    private void OverridePlaintextChk_CheckedChanged(object? sender, EventArgs e)
    {
        var isChecked = !overridePlaintextChk.Checked;
        outputDirSelectBtn.Enabled = isChecked;

        if (!isChecked)
        {
            outputDirLbl.Text = "Output directory of the cipher";
        }
    }

    private void UpdateEncryptBtnStatus()
    {
        encryptBtn.Enabled = File.Exists(plaintextPathLbl.Text)
                             && File.Exists(keyPathLbl.Text);
    }

    private void Encrypt()
    {
        try
        {
            var keyPath = keyPathLbl.Text;
            var plaintextPath = plaintextPathLbl.Text;
            var outputDirectory = Directory.Exists(outputDirLbl.Text)
                ? outputDirLbl.Text
                : Path.GetDirectoryName(plaintextPath) ?? Environment.CurrentDirectory;
            var amgineSettings = new AmgineSettings
            {
                OverrideFile = overridePlaintextChk.Checked,
                UseFileHeader = generateHeaderChk.Checked,
                SetCiphertextReadOnly = ciphertextReadOnlyChk.Checked,
                OutputDirectory = outputDirectory,
            };

            var otp = new OneTimePad(amgineSettings, keyPath);

            otp.EncryptFile(plaintextPath);
            MessageBox.Show("Encryption successful.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            if (MessageBox.Show(ex.ToString(), "Error during encryption", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error)
                == DialogResult.Retry)
            {
                EncryptBtn_Click(null, null);
            }
        }
    }

    private void EncryptBtn_Click(object? sender, EventArgs? e)
    {
        if (MessageBox.Show("Is everything configured correctly?", "Confirm encryption", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        var keySize = new FileInfo(keyPathLbl.Text).Length;
        if (keySize < _minimumKeySize)
        {
            MessageBox.Show($"The key is too small ({_minimumKeySize - keySize} bytes missing)!", "Cannot start encryption",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Encrypt();
    }

    private void PlaintextFileSelectBtn_Click(object? sender, EventArgs e)
    {
        openFileDialog = new OpenFileDialog
        {
            Title = "Choose a plaintext file",
            Filter = "All files|*.*",
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            LabelUtil.UpdateLabel(plaintextPathLbl, openFileDialog.FileName);
            var fileLength = (int)new FileInfo(openFileDialog.FileName).Length;
            var ApproximateHeaderSize = 400;
            _minimumKeySize = fileLength + ApproximateHeaderSize;
            keySizeInfoLbl.Text = $"The key must have at least {_minimumKeySize} ({fileLength}+{ApproximateHeaderSize}) bytes.";
        }

        UpdateEncryptBtnStatus();
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

        UpdateEncryptBtnStatus();
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

        UpdateEncryptBtnStatus();
    }
}