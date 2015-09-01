using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using System.Drawing.Imaging;

namespace TwoTrails.Forms
{
    public partial class IndexNavControl: UserControl
    {
        public IndexNavControl()
        {
            _CNs = new List<string>();
            _index = -1;
            InitializeComponent();
            UpdateLabel();
        }

        #region members
        private int _index;
        private List<string> _CNs;

        #endregion

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

        #endregion


        #region Navigation Buttons
        private void buttonFirst_Click(object sender, EventArgs e)
        {
            if (_index <= 0)
                TriggerAlreadyAtBeginning();
            else if(_CNs.Count > 0)
            {
                _index = 0;
                string CN = _CNs[_index];
                TriggerIndexChange(CN);
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            if (_index == _CNs.Count - 1)
                TriggerAlreadyAtEnd();
            else
            {
                _index = _CNs.Count - 1;
                string CN = _CNs[_index];
                TriggerIndexChange(CN);
            }       
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_index == _CNs.Count - 1)
                TriggerAlreadyAtEnd();
            else
            {
                _index++;
                string CN = _CNs[_index];
                TriggerIndexChange(CN);
            } 
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (_index == 0)
                TriggerAlreadyAtBeginning();            
            else if (_index > 0)
            {
                _index--;
                string CN = _CNs[_index];
                TriggerIndexChange(CN);
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
            {
                labelPointInfo.Text = "0 of 0";
            }
            else
            {
                sb.AppendFormat("{0} of {1}",
                    _index + 1, _CNs.Count);
                labelPointInfo.Text = sb.ToString();
            }
        }
        #endregion

        #region Properties

        public List<string> CNs
        {
            set { _CNs = value; }
        }

        /// <summary>
        /// Current point index
        /// </summary>
        public int SelectedIndex
        {
            get { return _index; }
            set
            {
                if (_CNs == null)
                    _CNs = new List<string>();
                if ((value < 0 && _CNs.Count > 0) || value > _CNs.Count - 1)
                    throw new IndexOutOfRangeException("LS IndexNavControl:SelectedIndex out of range.");
                _index = value;
                UpdateLabel();
            }
        }

        public bool NavigationEnabled
        {
            get { return btnBack.Enabled; }
            set
            {
                btnBack.Enabled = value;
                btnFirst.Enabled = value;
                btnNext.Enabled = value;
                btnLast.Enabled = value;
            }
        }
        #endregion

        #region Add/Remove CNs
        internal void AddAfter(string cnToAdd)
        {
            _CNs.Insert(_index + 1, cnToAdd);
            _index++;
            TriggerIndexChange(cnToAdd);
        }

        internal void AddBefore(string cnToAdd)
        {
            _CNs.Insert(_index, cnToAdd);
            TriggerIndexChange(cnToAdd);
        }

        internal void AddAtEnd(string cnToAdd)
        {
            _CNs.Add(cnToAdd);
            _index = _CNs.Count - 1;
            TriggerIndexChange(cnToAdd);
        }

        internal void AddAtBeginning(string p)
        {
            _CNs.Insert(0, p);
            _index = 0;
            TriggerIndexChange(p);
        }

        internal void Remove(string cnToRemove)
        {
            int index = _CNs.IndexOf(cnToRemove);
                //If deleting a point before, back up the index

            _CNs.Remove(cnToRemove);

            if (index < _index && index != -1)
            {
                _index--;
                TriggerIndexChange(_CNs[index]);
            }
            else if (index == _CNs.Count)
            {
                _index--;

                if (_CNs.Count > 0)
                {
                    index--;
                    TriggerIndexChange(_CNs[index]);
                }

            }

            UpdateLabel();
        }
        #endregion
    }

    public class PointNavEventArgs : EventArgs
    {        
        public string NextPointCN { get; set; }
    }


}
