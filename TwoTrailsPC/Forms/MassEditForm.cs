using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessLogic;
using TwoTrails.BusinessObjects;
using TwoTrails.Utilities;
using TwoTrails.Engine;

namespace TwoTrails.Forms
{
    public partial class MassEditForm : Form
    {
        List<Color> _Colors = new List<Color>() { Color.AliceBlue, Color.SeaShell, Color.Lavender, Color.Azure,
            Color.OldLace, Color.MintCream, Color.LavenderBlush, Color.Snow, Color.Gainsboro, Color.PaleGreen,
            Color.PaleTurquoise, Color.Wheat};
        int numColors = 0;

        bool edited = false, ignoreControls = true, qSelect = false, _closing = false;

        string qSelectCN;
        bool qStartSel = false, deleteWOAsk = false, resetWOAsk = false, init = false;

        int beforeShowSplit;

        Color multiColor = Color.FloralWhite;
        Color disCtrl = SystemColors.Control;

        DataAccessLayer DAL;

        Dictionary<string, TtPoint> _OrigPoints, _EditPoints;
        List<TtPoint> _SelectedPoints;
        Dictionary<string, TtPolygon> _Polygons;
        Dictionary<string, TtGroup> _Groups;
        Dictionary<string, TtMetaData> _MetaData;

        Dictionary<string, Color> _PolygonColors;

        BindingList<TtPoint> _DisplayPoints;
        BindingSource _DisplaySource;


        TtPoint _CurrentPoint;
        TtPoint CurrentPoint
        {
            get { return _CurrentPoint; }
            set
            {
                _CurrentPoint = value;
            }
        }

        bool advEdit = Values.Settings.DeviceOptions.FormMassEditAdvEdit;
        bool AdvEdit
        {
            get { return advEdit; }
            set
            {
                advEdit = value;
                Values.Settings.DeviceOptions.FormMassEditAdvEdit = value;
                txtIndex.Enabled = advEdit;
            }
        }

        bool advInfo = false;
        bool AdvInfo
        {
            get { return advInfo; }
            set
            {
                advInfo = value;
                pnlAdvInfo.Visible = advInfo;
            }
        }

        string currCellValue;
        int currCellIndex;

        TtPointUndoRedoManager urManager;

        DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();


        public MassEditForm(DataAccessLayer d)
        {
            DAL = d;
            InitializeComponent();
            splitContainer.Panel2MinSize = 190;
            this.Height = 720;
        }

        private void MassEditForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;

            tsmiAdvEdit.Checked = Values.Settings.DeviceOptions.FormMassEditAdvEdit;
            
            urManager = new TtPointUndoRedoManager();
            urManager.UndoRedoUpdate += new UndoRedoUpdateEvent(urManager_UndoRedoUpdate);

            tsslStatus.Text = "Loading Data";
            _OrigPoints = DAL.GetPoints().ToDictionary(p => p.CN, p => p);
            _EditPoints = new Dictionary<string, TtPoint>();
            _Polygons = DAL.GetPolygons().ToDictionary(p => p.CN, p => p);
            _Groups = DAL.GetGroups().ToDictionary(d => d.CN, d => d);
            _MetaData = DAL.GetMetaData().ToDictionary(m => m.CN, m => m);

            _PolygonColors = new Dictionary<string, Color>();
            foreach(string s in _Polygons.Keys)
            {
                _PolygonColors.Add(s, _Colors[numColors % _Colors.Count]);
                numColors++;
            }

            cboPoly.DisplayMember = "Name";
            cboPoly.ValueMember = "CN";
            cboPoly.DataSource = _Polygons.Values.ToList();

            cboMeta.DisplayMember = "Name";
            cboMeta.ValueMember = "CN";
            cboMeta.DataSource = _MetaData.Values.ToList();

            cboGroup.Sorted = true;
            cboGroup.DisplayMember = "Name";
            cboGroup.ValueMember = "CN";
            cboGroup.DataSource = _Groups.Values.ToList();

            cboOp.DisplayMember = "Dispaly";
            cboOp.ValueMember = "Value";
            cboOp.DataSource = new List<OpType>((OpType[])Enum.GetValues(typeof(OpType)));
            cboOp.SelectedIndex = 2;

            tsslStatus.Text = "Data Loaded";

            pnlSubFilter.Height = 0;

            InitFilters();

#if DEBUG
            tsmiAdvEdit.Checked = true;
            AdvEdit = true;
#endif

            tsmiAdvInfo.Checked = true;
            AdvInfo = true;

            UpdateSettings();

            ignoreControls = false;

            SetupDataGridView();

            if (RefreshData())
            {
                ColorRows();
                init = true;
            }
        }

        void urManager_UndoRedoUpdate()
        {
            if (urManager.CanRedo)
            {
                ctsmiRedo.Enabled = true;
                tsmiRedo.Enabled = true;
            }
            else
            {
                ctsmiRedo.Enabled = false;
                tsmiRedo.Enabled = false;
            }

            if (urManager.CanUndo)
            {
                ctsmiUndo.Enabled = true;
                tsmiUndo.Enabled = true;
            }
            else
            {
                ctsmiUndo.Enabled = false;
                tsmiUndo.Enabled = false;
            }
        }

        private bool RefreshData()
        {
            _EditPoints = new Dictionary<string, TtPoint>();

            try
            {
                foreach (KeyValuePair<string, TtPoint> kp in _OrigPoints)
                {
                    _EditPoints.Add(kp.Key, TtUtils.GetConversion(kp.Value, _MetaData[kp.Value.MetaDefCN]));
                }

                _DisplayPoints = new BindingList<TtPoint>(FilterPoints(_EditPoints.Values.ToList()));
                _DisplaySource = new BindingSource(_DisplayPoints, null);

                dgvPoints.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);

                dgvPoints.Columns[CMT].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvPoints.DataSource = _DisplaySource;

                if (AdvInfo)
                    UpdateAdvInfo();

                //dgvPoints.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvPoints.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvPoints.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (_DisplayPoints.Count > 0)
                {
                    CurrentPoint = _DisplayPoints[0];

                    urManager.EditPoint(CurrentPoint, _EditPoints);
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MassEditForm:RefreshData", ex.StackTrace);
                pnlInner.Enabled = false;
                tabCtrl.Enabled = false;

                tsmiPointsHaveErrors.Visible = true;
                tsslStatus.Text = "Points have Errors";

                return false;
            }

            return true;
        }

        private void SetupDataGridView()
        {
            dgvPoints.AutoGenerateColumns = false;
            dgvPoints.RowHeadersVisible = false;
            dgvPoints.AllowUserToResizeRows = false;

            DataGridViewColumn dgvc;

            //PID
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "PID";
            dgvc.Name = PID;
            dgvc.HeaderText = PID;
            dgvPoints.Columns.Add(dgvc);

            //Poly Name
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "PolyName";
            dgvc.Name = POLY;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //OpType
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "op";
            dgvc.Name = OP;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //Index
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "Index";
            dgvc.Name = INDX;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //OnBnd
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "OnBnd";
            dgvc.Name = ONBND;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //AdjX
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "AdjX";
            dgvc.Name = aX;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //AdjY
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "AdjY";
            dgvc.Name = aY;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //AdjZ
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "AdjZ";
            dgvc.Name = aZ;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //GroupName
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "GroupName";
            dgvc.Name = GN;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

            //Comment
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.DefaultCellStyle = defaultCellStyle;
            dgvc.DataPropertyName = "Comment";
            dgvc.Name = CMT;
            dgvc.ReadOnly = true;
            dgvPoints.Columns.Add(dgvc);

        }

        private void MassEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;

