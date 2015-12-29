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
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class ProjectInfoForm : Form
    {
        private DataAccessLayer _data;
        private bool _dirty = false;

        private void ProjectInfoForm_Load2(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            //Name/ID
            string val = _data.GetProjectID();
            /*
            if (val.IsEmpty())
            {
                val = Values.Settings.ProjectOptions.ProjectName;
                _data.SetProjectID(val);
            }
            */
            textBoxProjName.Text = val;

            //Description
            val = _data.GetProjectDescription();
            /*
            if (val.IsEmpty())
            {
                val = Values.Settings.ProjectOptions.Description;
                _data.SetProjectDescription(val);
            }
            */
            textBoxProjDescription.Text = val;


            //Region
            val = _data.GetProjectRegion();
            /*
            if (val.IsEmpty())
            {
                val = Values.Settings.ProjectOptions.Region.ToString();
                _data.SetProjectRegion(Values.Settings.ProjectOptions.Region);
            }
            */
            textBoxRegion.Text = val;

            //Forest
            val = _data.GetProjectForest();
            /*
            if (val.IsEmpty())
            {
                val = Values.Settings.ProjectOptions.Forest;
                _data.SetProjectForest(val);
            }
            */
            textBoxForest.Text = val;

            //District
            val = _data.GetProjectDistrict();
            /*
            if (val.IsEmpty())
            {
                val = Values.Settings.ProjectOptions.District;
                _data.SetProjectDistrict(val);
            }
            */
            textBoxDistrict.Text = val;

            //Year
            val = _data.GetProjectYear();
            if (val.IsEmpty())
            {
                val = Values.Settings.ProjectOptions.Year;                
                _data.SetProjectYear(val);
            }
            textBoxYear.Text = val;


            chkDropZeros.Checked = _data.GetProjectDropZeros();
        }

        private void buttonOK_Click2(object sender, EventArgs e)
        {
            if (_dirty)
                SaveProjectSettings();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveProjectSettings()
        {
            _data.SetProjectYear(textBoxYear.Text);
            _data.SetProjectID(textBoxProjName.Text);
            _data.SetProjectDescription(textBoxProjDescription.Text);

            /*
            int r;
#if (PocketPC || WindowsCE || Mobile)
            if (TtUtils.IntTryParse(textBoxRegion.Text.Trim(), out r))
#else
            if (Int32.TryParse(textBoxRegion.Text.Trim(), out r))
#endif
            {
                _data.SetProjectRegion(r.ToString());
                Values.Settings.ProjectOptions.Region = r;
            }
            */

            _data.SetProjectRegion(textBoxRegion.Text.Trim());
            Values.Settings.ProjectOptions.Region = textBoxRegion.Text.Trim();

            _data.SetProjectForest(textBoxForest.Text);
            Values.Settings.ProjectOptions.Forest = textBoxForest.Text;

            _data.SetProjectDistrict(textBoxDistrict.Text);
            Values.Settings.ProjectOptions.District = textBoxDistrict.Text;

            _data.SetProjectDropZeroSetting(chkDropZeros.Checked);
            Values.Settings.ProjectOptions.DropZero = chkDropZeros.Checked;

            Values.Settings.WriteProjectSettings();

#if !(PocketPC || WindowsCE || Mobile)
            Values.UpdateStatusText("Project Info Updated");
#endif
        }
        
        #region Text Box Events
        #region TextChanged Events
        private void textBoxProjName_TextChanged2(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void textBoxProjDescription_TextChanged2(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void textBoxRegion_TextChanged2(object sender, EventArgs e)
        {
            if (!textBoxRegion.Text.IsEmpty() && !textBoxRegion.Text.IsInteger())
                MessageBox.Show("Region must be numeric.");
            else if (!textBoxRegion.Text.IsEmpty())
                _dirty = true;
        }

        private void textBoxForest_TextChanged2(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void textBoxDistrict_TextChanged2(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void textBoxYear_TextChanged2(object sender, EventArgs e)
        {
            _dirty = true;
        }
        #endregion

        private void chkDropZeros_CheckedChanged2(object sender, EventArgs e)
        {
            _dirty = true;
            Values.Settings.ProjectOptions.DropZero = chkDropZeros.Checked;
        }

        private void chkRound_CheckedChanged2(object sender, EventArgs e)
        {
            _dirty = true;
            Values.Settings.ProjectOptions.Round = chkRound.Checked;
        }

        #region GotFocus Events
        private void textBoxProjName_GotFocus2(object sender, EventArgs e)
        {
            //Kb.ShowRegular(this, );
            Kb.Show(this, textBoxProjName);
        }

        private void textBoxProjDescription_GotFocus2(object sender, EventArgs e)
        {
            //Kb.ShowRegular(this, );
            Kb.Show(this, textBoxProjDescription);
        }

        private void textBoxRegion_GotFocus2(object sender, EventArgs e)
        {
            //Kb.ShowRegular(this, );
            Kb.Show(this, textBoxRegion);
        }

        private void textBoxForest_GotFocus2(object sender, EventArgs e)
        {
            //Kb.ShowRegular(this, );
            Kb.Show(this, textBoxForest);
        }

        private void textBoxDistrict_GotFocus2(object sender, EventArgs e)
        {
            //Kb.ShowRegular(this, );
            Kb.Show(this, textBoxDistrict);
        }

        private void textBoxYear_GotFocus2(object sender, EventArgs e)
        {
            //Kb.ShowNumeric(this, );
            Kb.Show(this, textBoxYear);
        }
        #endregion

        #region Lost Focus
        private void textBoxProjName_LostFocus2(object sender, EventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }

        private void textBoxProjDescription_LostFocus2(object sender, EventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }

        private void textBoxRegion_LostFocus2(object sender, EventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }

        private void textBoxForest_LostFocus2(object sender, EventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }

        private void textBoxDistrict_LostFocus2(object sender, EventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }

        private void textBoxYear_LostFocus2(object sender, EventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }

        private void ProjectInfoForm_Closing2(object sender, CancelEventArgs e)
        {
            //Kb.Hide(this);
            Kb.Hide(this);
        }
        #endregion

        private void buttonCancel_Click2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}