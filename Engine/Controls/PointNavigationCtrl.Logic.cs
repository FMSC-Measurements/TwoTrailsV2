using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Controls
{
    public partial class PointNavigationCtrl : UserControl
    {
        #region Delegates
        /// <summary>
        /// Point index is changed
        /// </summary>
        public delegate void IndexChangedEvent(object sender, PointNavEventArgs e);
        public event IndexChangedEvent IndexChanged;

        /// <summary>
        /// Triggered when a backward arrow is clicked and already at beginning of the point list
        /// </summary>
        public delegate void AlreadyAtBeginningEvent(object sender);
        public event AlreadyAtBeginningEvent AlreadyAtBeginning;

        /// <summary>
        /// Triggered when a forward arrow is clicked and already at end of the point list       
        /// </summary>
        public delegate void AlreadyAtEndEvent(object sender);
        public event AlreadyAtEndEvent AlreadyAtEnd;

        public delegate void JumpPointEvent(object sender);
        public event JumpPointEvent JumpPoint;

        #endregion

        private int CurrentIndex;
        private List<string> _CNs;

        public void Init()
        {
            CurrentIndex = -1;
            _CNs = new List<string>();
        }

        public void UpdatePointList(List<string> newPoints, int newIndex)
        {
            _CNs = newPoints;
            CurrentIndex = newIndex;
            UpdateLabel();
        }

        public void UpdateIndex(int newIndex)
        {
            CurrentIndex = newIndex;
            UpdateLabel();
        }

        #region Navigation Buttons
        private void btnFirst_Click2(object sender, EventArgs e)
        {
            if (CurrentIndex <= 0)
                TriggerAlreadyAtBeginning();
            else
            {
                CurrentIndex = 0;
                TriggerIndexChange(_CNs[CurrentIndex]);
            }
        }

        private void btnLast_Click2(object sender, EventArgs e)
        {
            if (CurrentIndex >= _CNs.Count - 1)
                TriggerAlreadyAtEnd();
            else
            {
                CurrentIndex = _CNs.Count -1;
                TriggerIndexChange(_CNs[CurrentIndex]);
            }
        }

        private void btnNext_Click2(object sender, EventArgs e)
        {
            if (CurrentIndex >= _CNs.Count - 1)
                TriggerAlreadyAtEnd();
            else
            {
                CurrentIndex++;
                TriggerIndexChange(_CNs[CurrentIndex]);
            }
        }

        private void btnBack_Click2(object sender, EventArgs e)
        {
            if (CurrentIndex <= 0)
                TriggerAlreadyAtBeginning();
            else if (CurrentIndex > 0)
            {
                CurrentIndex--;
                TriggerIndexChange(_CNs[CurrentIndex]);
            }
        }

        private void btnLblPos_Click2(object sender, EventArgs e)
        {
            if (JumpPoint != null)
            {
                JumpPoint(this);
            }
        }

        private void TriggerIndexChange(string CN)
        {
            if (IndexChanged != null)
            {
                PointNavEventArgs args = new PointNavEventArgs();
                args.NextPointCN = CN;
                IndexChanged(this, args);
            }
            UpdateLabel();
        }

        private void TriggerAlreadyAtBeginning()
        {
            if (AlreadyAtBeginning != null)
            {
                AlreadyAtBeginning(this);
            }
        }

        private void TriggerAlreadyAtEnd()
        {
            if (AlreadyAtEnd != null)
            {
                AlreadyAtEnd(this);
            }
        }

        private void UpdateLabel()
        {
            StringBuilder sb = new StringBuilder();
            if (_CNs == null)
                return;

            if (CurrentIndex > -1)
            {
                sb.AppendFormat("{0}/{1}",
                    CurrentIndex + 1, _CNs.Count);
            }
            else
            {
                sb.Append("");
            }
            btnLblPos.Text = sb.ToString();
        }
        #endregion


        #region Enabled Buttons

        public bool ForwardButtons
        {
            get
            {
                return btnNext.Enabled;
            }
            set
            {
                btnNext.Enabled = value;
                btnLast.Enabled = value;

                if (!value && !BackwardButtons)
                    btnLblPos.Enabled = false;
                else
                    btnLblPos.Enabled = true;
            }
        }

        public bool BackwardButtons
        {
            get
            {
                return btnFirst.Enabled;
            }
            set
            {
                btnFirst.Enabled = value;
                btnBack.Enabled = value;

                if (!value && !ForwardButtons)
                    btnLblPos.Enabled = false;
                else
                    btnLblPos.Enabled = true;
            }
        }

        #endregion

        public class PointNavEventArgs : EventArgs
        {
            public string NextPointCN { get; set; }
        }
    }
}
