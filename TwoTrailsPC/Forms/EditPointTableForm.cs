using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.Engine;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class EditPointTableForm : Form
    {
        #region Const Strings
        private const string PID = "Point ID";
        private const string CN = "CN";
        private const string OP = "Operation";
        private const string INDX = "Index";
        private const string POLY = "Poly Name";
        private const string POLYCN = "Poly CN";
        private const string GROUP = "Group Name";
        private const string GROUPCN = "Group ID";
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
        private const string pointAcc = "Point Acc (M)";
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
        #endregion

        DataAccessLayer DAL;

        bool _close = false;
        bool _edited = false;


        List<TtPoint> OrigPoints;
        List<TtPoint> EditPoints;


        DataTable OrigTable;
        DataTable EditTable;

        BindingSource bindPoints;

        Dictionary<string, TtMetaData> _metas;
        Dictionary<string, TtPolygon> _polys;
        List<bool> _editedPoints;


        public EditPointTableForm(DataAccessLayer d)
        {
            InitializeComponent();
            DAL = d;
        }

        private void EditPointTableForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Map;
            LoadData();
        }

        private void LoadData()
        {
            _editedPoints = new List<bool>();
            _polys = DAL.GetPolygons().ToDictionary(p => p.CN, p => p);

            SetupDataTables();

            SetupGridView();

            tsslStatus.Text = "Table Loaded";
        }

        private void SetupDataTables()
        {
            try
            {
                OrigTable = new DataTable();

                OrigTable.Columns.Add(PID, typeof(int));            //0
                OrigTable.Columns.Add(CN, typeof(string));
                OrigTable.Columns.Add(OP, typeof(OpType));
                OrigTable.Columns.Add(INDX, typeof(int));
                OrigTable.Columns.Add(POLY, typeof(string));
                OrigTable.Columns.Add(POLYCN, typeof(string));      //5
                OrigTable.Columns.Add(DATETIME, typeof(DateTime));
                OrigTable.Columns.Add(META, typeof(TtMetaData));
                OrigTable.Columns.Add(ONBND, typeof(bool));
                OrigTable.Columns.Add(GROUP, typeof(string));
                OrigTable.Columns.Add(GROUPCN, typeof(string));     //10
                OrigTable.Columns.Add(aX, typeof(double));
                OrigTable.Columns.Add(aY, typeof(double));          
                OrigTable.Columns.Add(aZ, typeof(double));
                OrigTable.Columns.Add(uX, typeof(double));
                OrigTable.Columns.Add(uY, typeof(double));          //15
                OrigTable.Columns.Add(uZ, typeof(double));
                OrigTable.Columns.Add(x, typeof(double));           
                OrigTable.Columns.Add(y, typeof(double));
                OrigTable.Columns.Add(z, typeof(double));
                OrigTable.Columns.Add(rmser, typeof(double));       //20
                OrigTable.Columns.Add(pointAcc, typeof(double));       
                OrigTable.Columns.Add(manacc, typeof(double));
                OrigTable.Columns.Add(fA, typeof(double));         
                OrigTable.Columns.Add(bA, typeof(double));
                OrigTable.Columns.Add(sD, typeof(double));          //25
                OrigTable.Columns.Add(sA, typeof(double));          
                OrigTable.Columns.Add(hD, typeof(double));
                OrigTable.Columns.Add(dec, typeof(double));         
                OrigTable.Columns.Add(pN, typeof(string));
                OrigTable.Columns.Add(pp, typeof(string));          //30   
                OrigTable.Columns.Add(ql, typeof(string));          
                OrigTable.Columns.Add(CMT, typeof(string));         //32

                //set read only
                OrigTable.Columns[1].ReadOnly = true;
                OrigTable.Columns[2].ReadOnly = true;
                OrigTable.Columns[4].ReadOnly = true;
                OrigTable.Columns[5].ReadOnly = true;
                OrigTable.Columns[6].ReadOnly = true;
                OrigTable.Columns[9].ReadOnly = true;
                OrigTable.Columns[10].ReadOnly = true;
                OrigTable.Columns[14].ReadOnly = true;
                OrigTable.Columns[15].ReadOnly = true;
                OrigTable.Columns[16].ReadOnly = true;
                OrigTable.Columns[20].ReadOnly = true;
                OrigTable.Columns[21].ReadOnly = true;
                OrigTable.Columns[28].ReadOnly = true;
                OrigTable.Columns[29].ReadOnly = true;
                OrigTable.Columns[30].ReadOnly = true;
                OrigTable.Columns[31].ReadOnly = true;

                AddDataToTable(OrigTable);

                EditTable = OrigTable.Copy();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTable:SetupDataTables", ex.StackTrace);
            }
        }

        private void AddDataToTable(DataTable table)
        {
            OrigPoints = DAL.GetPoints();
            OrigPoints.Sort();
            EditPoints = new List<TtPoint>();

            TtPoint point;
            GpsPoint gps;
            SideShotPoint ss;
            QuondamPoint qp;

            _metas = DAL.GetMetaData().ToDictionary(m => m.CN, m => m);

            if (_metas.Count < 1)
                throw new Exception("No Metadata");

            DataRow row;

            OrigTable.BeginLoadData();

            for (int i = 0; i < OrigPoints.Count; i++)
            {
                point = OrigPoints[i];

                if(_metas.ContainsKey(point.MetaDefCN))
                    point = TtUtils.GetConversion(point, _metas[point.MetaDefCN]);
                else
                    point = TtUtils.GetConversion(point, _metas.Values.ToList()[0]);
                EditPoints.Add(point);

                row = OrigTable.NewRow();
                row.BeginEdit();

                try
                {
                    row[0] = point.PID;
                    row[1] = point.CN;
                    row[2] = point.op;
                    row[3] = point.Index;
                    row[4] = point.PolyName;
                    row[5] = point.PolyCN;
                    row[6] = point.Time;
                    row[7] = _metas[point.MetaDefCN];
                    row[8] = point.OnBnd;
                    row[9] = (point.GroupName == null) ? "" : point.GroupName;
                    row[10] = (point.GroupCN == null) ? "" : point.GroupCN;
                    row[11] = point.AdjX;
                    row[12] = point.AdjY;
                    row[13] = point.AdjZ;
                    row[14] = point.UnAdjX;
                    row[15] = point.UnAdjY;
                    row[16] = point.UnAdjZ;

                    if (point.IsGpsType())
                    {
                        gps = (GpsPoint)point;

                        row[17] = gps.UnAdjX;
                        row[18] = gps.UnAdjY;
                        row[19] = gps.UnAdjZ;

                        if (gps.RMSEr != null) { row[20] = gps.RMSEr; }

                        if (gps.ManualAccuracy != null) { row[22] = gps.ManualAccuracy; }
                    }

                    row[21] = TtUtils.GetPointAcc(point, _polys);

                    if (point.IsTravType())
                    {
                        ss = (SideShotPoint)point;

                        if (ss.ForwardAz != null) { row[23] = ss.ForwardAz; }
                        if (ss.BackwardAz != null) { row[24] = ss.BackwardAz; }
                        row[25] = ss.SlopeDistance;
                        row[26] = ss.SlopeAngle;
                        row[27] = ss.HorizontalDistance;
                        row[28] = ss.Declination;
                    }

                    if (point.op == OpType.Quondam)
                    {
                        qp = (QuondamPoint)point;

                        row[29] = qp.ParentPID;
                        row[30] = qp.ParentPoly;
                    }

                    if (point.HasQuondamLinks)
                        row[31] = "Yes";
                    else
                        row[31] = "No";

                    row[32] = point.Comment;
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "EditPointTable:AddDataToTable", ex.StackTrace);
                }

                row.EndEdit();
                OrigTable.Rows.Add(row);

                _editedPoints.Add(false);
            }

            OrigTable.EndLoadData();
        }

        private void SetupGridView()
        {
            bindPoints = new BindingSource();
            bindPoints.DataSource = EditTable;


            dataGridPoints.Columns.Clear();
            dataGridPoints.MultiSelect = false;
            dataGridPoints.RowHeadersVisible = false;
            dataGridPoints.AutoGenerateColumns = false;
            dataGridPoints.DataSource = bindPoints;

            DataGridViewTextBoxColumn dtb;
            DataGridViewComboBoxColumn dcb;
            DataGridViewCheckBoxColumn dchk;

            //PID
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = PID;
            dtb.Name = PID;
            dataGridPoints.Columns.Add(dtb);

            //CN
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = CN;
            dtb.Name = CN;
            dtb.ReadOnly = true;
            dtb.Visible = false;
            dataGridPoints.Columns.Add(dtb);

            //OpType
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = OP;
            dtb.Name = OP;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Index
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = INDX;
            dtb.Name = INDX;
            dataGridPoints.Columns.Add(dtb);

            //Poly Name
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = POLY;
            dtb.Name = POLY;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Poly CN
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = POLYCN;
            dtb.Name = POLYCN;
            dtb.ReadOnly = true;
            dtb.Visible = false;
            dataGridPoints.Columns.Add(dtb);

            //Date Time
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = DATETIME;
            dtb.Name = DATETIME;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Meta Data
            dcb = new DataGridViewComboBoxColumn();
            dcb.HeaderText = META;
            dcb.DataPropertyName = META;
            dcb.Name = META;
            dcb.DataSource = _metas.Values.ToList();
            //dcb.ValueMember = "Self";
            dcb.DisplayMember = "Name";
            dcb.ValueType = typeof(TtMetaData);
            dataGridPoints.Columns.Add(dcb);

            //On Bound
            dchk = new DataGridViewCheckBoxColumn();
            dchk.DataPropertyName = ONBND;
            dchk.Name = ONBND;
            dataGridPoints.Columns.Add(dchk);

            //Group Name
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = GROUP;
            dtb.Name = GROUP;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Group CN
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = GROUPCN;
            dtb.Name = GROUPCN;
            dtb.ReadOnly = true;
            dtb.Visible = false;
            dataGridPoints.Columns.Add(dtb);

            //Adj X
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = aX;
            dtb.Name = aX;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Adj Y
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = aY;
            dtb.Name = aY;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Adj Z
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = aZ;
            dtb.Name = aZ;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //UnAdj X
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = uX;
            dtb.Name = uX;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //UnAdj Y
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = uY;
            dtb.Name = uY;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //UnAdj Z
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = uZ;
            dtb.Name = uZ;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //X
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = x;
            dtb.Name = x;
            dtb.Visible = false;
            dataGridPoints.Columns.Add(dtb);

            //Y
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = y;
            dtb.Name = y;
            dtb.Visible = false;
            dataGridPoints.Columns.Add(dtb);

            //Z
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = z;
            dtb.Name = z;
            dtb.Visible = false;
            dataGridPoints.Columns.Add(dtb);

            //RMSEr
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = rmser;
            dtb.Name = rmser;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Man Acc
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = pointAcc;
            dtb.Name = pointAcc;
            dataGridPoints.Columns.Add(dtb);

            //Man Acc
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = manacc;
            dtb.Name = manacc;
            dataGridPoints.Columns.Add(dtb);

            //Fwd Az
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = fA;
            dtb.Name = fA;
            dataGridPoints.Columns.Add(dtb);

            //Back Az
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = bA;
            dtb.Name = bA;
            dataGridPoints.Columns.Add(dtb);

            //Slope Dist
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = sD;
            dtb.Name = sD;
            dataGridPoints.Columns.Add(dtb);

            //Slope Angle
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = sA;
            dtb.Name = sA;
            dataGridPoints.Columns.Add(dtb);

            //Horiz Dist
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = hD;
            dtb.Name = hD;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Declination
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = dec;
            dtb.Name = dec;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Parent Name
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = pN;
            dtb.Name = pN;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Parent Poly
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = pp;
            dtb.Name = pp;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Qndm Link
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = ql;
            dtb.Name = ql;
            dtb.ReadOnly = true;
            dataGridPoints.Columns.Add(dtb);

            //Comment
            dtb = new DataGridViewTextBoxColumn();
            dtb.DataPropertyName = CMT;
            dtb.Name = CMT;
            dataGridPoints.Columns.Add(dtb);

            dataGridPoints.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);

            dataGridPoints.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridPoints.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridPoints.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridPoints.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            for (int i = 11; i < 21; i++)
            {
                dataGridPoints.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            for (int i = 0; i < EditPoints.Count; i++)
            {
                if (!EditPoints[i].IsGpsType())
                {
                    dataGridPoints[17, i].ReadOnly = true;
                    dataGridPoints[18, i].ReadOnly = true;
                    dataGridPoints[19, i].ReadOnly = true;
                }
            }

            foreach (DataGridViewColumn col in dataGridPoints.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void EditPointTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_close && _edited)
            {
                if (MessageBox.Show("You are exiting without saving. Do you wish to save your data?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!Save())
                    {
                        //error
                        e.Cancel = true;
                    }
                }
            }
        }


        private void dataGridPoints_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int ci = e.ColumnIndex;

            if ((ci == 0 || ci == 3) && ((string)e.FormattedValue).IsEmpty())
            {
                dataGridPoints.CancelEdit();
                e.Cancel = true;
                return;
            }
            else if (ci == 8 || ci == 7)
            {
                //onbnd and meta, handled in cell value changed
            }
            else
            {
                OpType op = (OpType)OrigTable.Rows[e.RowIndex][OP];

                if ((ci > 17 && ci < 20) && ((string)e.FormattedValue).IsEmpty())
                {
                    return;
                }
                //gps types
                else if (ci == 22 && (op != OpType.GPS && op != OpType.Take5 &&
                    op != OpType.Walk && op != OpType.WayPoint))
                {
                    //dataGridPoints.CancelEdit();

                    string o = (string)e.FormattedValue;
                    if (o.IsEmpty())
                        return;

                    e.Cancel = true;
                    MessageBox.Show("Only GPS type points can have this field edited.",
                        "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Hand,
                        MessageBoxDefaultButton.Button1);
                    return;
                }
                //sideshot - traverse
                else if ((ci > 22 && ci < 27) && (op != OpType.SideShot &&
                    op != OpType.Traverse))
                {
                    //dataGridPoints.CancelEdit();

                    string o = (string)e.FormattedValue;
                    if (o.IsEmpty())
                        return;

                    e.Cancel = true;
                    MessageBox.Show("Only Traverse type points can have this field edited.",
                        "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Hand,
                        MessageBoxDefaultButton.Button1);
                    return;
                }
            }
        }

        private void dataGridPoints_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

            switch (e.ColumnIndex)
            {
                case 0:
                case 3:
                case 17:
                case 18:
                case 19:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                    {
                        MessageBox.Show("The value must be numeric only.", "Input Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        dataGridPoints.CancelEdit();
                    }
                    break;
            }
        }


        private void dataGridPoints_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridPoints_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            object value = EditTable.Rows[e.RowIndex][e.ColumnIndex];
            bool isnull = true;
            TtPoint point = (TtPoint)EditPoints[e.RowIndex];

            try
            {
                //check for null cell
                if (value.GetType() == typeof(DBNull))
                    isnull = true;
                else
                    isnull = (value == null);

                //gps
                if (e.ColumnIndex > 16 && e.ColumnIndex < 22)
                {
                    GpsPoint gps = (GpsPoint)point;

                    switch (e.ColumnIndex)
                    {
                        case 22:
                            if (isnull)
                                gps.ManualAccuracy = null;
                            else
                                gps.ManualAccuracy = (double)value;
                            break;

                        case 17:
                            if (isnull)
                            {
                                gps.UnAdjX = 0;
                                EditTable.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            }
                            else
                                gps.UnAdjX = (double)value;
                            break;
                        case 18:
                            if (isnull)
                            {
                                gps.UnAdjY = 0;
                                EditTable.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            }
                            else
                                gps.UnAdjY = (double)value;
                            break;
                        case 19:
                            if (isnull)
                            {
                                gps.UnAdjZ = 0;
                                EditTable.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            }
                            else
                                gps.UnAdjZ = (double)value;
                            break;
                    }
                }
                //sideshhot - traverse
                else if (e.ColumnIndex > 22 && e.ColumnIndex < 29)
                {
                    SideShotPoint sp = (SideShotPoint)point;

                    switch (e.ColumnIndex)
                    {
                        case 23:
                            if (isnull)
                                sp.ForwardAz = null;
                            else
                                sp.ForwardAz = (double)value;
                            break;
                        case 24:
                            if (isnull)
                                sp.BackwardAz = null;
                            else
                                sp.BackwardAz = (double)value;
                            break;
                        case 25:
                            if (isnull)
                            {
                                sp.SlopeDistance = 0;
                                EditTable.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            }
                            else
                                sp.SlopeDistance = (double)value;
                            break;
                        case 26:
                            if (isnull)
                            {
                                sp.SlopeAngle = 0;
                                EditTable.Rows[e.RowIndex][e.ColumnIndex] = 0;
                            }
                            else
                                sp.SlopeAngle = (double)value;
                            break;
                        default:
                            return;
                    }
                }
                //metadata
                else if (e.ColumnIndex == 7)
                {
                    TtMetaData metaFrom, metaTo;

                    metaFrom = _metas[point.MetaDefCN];
                    metaTo = (TtMetaData)value;

                    if (point.op == OpType.SideShot)
                    {
                        SideShotPoint sp = (SideShotPoint)point;
                        sp.SlopeDistance = TtUtils.ConvertDistance(sp.SlopeDistance, metaTo.uomDistance, metaFrom.uomDistance);
                        sp.SlopeAngle = TtUtils.ConvertAngle(sp.SlopeAngle, metaTo.uomSlope, metaFrom.uomSlope);

                        EditTable.Rows[e.RowIndex][25] = sp.SlopeDistance;
                        EditTable.Rows[e.RowIndex][25] = sp.SlopeAngle;

                    }
                    else if (point.op == OpType.Traverse)
                    {
                        TravPoint tp = (TravPoint)point;
                        tp.SlopeDistance = TtUtils.ConvertDistance(tp.SlopeDistance, metaTo.uomDistance, metaFrom.uomDistance);
                        tp.SlopeAngle = TtUtils.ConvertAngle(tp.SlopeAngle, metaTo.uomSlope, metaFrom.uomSlope);

                        EditTable.Rows[e.RowIndex][25] = tp.SlopeDistance;
                        EditTable.Rows[e.RowIndex][26] = tp.SlopeAngle;
                    }
                }
                //general
                else
                {
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            if (isnull)
                                dataGridPoints.CancelEdit();
                            else
                                point.PID = (int)value;
                            break;
                        case 3:
                            if (isnull)
                                dataGridPoints.CancelEdit();
                            else
                                point.Index = (int)value;
                            break;
                        case 8:
                            if (isnull)
                                dataGridPoints.CancelEdit();
                            else
                                point.OnBnd = (bool)value;
                            break;
                        case 32:
                            if (isnull)
                            {
                                point.Comment = String.Empty;
                                EditTable.Rows[e.RowIndex][e.ColumnIndex] = String.Empty;
                            }
                            else
                                point.Comment = (string)value;
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTable:CellValueChanged", ex.StackTrace);
                tsslStatus.Text = "Point Update Error.";
                return;
            }

            _editedPoints[e.RowIndex] = true;
            _edited = true;

            tsslStatus.Text = String.Format("Point {0} Updated.", point.PID);
        }

        private void dataGridPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) //onbnd
                dataGridPoints.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private bool Save()
        {
            try
            {
                UpdateDataGridView();  //updates incase CellValueChanged wasnt called

                tsslStatus.Text = "Saving Points";

                List<TtPoint> tPoints = new List<TtPoint>();

                foreach(TtPoint p in EditPoints)
                {
                    tPoints.Add(TtUtils.SaveConversion(p, _metas[p.MetaDefCN]));
                }

                DAL.SavePoints(OrigPoints, tPoints);

                tsslStatus.Text = "Adjusting Polygons";
                PolygonAdjuster.Adjust(DAL, true);

                LoadData();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTableForm:Save", ex.StackTrace);
                MessageBox.Show("The Points were unable to save correctly. See log file for details.");
                return false;
            }

            tsslStatus.Text = "Table Saved";
            return true;
        }

        private void UpdateDataGridView()
        {
            dataGridPoints.ReadOnly = true;
            dataGridPoints.Enabled = false;
            dataGridPoints.ReadOnly = false;
            dataGridPoints.Enabled = true;
        }

        private void Export()
        {
            if (Values.DataExport.CreateDirectory())
            {
                if (Values.DataExport.WritePoints(DAL))
                {
                    tsslStatus.Text = "Table exported";
                }
                else
                {
                    tsslStatus.Text = "Table write error";
                }
            }
        }

        private bool ResetRow(int rowIndex)
        {
            TtPoint point = TtUtils.GetConversion(OrigPoints[rowIndex], _metas[OrigPoints[rowIndex].MetaDefCN]);

            EditPoints[rowIndex] = point;

            DataRow row = EditTable.NewRow();
            row.BeginEdit();

            try
            {
                row[0] = point.PID;
                row[1] = point.CN;
                row[2] = point.op;
                row[3] = point.Index;
                row[4] = point.PolyName;
                row[5] = point.PolyCN;
                row[6] = point.Time;
                row[7] = _metas[point.MetaDefCN];
                row[8] = point.OnBnd;

                row[11] = point.AdjX;
                row[12] = point.AdjY;
                row[13] = point.AdjZ;
                row[14] = point.UnAdjX;
                row[15] = point.UnAdjY;
                row[16] = point.UnAdjZ;

                if (point.IsGpsType())
                {
                    GpsPoint gps = (GpsPoint)point;

                    row[17] = gps.UnAdjX;
                    row[18] = gps.UnAdjY;
                    row[19] = gps.UnAdjZ;

                    if (gps.RMSEr != null) { row[20] = gps.RMSEr; }

                    if (gps.ManualAccuracy != null) { row[22] = gps.ManualAccuracy; }
                }

                row[21] = TtUtils.GetPointAcc(point, _polys);

                if (point.IsTravType())
                {
                    SideShotPoint ss = (SideShotPoint)point;

                    if (ss.ForwardAz != null) { row[23] = ss.ForwardAz; }
                    if (ss.BackwardAz != null) { row[24] = ss.BackwardAz; }
                    row[25] = ss.SlopeDistance;
                    row[26] = ss.SlopeAngle;
                    row[27] = ss.HorizontalDistance;
                    row[28] = ss.Declination;
                }

                if (point.op == OpType.Quondam)
                {
                    QuondamPoint qp = (QuondamPoint)point;

                    row[29] = qp.ParentPID;
                    row[30] = qp.ParentPoly;
                }

                if (point.HasQuondamLinks)
                    row[31] = "Yes";
                else
                    row[31] = "No";

                row[32] = point.Comment;
                row.EndEdit();

                EditTable.Rows.RemoveAt(rowIndex);
                EditTable.Rows.InsertAt(row, rowIndex);

                if (!EditPoints[rowIndex].IsGpsType())
                {
                    dataGridPoints[17, rowIndex].ReadOnly = true;
                    dataGridPoints[18, rowIndex].ReadOnly = true;
                    dataGridPoints[19, rowIndex].ReadOnly = true;
                }

                dataGridPoints.Rows[rowIndex].Cells[dataGridPoints.SelectedCells[0].ColumnIndex].Selected = true;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTable:ResetRow", ex.StackTrace);
                return false;
            }

            _editedPoints[rowIndex] = false;

            return true;
        }

        private bool ResetTable()
        {
            try
            {
                EditTable = OrigTable.Copy();
                bindPoints.DataSource = EditTable;

                EditPoints.Clear();
                foreach (TtPoint p in OrigPoints)
                {
                    EditPoints.Add(TtUtils.GetConversion(p, _metas[p.MetaDefCN]));
                }

                _editedPoints.ForEach(b => b = false);

                _edited = false;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTableForm:ResetTable", ex.StackTrace);
                return false;
            }

            return true;
        }

        private void AskResetRow()
        {
            if (MessageBox.Show(String.Format("Are you sure you want to reset point {0}?", EditPoints[dataGridPoints.CurrentCell.RowIndex].PID)
               , "Reset Point", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ResetRow(dataGridPoints.CurrentCell.RowIndex))
                {
                    tsslStatus.Text = String.Format("Point {0} reset", EditPoints[dataGridPoints.CurrentCell.RowIndex].PID);
                }
                else
                {
                    tsslStatus.Text = "Point reset error";
                }
            }
        }

        private void AskResetTable()
        {
            if (MessageBox.Show("Are you sure you want to reset the entire table?",
                "Reset Table", MessageBoxButtons.YesNo, MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ResetTable())
                {
                    tsslStatus.Text = "Table reset";
                }
                else
                {
                    tsslStatus.Text = "Table reset error";
                }
            }
        }


        #region Controls
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tsmiSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                _close = true;
                this.Close();
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            if (_edited)
            {
                if (MessageBox.Show("The table has been edited. Would you like to save before exporting?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!Save())
                    {
                        //error

                        return;
                    }
                }
            }

            Export();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiResetRow_Click(object sender, EventArgs e)
        {
            AskResetRow();
        }

        private void tsmiResetTable_Click(object sender, EventArgs e)
        {
            AskResetTable();
        }

        private void cstsmiResetRow_Click(object sender, EventArgs e)
        {
            AskResetRow();
        }

        private void cstsmiResetTable_Click(object sender, EventArgs e)
        {
            AskResetTable();
        }

        private void dataGridPoints_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dataGridPoints.ClearSelection();
                    dataGridPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
                catch (Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "EditPointTableForm:CellMouseDown");
                }
            }
        }

        private void tsmiIDs_Click(object sender, EventArgs e)
        {
            if (!tsmiIDs.Checked)   //checks before calling click
            {
                tsmiIDs.Checked = false;
                dataGridPoints.Columns[1].Visible = false;
                dataGridPoints.Columns[5].Visible = false;
                dataGridPoints.Columns[10].Visible = false;
            }
            else
            {
                tsmiIDs.Checked = true;
                dataGridPoints.Columns[1].Visible = true;
                dataGridPoints.Columns[5].Visible = true;
                dataGridPoints.Columns[10].Visible = true;
            }
        }
        #endregion


    }
}
