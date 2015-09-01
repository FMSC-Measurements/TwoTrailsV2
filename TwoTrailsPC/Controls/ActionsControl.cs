using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;

namespace TwoTrails.Controls
{
    public partial class ActionsControl : UserControl
    {
        #region delegates
        /// <summary>
        /// Cancel is clicked
        /// </summary>
        public delegate void CancelClicked(object sender, EventArgs e);
        public event CancelClicked Cancel_OnClick;

        /// <summary>
        /// New is clicked
        /// </summary>
        public delegate void NewClicked(object sender, EventArgs e);
        public event NewClicked New_OnClick;

        /// <summary>
        /// Delete is clicked
        /// </summary>
        public delegate void DeleteClicked(object sender, EventArgs e);
        public event DeleteClicked Delete_OnClick;

        /// <summary>
        /// Misc is clicked
        /// </summary>
        public delegate void MiscClicked(object sender, EventArgs e);
        public event MiscClicked Misc_OnClick;

        /// <summary>
        /// OK is clicked
        /// </summary>
        public delegate void OkClicked(object sender, EventArgs e);
        public event OkClicked Ok_OnClick;


        #endregion

        public ActionsControl()
        {
            InitializeComponent();
        }
        #region Button Click events
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            #region Trigger Event
            if (Cancel_OnClick != null)
                Cancel_OnClick(this, new EventArgs());
            #endregion
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            #region Trigger Event
            if (New_OnClick != null)
                New_OnClick(this, new EventArgs());
            #endregion
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            #region Trigger Event
            if (Delete_OnClick != null)
                Delete_OnClick(this, new EventArgs());
            #endregion
        }

        private void buttonMisc_Click(object sender, EventArgs e)
        {
            #region Trigger Event
            if (Misc_OnClick != null)
                Misc_OnClick(this, new EventArgs());
            #endregion
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            #region Trigger Event
            if (Ok_OnClick != null)
                Ok_OnClick(this, new EventArgs());
            #endregion
        }
        #endregion
        #region Button Properties
        #region Misc Button
        public bool MiscButtonEnabled
        {
            get { return buttonMisc.Enabled; }
            set { buttonMisc.Enabled = value; }
        }

        /// <summary>
        /// Get/Set the text on the miscellaneous button
        /// </summary>
        public string MiscButtonText
        {
            get { return buttonMisc.Text; }
            set { buttonMisc.Text = value; }
        }
        #endregion

        #region Delete Button
        public bool DeleteEnabled
        {
            get { return buttonDelete.Enabled; }
            set { buttonDelete.Enabled = value; }
        }
        #endregion


        #region New Button
        public bool NewEnabled
        {
            get { return buttonNew.Enabled; }
            set { buttonNew.Enabled = value; }
        }
        #endregion


        #region OK Button
        public bool OkEnabled
        {
            get { return buttonOK.Enabled; }
            set { buttonOK.Enabled = value; }
        }
        #endregion
        #endregion
    }
}
