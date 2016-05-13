using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine.BusinessLogic;
using System.IO;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class HowAmIDoingForm : Form
    {
        private HowAmIDoingLogic _logic;
        private HowAmIDoingOptions _options;
        private bool showpoints = false;
        StreamReader streamToPrint;
        Font printFont = new Font("Arial", 10);

        public HowAmIDoingForm(HowAmIDoingLogic logic, HowAmIDoingOptions options)
        {
            InitializeComponent();
            _logic = logic;
            _options = options;
        }

        private void HowAmIDoingForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            _logic.Execute(showpoints);
            reportTextBox.Text = _options.ReportText.ToString();
            reportTextBox.DeselectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _options.SaveReport = true;
                    _options.ReportPath = saveFileDialog1.FileName;
                    _logic.Execute(showpoints);
                    _options.SaveReport = false;

                    #if !(PocketPC || WindowsCE || Mobile)
                    Engine.Values.UpdateStatusText(String.Format("Summary saved to {0}", saveFileDialog1.FileName));
                    #endif
                }
                catch(Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "HowAmIDoingForm:Save", ex.StackTrace);
                }
            }
        }

        private void btnPointToggle_Click(object sender, EventArgs e)
        {
            showpoints = !showpoints;
            _logic.Execute(showpoints);
            reportTextBox.Text = _options.ReportText.ToString();
            reportTextBox.DeselectAll();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(_options == null || _options.ReportText == null)
            {
                //no report
                return;
            }

            using (PrintDialog dialog = new PrintDialog())
            {
                using (System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument())
                {
                    dialog.AllowSomePages = true;
                    dialog.ShowHelp = true;
                    dialog.Document = doc;

                    doc.PrintPage += doc_PrintPage;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        MemoryStream stream = new MemoryStream();
                        StreamWriter writer = new StreamWriter(stream);
                        writer.Write(_options.ReportText.ToString());

                        /*
                        foreach (string line in _options.ReportText.ToString().
                            Split( new string[] {Environment.NewLine},
                                StringSplitOptions.None))
                        {
                            if (line.Length <= 40)
                                writer.WriteLine(line);
                            else
                            {
                                int remaining = line.Length;
                                for (int start = 0; start < line.Length; start += 40)
                                {
                                    if (remaining > 40)
                                        writer.WriteLine(line.Substring(start, 40));
                                    else
                                        writer.WriteLine(line.Substring(start, remaining));

                                    remaining -= 40;
                                }
                            }
                        }
                        */

                        writer.Flush();
                        stream.Position = 0;

                        streamToPrint = new StreamReader(stream);

                        doc.Print();
                    }

                    doc.PrintPage -= doc_PrintPage;
                }
            }
        }

        void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 0;
            int leftMargin = e.MarginBounds.Left;
            int topMargin  = e.MarginBounds.Top;
            string line = null;
            SizeF actual;

            yPos = topMargin;
            while(yPos < e.MarginBounds.Top + e.MarginBounds.Size.Height)
            {
                line = streamToPrint.ReadLine();
                //stringformat is what makes wrapping happen
                StringFormat sf = StringFormat.GenericTypographic;
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                sf.FormatFlags = StringFormatFlags.LineLimit;
                sf.Trimming = StringTrimming.Word;

                if(line == null)
                    break;
                else if (line.Equals(""))
                {
                    //have to have something to easure, even if it is a blank line
                    line = " ";
                }
                actual = e.Graphics.MeasureString(line, printFont, 
                    new SizeF(e.MarginBounds.Size.Width,
                         e.MarginBounds.Size.Height), sf);

                e.Graphics.DrawString(line, printFont, Brushes.Black,
                   new RectangleF(leftMargin, yPos, e.MarginBounds.Size.Width,
                   e.MarginBounds.Size.Height), sf);
                yPos = yPos + actual.Height;
            }
            // If more lines exist, print another page.
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }


        void doc_PrintPage2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height /
               printFont.GetHeight(e.Graphics);
            
            // Print each line of the file. 
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page. 
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }
    }
}
