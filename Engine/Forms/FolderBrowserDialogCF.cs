using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TwoTrails.Forms
{
    public partial class FolderBrowserDialogCF : Form
    {
        private string _FolderPath;
        private List<string> _FolderList;

        public string Folder { get { return _FolderPath; } }

        public string Title { set { this.Text = value; } } 

        public FolderBrowserDialogCF(string StartFolder)
        {
            this.DialogResult = DialogResult.Cancel;

            InitializeComponent();

            _FolderList = new List<string>();

            if (StartFolder != null && Directory.Exists(StartFolder))
            {
                _FolderPath = StartFolder;
            }
            else
            {
                _FolderPath = "\\";// Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }

            LoadFolders(_FolderPath);
        }

        private void LoadFolders(string dir)
        {
            if (Directory.Exists(dir))
            {
                DirectoryInfo rootDir = new DirectoryInfo(dir);

                _FolderList.Clear();
                lstFolders.Items.Clear();

                foreach (DirectoryInfo di in rootDir.GetDirectories())
                {
                    _FolderList.Add(di.FullName);
                    lstFolders.Items.Add(di.Name);
                }

                if (rootDir.Parent != null)
                {
                    _FolderList.Add(rootDir.Parent.FullName);
                    lstFolders.Items.Add("Go to Parent");
                }

                txtFolder.Text = rootDir.FullName;
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_FolderList.Count > 0)
            {
                if (lstFolders.SelectedIndex > -1 && lstFolders.SelectedIndex < _FolderList.Count)
                {
                    _FolderPath = _FolderList[lstFolders.SelectedIndex];
                    LoadFolders(_FolderPath);
                }
            }
        }
    }
}