using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using System.IO;
using System.Diagnostics;

namespace TwoTrails.Forms
{
    public partial class DrawGMap : Form
    {
        DataAccessLayer DAL;

        public bool IsClosed = false;
        string tempFile;

        public DrawGMap(DataAccessLayer dal)
        {
            InitializeComponent();

            if (dal == null)
                throw new NullReferenceException();

            DAL = dal;
        }

        private void DrawGMap_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            try
            {
                DrawMap();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "DrawGMap:Load", ex.StackTrace);
                MessageBox.Show("Page Generation Error. Please see log file for details.");
                this.Close();
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(saveFileDialog1.FileName, false))
                    {
                        tw.WriteLine(TtGMapGenerator.GenerateHtml(DAL));
                    }
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "DrawGMap:Save", ex.StackTrace);
                    MessageBox.Show("Map Save Error. Please see log file for details.");
                    this.Close();
                }
            }
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiRedraw_Click(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void DrawMap()
        {
            tempFile = Path.GetTempPath() + "map.html";

            using (TextWriter tw = new StreamWriter(tempFile, false))
            {
                tw.WriteLine(TtGMapGenerator.GenerateHtml(DAL));
            }

            browser.Navigate(tempFile);
        }

        private void DrawGMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
        }
    }
}
