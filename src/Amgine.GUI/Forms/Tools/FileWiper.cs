using Amgine.GUI.Utils;
using MetroFramework.Forms;

namespace Amgine.GUI.Forms.Tools;

public partial class FileWiper : MetroForm
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

    public FileWiper()
    {
        InitializeComponent();
    }

    private void FileSelectBtn_Click(object sender, EventArgs e)
    {
        openFileDialog = new OpenFileDialog
        {
            Title = "Choose a file",
            Filter = "All files|*.*",
            InitialDirectory = Environment.CurrentDirectory
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
            LabelUtil.UpdateLabel(filePathLbl, openFileDialog.FileName);

        UpdateDeleteBtnStatus();
    }

    private void UpdateDeleteBtnStatus()
    {
        deleteBtn.Enabled = File.Exists(filePathLbl.Text);
    }

    private void DeleteBtn_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to permanently delete the file?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        var filePath = filePathLbl.Text;
        var overrides = (int)overridesNumericUpDown.Value;

        try
        {
            var fileWiper = new Core.IO.FileWiper(filePath);
            fileWiper.WipeFile(overrides);

            MessageBox.Show($"Permanently deleted {filePath}.", "Done", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}