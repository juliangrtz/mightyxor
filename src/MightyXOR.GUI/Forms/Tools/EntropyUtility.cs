using MightyXOR.Common.Utility;
using MetroFramework.Forms;

namespace MightyXOR.GUI.Forms.Tools;

public partial class EntropyUtility : MetroForm
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

    public EntropyUtility()
    {
        InitializeComponent();
        filePictureBox.AllowDrop = true;
    }

    private void FilePictureBox_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }

    private void FilePictureBox_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data == null)
            return;

        var files = (string[])e.Data.GetData(DataFormats.FileDrop);

        if (files.Length > 1)
        {
            MessageBox.Show("Please drag a single file into the rectangle.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        CalculateEntropy(files[0]);
    }

    private static Color RetrieveColorForEntropy(double entropy)
    {
        switch (entropy)
        {
            case >= 0 and <= 5:
                return Color.Red;

            case > 5 and <= 6:
                return Color.Yellow;

            case > 6 and <= 7:
                return Color.LightGreen;

            case > 7 and <= 8:
                return Color.Green;
        }

        if (Math.Abs(entropy - 8) < 0.1)
            return Color.DarkGreen;

        return Color.White;
    }

    private void CalculateEntropy(string filePath)
    {
        var fileName = new FileInfo(filePath).Name;
        var bytes = File.ReadAllBytes(filePath);
        var entropy = Math.Round(EntropyUtil.ShannonEntropy(bytes), 3);

        entropyLbl.ForeColor = RetrieveColorForEntropy(entropy);
        entropyLbl.Text = $"{fileName} has an entropy of {entropy}.";
    }
}