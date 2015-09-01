using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public partial class DeleteMessageWCheckForm : Form
    {
        public MessageWCheckResult Result { get; private set; }

        public DeleteMessageWCheckForm(string text)
        {
            init(text, null, null, false);
        }

        public DeleteMessageWCheckForm(string text, string caption)
        {
            init(text, caption, null, false);
        }

        public DeleteMessageWCheckForm(string text, string caption, string checkText)
        {
            init(text, caption, checkText, false);
        }

        public DeleteMessageWCheckForm(string text, string caption, string checkText, bool isChecked)
        {
            init(text, caption, checkText, isChecked);
        }

        private void init(string text, string caption, string checkText, bool isChecked)
        {
            InitializeComponent();

            this.Result = MessageWCheckResult.None;

            lblLabel.Text = text;
            this.Text = caption;
            chkCheck.Text = checkText;
            chkCheck.Checked = isChecked;

            this.Icon = Properties.Resources.Map;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (chkCheck.Checked)
                this.Result = MessageWCheckResult.YesChecked;
            else
                this.Result = MessageWCheckResult.Yes;

            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (chkCheck.Checked)
                this.Result = MessageWCheckResult.NoChecked;
            else
                this.Result = MessageWCheckResult.No;

            this.Close();
        }
    }

    public static class DeleteMessageWCheck
    {
        public static MessageWCheckResult Show(string text)
        {
            return init(text, null, null, false);
        }

        public static MessageWCheckResult Show(string text, string caption)
        {
            return init(text, caption, null, false);
        }

        public static MessageWCheckResult Show(string text, string caption, string checkText)
        {
            return init(text, caption, checkText, false);
        }

        public static MessageWCheckResult Show(string text, string caption, string checkText, bool isChecked)
        {
            return init(text, caption, checkText, isChecked);
        }

        private static MessageWCheckResult init(string text, string caption, string checkText, bool isChecked)
        {
            MessageWCheckResult result;

            using (DeleteMessageWCheckForm form = new DeleteMessageWCheckForm(text, caption, checkText, isChecked))
            {
                form.ShowDialog();
                result = form.Result;
            }

            return result;
        }
    }

    public enum MessageWCheckResult
    {
        Yes,
        YesChecked,
        No,
        NoChecked,
        None
    }
}
