using Amgine.Core.Crypto.KeyGenerators;
using MetroFramework.Forms;
using System.Diagnostics;
using KeyGen = Amgine.Core.Crypto.KeyGenerators.KeyGenerator;

namespace Amgine.GUI.Forms.Tools;

public partial class KeyGenerator : MetroForm
{
    private const string PcgUrl = "https://www.pcg-random.org/index.html";
    private readonly SaveFileDialog _saveFileDialog;

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

    public KeyGenerator()
    {
        InitializeComponent();

        _saveFileDialog = new SaveFileDialog
        {
            Title = "Choose a file name for the key",
            Filter = "Key file|*.key|Binary file|*.bin|All files|*.*",
        };
        UpdateFileNameInDialog();

        var keygens = Enum.GetNames(typeof(KeyGen));
        rngCbo.Items.AddRange(keygens.ToArray<object>());
        rngCbo.SelectedIndex = 0;
    }

    private void UpdateFileNameInDialog()
        => _saveFileDialog.FileName = $"{bytesNumericUpDown.Value}_bytes_{rngCbo.SelectedItem as string}.key";

    private void GenerateKeyBtn_Click(object sender, EventArgs e)
    {
        UpdateFileNameInDialog();

        if (_saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var keyGenFromEnum = (KeyGen)Enum.Parse(typeof(KeyGen), rngCbo.SelectedItem as string
                                                                ?? throw new InvalidOperationException());
                var keyGen = IKeyGenerator.FromEnum(keyGenFromEnum);
                var length = (int)bytesNumericUpDown.Value;

                File.WriteAllBytes(_saveFileDialog.FileName, keyGen.GenerateKey(length));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Key generation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BytesNumericUpDown_ValueChanged(object sender, EventArgs e)
        => UpdateFileNameInDialog();

    private void PcgLink_Click(object sender, EventArgs e)
        => Process.Start(new ProcessStartInfo("cmd", $"/c start {PcgUrl}") { CreateNoWindow = true });
}