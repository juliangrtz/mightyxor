using System.Diagnostics;
using MightyXOR.Common;
using MightyXOR.GUI.Utils;
using MetroFramework.Forms;

namespace MightyXOR.GUI.Forms.SecretSharing
{
    public partial class Reconstructor : MetroForm
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

        public Reconstructor()
        {
            InitializeComponent();
            RegisterClickHandlers();

            fileListView.BackColor = MainForm.DarkThemeColor;
            fileListView.AllowDrop = true;
        }

        private void RegisterClickHandlers()
        {
            outputDirSelectBtn.Click += OutputDirSelectBtnOnClick;
            reconstructBtn.Click += ReconstructBtnOnClick;
            deleteAllRowsBtn.Click += DeleteAllRowsBtnOnClick;
        }

        private void DeleteAllRowsBtnOnClick(object? sender, EventArgs e)
            => fileListView.Items.Clear();

        private void OutputDirSelectBtnOnClick(object? sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog()
            {
                Description = "Choose an output directory",
                ShowNewFolderButton = true,
                UseDescriptionForTitle = true,
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                LabelUtil.UpdateLabel(outputDirLbl, folderBrowserDialog.SelectedPath);
                UpdateReconstructBtnStatus();
            }
        }

        private void UpdateReconstructBtnStatus()
        {
            reconstructBtn.Enabled = Directory.Exists(outputDirLbl.Text) &&
                                     fileListView.CheckedItems.Count >= 2;
        }

        private void ReconstructBtnOnClick(object? sender, EventArgs e)
        {
            try
            {
                var shareFiles = fileListView.CheckedItems.Cast<object>().Select(x => fileListView.GetItemText(x))
                    .ToArray();
                var outputDirectory = Directory.Exists(outputDirLbl.Text)
                    ? outputDirLbl.Text
                    : Environment.CurrentDirectory;
                var k = (byte)shareFiles.Length;

                var reconstructor = new Core.SecretSharing.Shamir.Reconstructor(shareFiles);
                reconstructor.Reconstruct(k, headerUsedChk.Checked, outputDirectory);

                DeleteSharesIfWanted(shareFiles);

                var result = MessageBox.Show("Reconstruction successful. Open output directory?", "Finished",
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

        private void DeleteSharesIfWanted(string[] shareFiles)
        {
            // ToDo: Extract logic to Core library!

            if (deleteSharesChk.Checked)
            {
                foreach (var share in shareFiles)
                    new FileInfo(share).DeleteIfExists();
            }
        }

        private void FileListView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
                return;

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 255)
            {
                MessageBox.Show("Too many files.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            foreach (var file in files)
                fileListView.Items.Add(file, true);

            UpdateReconstructBtnStatus();
        }

        private void FileListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FileListView_ItemCheck(object sender, ItemCheckEventArgs e)
            => BeginInvoke((MethodInvoker)(UpdateReconstructBtnStatus));

        private void FileListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                fileListView.Items.Remove(fileListView.SelectedItem);
        }
    }
}