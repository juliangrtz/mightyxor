using System.Diagnostics;
using Amgine.Common.Utility;
using Amgine.Core.Models;
using Amgine.GUI.Utils;
using MetroFramework.Forms;

namespace Amgine.GUI.Forms.SecretSharing;

public partial class Distributor : MetroForm
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

    public Distributor()
    {
        InitializeComponent();
        RegisterClickEvents();
    }

    private void RegisterClickEvents()
    {
        fileSelectBtn.Click += FileSelectBtn_Click;
        outputDirSelectBtn.Click += OutputDirSelectBtn_Click;
        distributeBtn.Click += DistributeBtn_Click;
    }

    private void FileSelectBtn_Click(object? sender, EventArgs e)
    {
        openFileDialog = new OpenFileDialog
        {
            Title = "Choose a file that is to be distributed",
            Filter = "All files|*.*",
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            LabelUtil.UpdateLabel(secretPathLbl, openFileDialog.FileName);
            distributeBtn.Enabled = true;
        }
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

    private void DistributeBtn_Click(object? sender, EventArgs e)
    {
        try
        {
            var pathToSecret = secretPathLbl.Text;
            var outputDirectory = Directory.Exists(outputDirLbl.Text) ? outputDirLbl.Text
                                                                           : Path.GetDirectoryName(Path.GetFullPath(pathToSecret))
                                        ?? Environment.CurrentDirectory;
            var n = (byte)participantsNumericUpDown.Value;
            var k = (byte)requiredParticipantsNumericUpDown.Value;

            if (useHeaderChk.Checked)
            {
                var secretBytes = File.ReadAllBytes(pathToSecret);
                var amgineFileHeader = new AmgineFileHeader(new FileInfo(pathToSecret),
                                                            new HashUtil(HashType.MD5).GenerateHash(secretBytes));
                var amgineFile = new AmgineFile(amgineFileHeader, secretBytes);
                var distributor = new Core.SecretSharing.Shamir.Distributor(amgineFile);
                distributor.GenerateFileShares(n, k, outputDirectory);
            }
            else
            {
                var distributor = new Core.SecretSharing.Shamir.Distributor(pathToSecret);
                distributor.GenerateFileShares(n, k, outputDirectory);
            }

            var result = MessageBox.Show("Distribution successful. Open output directory?", "Finished",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Process.Start("explorer.exe", outputDirectory);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error during distribution", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}