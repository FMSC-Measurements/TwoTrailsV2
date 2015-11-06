using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.Controls
{
    public partial class WalkInfoCtrl : UserControl
    {
        public delegate void ButtonHideEvent();
        public delegate void ButtonDeleteEvent();
        public delegate void ButtonAddEvent();
        public delegate void EditAccuracyEvent(double acc);

        public event ButtonHideEvent ButtonHide;
        public event ButtonDeleteEvent DeleteWalk;
        public event EditAccuracyEvent EditAccuracy;
        public event ButtonAddEvent AddToWalk;

        private WalkPoint CurrentPoint { get; set; }

        private bool _locked, _setting = false;

        public void Init()
        {
            _locked = true;
        }

        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;

                txtAcc.Enabled = !_locked;
                btnDel.Enabled = !_locked;
                btnSetManAcc.Enabled = !_locked;
                btnAdd.Enabled = !_locked;
            }
        }


        public void SetPoint(WalkPoint point)
        {
            CurrentPoint = point;

            _setting = true;

            if (TtUtils.PointHasValue(CurrentPoint))
            {
                txtAcc.Text = CurrentPoint.ManualAccuracy.ToString();


                lblWalkName.Text = CurrentPoint.GroupName;
            }
            else
            {
                txtAcc.Text = "";
                lblWalkName.Text = "";
            }

            _setting = false;
        }

        private void btnHide_Click2(object sender, EventArgs e)
        {
            if (ButtonHide != null)
                ButtonHide();
        }

        private void btnDel_Click2(object sender, EventArgs e)
        {
            if (DeleteWalk != null)
                DeleteWalk();
        }

        private void btnSetManAcc_Click2(object sender, EventArgs e)
        {
            if (!txtAcc.Text.IsEmpty() && txtAcc.Text.IsDouble())
            {
                EditAccuracy(txtAcc.Text.ToDouble());
            }
            else
            {
                MessageBox.Show("No accuracy value to set.");
                txtAcc.Focus();
            }
        }

        private void txtAcc_TextChanged2(object sender, EventArgs e)
        {
            if (_setting)
                return;

            if (txtAcc.Text.IsDouble())
            {
                CurrentPoint.ManualAccuracy = txtAcc.Text.ToDouble();
            }
            else
                txtAcc.Text = CurrentPoint.ManualAccuracy.ToString();
        }

        private void btnAdd_Click2(object sender, EventArgs e)
        {
            if (AddToWalk != null)
                AddToWalk();
        }

        private void txtAcc_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtAcc);
        }

        private void txtAcc_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }
    }
}
