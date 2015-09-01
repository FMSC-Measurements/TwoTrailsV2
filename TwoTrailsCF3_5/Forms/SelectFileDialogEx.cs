using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class SelectFileDialogEx : Form
    {
        private string _ItemPath, _Type;
        private List<string> _ItemList, _TypeList = new List<string>() { ".tt2", null};

        public string FileName { get { return _ItemPath; } }

        public string Title { set { this.Text = value; } }


        public SelectFileDialogEx(string filename, string StartFolder)
        {
            InitializeComponent();
            Init(filename, StartFolder, true);
        }

        public SelectFileDialogEx(string filename, string StartFolder, bool showFiles)
        {
            InitializeComponent();
            Init(filename, StartFolder, showFiles);
        }

        private void Init(string filename, string StartFolder, bool showFiles)
        {
            cboType.Items.Add("TwoTrails 2 File");
            cboType.Items.Add("All Files");
            _Type = _TypeList[0];
            cboType.SelectedIndex = 0;

            _ItemList = new List<string>();

            if (StartFolder != null && Directory.Exists(StartFolder))
            {
                _ItemPath = StartFolder;
            }
            else
            {
                _ItemPath = "\\";// Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
        }


        private void LoadItems(string dir)
        {
            if (Directory.Exists(dir))
            {
                DirectoryInfo rootDir = new DirectoryInfo(dir);

                _ItemList.Clear();
                lstBrowse.Items.Clear();

                lblDir.Text = rootDir.Name;

                foreach (DirectoryInfo di in rootDir.GetDirectories())
                {
                    _ItemList.Add(di.FullName);
                    lstBrowse.Items.Add(String.Format("[{0}]", di.Name));
                }

                foreach (FileInfo fi in rootDir.GetFiles())
                {
                    if (_Type == null || fi.Extension == _Type)
                    {
                        _ItemList.Add(fi.FullName);
                        lstBrowse.Items.Add(fi.Name);
                    }
                }

                if (rootDir.Parent != null)
                {
                    _ItemList.Add(rootDir.Parent.FullName);
                    lstBrowse.Items.Add("Go to Parent");
                }

                //_ItemPath = String.Empty;
                //txtFileName.Text = _ItemPath;
            }
        }

        private void SelectFileDialogEx_Load(object sender, EventArgs e)
        {
            LoadItems(_ItemPath);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtFileName.Text.IsEmpty())
            {
                if (Directory.Exists(FileName))
                {
                    _ItemPath = Path.Combine(_ItemPath, (txtFileName.Text.Contains(".tt2")) ? txtFileName.Text : txtFileName.Text + ".tt2");
                }

                if (File.Exists(FileName))
                {
                    if (MessageBox.Show("This File already exists. Would you like to overwrite it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(FileName);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch
                        {
                            MessageBox.Show(String.Format("Unable to delete file {0}", FileName));
                            return;
                        }
                    }
                    else
                        return;
                }
                else
                    this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("File Name not entered");
                txtFileName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lstBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ItemList.Count > 0)
            {
                if (lstBrowse.SelectedIndex > -1 && lstBrowse.SelectedIndex < _ItemList.Count)
                {
                    _ItemPath = _ItemList[lstBrowse.SelectedIndex];


                    if (File.Exists(_ItemPath))
                    {
                        txtFileName.Text = Path.GetFileName(_ItemPath);
                    }
                    else
                        LoadItems(_ItemPath);
                }
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex > -1)
            {
                _Type = _TypeList[cboType.SelectedIndex];
                LoadItems(_ItemPath);
            }
        }

        private void txtFileName_GotFocus(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtFileName);
        }

        private void lstBrowse_GotFocus(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void cboType_GotFocus(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtFileName_LostFocus(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            NewFolderBox(false);
        }

        private void txtFolderName_GotFocus(object sender, EventArgs e)
        {
            Kb.ShowRegular(this, txtFolderName);
        }

        private void btnFolderCancel_Click(object sender, EventArgs e)
        {
            NewFolderBox(true);
        }

        private void btnFolderCreate_Click(object sender, EventArgs e)
        {
            if (!txtFolderName.Text.IsEmpty())
            {
                if (txtFolderName.Text != Path.GetDirectoryName(_ItemPath))
                {
                    string path = Directory.Exists(_ItemPath) ? _ItemPath : Path.GetPathRoot(_ItemPath);
                    _ItemPath = Path.Combine(path, txtFolderName.Text);

                    if (!Directory.Exists(_ItemPath))
                        Directory.CreateDirectory(_ItemPath);
                    LoadItems(_ItemPath);
                    txtFolderName.Text = String.Empty;
                }
            }
            else
            {
                return;
            }

            NewFolderBox(true);
        }

        private void NewFolderBox(bool hide)
        {
            pnlFolder.Visible = !hide;
            btnCancel.Enabled = hide;
            btnNewFolder.Enabled = hide;
            btnSave.Enabled = hide;
            lstBrowse.Enabled = hide;
            txtFileName.Enabled = hide;
            cboType.Enabled = hide;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text.IsEmpty())
                lblDesc.Visible = true;
            else
                lblDesc.Visible = false;
        }
    }
}