            if (edited)
            {
                DialogResult dr = MessageBox.Show("Data has been edited. Do you want to save before exiting?", "Save Points",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);

                if (dr == DialogResult.Yes || dr == DialogResult.OK)
                {
                    if (!Save())
                    {
                        MessageBox.Show("Save Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }

            _closing = false;
        }


        #region Filter

        private bool UseExtraFilters { get; set; }

        private List<TtPoint> FilterPoints(IEnumerable<TtPoint> points)
        {
            List<TtPoint> newPoints = new List<TtPoint>();
            try
            {
                bool exit = true;
                foreach (int item in chkLstPolyFilter.CheckedIndices)
                {
                    if (item != 0)
                    {
                        exit = false;
                        break;
                    }
                }

                if (exit)
                {
                    return newPoints;
                }

                GpsPoint tmpGps;
                SideShotPoint tmpSp;
                double dTmp;

                string searchDesc = null;

                if (!txtSearchDesc.Text.Trim().IsEmpty())
                    searchDesc = txtSearchDesc.Text.ToLower().Trim();

                #region Regular Filter Setup
                bool allOps = (chkLstOpFilter.CheckedItems.Count == 0 || chkLstOpFilter.CheckedIndices[0] == 0 ||
                    (chkLstOpFilter.CheckedIndices.Count == chkLstOpFilter.Items.Count - 1 && chkLstOpFilter.CheckedIndices[0] != 0));

                bool allMeta = (chkLstMetaFilter.CheckedItems.Count == 0 || chkLstMetaFilter.CheckedIndices[0] == 0 ||
                    (chkLstMetaFilter.CheckedIndices.Count == chkLstMetaFilter.Items.Count - 1 && chkLstMetaFilter.CheckedIndices[0] != 0));

                bool allGroups = (chkLstGroupFilter.CheckedItems.Count == 0 || chkLstGroupFilter.CheckedIndices[0] == 0 ||
                    (chkLstGroupFilter.CheckedIndices.Count == chkLstGroupFilter.Items.Count - 1 && chkLstGroupFilter.CheckedIndices[0] != 0));

                _DisplayPoints = new BindingList<TtPoint>();

                List<string> polyCNs = new List<string>();
                List<OpType> Ops = new List<OpType>();
                List<string> groupCNs = new List<string>();
                List<string> metaCNs = new List<string>();

                for (int i = 0; i < chkLstPolyFilter.CheckedItems.Count; i++)
                {
                    if (chkLstPolyFilter.CheckedItems[i].GetType() == typeof(TtPolygon))
                    {
                        polyCNs.Add(((TtPolygon)chkLstPolyFilter.CheckedItems[i]).CN);
                    }
                }

                if (!allOps)
                {
                    for (int i = 0; i < chkLstOpFilter.CheckedItems.Count; i++)
                    {
                        Ops.Add((OpType)(chkLstOpFilter.CheckedItems[i]));
                    }
                }

                if (!allMeta)
                {
                    for (int i = 0; i < chkLstMetaFilter.CheckedItems.Count; i++)
                    {
                        metaCNs.Add(((TtMetaData)chkLstMetaFilter.CheckedItems[i]).CN);
                    }
                }

                if (!allGroups)
                {
                    for (int i = 0; i < chkLstGroupFilter.CheckedItems.Count; i++)
                    {
                        groupCNs.Add(((TtGroup)chkLstGroupFilter.CheckedItems[i]).CN);
                    }
                }
                #endregion

                TbStatus statusPid, statusPid2, statusX, statusX2, statusY, statusY2, statusZ, statusZ2,
                    statusManAcc, statusManAcc2, statusRMSEr, statusRMSEr2, statusFA, statusFA2,
                    statusBA, statusBA2, statusSD, statusSD2, statusSA, statusSA2;

                statusPid = statusPid2 = statusX = statusX2 = statusY = statusY2 = statusZ = statusZ2 =
                    statusManAcc = statusManAcc2 = statusRMSEr = statusRMSEr2 = statusFA = statusFA2 =
                    statusBA = statusBA2 = statusSD = statusSD2 = statusSA = statusSA2 = TbStatus.Bad;

                statusPid = TestTextbox(txtPID1, "PID From", true);
                statusPid2 = TestTextbox(txtPID2, "PID To", true);

                int pid1, pid2;
                double x, x2, y, y2, z, z2, manAcc, manAcc2, rmser, rmser2, fa, fa2, ba, ba2, sd, sd2,
                    sa, sa2;

                pid1 = pid2 = 0;
                x = x2 = y = y2 = z = z2 = manAcc = manAcc2 = rmser = rmser2 =
                    fa = fa2 = ba = ba2 = sd = sd2 = sa = sa2 = 0;

                #region Proccess filter values
                #region PID
                if (statusPid == TbStatus.Bad || statusPid2 == TbStatus.Bad)
                    return null;

                if (statusPid == TbStatus.OK)
                    pid1 = txtPID1.Text.ToInteger();

                if (statusPid2 == TbStatus.OK)
                    pid2 = txtPID2.Text.ToInteger();
                #endregion

                if (UseExtraFilters)
                {
                    if (chkUseGpsFilter.Checked)
                    {
                        #region X
                        statusX = TestTextbox(txtX1, "X From", true);
                        statusX2 = TestTextbox(txtX2, "X To", true);

                        if (statusX == TbStatus.Bad || statusX2 == TbStatus.Bad)
                            return null;

                        if (statusX == TbStatus.OK)
                            x = txtX1.Text.ToDouble();

                        if (statusX2 == TbStatus.OK)
                            x2 = txtX2.Text.ToDouble();
                        #endregion

                        #region Y
                        statusY = TestTextbox(txtY1, "Y From", true);
                        statusY2 = TestTextbox(txtY2, "Y To", true);

                        if (statusY == TbStatus.Bad || statusY2 == TbStatus.Bad)
                            return null;

                        if (statusY == TbStatus.OK)
                            y = txtY1.Text.ToDouble();

                        if (statusY2 == TbStatus.OK)
                            y2 = txtY2.Text.ToDouble();
                        #endregion

                        #region Z
                        statusZ = TestTextbox(txtZ1, "Z From", true);
                        statusZ2 = TestTextbox(txtZ2, "Z To", true);

                        if (statusZ == TbStatus.Bad || statusZ2 == TbStatus.Bad)
                            return null;

                        if (statusZ == TbStatus.OK)
                            z = txtZ1.Text.ToDouble();

                        if (statusY2 == TbStatus.OK)
                            z2 = txtZ2.Text.ToDouble();
                        #endregion

                        #region ManAcc
                        statusManAcc = TestTextbox(txtManAcc1, "ManAcc From", true);
                        statusManAcc2 = TestTextbox(txtManAcc2, "ManAcc To", true);

                        if (statusManAcc == TbStatus.Bad || statusManAcc2 == TbStatus.Bad)
                            return null;

                        if (statusManAcc == TbStatus.OK)
                            manAcc = txtManAcc1.Text.ToDouble();

                        if (statusManAcc2 == TbStatus.OK)
                            manAcc2 = txtManAcc2.Text.ToDouble();
                        #endregion

                        #region RMSEr
                        statusRMSEr = TestTextbox(txtR1, "RMSEr From", true);
                        statusRMSEr2 = TestTextbox(txtR2, "RMSEr To", true);

                        if (statusRMSEr == TbStatus.Bad || statusRMSEr2 == TbStatus.Bad)
                            return null;

                        if (statusRMSEr == TbStatus.OK)
                            rmser = txtR1.Text.ToDouble();

                        if (statusRMSEr2 == TbStatus.OK)
                            rmser2 = txtR2.Text.ToDouble();

                        #endregion
                    }

                    if (chkUseTarvFilter.Checked)
                    {
                        #region FA
                        statusFA = TestTextbox(txtFA1, "Forward Azimuth From", true);
                        statusFA2 = TestTextbox(txtFA2, "Forward Azimuth To", true);

                        if (statusFA == TbStatus.Bad || statusFA2 == TbStatus.Bad)
                            return null;

                        if (statusFA == TbStatus.OK)
                            fa = txtFA1.Text.ToDouble();

                        if (statusFA2 == TbStatus.OK)
                            fa2 = txtFA2.Text.ToDouble();
                        #endregion

                        #region BA
                        statusBA = TestTextbox(txtBA1, "Backward Azimuth From", true);
                        statusBA2 = TestTextbox(txtBA2, "Backward Azimuth To", true);

                        if (statusBA == TbStatus.Bad || statusBA2 == TbStatus.Bad)
                            return null;

                        if (statusBA == TbStatus.OK)
                            ba = txtBA1.Text.ToDouble();

                        if (statusBA2 == TbStatus.OK)
                            ba2 = txtBA2.Text.ToDouble();
                        #endregion

                        #region SD
                        statusSD = TestTextbox(txtSD1, "Slope Distance From", true);
                        statusSD2 = TestTextbox(txtSD2, "Slope Distance To", true);

                        if (statusSD == TbStatus.Bad || statusSD2 == TbStatus.Bad)
                            return null;

                        if (statusSD == TbStatus.OK)
                            sd = txtSD1.Text.ToDouble();

                        if (statusSD2 == TbStatus.OK)
                            sd2 = txtSD2.Text.ToDouble();
                        #endregion

                        #region SA
                        statusSA = TestTextbox(txtSA1, "Slope Angle From", true);
                        statusSA2 = TestTextbox(txtSA2, "Slope Angle To", true);

                        if (statusSA == TbStatus.Bad || statusSA2 == TbStatus.Bad)
                            return null;

                        if (statusSA == TbStatus.OK)
                            sa = txtSA1.Text.ToDouble();

                        if (statusSA2 == TbStatus.OK)
                            sa2 = txtSA2.Text.ToDouble();
                        #endregion
                    }
                }
                #endregion

                foreach (TtPoint point in points)
                {
                    #region Regular Filters
                    if (!polyCNs.Contains(point.PolyCN))
                    {
                        continue;
                    }

                    if (!allOps)
                    {
                        if (!Ops.Contains(point.op))
                            continue;
                    }

                    if (!allMeta)
                    {
                        if (!metaCNs.Contains(point.MetaDefCN))
                            continue;
                    }

                    if (!allGroups)
                    {
                        if (point.GroupCN == null || !groupCNs.Contains(point.GroupCN))
                            continue;

                    }

                    if (statusPid == TbStatus.OK)
                    {
                        if (pid1 > point.PID)
                            continue;
                    }

                    if (statusPid2 == TbStatus.OK)
                    {
                        if (pid2 < point.PID)
                            continue;
                    }

                    if (searchDesc != null)
                    {
                        if (point.Comment.IndexOf(searchDesc, StringComparison.InvariantCultureIgnoreCase) < 0)
                            continue;
                    }

                    #endregion

                    if (UseExtraFilters)
                    {
                        #region Gps / Coords
                        if (chkUseGpsFilter.Checked)
                        {
                            if (chkOnBndFilter.CheckState != CheckState.Indeterminate)
                            {
                                if (point.OnBnd != chkOnBndFilter.Checked)
                                    continue;
                            }

                            if (radGps.Checked)
                            {
                                if (!point.IsGpsType())
                                    continue;
                                else
                                    tmpGps = (GpsPoint)point;

                                #region X
                                if (statusX == TbStatus.OK)
                                {
                                    if (x > tmpGps.UnAdjX)
                                        continue;
                                }

                                if (statusX2 == TbStatus.OK)
                                {
                                    if (x2 < tmpGps.UnAdjX)
                                        continue;
                                }
                                #endregion

                                #region Y
                                if (statusY == TbStatus.OK)
                                {
                                    if (y > tmpGps.UnAdjY)
                                        continue;
                                }

                                if (statusY2 == TbStatus.OK)
                                {
                                    if (y2 < tmpGps.UnAdjY)
                                        continue;
                                }
                                #endregion

                                #region Z
                                if (statusZ == TbStatus.OK)
                                {
                                    if (z > tmpGps.UnAdjZ)
                                        continue;
                                }

                                if (statusZ2 == TbStatus.OK)
                                {
                                    if (z2 < tmpGps.UnAdjZ)
                                        continue;
                                }
                                #endregion

                            }
                            else
                            {
                                double dX, dY, dZ;

                                if (radAdj.Checked)
                                {
                                    dX = point.AdjX;
                                    dY = point.AdjY;
                                    dZ = point.AdjZ;
                                }
                                else
                                {
                                    dX = point.UnAdjX;
                                    dY = point.UnAdjY;
                                    dZ = point.UnAdjZ;
                                }

                                #region X
                                if (statusX == TbStatus.OK)
                                {
                                    if (x > dX)
                                        continue;
                                }

                                if (statusX2 == TbStatus.OK)
                                {
                                    if (x2 < dX)
                                        continue;
                                }
                                #endregion

                                #region Y
                                if (statusY == TbStatus.OK)
                                {
                                    if (y > dY)
                                        continue;
                                }

                                if (statusY2 == TbStatus.OK)
                                {
                                    if (y2 < dY)
                                        continue;
                                }
                                #endregion

                                #region Z
                                if (statusZ == TbStatus.OK)
                                {
                                    if (z > dZ)
                                        continue;
                                }

                                if (statusZ2 == TbStatus.OK)
                                {
                                    if (z2 < dZ)
                                        continue;
                                }
                                #endregion
                            }

                            if (point.IsGpsType())
                            {
                                #region ManAcc
                                tmpGps = (GpsPoint)point;

                                if (tmpGps.ManualAccuracy != null)
                                {
                                    dTmp = (double)tmpGps.ManualAccuracy;

                                    if (statusManAcc == TbStatus.OK)
                                    {
                                        if (manAcc > dTmp)
                                            continue;
                                    }

                                    if (statusManAcc2 == TbStatus.OK)
                                    {
                                        if (manAcc2 < dTmp)
                                            continue;
                                    }
                                }
                                #endregion

                                #region RMSEr
                                if (tmpGps.NSSDA_RMSEr != null)
                                {
                                    dTmp = (double)tmpGps.NSSDA_RMSEr;

                                    if (statusRMSEr == TbStatus.OK)
                                    {
                                        if (rmser > dTmp)
                                            continue;
                                    }

                                    if (statusRMSEr2 == TbStatus.OK)
                                    {
                                        if (rmser2 < dTmp)
                                            continue;
                                    }
                                }
                                #endregion
                            }
                        }

                        #endregion

                        #region Trav / SideShot
                        if (chkUseTarvFilter.Checked)
                        {
                            if (point.IsTravType())
                            {
                                tmpSp = (SideShotPoint)point;

                                if (tmpSp.ForwardAz != null)
                                {
                                    dTmp = (double)tmpSp.ForwardAz;

                                    if (statusFA == TbStatus.OK)
                                    {
                                        if (fa > dTmp)
                                            continue;
                                    }

                                    if (statusFA2 == TbStatus.OK)
                                    {
                                        if (fa2 < dTmp)
                                            continue;
                                    }
                                }

                                if (tmpSp.BackwardAz != null)
                                {
                                    dTmp = (double)tmpSp.BackwardAz;
                                    if (statusBA == TbStatus.OK)
                                    {
                                        if (ba > dTmp)
                                            continue;
                                    }

                                    if (statusBA2 == TbStatus.OK)
                                    {
                                        if (ba2 < dTmp)
                                            continue;
                                    }
                                }

                                if (statusSD == TbStatus.OK)
                                {
                                    if (sd > tmpSp.SlopeDistance)
                                        continue;
                                }

                                if (statusSD2 == TbStatus.OK)
                                {
                                    if (sd2 < tmpSp.SlopeDistance)
                                        continue;
                                }

                                if (statusSA == TbStatus.OK)
                                {
                                    if (sa > tmpSp.SlopeAngle)
                                        continue;
                                }

                                if (statusSA2 == TbStatus.OK)
                                {
                                    if (sa2 < tmpSp.SlopeAngle)
                                        continue;
                                }
                            }
                        }
                        #endregion

                        #region Qndm
                        if (chkPointsWLinks.Checked && !point.HasQuondamLinks)
                        {
                            continue;
                        }
                        #endregion
                    }

                    newPoints.Add(TtUtils.CopyPoint(point));
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "MassEditForm:UpdateFilter", ex.StackTrace);
            }

            newPoints.Sort();
            return newPoints;
        }

        private void UpdateFilter()
        {
            _DisplayPoints = new BindingList<TtPoint>(FilterPoints(_EditPoints.Values.ToList()));

            if (_DisplaySource != null)
                _DisplaySource.Clear();
            else
                _DisplaySource = new BindingSource();

            if (_DisplayPoints.Count > 0)
            {
                _DisplaySource.DataSource = _DisplayPoints;
                ColorRows();
                pnlInner.Enabled = true;
            }
            else
            {
                ClearFields();
                pnlInner.Enabled = false;
            }
        }

        private void ColorRows()
        {
            if (dgvPoints.Rows.Count > 0)
            {
                if (Values.Settings.DeviceOptions.FormMassEditUseAlternatingRows)
                {
                    string lastPoly = String.Empty;
                    bool on = false;

                    for (int i = 0; i < _DisplayPoints.Count; i++)
                    {
                        if (lastPoly != _DisplayPoints[i].PolyCN)
                            on = false;

                        lastPoly = _DisplayPoints[i].PolyCN;

                        if (!on)
                        {
                            if (Values.Settings.DeviceOptions.FormMassEditUseColoredRows)
                            {
                                dgvPoints.Rows[i].DefaultCellStyle.BackColor = _PolygonColors[lastPoly];
                            }
                            else
                            {
                                dgvPoints.Rows[i].DefaultCellStyle.BackColor = SystemColors.Control;
                            }

                            on = true;
                        }
                        else
                        {
                            dgvPoints.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            on = false;
                        }

                    }
                }
                else if (Values.Settings.DeviceOptions.FormMassEditUseColoredRows)
                {
                    for (int i = 0; i < _DisplayPoints.Count; i++)
                    {
                        dgvPoints.Rows[i].DefaultCellStyle.BackColor = _PolygonColors[_DisplayPoints[i].PolyCN];
                    }
                }
            }
        }

        private TbStatus TestTextbox(TextBox tb, string tbname, bool emptyOk)
        {
            string tmp;

            tmp = tb.Text.Trim();
            if (tmp.IsEmpty())
            {
                if (emptyOk)
                    return TbStatus.Empty;

                MessageBox.Show(String.Format("{0} is invalid. Must contain a Number.", tbname));
                tb.Focus();

                return TbStatus.Bad;
            }

            if (!tmp.IsDouble())
            {
                MessageBox.Show(String.Format("{0} is invalid. Must be Numeric.", tbname));
                tb.Focus();

                return TbStatus.Bad;
            }

            return TbStatus.OK;
        }

        private void InitFilters()
        {
            chkLstMetaFilter.Items.Clear();
            chkLstMetaFilter.Items.Add("All", true);
            foreach (TtMetaData md in _MetaData.Values)
            {
                chkLstMetaFilter.Items.Add(md, true);
            }


            chkLstGroupFilter.Items.Clear();
            chkLstGroupFilter.Items.Add("All", true);
            chkLstGroupFilter.Items.Add(Values.MainGroup, true);
            foreach (TtGroup g in _Groups.Values)
            {
                if(g.CN != Values.MainGroup.CN)
                    chkLstGroupFilter.Items.Add(g, true);
            }


            chkLstPolyFilter.Items.Clear();
            chkLstPolyFilter.Items.Add("All", true);
            foreach (TtPolygon p in _Polygons.Values)
            {
                chkLstPolyFilter.Items.Add(p, true);
            }


            chkLstOpFilter.Items.Clear();
            chkLstOpFilter.Items.Add("All", true);
            foreach (OpType o in (OpType[])Enum.GetValues(typeof(OpType)))
            {
                chkLstOpFilter.Items.Add(o, true);
            }
        }


        #region Filter Controls

        private void chkLstPolyFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ignoreControls)
            {
                bool value = (e.NewValue == CheckState.Checked) ? (true) : (false);

                ignoreControls = true;

                if (e.Index == 0)
                {
                    for (int i = 1; i < chkLstPolyFilter.Items.Count; i++)
                    {
                        chkLstPolyFilter.SetItemChecked(i, value);
                    }
                }
                else
                {
                    chkLstPolyFilter.SetItemChecked(0, false);
                    chkLstPolyFilter.SetItemChecked(e.Index, value);
                }

                UpdateFilter();

                ignoreControls = false;
            }
        }

        private void chkLstOpFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ignoreControls)
            {
                bool value = (e.NewValue == CheckState.Checked) ? (true) : (false);

                ignoreControls = true;

                if (e.Index == 0)
                {
                    for (int i = 1; i < chkLstOpFilter.Items.Count; i++)
                    {
                        chkLstOpFilter.SetItemChecked(i, value);
                    }
                }
                else
                {
                    chkLstOpFilter.SetItemChecked(0, false);
                    chkLstOpFilter.SetItemChecked(e.Index, value);
                }

                ignoreControls = false;

                UpdateFilter();
            }
        }

        private void chkLstMetaFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ignoreControls)
            {
                bool value = (e.NewValue == CheckState.Checked) ? (true) : (false);

                ignoreControls = true;

                if (e.Index == 0)
                {
                    for (int i = 1; i < chkLstMetaFilter.Items.Count; i++)
                    {
                        chkLstMetaFilter.SetItemChecked(i, value);
                    }
                }
                else
                {
                    chkLstMetaFilter.SetItemChecked(0, false);
                    chkLstMetaFilter.SetItemChecked(e.Index, value);
                }

                ignoreControls = false;

                UpdateFilter();
            }
        }

        private void chkLstGroupFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!ignoreControls)
            {
                bool value = (e.NewValue == CheckState.Checked) ? (true) : (false);

                ignoreControls = true;

                if (e.Index == 0)
                {
                    for (int i = 1; i < chkLstGroupFilter.Items.Count; i++)
                    {
                        chkLstGroupFilter.SetItemChecked(i, value);
                    }
                }
                else
                {
                    chkLstGroupFilter.SetItemChecked(0, false);
                    chkLstGroupFilter.SetItemChecked(e.Index, value);
                }

                ignoreControls = false;

                UpdateFilter();
            }
        }

        private void txtPID1_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void txtPID2_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void radUnAdj_CheckedChanged(object sender, EventArgs e)
        {
            if(chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void radAdj_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void radGps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtX1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtX2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtY1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtY2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtZ1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtZ2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtManAcc1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtManAcc2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void chkOnBndFilter_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkUseGpsFilter.Checked)
                UpdateFilter();
        }

        private void txtR1_TextChanged(object sender, EventArgs e)
        {
            if(chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtR2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void btnClearGps_Click(object sender, EventArgs e)
        {
            ignoreControls = true;

            txtX1.Text = String.Empty;
            txtY1.Text = String.Empty;
            txtZ1.Text = String.Empty;
            txtX2.Text = String.Empty;
            txtY2.Text = String.Empty;
            txtZ2.Text = String.Empty;

            txtManAcc1.Text = String.Empty;
            txtManAcc2.Text = String.Empty;

            txtR1.Text = String.Empty;
            txtR2.Text = String.Empty;
            chkOnBnd.CheckState = CheckState.Indeterminate;

            ignoreControls = false;
        }

        private void txtFA1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtFA2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtBA1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtBA2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void radSDLess_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtSD1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtSD2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtSA1_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void txtSA2_TextChanged(object sender, EventArgs e)
        {
            if (chkUseTarvFilter.Checked)
                UpdateFilter();
        }

        private void btnClearTrav_Click(object sender, EventArgs e)
        {
            ignoreControls = true;

            txtSD1.Text = String.Empty;
            txtSA1.Text = String.Empty;
            txtFA1.Text = String.Empty;
            txtBA1.Text = String.Empty;

            txtSD2.Text = String.Empty;
            txtSA2.Text = String.Empty;
            txtFA2.Text = String.Empty;
            txtBA2.Text = String.Empty;

            ignoreControls = false;
        }

        private void chkPointsWLinks_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void txtSearchDesc_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();

            if (txtSearchDesc.Text.IsEmpty())
                lblSDesc.Visible = true;
            else
                lblSDesc.Visible = false;
        }

        private void lblSDesc_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearchDesc.Focus();
        }
        
        private void chkUseGpsFilter_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void chkUseTarvFilter_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }
        #endregion
        #endregion


        #region Row Cell, Point Info

        private bool MultiPointsSelected { get { return dgvPoints.SelectedRows.Count > 1; } }
        

        private List<TtPoint> GetSelectedPoints()
        {
            List<TtPoint> points = new List<TtPoint>();
            foreach (DataGridViewRow row in dgvPoints.SelectedRows)
            {
                points.Add(_DisplayPoints[row.Index]);
            }

            return points;
        }
        
        private void UpdateAdvInfo()
        {
            double n, s, e, w, ae, an, ce, cn, mna, mxa, dist = 0, area = 0;

            if (dgvPoints.SelectedRows.Count > 0)
            {
                List<TtPoint> selctedPoints = new List<TtPoint>();

                foreach (DataGridViewRow r in dgvPoints.SelectedRows)
                {
                    selctedPoints.Add(_DisplayPoints[r.Index]);
                }

                selctedPoints.Sort();

                n = s = an = cn = selctedPoints[0].AdjY;
                e = w = ae = ce = selctedPoints[0].AdjX;

                if (_MetaData[selctedPoints[0].MetaDefCN].uomElevation == UomElevation.Feet)
                    mna = mxa = selctedPoints[0].AdjZ;
                else
                    mna = mxa = TtUtils.ConvertToFeetTenths(selctedPoints[0].AdjZ, Unit.METERS);

                if (selctedPoints.Count > 1)
                {
                    TtPoint p;
                    for (int i = 0; i < selctedPoints.Count; i++)
                    {
                        p = selctedPoints[i];

                        if (p.AdjY > n)
                            n = p.AdjX;

                        if (p.AdjY < s)
                            s = p.AdjX;

                        if (p.AdjX > e)
                            e = p.AdjX;

                        if (p.AdjX < w)
                            w = p.AdjX;

                        ae += p.AdjX;
                        an += p.AdjY;

                        if (_MetaData[selctedPoints[i].MetaDefCN].uomElevation == UomElevation.Meters)
                            mna = mxa = selctedPoints[i].AdjZ;
                        else
                            mna = mxa = TtUtils.ConvertToMeters(selctedPoints[i].AdjZ, Unit.FEET_TENTH);
                        
                        if(i < selctedPoints.Count - 1)
                            dist += TtUtils.Distance(selctedPoints[i + 1], p);

                        if (selctedPoints.Count > 2)
                        {
                            if (i < selctedPoints.Count - 1)
                            {
                                TtPoint p1 = selctedPoints[i + 1];
                                area += ((p1.AdjX - p.AdjX) * (p1.AdjY + p.AdjY) / 2);
                            }
                            else
                            {
                                TtPoint p0 = selctedPoints[0];
                                area += ((p.AdjX - p0.AdjX) * (p.AdjY + p0.AdjY) / 2);
                            }
                        }
                        
                    }

                    area = Math.Abs(area);

                    ae /= selctedPoints.Count;
                    an /= selctedPoints.Count;

                    ce = (e + w) / 2;
                    cn = (n + s) / 2;
                }

                if (selctedPoints.Count == 2)
                {
                    double az = TtUtils.AzimuthOfPoint(
                        new DoublePoint(selctedPoints[0].UnAdjX, selctedPoints[0].UnAdjY),
                        new DoublePoint(selctedPoints[1].UnAdjX, selctedPoints[1].UnAdjY));

                    lblAzimuth.Text = az.ToString("f2");
                }
                else
                {
                    lblAzimuth.Text = String.Empty;
                }

                if (Values.Settings.DeviceOptions.FormMassEditElevationFeet)
                {
                    lblMaxAlt.Text = TtUtils.ConvertToFeetTenths(mxa, Unit.METERS).ToString("f2");
                    lblMinAlt.Text = TtUtils.ConvertToFeetTenths(mna, Unit.METERS).ToString("f2");
                }
                else
                {
                    lblMaxAlt.Text = mxa.ToString("f2");
                    lblMinAlt.Text = mna.ToString("f2");
                }

                lblAvg.Text = String.Format("X: {0}, Y: {1}", ae.ToString("f2"), an.ToString("f2"));
                lblCenter.Text = String.Format("X: {0}, Y: {1}", ce.ToString("f2"), cn.ToString("f2"));

                lblNorth.Text = n.ToString("f2");
                lblSouth.Text = s.ToString("f2");
                lblEast.Text = e.ToString("f2");
                lblWest.Text = w.ToString("f2");

                if (selctedPoints.Count > 1)
                {
                    lblDistMeter.Text = dist.ToString("f2");
                    lblDistFeet.Text = TtUtils.ConvertToFeetTenths(dist, Unit.METERS).ToString("f2");

                    if (selctedPoints.Count > 2)
                        lblHa.Text = TtUtils.ConvertMeters2ToAcres(area).ToString("f2");
                    else
                        lblHa.Text = String.Empty;
                }
                else
                {
                    lblDistFeet.Text = lblDistMeter.Text = String.Empty;
                    lblHa.Text = String.Empty;
                }
            }
        }

        #endregion


        #region Fields
        private void SetFields(TtPoint point)
        {
            SetFields(false, point);
        }

        private void SetFields(bool multiPoints)
        {
            SetFields(multiPoints, null);
        }

        private void SetFields(bool multiPoints, TtPoint point)
        {
            if (_DisplayPoints.Count < 1)
            {
                ClearFields();
            }
            else
            {
                try
                {
                    ignoreControls = true;

                    ClearFields();
                    ClearTabStops();

                    if (multiPoints)
                    {
                        #region Multi Points

                        _SelectedPoints = GetSelectedPoints();

                        TtPoint fPoint = _SelectedPoints[0];
                        double? compdn;
                        double compd;
                        string comp;
                        bool same, compb;

                        CurrentPoint = null;

                        txtPID.Text = string.Empty;
                        txtPID.Enabled = false;

                        txtIndex.Text = string.Empty;
                        txtIndex.Enabled = false;

                        #region OnBnd
                        compb = fPoint.OnBnd;
                        same = true;
                        for (int i = 1; i < _SelectedPoints.Count; i++)
                        {
                            if (compb != _SelectedPoints[i].OnBnd)
                            {
                                same = false;
                                break;
                            }
                        }

                        if (same)
                        {
                            chkOnBnd.Checked = fPoint.OnBnd;

                            if (fPoint.OnBnd)
                                chkOnBnd.CheckState = CheckState.Checked;
                        }
                        else
                            chkOnBnd.CheckState = CheckState.Indeterminate;
                        #endregion

                        #region Poly
                        comp = fPoint.PolyCN;
                        same = true;
                        for (int i = 1; i < _SelectedPoints.Count; i++)
                        {
                            if (comp != _SelectedPoints[i].PolyCN)
                            {
                                same = false;
                                break;
                            }
                        }

                        if (same)
                            cboPoly.SelectedItem = _Polygons[fPoint.PolyCN];
                        else
                        {
                            cboPoly.SelectedItem = null;
                            cboPoly.BackColor = multiColor;
                        }
                        #endregion

                        #region Comment
                        comp = fPoint.Comment;
                        same = true;
                        for (int i = 1; i < _SelectedPoints.Count; i++)
                        {
                            if (comp != _SelectedPoints[i].Comment)
                            {
                                same = false;
                                break;
                            }
                        }

                        if (same)
                            txtCmt.Text = fPoint.Comment;
                        else
                        {
                            txtCmt.Text = String.Empty;
                            txtCmt.BackColor = multiColor;
                        }
                        #endregion

                        #region Meta
                        comp = fPoint.MetaDefCN;
                        same = true;
                        for (int i = 1; i < _SelectedPoints.Count; i++)
                        {
                            if (comp != _SelectedPoints[i].MetaDefCN)
                            {
                                same = false;
                                break;
                            }
                        }

                        if (same)
                            cboMeta.SelectedItem = _MetaData[fPoint.MetaDefCN];
                        else
                        {
                            cboMeta.SelectedItem = null;
                            cboMeta.BackColor = multiColor;
                        }
                        #endregion

                        #region Group
                        if (_Groups.Count > 1)
                        {
                            comp = fPoint.GroupCN;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (comp != _SelectedPoints[i].GroupCN)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                            {
                                if (!fPoint.GroupCN.IsEmpty())
                                    cboGroup.SelectedItem = _Groups[fPoint.GroupCN];
                                else
                                    cboGroup.SelectedItem = _Groups["none"];
                            }
                            else
                            {
                                cboGroup.SelectedItem = null;
                                cboGroup.BackColor = multiColor;
                            }
                        }
                        #endregion

                        #region Op
                        OpType op = fPoint.op;
                        same = true;
                        for (int i = 1; i < _SelectedPoints.Count; i++)
                        {
                            if (op != _SelectedPoints[i].op)
                            {
                                same = false;
                                break;
                            }
                        }

                        if (same)
                        {
                            cboOp.SelectedItem = fPoint.op;
                            SetTabStops(fPoint.op);
                        }
                        else
                        {
                            cboOp.SelectedItem = null;
                            cboOp.BackColor = multiColor;
                        }
                        #endregion

                        if (_SelectedPoints.AreAllGpsType())
                        {
                            #region All Gps
                            GpsPoint gps = (GpsPoint)fPoint;

                            txtX.Text = String.Empty;
                            txtY.Text = String.Empty;
                            txtZ.Text = String.Empty;
                            txtX.BackColor = multiColor;
                            txtY.BackColor = multiColor;
                            txtZ.BackColor = multiColor;

                            #region Man Acc
                            compdn = gps.ManualAccuracy;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compdn != ((GpsPoint)_SelectedPoints[i]).ManualAccuracy)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                            {
                                if (gps.ManualAccuracy != null && gps.ManualAccuracy >= 0)
                                    txtManAcc.Text = gps.ManualAccuracy.ToString();
                                else
                                    txtManAcc.Text = String.Empty;
                            }
                            else
                            {
                                txtManAcc.Text = String.Empty;
                                txtManAcc.BackColor = multiColor;
                            }
                            #endregion

                            #region NSSDA
                            compdn = gps.NSSDA_RMSEr;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compdn != ((GpsPoint)_SelectedPoints[i]).NSSDA_RMSEr)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtNSSDA.Text = gps.NSSDA_RMSEr == null ? "" : ((double)gps.NSSDA_RMSEr).ToString("0.###");
                            else
                            {
                                txtNSSDA.Text = String.Empty;
                                txtNSSDA.BackColor = multiColor;
                            }
                            #endregion

                            #region RMSEr
                            compdn = gps.RMSEr;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compdn != ((GpsPoint)_SelectedPoints[i]).RMSEr)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtRMSEr.Text = gps.RMSEr == null ? "" : ((double)gps.RMSEr).ToString("0.###");
                            else
                            {
                                txtRMSEr.Text = String.Empty;
                                txtRMSEr.BackColor = multiColor;
                            }
                            #endregion

                            txtX.Enabled = true;
                            txtY.Enabled = true;
                            txtZ.Enabled = true;
                            txtManAcc.Enabled = true;

                            txtFAz.Enabled = false;
                            txtBAz.Enabled = false;
                            txtSlpAng.Enabled = false;
                            txtSlpDist.Enabled = false;
                            txtQndm.Enabled = false;


                            txtFAz.BackColor = disCtrl;
                            txtBAz.BackColor = disCtrl;
                            txtSlpAng.BackColor = disCtrl;
                            txtSlpDist.BackColor = disCtrl;
                            #endregion
                        }
                        else if (_SelectedPoints.AreAllTravType())
                        {
                            #region All Trav
                            SideShotPoint ss = (SideShotPoint)fPoint;

                            #region Fwd Az
                            compdn = ss.ForwardAz;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compdn != ((SideShotPoint)_SelectedPoints[i]).ForwardAz)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtFAz.Text = ss.ForwardAz.ToString();
                            else
                            {
                                txtFAz.Text = String.Empty;
                                txtFAz.BackColor = multiColor;
                            }
                            #endregion

                            #region Back Az
                            compdn = ss.BackwardAz;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compdn != ((SideShotPoint)_SelectedPoints[i]).BackwardAz)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtBAz.Text = ss.BackwardAz.ToString();
                            else
                            {
                                txtBAz.Text = String.Empty;
                                txtBAz.BackColor = multiColor;
                            }
                            #endregion

                            #region Slope Angle
                            compd = ss.SlopeAngle;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compd != ((SideShotPoint)_SelectedPoints[i]).SlopeAngle)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtSlpAng.Text = ss.SlopeAngle.ToString();
                            else
                            {
                                txtSlpAng.Text = String.Empty;
                                txtSlpAng.BackColor = multiColor;
                            }
                            #endregion

                            #region Slope Dist
                            compdn = ss.SlopeDistance;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (compdn != ((SideShotPoint)_SelectedPoints[i]).SlopeDistance)
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtSlpDist.Text = ss.SlopeDistance.ToString();
                            else
                            {
                                txtSlpDist.Text = String.Empty;
                                txtSlpDist.BackColor = multiColor;
                            }
                            #endregion

                            #region Horizontal Dist
                            compd = ss.HorizontalDistance;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (!TtUtils.WithinDifferenceOf(compd, ((SideShotPoint)_SelectedPoints[i]).HorizontalDistance, .05))
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtHD.Text = ss.HorizontalDistance.ToString("0.###");
                            else
                            {
                                txtHD.Text = String.Empty;
                                txtHD.BackColor = multiColor;
                            }
                            #endregion

                            #region Declination
                            compd = ss.Declination;
                            same = true;
                            for (int i = 1; i < _SelectedPoints.Count; i++)
                            {
                                if (!TtUtils.WithinDifferenceOf(compd, ((SideShotPoint)_SelectedPoints[i]).Declination, .05))
                                {
                                    same = false;
                                    break;
                                }
                            }

                            if (same)
                                txtDec.Text = ss.Declination.ToString("0.###");
                            else
                            {
                                txtDec.Text = String.Empty;
                                txtDec.BackColor = multiColor;
                            }
                            #endregion

                            txtFAz.Enabled = true;
                            txtBAz.Enabled = true;
                            txtSlpAng.Enabled = true;
                            txtSlpDist.Enabled = true;

                            txtX.Enabled = false;
                            txtY.Enabled = false;
                            txtZ.Enabled = false;
                            txtManAcc.Enabled = false;
                            txtQndm.Enabled = false;

                            txtX.BackColor = disCtrl;
                            txtY.BackColor = disCtrl;
                            txtZ.BackColor = disCtrl;
                            txtManAcc.BackColor = disCtrl;
                            #endregion
                        }
                        else if (_SelectedPoints.AreAllQndmType())
                        {
                            #region All Qndm

                            txtQndm.Text = "Cant Multi Edit";
                            txtQndm.Enabled = false;

                            txtManAcc.Enabled = false;
                            txtFAz.Enabled = false;
                            txtBAz.Enabled = false;
                            txtSlpAng.Enabled = false;
                            txtSlpDist.Enabled = false;
                            txtX.Enabled = false;
                            txtY.Enabled = false;
                            txtZ.Enabled = false;

                            txtX.BackColor = disCtrl;
                            txtY.BackColor = disCtrl;
                            txtZ.BackColor = disCtrl;
                            txtManAcc.BackColor = disCtrl;

                            txtFAz.BackColor = disCtrl;
                            txtBAz.BackColor = disCtrl;
                            txtSlpAng.BackColor = disCtrl;
                            txtSlpDist.BackColor = disCtrl;
                            #endregion
                        }
                        else //Mixed
                        {
                            #region Mixed
                            txtManAcc.Enabled = false;
                            txtFAz.Enabled = false;
                            txtBAz.Enabled = false;
                            txtSlpAng.Enabled = false;
                            txtSlpDist.Enabled = false;
                            txtX.Enabled = false;
                            txtY.Enabled = false;
                            txtZ.Enabled = false;

                            txtX.BackColor = disCtrl;
                            txtY.BackColor = disCtrl;
                            txtZ.BackColor = disCtrl;
                            txtManAcc.BackColor = disCtrl;

                            txtFAz.BackColor = disCtrl;
                            txtBAz.BackColor = disCtrl;
                            txtSlpAng.BackColor = disCtrl;
                            txtSlpDist.BackColor = disCtrl;
                            #endregion
                        }

                        #endregion
                    }
                    else
                    {
                        #region One Point

                        if (point != null)
                            CurrentPoint = point;
                        else
                            CurrentPoint = _DisplayPoints[dgvPoints.SelectedRows[0].Index];

                        txtPID.Text = CurrentPoint.PID.ToString();
                        txtPID.Enabled = true;

                        txtIndex.Text = CurrentPoint.Index.ToString();
                        if (AdvEdit)
                            txtIndex.Enabled = true;

                        txtCmt.Text = CurrentPoint.Comment;
                        txtCmt.Enabled = true;

                        cboPoly.SelectedItem = _Polygons[CurrentPoint.PolyCN];
                        cboPoly.Enabled = true;

                        cboMeta.SelectedItem = _MetaData[CurrentPoint.MetaDefCN];
                        cboMeta.Enabled = true;

                        cboGroup.SelectedItem = _Groups[CurrentPoint.GroupCN];
                        cboGroup.Enabled = true;

                        cboOp.SelectedItem = CurrentPoint.op;
                        cboOp.Enabled = true;
                        SetTabStops(CurrentPoint.op);

                        if (CurrentPoint.OnBnd)
                        {
                            chkOnBnd.Checked = true;
                            chkOnBnd.CheckState = CheckState.Checked;
                        }
                        else
                            chkOnBnd.Checked = false;

                        cboGroup.SelectedItem = _Groups[CurrentPoint.GroupCN];

                        if (CurrentPoint.IsGpsType())
                        {
                            GpsPoint gps = (GpsPoint)CurrentPoint;

                            txtX.Text = gps.UnAdjX.ToString("0.###");
                            txtY.Text = gps.UnAdjY.ToString("0.###");
                            txtZ.Text = gps.UnAdjZ.ToString("0.###");

                            if (gps.ManualAccuracy != null && gps.ManualAccuracy >= 0)
                                txtManAcc.Text = gps.ManualAccuracy.ToString();
                            else
                                txtManAcc.Text = String.Empty;

                            txtX.Enabled = true;
                            txtY.Enabled = true;
                            txtZ.Enabled = true;
                            txtManAcc.Enabled = true;

                            txtRMSEr.Text = gps.RMSEr == null ? "" : ((double)gps.RMSEr).ToString("0.###");
                            txtNSSDA.Text = gps.NSSDA_RMSEr == null ? "" : ((double)gps.NSSDA_RMSEr).ToString("0.###");
                        }
                        else
                        {
                            txtX.Enabled = false;
                            txtY.Enabled = false;
                            txtZ.Enabled = false;
                            txtManAcc.Enabled = false;

                            txtX.BackColor = disCtrl;
                            txtY.BackColor = disCtrl;
                            txtZ.BackColor = disCtrl;
                            txtManAcc.BackColor = disCtrl;
                        }

                        if (CurrentPoint.IsTravType())
                        {
                            SideShotPoint sp = (SideShotPoint)CurrentPoint;

                            txtFAz.Text = sp.ForwardAz.ToString();
                            txtBAz.Text = sp.BackwardAz.ToString();
                            txtSlpAng.Text = sp.SlopeAngle.ToString("0.###");
                            txtSlpDist.Text = sp.SlopeDistance.ToString("0.###");

                            txtFAz.Enabled = true;
                            txtBAz.Enabled = true;
                            txtSlpAng.Enabled = true;
                            txtSlpDist.Enabled = true;

                            txtHD.Text = sp.HorizontalDistance.ToString("0.###");
                            txtDec.Text = sp.Declination.ToString("0.###");
                        }
                        else
                        {
                            txtFAz.Enabled = false;
                            txtBAz.Enabled = false;
                            txtSlpAng.Enabled = false;
                            txtSlpDist.Enabled = false;

                            txtFAz.BackColor = disCtrl;
                            txtBAz.BackColor = disCtrl;
                            txtSlpAng.BackColor = disCtrl;
                            txtSlpDist.BackColor = disCtrl; ;
                        }

                        if (CurrentPoint.op == TwoTrails.Engine.OpType.Quondam)
                        {
                            QuondamPoint qp = (QuondamPoint)CurrentPoint;

                            txtQndm.Text = String.Format("{0}, {1}", qp.ParentPID, qp.ParentPoly);
                            txtQndm.Enabled = true;
                        }
                        else
                        {
                            txtQndm.Enabled = false;
                        }
                        #endregion
                    }

                    pnlInner.Enabled = true;
                    tabCtrl.Enabled = true;
                    dgvPoints.Focus();

                    tsmiPointsHaveErrors.Visible = false;
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MassEditForm:SetFields", ex.StackTrace);
                    pnlInner.Enabled = false;
                    tabCtrl.Enabled = false;

                    if (AdvEdit)
                    {
                        tsmiPointsHaveErrors.Visible = true;
                        tsslStatus.Text = "Points have Errors";
                    }

                }
                finally
                {
                    ignoreControls = false;
                }


                //TEMP
                txtQndm.Enabled = false;
            }
        }

     
        private void ClearFields()
        {
            txtPID.Text = String.Empty;
            txtIndex.Text = String.Empty;
            txtX.Text = String.Empty;
            txtY.Text = String.Empty;
            txtZ.Text = String.Empty;
            txtManAcc.Text = String.Empty;
            txtFAz.Text = String.Empty;
            txtBAz.Text = String.Empty;
            txtSlpDist.Text = String.Empty;
            txtSlpAng.Text = String.Empty;
            txtQndm.Text = String.Empty;
            txtCmt.Text = String.Empty;


            txtRMSEr.Text = String.Empty;
            txtNSSDA.Text = String.Empty;
            txtHD.Text = String.Empty;
            txtDec.Text = String.Empty;

            txtRMSEr.BackColor = SystemColors.Control;
            txtNSSDA.BackColor = SystemColors.Control;
            txtHD.BackColor = SystemColors.Control;
            txtDec.BackColor = SystemColors.Control;


            txtCmt.BackColor = Color.White;
            cboMeta.BackColor = Color.White;
            cboPoly.BackColor = Color.White;
            cboGroup.BackColor = Color.White;
            cboOp.BackColor = Color.White;

            txtX.BackColor = Color.White;
            txtY.BackColor = Color.White;
            txtZ.BackColor = Color.White;
            txtManAcc.BackColor = Color.White;

            txtFAz.BackColor = Color.White;
            txtBAz.BackColor = Color.White;
            txtSlpAng.BackColor = Color.White;
            txtSlpDist.BackColor = Color.White;
        }


        private void SetTabStops(OpType op)
        {
            switch (op)
            {
                case OpType.GPS:
                case OpType.Take5:
                case OpType.Walk:
                case OpType.WayPoint:
                    {
                        chkOnBnd.TabStop = true;
                        txtX.TabStop = true;
                        txtY.TabStop = true;
                        txtZ.TabStop = true;
                        txtManAcc.TabStop = true;
                        txtCmt.TabStop = true;
                    }
                    break;
                case OpType.SideShot:
                case OpType.Traverse:
                    {
                        chkOnBnd.TabStop = true;
                        txtFAz.TabStop = true;
                        txtBAz.TabStop = true;
                        txtSlpAng.TabStop = true;
                        txtSlpDist.TabStop = true;
                        txtCmt.TabStop = true;
                    }
                    break;
                case OpType.Quondam:
                    {
                        chkOnBnd.TabStop = true;
                        txtCmt.TabStop = true;
                    }
                    break;
            }
        }

        private void ClearTabStops()
        {
            chkOnBnd.TabStop = false;
            txtX.TabStop = false;
            txtY.TabStop = false;
            txtZ.TabStop = false;
            txtManAcc.TabStop = false;
            txtFAz.TabStop = false;
            txtBAz.TabStop = false;
            txtSlpAng.TabStop = false;
            txtSlpDist.TabStop = false;
            txtCmt.TabStop = false;
        }

        private void UpdateRow(string cn)
        {
            for (int i = 0; i < _DisplayPoints.Count; i++)
            {
                if (_DisplayPoints[i].CN == cn)
                {
                    _DisplayPoints[i] = TtUtils.CopyPoint(_EditPoints[cn]);
                }
            }
        }

        private void UpdateRow(int row)
        {
            if (_DisplayPoints.Count > row)
            {
                _DisplayPoints[row] = TtUtils.CopyPoint(_EditPoints[_DisplayPoints[row].CN]);
            }
        }


        private void UpdateRows(List<string> cns)
        {
            string cn, ccn;

            for (int i = 0; i < _DisplayPoints.Count; i++)
            {
                ccn = _DisplayPoints[i].CN;

                for (int j = 0; j < cns.Count; j++)
                {
                    cn = cns[j];

                    if (ccn == cn)
                    {
                        _DisplayPoints[i] = TtUtils.CopyPoint(_EditPoints[cn]);
                        break;
                    }
                }
            }
        }

        private void UpdateRows(List<TtPoint> points)
        {
            string cn, ccn;

            for (int i = 0; i < _DisplayPoints.Count; i++)
            {
                ccn = _DisplayPoints[i].CN;

                for (int j = 0; j < points.Count; j++)
                {
                    cn = points[j].CN;

                    if (ccn == cn)
                    {
                        _DisplayPoints[i] = TtUtils.CopyPoint(_EditPoints[cn]);
                        break;
                    }
                }
            }
        }

        private void UpdateRows(List<int> rows)
        {
            foreach (int row in rows)
            {
                if (_DisplayPoints.Count > row)
                {
                    _DisplayPoints[row] = TtUtils.CopyPoint(_EditPoints[_DisplayPoints[row].CN]);
                }
            }
        }


        private void UpdateView(bool multi)
        {
            if (!MultiPointsSelected)
            {
                if (multi)
                {
                    if (CurrentPoint == null)
                    {
                        UpdateFilter();
                    }
                    else
                    {
                        string cn = CurrentPoint.CN;

                        UpdateFilter();
                        dgvPoints.ClearSelection();

                        bool found = false;
                        for (int i = 0; i < _DisplayPoints.Count; i++)
                        {
                            if (_DisplayPoints[i].CN == cn)
                            {
                                dgvPoints.Rows[i].Selected = true;
                                found = true;
                                break;
                            }
                        }

                        if (!found && dgvPoints.Rows.Count > 0)
                            dgvPoints.Rows[0].Selected = true;
                    }
                }
                else
                {
                    if (CurrentPoint != null)
                    {
                        CurrentPoint = TtUtils.CopyPoint(_EditPoints[CurrentPoint.CN]);

                        for (int i = 0; i < _DisplayPoints.Count; i++)
                        {
                            if (_DisplayPoints[i].CN == CurrentPoint.CN)
                            {
                                _DisplayPoints[i] = CurrentPoint;
                                break;
                            }
                        }

                        SetFields(CurrentPoint);
                    }
                }
            }
            else
            {
                List<string> cns = new List<string>();

                foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                {
                    cns.Add(_DisplayPoints[row.Index].CN);
                }

                UpdateFilter();
                dgvPoints.ClearSelection();

                for (int i = 0; i < _DisplayPoints.Count; i++)
                {
                    if (cns.Contains(_DisplayPoints[i].CN))
                    {
                        dgvPoints.Rows[i].Selected = true;
                    }
                }
            }
        }


        private void SelectRow(string cn)
        {
            foreach (DataGridViewRow row in dgvPoints.Rows)
            {
                if (_DisplayPoints[row.Index].CN == cn)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void SelectRows(List<string> cns)
        {
            foreach (DataGridViewRow row in dgvPoints.Rows)
            {
                if (cns.Contains(_DisplayPoints[row.Index].CN))
                {
                    row.Selected = true;
                }
            }
        }
        #endregion


        #region Controls
        private Color DgvBackColor
        {
            get { return defaultCellStyle.BackColor; }
            set { defaultCellStyle.BackColor = value; }
        }

        private bool _QndmSelectMode;
        private bool QndmSelectMode
        {
            get { return _QndmSelectMode; }
            set
            {
                _QndmSelectMode = value;
                if (_QndmSelectMode)
                    EnableQndmSelectMode();
                else
                    DisableQndmSelectMode();
            }
        }

        private void EnableQndmSelectMode()
        {
            pnlfilter.Enabled = false;
            pnlSubFilter.Enabled = false;
            pnlInner.Enabled = false;
            menuStrip.Enabled = false;
            DgvBackColor = Color.AliceBlue;
            txtQndm.BackColor = Color.AliceBlue;
            btnCancelQndm.Visible = true;
        }

        private void DisableQndmSelectMode()
        {
            pnlfilter.Enabled = true;
            pnlSubFilter.Enabled = true;
            pnlInner.Enabled = true;
            menuStrip.Enabled = true;
            DgvBackColor = Color.White;
            txtQndm.BackColor = Color.White;
            btnCancelQndm.Visible = false;
        }


        private void dgvPoints_SelectionChanged(object sender, EventArgs e)
        {
            tsslInfo.Text = String.Format("{0} / {1}", dgvPoints.SelectedRows.Count, _DisplayPoints.Count);

            if (ignoreControls)
                return;

            if (qSelect)
            {
                if (!qStartSel || dgvPoints.SelectedRows.Count < 1)
                    return;

                QuondamPoint qPoint;
                TtPoint newParentPoint, oldParentPoint;
                List<TtPoint> points = new List<TtPoint>();

                ignoreControls = true;
                
                qPoint = (QuondamPoint)TtUtils.CopyPoint(CurrentPoint);

                if (!qPoint.ParentCN.IsEmpty())
                {
                    oldParentPoint = TtUtils.CopyPoint(_EditPoints[qPoint.ParentCN]);
                    oldParentPoint.RemoveQuondamLink(qPoint.CN);
                    points.Add(oldParentPoint);
                }

                newParentPoint = _DisplayPoints[dgvPoints.SelectedRows[0].Index];

                newParentPoint.AddQuondamLink(qPoint.CN);
                qPoint.ParentPoint = newParentPoint;

                points.Add(qPoint);
                points.Add(newParentPoint);

                urManager.EditPoints(points, _EditPoints);
                edited = true;
                qSelect = false;
                qStartSel = false;

                UpdateFilter();
                dgvPoints.ClearSelection();
                SelectRow(qPoint.CN);
                SetFields(qPoint);
                ignoreControls = false;
                DisableQndmSelectMode();
            }
            else
            {
                if (dgvPoints.SelectedRows.Count > 0)
                {
                    bool multiSelected = MultiPointsSelected;

                    SetFields(multiSelected);

                    if (AdvInfo)
                        UpdateAdvInfo();

                    tsmiReversePoints.Enabled = multiSelected;
                }
            }
        }

        private void dgvPoints_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (!MultiPointsSelected)
                    {
                        dgvPoints.ClearSelection();
                        dgvPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        SetFields(_DisplayPoints[e.RowIndex]);
                    }

                    currCellValue = dgvPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    currCellIndex = e.RowIndex;
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MassEditForm:CellMouseDown");
                }
            }
        }

        private void btnSubFilter_Click(object sender, EventArgs e)
        {
            if (pnlSubFilter.Height < 2)
            {
                pnlSubFilter.Height = 130;
                //set split to be bigger for options
                beforeShowSplit = splitContainer.SplitterDistance;
                splitContainer.SplitterDistance -= 5;
                btnSubFilter.Text = "Hide Options";
            }
            else
            {
                pnlSubFilter.Height = 0;
                //set split to be smaller for options
                splitContainer.SplitterDistance = beforeShowSplit;
                btnSubFilter.Text = "Show More Options";
            }
        }



        private void txtPID_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (!MultiPointsSelected && CurrentPoint != null)
                {
                    if (!txtPID.Text.IsEmpty() && txtPID.Text.IsInteger())
                    {
                        int pid = txtPID.Text.ToInteger();
                        if (pid != CurrentPoint.PID)
                        {
                            CurrentPoint.PID = pid;
                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                            UpdateRow(CurrentPoint.CN);
                        }
                    }
                }
            }
        }

        private void cboPoly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (cboPoly.SelectedItem != null)
                {
                    TtPolygon poly = (TtPolygon)cboPoly.SelectedItem;

                    List<TtPoint> pointsInTargetPoly = _EditPoints.Values.Where(p => p.PolyCN == poly.CN).ToList();
                    pointsInTargetPoly.Sort();
                    int index;

                    if (pointsInTargetPoly.Count > 0)
                        index = (int)(pointsInTargetPoly[pointsInTargetPoly.Count - 1].Index + 1);
                    else
                        index = 0;

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            CurrentPoint.PolyCN = poly.CN;
                            CurrentPoint.PolyName = poly.Name;
                            CurrentPoint.Index = index;
                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                            UpdateRow(CurrentPoint.CN);
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        index = index + dgvPoints.SelectedRows.Count - 1;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            tmpPoint.PolyCN = poly.CN;
                            tmpPoint.PolyName = poly.Name;
                            tmpPoint.Index = index;
                            index--;

                            points.Add(tmpPoint);
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;

                        UpdateRows(points);
                    }
                }
            }
        }

        private void txtIndex_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls && !MultiPointsSelected && CurrentPoint != null)
            {
                if (!txtIndex.Text.IsEmpty() && txtIndex.Text.IsInteger())
                {
                    CurrentPoint.Index = txtIndex.Text.ToInteger();
                    urManager.EditPoint(_CurrentPoint, _EditPoints);
                    edited = true;
                    UpdateRow(CurrentPoint.CN);
                }
            }
        }

        private void cboOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (cboOp.SelectedItem != null)
                {
                    OpType op = (OpType)cboOp.SelectedItem;

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null && CurrentPoint.op != op)
                        {
                            if (op == OpType.WayPoint && CurrentPoint.HasQuondamLinks)
                            {
                                MessageBox.Show("You can not change the Op to WayPoint if the point has a Quondam linked to it.");
                                cboOp.SelectedItem = CurrentPoint.op;
                                return;
                            }
                            else if (CurrentPoint.op == OpType.Quondam)
                            {
                                if (MessageBox.Show("Changing from a Quondam requires saving. You can not undo this operation. Continue?", "Convert Point",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                                {
                                    string cn = CurrentPoint.CN;

                                    CurrentPoint = DAL.GetNewPointByOpType(op, CurrentPoint);

                                    _EditPoints[CurrentPoint.CN] = CurrentPoint;
                                    edited = true;

                                    Save();

                                    _OrigPoints = DAL.GetPoints().ToDictionary(p => p.CN, p => p);

                                    RefreshData();

                                    dgvPoints.ClearSelection();

                                    for (int i = 0; i < _DisplayPoints.Count; i++)
                                    {
                                        if (_DisplayPoints[i].CN == cn)
                                        {
                                            dgvPoints.Rows[i].Selected = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                    return;
                            }
                            else
                            {
                                CurrentPoint = TtUtils.GetNewPointByOpType(op, CurrentPoint);

                                urManager.EditPoint(_CurrentPoint, _EditPoints);
                                edited = true;

                                UpdateRow(CurrentPoint.CN);
                            }
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (op == OpType.WayPoint && tmpPoint.HasQuondamLinks)
                            {
                                MessageBox.Show("You can not change an Op to WayPoint if the point has a Quondam linked to it.");
                                return;
                            }
                            else if (tmpPoint.op == OpType.Quondam)
                            {
                                MessageBox.Show("Can not convert Ops that contain a Quondam operation.");
                                return;
                            }
                            else if (op == tmpPoint.op)
                            {
                                continue;
                            }

                            tmpPoint = TtUtils.GetNewPointByOpType(op, tmpPoint);

                            points.Add(tmpPoint);
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;

                        UpdateRows(points);
                    }
                }
            }
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (cboMeta.SelectedItem != null)
                {
                    TtMetaData meta = (TtMetaData)cboMeta.SelectedItem;

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            CurrentPoint = TtUtils.SaveConversion(CurrentPoint, _MetaData[CurrentPoint.MetaDefCN]);
                            CurrentPoint = TtUtils.GetConversion(CurrentPoint, meta);

                            int oldZone = _MetaData[CurrentPoint.MetaDefCN].Zone;

                            if (oldZone != meta.Zone && CurrentPoint.IsGpsType())
                            {
                                CurrentPoint = TtUtils.RecalcPoint(CurrentPoint, meta.Zone, oldZone, DAL);
                            }
                            
                            CurrentPoint.MetaDefCN = meta.CN;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                            UpdateRow(CurrentPoint.CN);
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;
                        TtMetaData tmpMeta;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];
                            tmpMeta = _MetaData[tmpPoint.MetaDefCN];

                            tmpPoint = TtUtils.SaveConversion(tmpPoint, tmpMeta);
                            tmpPoint = TtUtils.GetConversion(tmpPoint, meta);

                            if (tmpMeta.Zone != meta.Zone && tmpPoint.IsGpsType())
                            {
                                tmpPoint = TtUtils.RecalcPoint(tmpPoint, meta.Zone, tmpMeta.Zone, DAL);
                            }

                            tmpPoint.MetaDefCN = meta.CN;

                            points.Add(tmpPoint);
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;

                        UpdateRows(points);
                    }
                }
            }
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (cboGroup.SelectedItem != null)
                {
                    TtGroup group = (TtGroup)cboGroup.SelectedItem;

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            _CurrentPoint.GroupCN = group.CN;
                            _CurrentPoint.GroupName = group.Name;

                            //Values.GroupManager.Groups[CurrentPoint.GroupCN].RemovePointFromGroup(CurrentPoint);
                            //Values.GroupManager.Groups[group.CN].AddPointToGroup(CurrentPoint);

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                            UpdateRow(CurrentPoint.CN);
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            tmpPoint.GroupCN = group.CN;
                            tmpPoint.GroupName = group.Name;

                            //Values.GroupManager.Groups[tmpPoint.GroupCN].RemovePointFromGroup(tmpPoint);
                            //Values.GroupManager.Groups[group.CN].AddPointToGroup(tmpPoint);

                            points.Add(tmpPoint);
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;

                        UpdateRows(points);
                    }
                }
            }
        }

        private void chkOnBnd_CheckedChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                bool onBnd = chkOnBnd.Checked;

                if (!MultiPointsSelected)
                {
                    if (CurrentPoint != null)
                    {
                        CurrentPoint.OnBnd = onBnd;
                        urManager.EditPoint(_CurrentPoint, _EditPoints);
                        edited = true;
                        UpdateRow(CurrentPoint.CN);
                    }
                }
                else
                {
                    List<TtPoint> points = new List<TtPoint>();
                    TtPoint tmpPoint;

                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        tmpPoint = _DisplayPoints[row.Index];
                        tmpPoint.OnBnd = onBnd;
                        points.Add(tmpPoint);
                    }

                    urManager.EditPoints(points, _EditPoints);
                    edited = true;

                    UpdateRows(points);
                }
            }
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtX.Text.IsDouble())
                {
                    double value = txtX.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            GpsPoint p = CurrentPoint as GpsPoint;
                            //p.X = value;
                            p.UnAdjX = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;
                        GpsPoint gps;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsGpsType())
                            {
                                gps = tmpPoint as GpsPoint;
                                //gps.X = value;
                                gps.UnAdjX = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtY.Text.IsDouble())
                {
                    double value = txtY.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            GpsPoint p = CurrentPoint as GpsPoint;
                            //p.Y = value;
                            p.UnAdjY = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;
                        GpsPoint gps;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsGpsType())
                            {
                                gps = tmpPoint as GpsPoint;
                                //gps.Y = value;
                                gps.UnAdjY = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtZ_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtZ.Text.IsDouble())
                {
                    double value = txtZ.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            GpsPoint p = CurrentPoint as GpsPoint;
                            //p.Z = value;
                            p.UnAdjZ = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;
                        GpsPoint gps;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsGpsType())
                            {
                                gps = tmpPoint as GpsPoint;
                                //gps.Z = value;
                                gps.UnAdjZ = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtManAcc_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtManAcc.Text.IsEmpty())
                {
                    if (CurrentPoint != null)
                    {
                        ((GpsPoint)CurrentPoint).ManualAccuracy = null;

                        urManager.EditPoint(_CurrentPoint, _EditPoints);
                        edited = true;
                    }
                }
                else if (txtManAcc.Text.IsDouble())
                {
                    double value = txtManAcc.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            ((GpsPoint)CurrentPoint).ManualAccuracy = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsGpsType())
                            {
                                ((GpsPoint)tmpPoint).ManualAccuracy = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtFAz_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtFAz.Text.IsEmpty())
                {
                    if (CurrentPoint != null)
                    {
                        ((SideShotPoint)CurrentPoint).ForwardAz = null;

                        urManager.EditPoint(_CurrentPoint, _EditPoints);
                        edited = true;
                    }
                }
                else if (txtFAz.Text.IsDouble())
                {
                    double value = txtFAz.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            ((SideShotPoint)CurrentPoint).ForwardAz = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsTravType())
                            {
                                ((SideShotPoint)tmpPoint).ForwardAz = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtBAz_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtBAz.Text.IsEmpty())
                {
                    if (CurrentPoint != null)
                    {
                        ((SideShotPoint)CurrentPoint).BackwardAz = null;

                        urManager.EditPoint(_CurrentPoint, _EditPoints);
                        edited = true;
                    }
                }
                else if (txtBAz.Text.IsDouble())
                {
                    double value = txtBAz.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            ((SideShotPoint)CurrentPoint).BackwardAz = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsTravType())
                            {
                                ((SideShotPoint)tmpPoint).BackwardAz = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtSlpDist_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtSlpDist.Text.IsDouble())
                {
                    double value = txtSlpDist.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            ((SideShotPoint)CurrentPoint).SlopeDistance = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsTravType())
                            {
                                ((SideShotPoint)tmpPoint).SlopeDistance = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtSlpAng_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (txtSlpAng.Text.IsDouble())
                {
                    double value = txtSlpAng.Text.ToDouble();

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            ((SideShotPoint)CurrentPoint).SlopeAngle = value;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            if (tmpPoint.IsTravType())
                            {
                                ((SideShotPoint)tmpPoint).SlopeAngle = value;
                                points.Add(tmpPoint);
                            }
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;
                    }
                }
            }
        }

        private void txtQndm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!ignoreControls && CurrentPoint != null)
            {
                if (!MultiPointsSelected)
                {
                    txtQndm.Text = "Select Parent";
                    qSelectCN = CurrentPoint.CN;
                    qSelect = true;
                    _DisplayPoints = new BindingList<TtPoint>(_EditPoints.Values.Where(p => p.op != OpType.WayPoint &&
                        p.op != OpType.Quondam).ToList());
                    _DisplaySource.DataSource = _DisplayPoints;
                    dgvPoints.ClearSelection();
                    qStartSel = true;
                    EnableQndmSelectMode();
                }
            }
        }

        private void txtCmt_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                string text = txtCmt.Text;
                
                if (!MultiPointsSelected)
                {
                    if (CurrentPoint != null)
                    {
                        CurrentPoint.Comment = text;
                        urManager.EditPoint(_CurrentPoint, _EditPoints);
                        edited = true;
                        UpdateRow(CurrentPoint.CN);
                    }
                }
                else
                {
                    List<TtPoint> points = new List<TtPoint>();
                    TtPoint tmpPoint;

                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        tmpPoint = _DisplayPoints[row.Index];

                        tmpPoint.Comment = text;

                        points.Add(tmpPoint);
                    }

                    urManager.EditPoints(points, _EditPoints);
                    edited = true;

                    UpdateRows(points);
                }
            }
        }

        int tabCtrlHeight = 0;
        private void tabCtrl_Resize(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                Control ctrl = sender as Control;
                if (ctrl.Height != tabCtrlHeight)
                {
                    UseExtraFilters = pnlSubFilter.Height > 1;
                    UpdateFilter();
                    tabCtrlHeight = ctrl.Height;
                }
            }
        }

        private void btnCancelQndm_Click(object sender, EventArgs e)
        {
            qSelect = qStartSel = false;
            ignoreControls = true;
            UpdateFilter();
            dgvPoints.ClearSelection();
            SetFields(CurrentPoint);
            ignoreControls = false;
            DisableQndmSelectMode();
        }


        #region Verify Content
        private void txtPID_Leave(object sender, EventArgs e)
        {
            if (!txtPID.Text.IsInteger())
            {
                MessageBox.Show("PID must have a numeric value.");
                txtPID.Focus();
            }
        }

        private void txtIndex_Leave(object sender, EventArgs e)
        {
            if (!txtIndex.Text.IsInteger())
            {
                MessageBox.Show("Index must have a numeric value.");
                txtIndex.Focus();
            }
        }

        private void txtX_Leave(object sender, EventArgs e)
        {
            if (!txtX.Text.IsDouble())
            {
                MessageBox.Show("X must have a numeric value.");
                txtX.Focus();
            }
        }

        private void txtY_Leave(object sender, EventArgs e)
        {
            if (!txtY.Text.IsDouble())
            {
                MessageBox.Show("Y must have a numeric value.");
                txtY.Focus();
            }
        }

        private void txtZ_Leave(object sender, EventArgs e)
        {
            if (!txtZ.Text.IsDouble())
            {
                MessageBox.Show("Z must have a numeric value.");
                txtZ.Focus();
            }
        }

        private void txtManAcc_Leave(object sender, EventArgs e)
        {
            if (!txtManAcc.Text.IsEmpty() && !txtManAcc.Text.IsDouble())
            {
                MessageBox.Show("ManAcc must have a numeric value.");
                txtManAcc.Focus();
            }
        }

        private void txtFAz_Leave(object sender, EventArgs e)
        {
            if (!txtFAz.Text.IsEmpty() && !txtFAz.Text.IsDouble())
            {
                MessageBox.Show("Forward Azimuth must have a numeric value.");
                txtFAz.Focus();
            }
        }

        private void txtBAz_Leave(object sender, EventArgs e)
        {
            if (!txtBAz.Text.IsEmpty() && !txtBAz.Text.IsDouble())
            {
                MessageBox.Show("Backward Azimuth must have a numeric value.");
                txtBAz.Focus();
            }
        }

        private void txtSlpDist_Leave(object sender, EventArgs e)
        {
            if (!txtSlpDist.Text.IsDouble())
            {
                MessageBox.Show("Slope Distance must have a numeric value.");
                txtSlpDist.Focus();
            }
        }

        private void txtSlpAng_Leave(object sender, EventArgs e)
        {
            if (!txtSlpAng.Text.IsDouble())
            {
                MessageBox.Show("Slope Angle must have a numeric value.");
                txtSlpAng.Focus();
            }
        }
        #endregion
        #endregion


        #region Save / Delete / Undo-Redo
        private bool Save()
        {
            if (edited)
            {
                try
                {
                    TtUtils.ShowWaitCursor();

                    List<TtPoint> origpoints = new List<TtPoint>();
                    List<TtPoint> delpoints = new List<TtPoint>();
                    List<TtPoint> addpoints = new List<TtPoint>();
                    List<string> cns = new List<string>();
                    List<string> cnsAdd = new List<string>();
                    TtPoint tmpPoint;

                    foreach (TtPoint p in _OrigPoints.Values)
                    {
                        if (_EditPoints.ContainsKey(p.CN))
                            origpoints.Add(p);
                        else
                            delpoints.Add(p);
                    }

                    foreach (DataGridViewRow row in dgvPoints.Rows)
                    {
                        if (row.Selected)
                            cns.Add(_DisplayPoints[row.Index].CN);
                    }

                    foreach (KeyValuePair<string,TtPoint> kvp in _EditPoints)
                    {
                        //check valididty of Point
                        if (kvp.Value.IsTravType())
                        {
                            if (((SideShotPoint)kvp.Value).Azimuth == null)
                            {
                                MessageBox.Show(String.Format("Point {0} has no Azimuth", kvp.Value.PID));

                                return false;
                            }
                        }

                        if (!_OrigPoints.ContainsKey(kvp.Key))
                        {
                            addpoints.Add(kvp.Value);
                        }
                    }

                    for (int i = 0; i < addpoints.Count; i++)
                    {
                        tmpPoint = addpoints[i];
                        _EditPoints.Remove(tmpPoint.CN);
                        addpoints[i] = TtUtils.SaveConversion(tmpPoint, _MetaData[tmpPoint.MetaDefCN]);
                    }

                    if (_EditPoints.Count != origpoints.Count)
                        throw new Exception("Point lists dont match for saving.");

                    List<TtPoint> edPoints = _EditPoints.Values.ToList();
                    for (int i = 0; i < edPoints.Count; i++)
                    {
                        tmpPoint = edPoints[i];
                        edPoints[i] = TtUtils.SaveConversion(tmpPoint, _MetaData[tmpPoint.MetaDefCN]);
                    }

                    DAL.SavePoints(origpoints, edPoints);
                    DAL.InsertPoints(addpoints);

                    foreach (TtGroup g in _Groups.Values)
                    {
                        DAL.UpdateGroup(g);
                    }

                    foreach (TtPoint p in delpoints)
                    {
                        DAL.DeletePoint(p);
                    }

                    urManager.ClearHistory();

                    bool adjusted = false;
                    if (PolygonAdjuster.CanAdjust(DAL))
                    {
                        PolygonAdjuster.Adjust(DAL, true);
                        adjusted = true;
                    }

                    if (!_closing)
                    {
                        _OrigPoints = DAL.GetPoints().ToDictionary(p => p.CN, p => p);
                        RefreshData();
                        UpdateView(true);

                        dgvPoints.ClearSelection();
                        ignoreControls = true;

                        foreach (DataGridViewRow row in dgvPoints.Rows)
                        {
                            if (cns.Contains(_DisplayPoints[row.Index].CN))
                                row.Selected = true;
                        }

                        if (dgvPoints.SelectedRows.Count > 1)
                        {
                            SetFields(true);
                        }
                        else if (dgvPoints.SelectedRows.Count > 0)
                        {
                            CurrentPoint = _DisplayPoints[dgvPoints.SelectedRows[0].Index];
                            SetFields(false);
                        }

                        if (adjusted)
                            tsslStatus.Text = "Data Saved";
                        else
                        {
                            tsslStatus.Text = "Data Saved | Polygons NOT Adjusted";
                        }
                    }

                    ignoreControls = false;
                    edited = false;
                }
                catch (Exception ex)
                {
                    TtUtils.HideWaitCursor();
                    TtUtils.WriteError(ex.Message, "MassEditForm:Save", ex.StackTrace);
                    MessageBox.Show("Save Error. See log for details.");
                    return false;
                }
            }

            TtUtils.HideWaitCursor();
            return true;
        }

        private void DeletePoint()
        {
            try
            {
                if (MultiPointsSelected)
                {
                    List<TtPoint> points = GetSelectedPoints();

                    urManager.DeletePoints(points, _EditPoints);
                    UpdateFilter();
                    CurrentPoint = null;
                    pnlInner.Enabled = false;
                    tsslStatus.Text = "Points Deleted";
                }
                else
                {
                    if (CurrentPoint != null)
                    {
                        urManager.DeletePoint(CurrentPoint, _EditPoints);
                        UpdateFilter();
                        CurrentPoint = null;
                        pnlInner.Enabled = false;
                        tsslStatus.Text = "Point Deleted";
                    }
                }

                edited = true;
                dgvPoints.ClearSelection();
                ClearFields();
            }
            catch
            {
                //
            }
        }

        private void ResetPoint()
        {
            try
            {
                int np = 0;

                foreach (TtPoint p in GetSelectedPoints())
                {
                    string cn = p.CN;

                    _EditPoints[cn] = TtUtils.GetConversion(_OrigPoints[cn], _MetaData[_OrigPoints[cn].MetaDefCN]);
                    np++;
                }

                UpdateView(true);

                if (np > 0)
                {
                    tsslStatus.Text = String.Format("Point{0} Reset", np > 1 ? "s" : "");
                }
            }
            catch
            {

            }
        }

        private void ResetAll()
        {
            ignoreControls = true;

            ClearFields();

            txtX1.Text = String.Empty;
            txtY1.Text = String.Empty;
            txtZ1.Text = String.Empty;
            txtX2.Text = String.Empty;
            txtY2.Text = String.Empty;
            txtZ2.Text = String.Empty;

            txtManAcc1.Text = String.Empty;
            txtManAcc2.Text = String.Empty;

            txtR1.Text = String.Empty;
            txtR2.Text = String.Empty;

            txtSD1.Text = String.Empty;
            txtSA1.Text = String.Empty;
            txtFA1.Text = String.Empty;
            txtBA1.Text = String.Empty;

            txtSD2.Text = String.Empty;
            txtSA2.Text = String.Empty;
            txtFA2.Text = String.Empty;
            txtBA2.Text = String.Empty;

            InitFilters();

            RefreshData();

            tsslStatus.Text = "Data Reset";

            edited = false;

            ignoreControls = false;
        }

        private void Undo()
        {
            UndoRedoResult result = urManager.Undo(1, _EditPoints);

            switch (result)
            {
                case UndoRedoResult.Delete:
                    UpdateView(true);
                    dgvPoints.ClearSelection();
                    ClearFields();
                    CurrentPoint = null;

                    List<string> cns = _EditPoints
                        .Where(kvp => kvp.Value == null)
                        .Select(k => k.Key).ToList();

                    foreach (string cn in cns)
                        _EditPoints.Remove(cn);
                    break;
                case UndoRedoResult.Multi:
                    UpdateView(true);
                    break;
                case UndoRedoResult.Single:
                    UpdateView(false);
                    break;
                case UndoRedoResult.None:
                    break;
            }

            if (result != UndoRedoResult.None)
                tsslStatus.Text = "Action Undone.";
        }

        private void Redo()
        {
            UndoRedoResult result = urManager.Redo(1, _EditPoints);

            switch (result)
            {
                case UndoRedoResult.Multi:
                    UpdateView(true);
                    break;
                case UndoRedoResult.Single:
                    UpdateView(false);
                    break;
                case UndoRedoResult.None:
                    break;
            }

            if (result != UndoRedoResult.None)
                tsslStatus.Text = "Action Redone.";
        }
        #endregion


        #region Rename / Write / Fix / Edit

        private void Rename()
        {
            if (dgvPoints.SelectedRows.Count > 0)
            {
                int pi = 0;
                bool reverse = false;

                if (dgvPoints.SelectedRows.Count == 1 || dgvPoints.SelectedRows[0].Index < dgvPoints.SelectedRows[dgvPoints.SelectedRows.Count - 1].Index)
                    pi = dgvPoints.SelectedRows[0].Index;
                else
                {
                    pi = dgvPoints.SelectedRows[dgvPoints.SelectedRows.Count - 1].Index;
                    reverse = true;
                }

                TtPoint firstPoint = _DisplayPoints[pi];

                int si = firstPoint.PID;
                int inc = 10;
                int currPid;

                using (RenamePointPromptForm form = new RenamePointPromptForm(si, inc))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        si = form.StartIndex;
                        currPid = si;
                        inc = form.Increment;
                    }
                    else
                        return;
                }

                List<TtPoint> points = new List<TtPoint>();
                TtPoint tmpPoint;

                if (MultiPointsSelected)
                {
                    if (reverse)
                    {
                        currPid += inc * (dgvPoints.SelectedRows.Count -1);
                    }

                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        tmpPoint = _DisplayPoints[row.Index];

                        tmpPoint.PID = currPid;

                        if (reverse)
                            currPid -= inc;
                        else
                            currPid += inc;

                        points.Add(tmpPoint);
                    }
                }
                else
                {
                    for (int i = pi; i < dgvPoints.Rows.Count; i++)
                    {
                        tmpPoint = _DisplayPoints[i];

                        tmpPoint.PID = currPid;
                        currPid += inc;

                        points.Add(tmpPoint);
                    }
                }

                //if (MessageBox.Show(String.Format("{0} Points will be renamed.", points.Count), "Rename Points",
                //    MessageBoxButtons.OKCancel, MessageBoxIcon.Hand,
                //    MessageBoxDefaultButton.Button1) == DialogResult.OK)
                //{
                    urManager.EditPoints(points, _EditPoints);
                    edited = true;

                    UpdateRows(points);
                    tsslStatus.Text = "Points Renamed";
                //}
            }
        }

        private void ExportPoints(bool allpoints)
        {
            if (edited)
            {
                DialogResult dr = MessageBox.Show("Data has been edited. Do you want to save before exporting?",
                    "Export Points", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand,
                    MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Yes)
                {

                }
                else if (dr == DialogResult.Cancel)
                    return;
            }

            bool success = false;

            using (SaveFileDialog ofd = new SaveFileDialog())
            {
                ofd.Filter = "CSV|*.csv|All Files|*.*";
                ofd.InitialDirectory = Values.DataExport.SelectedPath;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (allpoints)
                        success = ExportPoints(_EditPoints.Values.ToList(), ofd.FileName);
                    else
                        success = ExportPoints(_DisplayPoints.ToList(), ofd.FileName);
                }
            }

            if (success)
                MessageBox.Show("Points Exported");
        }

        private bool ExportPoints(List<TtPoint> points, string filename)
        {
            if (points != null && points.Count > 0)
            {
                List<string> Columns = new List<string>();
                List<List<string>> data = new List<List<string>>();
                List<TtMetaData> meta = _MetaData.Values.ToList();
                List<string> metaCNs = new List<string>();

                foreach (TtMetaData m in meta)
                {
                    metaCNs.Add(m.CN);
                }

                #region Columns
                Columns.Add("Point ID");    //0
                Columns.Add("CN");
                Columns.Add("Operation");
                Columns.Add("Index");
                Columns.Add("Poly Name");
                Columns.Add("Poly CN");     //5
                Columns.Add("Group Name");
                Columns.Add("Group CN");
                Columns.Add("DateTime");
                Columns.Add("Metadata");
                Columns.Add("OnBnd");       //10
                Columns.Add("AdjX");
                Columns.Add("AdjY");
                Columns.Add("AdjZ");
                Columns.Add("UnAdjX");
                Columns.Add("UnAdjY");      //15
                Columns.Add("UnAdjZ");
                Columns.Add("X");
                Columns.Add("Y");
                Columns.Add("Z");
                Columns.Add("RMSEr");       //20
                Columns.Add("Man Acc");
                Columns.Add("Fwd Az");
                Columns.Add("Back Az");
                Columns.Add("Slope Dist");
                Columns.Add("Slope Angle"); //25
                Columns.Add("Horiz Dist");
                Columns.Add("Declination");
                Columns.Add("Parent Name");
                Columns.Add("Parent CN");   //29
                Columns.Add("Comment");
                Columns.Add("Linked CNs");  //31
                #endregion

                #region Add Data
                try
                {
                    foreach (TtPoint p in points)
                    {
                        List<string> pl = new List<string>();

                        pl.Add(p.PID.ToString());   //0
                        pl.Add(p.CN);
                        pl.Add(p.op.ToString());
                        pl.Add(p.Index.ToString());
                        pl.Add(p.PolyName);
                        pl.Add(p.PolyCN);           //5
                        pl.Add(p.GroupName);
                        pl.Add(p.GroupCN);
                        pl.Add(p.Time.ToString());


                        try
                        {
                            pl.Add(meta[metaCNs.IndexOf(p.MetaDefCN)].Name);
                        }
                        catch
                        {
                            pl.Add(p.MetaDefCN);
                        }

                        pl.Add(p.OnBnd.ToString()); //10
                        pl.Add(p.AdjX.ToString());
                        pl.Add(p.AdjY.ToString());
                        pl.Add(p.AdjZ.ToString());
                        pl.Add(p.UnAdjX.ToString());
                        pl.Add(p.UnAdjY.ToString());//15
                        pl.Add(p.UnAdjZ.ToString());

                        if (p.IsGpsType())
                        {
                            pl.Add(p.UnAdjX.ToString());
                            pl.Add(p.UnAdjY.ToString());
                            pl.Add(p.UnAdjZ.ToString());
                            pl.Add(((GpsPoint)p).RMSEr.ToString()); //20
                            pl.Add(((GpsPoint)p).ManualAccuracy.ToString());
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++) { pl.Add(""); }
                        }

                        if (p.IsTravType())
                        {
                            pl.Add(((SideShotPoint)p).ForwardAz.ToString());
                            pl.Add(((SideShotPoint)p).BackwardAz.ToString());
                            pl.Add(((SideShotPoint)p).SlopeDistance.ToString());
                            pl.Add(((SideShotPoint)p).SlopeAngle.ToString());   //25
                            pl.Add(((SideShotPoint)p).HorizontalDistance.ToString());
                            pl.Add(((SideShotPoint)p).Declination.ToString());
                        }
                        else
                        {
                            for (int i = 0; i < 6; i++) { pl.Add(""); }
                        }

                        if (p.op == OpType.Quondam)
                        {
                            pl.Add(((QuondamPoint)p).ParentPID.ToString());
                            pl.Add(((QuondamPoint)p).ParentCN);
                        }
                        else
                        {
                            pl.Add(""); pl.Add("");
                        }

                        pl.Add(p.Comment);  //30

                        StringBuilder sb = new StringBuilder();
                        foreach (string link in p.LinkedPoints)
                        {
                            sb.Append(link + "_");  //31
                        }

                        pl.Add(sb.ToString());

                        data.Add(pl);
                    }
                #endregion

                    return TtUtils.WriteCsvFile(filename, Columns, data);
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "MassEdit:ExportPoints", ex.StackTrace);
                }
            }

            return false;
        }

        private void FixPoints()
        {
            ignoreControls = true;

            if (init)
            {
                List<TtPoint> fixedPoints = new List<TtPoint>();

                foreach (KeyValuePair<string, TtPoint> kvp in _EditPoints)
                {
                    if (kvp.Value.HasErrors(_MetaData, _Groups))
                        fixedPoints.Add(kvp.Value.Fix(DAL, _MetaData, _Groups));
                }

                urManager.EditPoints(fixedPoints, _EditPoints);

                _Groups = DAL.GetGroups().ToDictionary(d => d.CN, d => d);
                _MetaData = DAL.GetMetaData().ToDictionary(m => m.CN, m => m);

                dgvPoints.ClearSelection();

                cboMeta.DisplayMember = "Name";
                cboMeta.ValueMember = "CN";
                cboMeta.DataSource = _MetaData.Values.ToList();

                cboGroup.Sorted = true;
                cboGroup.DisplayMember = "Name";
                cboGroup.ValueMember = "CN";
                cboGroup.DataSource = _Groups.Values.ToList();
            }
            else
            {
                if (MessageBox.Show("You can not undo fixing points. Do you want to continue?", "Fix Points", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    foreach (TtPoint point in DAL.GetPoints())
                    {
                        if (point.HasErrors(_MetaData, _Groups))
                        {
                            DAL.SavePoint(point, point.Fix(DAL, _MetaData, _Groups));
                        }
                    }

                    PolygonAdjuster.Adjust(DAL);

                    _OrigPoints = DAL.GetPoints().ToDictionary(p => p.CN, p => p);
                    _EditPoints = new Dictionary<string, TtPoint>();
                    _Polygons = DAL.GetPolygons().ToDictionary(p => p.CN, p => p);
                    _Groups = DAL.GetGroups().ToDictionary(d => d.CN, d => d);
                    _MetaData = DAL.GetMetaData().ToDictionary(m => m.CN, m => m);

                    if (RefreshData())
                    {
                        init = true;
                        tsmiPointsHaveErrors.Visible = false;
                        pnlInner.Enabled = true;
                        tabCtrl.Enabled = true;
                        UpdateFilter();
                    }
                    else
                    {
                        MessageBox.Show("???");
                    }
                }
            }

            ignoreControls = false;

        }

        private void MovePoints(bool qndm)
        {
            List<TtPoint> points = new List<TtPoint>();

            foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                points.Add(_DisplayPoints[row.Index]);

            using (MassEditPointLocManip form = new MassEditPointLocManip(_Polygons.Values.ToList(), _EditPoints.Values.ToList(),
                points, !qndm, DAL))
            {
                DialogResult dr = form.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (form.EditedPoints.Count > 0)
                    {
                        urManager.EditPoints(form.EditedPoints, _EditPoints);
                        edited = true;
                    }

                    if (form.AddedPoints.Count > 0)
                    {
                        urManager.AddPoints(form.AddedPoints, _EditPoints);
                        edited = true;
                    }

                    if(edited)
                        UpdateView(true);
                }
                else if (dr == DialogResult.Abort)
                {
                    MessageBox.Show("An Error has occured. See log for details.");
                }
            }
        }
        #endregion


        #region Options
        private void UpdateSettings()
        {
            if (Values.Settings.DeviceOptions.FormMassEditElevationFeet)
                lblAltType.Text = "(Ft)";
            else
                lblAltType.Text = "(M)";
        }
        #endregion


        #region Menu Controls
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (!Save())
            {
                MessageBox.Show("Save Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            int rows = dgvPoints.SelectedRows.Count;

            if(rows < 1)
                return;

#if DEBUG
#else
            if (!deleteWOAsk)
            {
                string text = String.Format("You are deleting {0}",
                    rows > 1 ? "several points." : String.Format("point {0}.",
                        _DisplayPoints[dgvPoints.SelectedRows[0].Index].PID) );

                string text2 = String.Format("Delete Point{0}", rows > 1 ? "s" : "");

                MessageWCheckResult result = DeleteMessageWCheck.Show(text, text2, "Do not ask again.");

                switch (result)
                {
                    case MessageWCheckResult.YesChecked:
                        deleteWOAsk = true;
                        break;
                    case MessageWCheckResult.Yes:
                        break;
                    case MessageWCheckResult.NoChecked:
                        deleteWOAsk = true;
                        return;
                    case MessageWCheckResult.No:
                    case MessageWCheckResult.None:
                        return;
                }

            }
#endif

            DeletePoint();
        }

        private void tsmiResetPoint_Click(object sender, EventArgs e)
        {
            int rows = dgvPoints.SelectedRows.Count;

            if (rows < 1)
                return;

            if (!resetWOAsk)
            {
                string text = String.Format("You are resetting {0}",
                    rows > 1 ? "several points." : String.Format("point {0}.",
                        _DisplayPoints[dgvPoints.SelectedRows[0].Index].PID));

                string text2 = String.Format("Reset Point{0}", rows > 1 ? "s" : "");

                MessageWCheckResult result = DeleteMessageWCheck.Show(text, text2, "Do not ask again.");

                switch (result)
                {
                    case MessageWCheckResult.YesChecked:
                        resetWOAsk = true;
                        break;
                    case MessageWCheckResult.Yes:
                        break;
                    case MessageWCheckResult.NoChecked:
                        resetWOAsk = true;
                        return;
                    case MessageWCheckResult.No:
                    case MessageWCheckResult.None:
                        return;
                }

            }

            ResetPoint();
        }

        private void tsmiResetAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to reset all your points. You will lose all changes. Continue?") == DialogResult.Yes)
            {
                ResetAll();
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void tsmiExportCurr_Click(object sender, EventArgs e)
        {
            ExportPoints(false);
        }

        private void tsmiExportAll_Click(object sender, EventArgs e)
        {
            ExportPoints(true);
        }

        private void tsmiFixPoints_Click(object sender, EventArgs e)
        {
            FixPoints();
        }

        private void tsmiAdvEdit_Click(object sender, EventArgs e)
        {
            AdvEdit = tsmiAdvEdit.Checked;
        }

        private void tsmiAdvInfo_Click(object sender, EventArgs e)
        {
            AdvInfo = tsmiAdvInfo.Checked;
        }
        
        private void tsmiOptions_Click(object sender, EventArgs e)
        {
            using (MassEditOptions form = new MassEditOptions())
            {
                form.ShowDialog();

                UpdateSettings();

                ColorRows();

                if(AdvInfo)
                    UpdateAdvInfo();
            }
        }

        private void tsmiNewPoly_Click(object sender, EventArgs e)
        {
            int num = (int)(DAL.GetPolyCount() + 1);
            using (MassEditNewPoly form = new MassEditNewPoly(String.Format("Poly {0}", num), (num * 1000) + 10))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DAL.InsertPolygon(form.Poly);

                    ignoreControls = true;
                    _Polygons.Add(form.Poly.CN, form.Poly);
                    _PolygonColors.Add(form.Poly.CN, _Colors[numColors % _Colors.Count]);
                    numColors++;

                    cboPoly.DataSource = _Polygons.Values.ToList();
                    chkLstPolyFilter.Items.Add(form.Poly, true);

                    numColors++;

                    UpdateView(MultiPointsSelected);
                    ColorRows();
                    SetFields(MultiPointsSelected);
                    ignoreControls = false;
                }
            }
        }

        private void tsmiNewGroup_Click(object sender, EventArgs e)
        {
            using (MassEditNewGroup form = new MassEditNewGroup())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ignoreControls = true;

                    _Groups.Add(form.Group.CN, form.Group);
                    DAL.InsertGroup(form.Group);

                    chkLstGroupFilter.Items.Add(form.Group, true);
                    _Groups.Add(form.Group.CN, form.Group);

                    cboGroup.DataSource = null;
                    cboGroup.Sorted = true;
                    cboGroup.DisplayMember = "Name";
                    cboGroup.ValueMember = "CN";
                    cboGroup.DataSource = _Groups.Values.ToList();
                    ignoreControls = false;

                    if (!MultiPointsSelected)
                    {
                        if (CurrentPoint != null)
                        {
                            CurrentPoint.GroupCN = form.Group.CN;
                            CurrentPoint.GroupName = form.Group.Name;

                            urManager.EditPoint(_CurrentPoint, _EditPoints);
                            edited = true;
                            UpdateRow(CurrentPoint.CN);
                            SetFields(false);
                        }
                    }
                    else
                    {
                        List<TtPoint> points = new List<TtPoint>();
                        TtPoint tmpPoint;

                        foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                        {
                            tmpPoint = _DisplayPoints[row.Index];

                            tmpPoint.GroupCN = form.Group.CN;
                            tmpPoint.GroupName = form.Group.Name;

                            points.Add(tmpPoint);
                        }

                        urManager.EditPoints(points, _EditPoints);
                        edited = true;

                        UpdateRows(points);
                        SetFields(true);
                    }
                }
            }
        }


        private void ctsmiUndo_Click(object sender, EventArgs e)
        {
            tsmiUndo_Click(sender, e);
        }

        private void ctsmiRedo_Click(object sender, EventArgs e)
        {
            tsmiRedo_Click(sender, e);
        }

        private void ctsmiReset_Click(object sender, EventArgs e)
        {
            tsmiResetPoint_Click(sender, e);
        }

        private void ctsmiDelete_Click(object sender, EventArgs e)
        {
            tsmiDelete_Click(sender, e);
        }

        private void ctsmiRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void ctsmiCopyValue_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(currCellValue);
        }

        private void ctsmiCopyPointInfo_Click(object sender, EventArgs e)
        {
            if (MultiPointsSelected)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgvPoints.SelectedRows.Count; i++)
                {
                    TtPoint p = _DisplayPoints[dgvPoints.SelectedRows[i].Index];

                    sb.AppendLine(String.Format(
                    "PID: {0, -5}  Poly Name: {1, -8}  Op: {2,-7}  Index: {3,-3}  OnBnd: {4,-5}  " +
                    "AdjX: {5,-16}  AdjY: {6,-16}  AdjZ: {7,-16}  Group Name: {8, -14}  Comment: {9}",
                    p.PID, p.PolyName, p.op.ToString(), p.Index, p.OnBnd, p.AdjX, p.AdjY, p.AdjZ,
                    p.GroupName, p.Comment));
                }

                Clipboard.SetText(sb.ToString());
            }
            else if (_DisplayPoints.Count > 0 && currCellIndex > -1)
            {
                TtPoint p = _DisplayPoints[currCellIndex];
                Clipboard.SetText(String.Format(
                    "PID: {0, -5}  Poly Name: {1, -8}  Op: {2,-7}  Index: {3,-3}  OnBnd: {4,-5}  " +
                    "AdjX: {5,-16}  AdjY: {6,-16}  AdjZ: {7,-16}  Group Name: {8, -14}  Comment: {9}",
                    p.PID, p.PolyName, p.op.ToString(), p.Index, p.OnBnd, p.AdjX, p.AdjY, p.AdjZ,
                    p.GroupName, p.Comment));
            }
        }

        private void ctsmiChangePoly_Click(object sender, EventArgs e)
        {
            MovePoints(false);
        }

        private void ctsmiCreateQndm_Click(object sender, EventArgs e)
        {
            MovePoints(true);
        }

        private void tsmiEveryOther_Click(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (MultiPointsSelected)
                {
                    bool odd = false;

                    if (dgvPoints.SelectedRows.Count % 2 == 0)
                        odd = true;

                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        if (odd)
                        {
                            odd = false;
                            row.Selected = false;
                        }
                        else
                        {
                            odd = true;
                        }
                    }
                }
                else
                {
                    bool selected = true;

                    if (dgvPoints.SelectedRows.Count % 2 == 0)
                        selected = false;

                    foreach (DataGridViewRow row in dgvPoints.Rows)
                    {
                        row.Selected = selected;
                        selected = !selected;
                    }
                }
            }
        }

        private void tsmiReversePoints_Click(object sender, EventArgs e)
        {
            if (!ignoreControls && MultiPointsSelected)
            {
                List<TtPoint> points = new List<TtPoint>();
                TtPoint tmpPoint, tmpPoint2;

                int count = dgvPoints.SelectedRows.Count;
                long tmpIndex = 0;

                for (int i = 0; i < count / 2; i++)
                {
                    tmpPoint = _DisplayPoints[dgvPoints.SelectedRows[i].Index];

                    tmpPoint2 = _DisplayPoints[dgvPoints.SelectedRows[count - 1 - i].Index];

                    tmpIndex = tmpPoint.Index;
                    tmpPoint.Index = tmpPoint2.Index;
                    tmpPoint2.Index = tmpIndex;

                    points.Add(tmpPoint);
                    points.Add(tmpPoint2);
                }

                urManager.EditPoints(points, _EditPoints);
                edited = true;

                UpdateView(true);
                SetFields(true);
            }
        }

        private void tsmiSelectGPS_Click(object sender, EventArgs e)
        {
            if (!ignoreControls )
            {
                if (MultiPointsSelected)
                {
                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        row.Selected = _DisplayPoints[row.Index].op == OpType.GPS;
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvPoints.Rows)
                    {
                        row.Selected = _DisplayPoints[row.Index].op == OpType.GPS;
                    }
                }
            }
        }

        private void tsmiSelectSideShots_Click(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                if (MultiPointsSelected)
                {
                    foreach (DataGridViewRow row in dgvPoints.SelectedRows)
                    {
                        row.Selected = _DisplayPoints[row.Index].op == OpType.SideShot;
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvPoints.Rows)
                    {
                        row.Selected = _DisplayPoints[row.Index].op == OpType.SideShot;
                    }
                }
            }
        }

        private void tsmiDeselectPoints_Click(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                foreach (DataGridViewRow row in dgvPoints.Rows)
                {
                    row.Selected = false;
                }
            }
        }

        private void tsmiSelectInverse_Click(object sender, EventArgs e)
        {
            if (!ignoreControls)
            {
                foreach (DataGridViewRow row in dgvPoints.Rows)
                {
                    row.Selected = !row.Selected;
                }
            }
        }
        #endregion


        #region Const Strings
        private const string PID = "Point ID";
        private const string CN = "CN";
        private const string OP = "Operation";
        private const string INDX = "Index";
        private const string POLY = "Poly Name";
        private const string POLYCN = "Poly CN";
        private const string DATETIME = "DateTime";
        private const string META = "Metadata";
        private const string ONBND = "OnBnd";
        private const string aX = "AdjX";
        private const string aY = "AdjY";
        private const string aZ = "AdjZ";
        private const string uX = "UnAdjX";
        private const string uY = "UnAdjY";
        private const string uZ = "UnAdjZ";
        private const string x = "X";
        private const string y = "Y";
        private const string z = "Z";
        private const string rmser = "RMSEr";
        private const string manacc = "ManAcc";
        private const string fA = "Fwd Az";
        private const string bA = "Back Az";
        private const string sD = "Slope Dist";
        private const string sA = "Slope Angle";
        private const string hD = "Horz Dist";
        private const string dec = "Declination";
        private const string pN = "Parent Name";
        private const string pp = "Parent Poly";
        private const string ql = "Qndm Links";
        private const string CMT = "Comment";
        private const string GN = "Group Name";
        #endregion
    }

    public enum TbStatus
    {
        OK,
        Bad,
        Empty
    }
}
