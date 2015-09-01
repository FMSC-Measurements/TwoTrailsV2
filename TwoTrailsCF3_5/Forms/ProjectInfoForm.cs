using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
//using Engine.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class ProjectInfoForm : Form
    {
        public ProjectInfoForm(DataAccess.DataAccessLayer data)
        {
            _data = data;
            InitializeComponent();
        }

        private void ProjectInfoForm_Load(object sender, EventArgs e)
        {
            ProjectInfoForm_Load2(sender, e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonOK_Click2(sender, e);
        }

        #region Text Box Events
        #region TextChanged Events
        private void textBoxProjName_TextChanged(object sender, EventArgs e)
        {
            textBoxProjName_TextChanged2(sender, e);
        }

        private void textBoxProjDescription_TextChanged(object sender, EventArgs e)
        {
            textBoxProjDescription_TextChanged2(sender, e);
        }

        private void textBoxRegion_TextChanged(object sender, EventArgs e)
        {
            textBoxRegion_TextChanged2(sender, e);
        }

        private void textBoxForest_TextChanged(object sender, EventArgs e)
        {
            textBoxForest_TextChanged2(sender, e);
        }

        private void textBoxDistrict_TextChanged(object sender, EventArgs e)
        {
            textBoxDistrict_TextChanged2(sender, e);
        }

        private void textBoxYear_TextChanged(object sender, EventArgs e)
        {
            textBoxYear_TextChanged2(sender, e);
        }
        #endregion

        private void chkDropZero_CheckStateChanged(object sender, EventArgs e)
        {
            chkDropZeros_CheckedChanged2(sender, e);
        }

        #region GotFocus Events
        private void textBoxProjName_GotFocus(object sender, EventArgs e)
        {
            textBoxProjName_GotFocus2(sender, e);
        }

        private void textBoxProjDescription_GotFocus(object sender, EventArgs e)
        {
            textBoxProjDescription_GotFocus2(sender, e);
        }

        private void textBoxRegion_GotFocus(object sender, EventArgs e)
        {
            textBoxRegion_GotFocus2(sender, e);
        }

        private void textBoxForest_GotFocus(object sender, EventArgs e)
        {
            textBoxForest_GotFocus2(sender, e);
        }

        private void textBoxDistrict_GotFocus(object sender, EventArgs e)
        {
            textBoxDistrict_GotFocus2(sender, e);
        }

        private void textBoxYear_GotFocus(object sender, EventArgs e)
        {
            textBoxYear_GotFocus2(sender, e);
        }
        #endregion

        #region Lost Focus
        private void textBoxProjName_LostFocus(object sender, EventArgs e)
        {
            textBoxProjName_LostFocus2(sender, e);
        }

        private void textBoxProjDescription_LostFocus(object sender, EventArgs e)
        {
            textBoxProjDescription_LostFocus2(sender, e);
        }

        private void textBoxRegion_LostFocus(object sender, EventArgs e)
        {
            textBoxRegion_LostFocus2(sender, e);
        }

        private void textBoxForest_LostFocus(object sender, EventArgs e)
        {
            textBoxForest_LostFocus2(sender, e);
        }

        private void textBoxDistrict_LostFocus(object sender, EventArgs e)
        {
            textBoxDistrict_LostFocus2(sender, e);
        }

        private void textBoxYear_LostFocus(object sender, EventArgs e)
        {
            textBoxYear_LostFocus2(sender, e);
        }

        private void ProjectInfoForm_Closing(object sender, CancelEventArgs e)
        {
            ProjectInfoForm_Closing2(sender, e);
        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel_Click2(sender, e);
        }
        #endregion

        private void chkRound_CheckStateChanged(object sender, EventArgs e)
        {
            chkRound_CheckedChanged2(sender, e);
        }
    }
}