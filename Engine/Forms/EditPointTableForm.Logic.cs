using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.BusinessObjects;
using TwoTrails.BusinessLogic;
using TwoTrails.DataAccess;
using TwoTrails.Utilities;
using TwoTrails.Engine;
#if (PocketPC || WindowsCE || Mobile)
using FMSC.Controls;
#endif

namespace TwoTrails.Forms
{
    public partial class EditPointTableForm : Form
    {
        #region Const Strings
        private const string CN = "CN";
        private const string ID = "PID";
        private const string Polygon = "Polygon";
        private const string Op = "Op";
        private const string Indx = "Index";
        private const string OnBnd = "OnBnd";
        private const string Group = "GroupName";
        private const string GroupCN = "GroupCN";
        private const string X = "X";
        private const string Y = "Y";
        private const string Z = "Z";
        private const string ManAcc = "ManAcc";
        private const string uX = "UnAdjX";
        private const string uY = "UnAdjY";
        private const string uZ = "UnAdjZ";
        private const string aX = "AdjX";
        private const string aY = "AdjY";
        private const string aZ = "AdjZ";
        private const string fA = "FwdAz";
        private const string bA = "BkAz";
        private const string sD = "SlpDist";
        private const string sA = "SlpAng";
        private const string hD = "HorzDist";
        private const string QL = "QndmLink";
        private const string Meta = "Meta";
        private const string Cmt = "Comment";
        #endregion

        private DataAccessLayer DAL;

        #if (PocketPC || WindowsCE || Mobile)
        private EditableDataGrid edg;
        #endif

        private BindingSource bs;
        private DataGridTableStyle ts = new DataGridTableStyle() { MappingName = "PointInfo" };

        #if (PocketPC || WindowsCE || Mobile)
        private Microsoft.WindowsCE.Forms.InputPanel input;
        #endif

        private Dictionary<string, TtPoint> _Points;
        private Dictionary<string, bool> _PointEdited;
        private List<TtPolygon> _Polys;
        private List<string> _PolyCNs;
        private static Dictionary<string, TtMetaData> _Meta;

        private List<PointInfo> GridPoints;
        private Dictionary<string, PointInfo> OldGridPoints;

        private string _LastPoint;
        private string _LastString;

        private static List<string> _MetaNames;
        private static List<string> _PolyNames;
        private static List<string> _PointNames;

        #if (PocketPC || WindowsCE || Mobile)
        #region TextBoxColumns
        DataGridButtonColumn button = new DataGridButtonColumn() { MappingName = "btn", UseCellColumnTextForCellValue = true, Text = "R", Width = 15};
        EditableTextBoxColumn etxt_pid = new EditableTextBoxColumn() { MappingName = ID, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableComboBoxColumn ecbo_poly = new EditableComboBoxColumn() { MappingName = Polygon };
        EditableTextBoxColumn etxt_op = new EditableTextBoxColumn() { MappingName = Op, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_indx = new EditableTextBoxColumn() { MappingName = Indx, MaxTextLength = 4, GoToNextColumnWhenTextCompleate = false };
        EditableCheckBoxColumn echk_onbnd = new EditableCheckBoxColumn() { MappingName = OnBnd };
        EditableTextBoxColumn etxt_ax = new EditableTextBoxColumn() { MappingName = aX, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_ay = new EditableTextBoxColumn() { MappingName = aY, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_az = new EditableTextBoxColumn() { MappingName = aZ, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_ux = new EditableTextBoxColumn() { MappingName = uX, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_uy = new EditableTextBoxColumn() { MappingName = uY, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_uz = new EditableTextBoxColumn() { MappingName = uZ, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_x = new EditableTextBoxColumn() { MappingName = X, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_y = new EditableTextBoxColumn() { MappingName = Y, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_z = new EditableTextBoxColumn() { MappingName = Z, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_manacc = new EditableTextBoxColumn() { MappingName = ManAcc, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_fa = new EditableTextBoxColumn() { MappingName = fA, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_ba = new EditableTextBoxColumn() { MappingName = bA, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_sd = new EditableTextBoxColumn() { MappingName = sD, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_sa = new EditableTextBoxColumn() { MappingName = sA, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_hd = new EditableTextBoxColumn() { MappingName = hD, MaxTextLength = 16, GoToNextColumnWhenTextCompleate = false };
        EditableComboBoxColumn ecbo_qdm = new EditableComboBoxColumn() { MappingName = QL};
        EditableComboBoxColumn ecbo_meta = new EditableComboBoxColumn() { MappingName = Meta };
        EditableTextBoxColumn etxt_cmt = new EditableTextBoxColumn() { MappingName = Cmt, MaxTextLength = 50, GoToNextColumnWhenTextCompleate = false };
        EditableTextBoxColumn etxt_cn = new EditableTextBoxColumn() { MappingName = CN, MaxTextLength = 36, GoToNextColumnWhenTextCompleate = false };
        #endregion
        #endif

        public class PointInfo : IDataErrorInfo
        {
            #region Members
            public string btn { get; set; }
            public string CN { get; set; }
            public int PID { get; set; }
            public string Polygon { get; set; }
            public string Op { get; set; }
            public string Index { get; set; }
            public bool OnBnd { get; set; }
            public string X { get; set; }
            public string Y { get; set; }
            public string Z { get; set; }
            public string ManAcc { get; set; }
            public string UnAdjX { get; set; }
            public string UnAdjY { get; set; }
            public string UnAdjZ { get; set; }
            public string AdjX { get; set; }
            public string AdjY { get; set; }
            public string AdjZ { get; set; }
            public string FwdAz { get; set; }
            public string BkAz { get; set; }
            public string SlpDist { get; set; }
            public string SlpAng { get; set; }
            public string HorzDist { get; set; }
            public string QndmLink { get; set; }
            public string Meta { get; set; }
            public string Comment { get; set; }
            #endregion

            public PointInfo(PointInfo p)
            {
                btn = p.btn;
                CN = p.CN;
                PID = p.PID;
                Polygon = p.Polygon;
                Op = p.Op;
                Index = p.Index;
                OnBnd = p.OnBnd;
                X = p.X;
                Y = p.Y;
                Z = p.Z;
                ManAcc = p.ManAcc;
                UnAdjX = p.UnAdjX;
                UnAdjY = p.UnAdjY;
                UnAdjZ = p.UnAdjZ;
                AdjX = p.AdjX;
                AdjY = p.AdjY;
                AdjZ = p.AdjZ;
                FwdAz = p.FwdAz;
                BkAz = p.BkAz;
                SlpDist = p.SlpDist;
                HorzDist = p.HorzDist;
                QndmLink = p.QndmLink;
                Meta = p.Meta;
                Comment = p.Comment;
            }

            public PointInfo(TtPoint p)
            {
                CN = p.CN;
                PID = p.PID;
                Polygon = p.PolyName;
                Op = p.op.ToString();
                Index = p.Index.ToString();
                OnBnd = p.OnBnd;
                try
                {
                    Meta = _Meta[p.MetaDefCN].Name;
                }
                catch
                {
                    Meta = _Meta.Values.ToList()[0].Name;
                }

                UnAdjX = Math.Round(p.UnAdjX, 3).ToString();
                UnAdjY = Math.Round(p.UnAdjY, 3).ToString();
                UnAdjZ = Math.Round(p.UnAdjZ, 3).ToString();

                if (p.op == OpType.GPS || p.op == OpType.Take5 || p.op == OpType.Walk || p.op == OpType.WayPoint)
                {
                    GpsPoint gp = (GpsPoint)p;
                    X = Math.Round(gp.X, 3).ToString();
                    Y = Math.Round(gp.Y, 3).ToString();
                    Z = Math.Round(gp.Z, 3).ToString();
                    AdjX = Math.Round(gp.AdjX, 3).ToString();
                    AdjY = Math.Round(gp.AdjY, 3).ToString();
                    AdjZ = Math.Round(gp.AdjZ, 3).ToString();
                    ManAcc = (gp.ManualAccuracy != null) ? Math.Round((double)gp.ManualAccuracy, 3).ToString() : "";
                }
                else
                {
                    X = "";
                    Y = "";
                    Z = "";
                    ManAcc = "";
                }

                if (p.op == OpType.SideShot || p.op == OpType.Traverse)
                {
                    SideShotPoint ssp = (SideShotPoint)p;

                    FwdAz = (ssp.ForwardAz != null && ssp.ForwardAz >= 0) ? Math.Round((double)ssp.ForwardAz, 3).ToString() : "";
                    BkAz = (ssp.BackwardAz != null && ssp.BackwardAz >= 0) ? Math.Round((double)ssp.BackwardAz, 3).ToString() : "";
                    SlpAng = Math.Round(ssp.SlopeAngle, 3).ToString();
                    SlpDist = Math.Round(ssp.SlopeDistance, 3).ToString();
                    HorzDist = Math.Round(ssp.HorizontalDistance, 3).ToString();
                }
                else
                {
                    FwdAz = "";
                    BkAz = "";
                    SlpAng = "";
                    SlpDist = "";
                    HorzDist = "";
                }

                if (p.op == OpType.Quondam)
                {
                    QuondamPoint qp = (QuondamPoint)p;

                    QndmLink = String.Format("{0}, {1}", qp.PolyName, qp.ParentPID);
                }
                else
                {
                    QndmLink = "";
                }

                Comment = p.Comment;
            }

            public string Error
            {
                get { return null; }
            }

            public string this[string columnName]
            {
                get { return null; }
            }
        }
            
        public void Init()
        {
            TtUtils.ShowWaitCursor();
            this.DialogResult = DialogResult.Cancel;
            
            #if (PocketPC || WindowsCE || Mobile)

            edg = new EditableDataGrid();
            edg.Left = 0;
            edg.Top = 0;
            edg.Dock = DockStyle.Top;
            
            if (Environment.OSVersion.Version.Major < 5)
            {
                edg.Size = new System.Drawing.Size(tablePanel.Width, tablePanel.Height - 55);
            }
            else
            {
                edg.Size = new System.Drawing.Size(tablePanel.Width, tablePanel.Height - 70);
            }
            

            /*
            //new not working with archer 2
            if (Environment.OSVersion.Version.Major < 5)
            {
                edg.Size = new System.Drawing.Size(this.Width, this.Height - 55);
                edg.Dock = DockStyle.Top;
            }
            else
            {
                edg.Size = new System.Drawing.Size(this.Width, this.Height - 25);
                edg.Dock = DockStyle.Top;
                if (Environment.Version.Minor > 1)
                {
                    edg.Dock = DockStyle.Fill;
                    btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y - 10);
                    btnSave.Location = new Point(btnSave.Location.X, btnSave.Location.Y - 10);
                }
            }
            */


            edg.Visible = true;
            edg.Enabled = true;
            edg.ColumnHeadersVisible = true;
            edg.RowHeadersVisible = false;
            edg.BackgroundColor = Color.Gray;
            edg.AlternatingBackColor = Color.LightGray;
            edg.ErrorColor = Color.Red;
            edg.Name = "Grid";
            edg.CellValueChanged += new EditableDataGridCellValueChangedEventHandler(edg_CellValueChanged);

            if (Environment.OSVersion.Platform != PlatformID.WinCE)
            {
                input = new Microsoft.WindowsCE.Forms.InputPanel();

                edg.SIP = input;
            }

            tablePanel.Controls.Add(edg);
            //this.Controls.Add(edg);
#endif

            try
            {
                List<TtPoint> tmpPoints = DAL.GetPoints();

                tmpPoints.Sort();

                _Points = tmpPoints.ToDictionary(x => x.CN, x => x);
                _Polys = DAL.GetPolygons();
                _Meta = DAL.GetMetaData().ToDictionary(x=> x.CN, x => x);
                _MetaNames = new List<string>();
                _PolyNames = new List<string>();
                _PointNames = new List<string>();

                _PolyCNs = new List<string>();
                _PointEdited = new Dictionary<string, bool>();

                bs = new BindingSource();

                foreach (TtPolygon poly in _Polys)
                {
                    _PolyCNs.Add(poly.CN);
                    _PolyNames.Add(poly.Name);
                }

                foreach (TtMetaData meta in _Meta.Values)
                {
                    _MetaNames.Add(meta.Name);
                }

                if (SetupDataTable())
                {
                    AddDataToTable();
                }
                bs.DataSource = GridPoints;

                #if (PocketPC || WindowsCE || Mobile)
                edg.DataSource = bs;
                #endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTableFormLogic:Init");
            }

            TtUtils.HideWaitCursor();
        }

        public void Save()
        {
            bool adjust = false;
            TtUtils.ShowWaitCursor();


            TtPoint spoint = null;

            foreach (PointInfo point in GridPoints)
            {
                try
                {
                    if (_PointEdited[point.CN])
                    {
                        spoint = TtUtils.CopyPoint(_Points[point.CN]);

                        spoint.PID = point.PID;
                        spoint.PolyCN = _PolyCNs[_PolyNames.IndexOf(point.Polygon)];
                        spoint.Index = point.Index.ToInteger();
                        spoint.OnBnd = point.OnBnd;
                        spoint.Comment = point.Comment;

                        TtMetaData meta = _Meta.Values.Where(m => m.Name == point.Meta).Single < TtMetaData>();
                        spoint.MetaDefCN = meta.CN;


                        switch ((OpType)Enum.Parse(typeof(OpType), point.Op, true))
                        {
                            case OpType.GPS:
                            case OpType.WayPoint:
                            case OpType.Walk:
                            case OpType.Take5:
                                {
                                    spoint.UnAdjX = point.UnAdjX.ToDouble();
                                    spoint.UnAdjY = point.UnAdjY.ToDouble();
                                    spoint.UnAdjZ = point.UnAdjZ.ToDouble();

                                    GpsPoint gp = (GpsPoint)spoint;
                                    gp.ManualAccuracy = point.ManAcc.ToDouble();

                                    spoint = gp;
                                    break;
                                }
                            case OpType.Traverse:
                            case OpType.SideShot:
                                {
                                    TravPoint tp = (TravPoint)spoint;

                                    tp.ForwardAz = point.FwdAz.ToDouble();
                                    tp.BackwardAz = point.BkAz.ToDouble();
                                    tp.SlopeDistance = point.SlpDist.ToDouble();
                                    tp.SlopeAngle = point.SlpAng.ToDouble();

                                    spoint = tp;
                                    break;
                                }
                            case OpType.Quondam:
                                {
                                    QuondamPoint qp = (QuondamPoint)spoint;

                                    string polyname = point.QndmLink.Substring(0, point.QndmLink.IndexOf(", "));
                                    string pointnameStr = point.QndmLink.Substring(point.QndmLink.IndexOf(", ") + 2);

                                    int pointname = -1;

                                    if (pointnameStr.IsInteger())
                                        pointname = pointnameStr.ToInteger();

                                    if (polyname != null && pointname > -1)
                                    {
                                        try
                                        {
                                            qp.ParentPoint = _Points.Values.Where
                                                (p => p.PID == pointname && p.PolyName == polyname).Single<TtPoint>();

                                            spoint = qp;
                                        }
                                        catch (Exception ex)
                                        {
                                            TtUtils.WriteError(ex.Message, "EditPointTableFormLogic:Save-Quondam");
                                        }
                                    }
                                    break;
                                }
                            default:
                                continue;
                        }

                        spoint = TtUtils.SaveConversion(spoint, meta); 

                        DAL.SavePoint(_Points[point.CN], spoint);
                        adjust = true;
                    }
                }
                catch(Exception ex)
                {
                    TtUtils.WriteError(ex.Message, "EditPointTableFormLogic:Save");
                }
            }

            if (adjust)
            {
                PolygonAdjuster.Adjust(DAL);
            }

            TtUtils.HideWaitCursor();
        }

        public void OnLoad()
        {
            #if (PocketPC || WindowsCE || Mobile)
            ecbo_poly.DataSource = _PolyNames;
            ecbo_meta.DataSource = _MetaNames;
            ecbo_qdm.DataSource = _PointNames;
            //ecbo_poly.ComboBoxItems = _PolyNames;
            //ecbo_meta.ComboBoxItems = _MetaNames;
            //ecbo_qdm.ComboBoxItems = _PointNames;
            #endif

            btnSave.BringToFront();
            btnCancel.BringToFront();
        }


        #region Events

#if (PocketPC || WindowsCE || Mobile)

        void edg_CellValueChanged(object sender, EditableDataGridCellEventArgs e)
        {
            switch (e.Column.MappingName)
            {
                case ID:
                        etxt_pid_CellEdited();
                        break;
                case Indx:
                        etxt_indx_CellEdited();
                        break;
                case Polygon:
                        //ecbo_poly_SelectedValueChanged(sender, e);
                        break;
                case Op:
                        break;
                case OnBnd:
                        break;
                case Group:
                        break;
                case GroupCN:
                        break;
                case X:
                        break;
                case Y:
                        break;
                case Z:
                        break;
                case ManAcc:
                        etxt_manacc_CellEdited();
                        break;
                case uX:
                        etxt_ux_CellEdited();
                        break;
                case uY:
                        etxt_uy_CellEdited();
                        break;
                case uZ:
                        etxt_uz_CellEdited();
                        break;
                case aX:
                        break;
                case aY:
                        break;
                case aZ:
                        break;
                case fA:
                        etxt_fa_CellEdited();
                        break;
                case bA:
                        etxt_ba_CellEdited();
                        break;
                case sD:
                        etxt_sd_CellEdited();
                        break;
                case sA:
                        etxt_sa_CellEdited();
                        break;
                case hD:
                        break;
                case QL:
                        break;
                case Meta:
                        break;
                case Cmt:
                        break;
            }
        }


        private void btnClick(ButtonCellClickEventArgs e)
        {
            string cn = GetPointCN(e.RowNumber);

            _LastPoint = null;
            _LastString = null;

            if (cn != null)
            {

                TtPoint oPoint = TtUtils.GetConversion(_Points[cn], _Meta[_Points[cn].MetaDefCN]);
                GridPoints[GridPoints.IndexOf(GridPoints.Where(p => p.CN == cn).Single<PointInfo>())] = new PointInfo(oPoint);
                _PointEdited[cn] = false;
                edg.Refresh();
                _LastPoint = cn;
            }
        }

        private void etxt_pid_CellEditBeginning(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].Index;

            Kb.ShowRegular(this);
        }

        private void etxt_pid_CellEdited()
        {
            //if invalid, change
            _PointEdited[_LastPoint] = true;
        }

        private void etxt_indx_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].Index;

            Kb.ShowRegular(this);
        }

        private void etxt_indx_CellEdited()
        {
            if (_LastPoint != null && (!GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().Index.IsInteger() ||
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().Index.ToInteger() < 0))
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().Index = _LastString;
            }
            else
                _PointEdited[_LastPoint] = true;
        }

        private void ecbo_poly_CellEditBeginning(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].Polygon;

            Kb.Hide(this);
        }

        private void ecbo_poly_SelectedValueChanged(object sender, EventArgs e)
        {
            //nothing
            _PointEdited[_LastPoint] = true;

            Kb.Hide(this);
        }

        private void echk_onbnd_CellEditBeginning(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = null;
            _PointEdited[_LastPoint] = true;

            Kb.Hide(this);
        }

        private void etxt_ux_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].UnAdjX;

            Kb.ShowRegular(this);
        }

        private void etxt_ux_CellEdited()
        {
            if (_LastPoint != null && !GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().UnAdjX.IsDouble())
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().UnAdjX = _LastString;
            }
            else
                _PointEdited[_LastPoint] = true;
        }

        private void etxt_uy_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].UnAdjY;

            Kb.ShowRegular(this);
        }

        private void etxt_uy_CellEdited()
        {
            if (_LastPoint != null && !GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().UnAdjY.IsDouble())
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().UnAdjY = _LastString;
            }
            else
                _PointEdited[_LastPoint] = true;
        }

        private void etxt_uz_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].UnAdjZ;

            Kb.ShowRegular(this);
        }

        private void etxt_uz_CellEdited()
        {
            if (!GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().UnAdjZ.IsDouble())
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().UnAdjZ = _LastString;
            }
            else
                _PointEdited[_LastPoint] = true;
        }

        private void etxt_manacc_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].ManAcc;

            Kb.ShowRegular(this);
        }

        private void etxt_manacc_CellEdited()
        {
            if (_Points[_LastPoint].op == OpType.GPS || _Points[_LastPoint].op == OpType.Take5 ||
                _Points[_LastPoint].op == OpType.Walk || _Points[_LastPoint].op == OpType.WayPoint)
            {
                if (_LastPoint != null && !GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().ManAcc.IsDouble())
                {
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().ManAcc = _LastString;
                }
                else
                    _PointEdited[_LastPoint] = true;
            }
            else
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().ManAcc = "";
            }
        }

        private void etxt_fa_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].FwdAz;

            Kb.ShowRegular(this);
        }

        private void etxt_fa_CellEdited()
        {
            if (_Points[_LastPoint].op == OpType.Traverse || _Points[_LastPoint].op == OpType.SideShot)
            {
                if (_LastPoint != null && (!GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().FwdAz.IsDouble() ||
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().FwdAz.ToDouble() < 0))
                {
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().FwdAz = _LastString;
                }
                else
                    _PointEdited[_LastPoint] = true;
            }
            else
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().FwdAz = "";
            }
        }

        private void etxt_ba_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].UnAdjZ;

            Kb.ShowRegular(this);
        }

        private void etxt_ba_CellEdited()
        {
            if (_Points[_LastPoint].op == OpType.Traverse || _Points[_LastPoint].op == OpType.SideShot)
            {
                if (_LastPoint != null && (!GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().BkAz.IsDouble() ||
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().BkAz.ToDouble() < 0))
                {
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().BkAz = _LastString;
                }
                else
                    _PointEdited[_LastPoint] = true;
            }
            else
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().BkAz = "";
            }
        }

        private void etxt_sd_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].SlpDist;

            Kb.ShowRegular(this);
        }

        private void etxt_sd_CellEdited()
        {
            if (_Points[_LastPoint].op == OpType.Traverse || _Points[_LastPoint].op == OpType.SideShot)
            {
                if (_LastPoint != null && (!GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpDist.IsDouble() ||
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpDist.ToDouble() < 0))
                {
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpDist = _LastString;
                }
                else
                    _PointEdited[_LastPoint] = true;
            }
            else
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpDist = "";
            }
        }

        private void etxt_sa_edit(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].SlpAng;

            Kb.ShowRegular(this);
        }

        private void etxt_sa_CellEdited()
        {
            if (_Points[_LastPoint].op == OpType.Traverse || _Points[_LastPoint].op == OpType.SideShot)
            {
                if (_LastPoint != null && (!GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpAng.IsDouble() ||
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpAng.ToDouble() < 0))
                {
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpAng = _LastString;
                }
                else
                    _PointEdited[_LastPoint] = true;
            }
            else
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().SlpAng = "";
            }
        }

        private void ecbo_meta_CellEditBeginning(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].Meta;

            Kb.Hide(this);
        }

        private void ecbo_meta_SelectedValueChanged(object sender, EventArgs e)
        {
            //change meta
            try
            {
                TtPoint point = TtUtils.CopyPoint(_Points[_LastPoint]);
                TtMetaData meta = _Meta.Values.Where(m => m.Name == _LastString).Single<TtMetaData>();
                point.MetaDefCN = meta.CN;

                point = TtUtils.GetConversion(point, meta);

                GridPoints[GridPoints.IndexOf(GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>())] = new PointInfo(point);
                _PointEdited[_LastPoint] = true;
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTableFormLogic:changeMeta");
            }
        }

        private void ecbo_qdm_CellEditBeginning(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].QndmLink;

            Kb.Hide(this);
        }

        private void ecbo_qdm_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_Points[_LastPoint].op == OpType.Quondam)
            {
                if (_LastPoint != null && (GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().QndmLink != String.Empty))
                {
                    GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().QndmLink = _LastString;
                }
                else
                {
                    _PointEdited[_LastPoint] = true;
                }
            }
            else
            {
                GridPoints.Where(p => p.CN == _LastPoint).Single<PointInfo>().QndmLink = _LastString;
            }
        }

        private void etxt_cmt_CellEditBeginning(EditableColumnBase sender, CellEditEventArgs e)
        {
            string cn = GetPointCN(e.Row);

            _LastPoint = cn;
            _LastString = GridPoints[e.Row].Comment;

            Kb.ShowRegular(this);
        }

        private void etxt_cmt_Cell_Edited()
        {
            _PointEdited[_LastPoint] = true;
        }
        #endif
        #endregion

        private void RemoveEvents()
        {
            #if (PocketPC || WindowsCE || Mobile)
            edg.CellValueChanged -= new EditableDataGridCellValueChangedEventHandler(edg_CellValueChanged);
            button.Click -= new ButtonCellClickEventHandler(btnClick);
            etxt_pid.CellEditBeginning -= new CellEditEventHandler(etxt_pid_CellEditBeginning);
            etxt_indx.CellEditBeginning -= new CellEditEventHandler(etxt_indx_edit);
            etxt_ux.CellEditBeginning -= new CellEditEventHandler(etxt_ux_edit);
            etxt_uy.CellEditBeginning -= new CellEditEventHandler(etxt_uy_edit);
            etxt_uz.CellEditBeginning -= new CellEditEventHandler(etxt_uz_edit);
            etxt_manacc.CellEditBeginning -= new CellEditEventHandler(etxt_manacc_edit);
            etxt_fa.CellEditBeginning -= new CellEditEventHandler(etxt_fa_edit);
            etxt_ba.CellEditBeginning -= new CellEditEventHandler(etxt_ba_edit);
            etxt_sd.CellEditBeginning -= new CellEditEventHandler(etxt_sd_edit);
            etxt_sa.CellEditBeginning -= new CellEditEventHandler(etxt_sa_edit);
            ecbo_meta.CellEditBeginning -= new CellEditEventHandler(ecbo_meta_CellEditBeginning);
            ecbo_qdm.CellEditBeginning -= new CellEditEventHandler(ecbo_qdm_CellEditBeginning);
            echk_onbnd.CellEditBeginning -= new CellEditEventHandler(echk_onbnd_CellEditBeginning);
            etxt_cmt.CellEditBeginning -= new CellEditEventHandler(etxt_cmt_CellEditBeginning);
            ecbo_poly.SelectedValueChanged -= new EventHandler(ecbo_poly_SelectedValueChanged);
            ecbo_meta.SelectedValueChanged -= new EventHandler(ecbo_meta_SelectedValueChanged);
            ecbo_qdm.SelectedValueChanged -= new EventHandler(ecbo_qdm_SelectedValueChanged);
            #endif
        }


        //setup table and events
        private bool SetupDataTable()
        {
            try
            {
                #if (PocketPC || WindowsCE || Mobile)
                button.Click += new ButtonCellClickEventHandler(btnClick);
                ts.GridColumnStyles.Add(button);

                etxt_pid.ReadOnly = false;
                etxt_pid.HeaderText = ID;
                etxt_pid.CellEditBeginning += new CellEditEventHandler(etxt_pid_CellEditBeginning);
                ts.GridColumnStyles.Add(etxt_pid);

                etxt_indx.ReadOnly = false;
                etxt_indx.HeaderText = Indx;
                etxt_indx.Width = 0;
                etxt_indx.CellEditBeginning += new CellEditEventHandler(etxt_indx_edit);
                ts.GridColumnStyles.Add(etxt_indx);

                ecbo_poly.ReadOnly = false;
                ecbo_poly.HeaderText = Polygon;
                ecbo_poly.CellEditBeginning += new CellEditEventHandler(ecbo_poly_CellEditBeginning);
                ecbo_poly.SelectedValueChanged += new EventHandler(ecbo_poly_SelectedValueChanged);
                ts.GridColumnStyles.Add(ecbo_poly);

                etxt_op.ReadOnly = true;
                etxt_op.HeaderText = Op;
                ts.GridColumnStyles.Add(etxt_op);

                echk_onbnd.ReadOnly = false;
                echk_onbnd.HeaderText = OnBnd;
                echk_onbnd.CellEditBeginning += new CellEditEventHandler(echk_onbnd_CellEditBeginning);
                ts.GridColumnStyles.Add(echk_onbnd);

                etxt_ax.ReadOnly = true;
                etxt_ax.HeaderText = aX;
                ts.GridColumnStyles.Add(etxt_ax);

                etxt_ay.ReadOnly = true;
                etxt_ay.HeaderText = aY;
                ts.GridColumnStyles.Add(etxt_ay);

                etxt_az.ReadOnly = true;
                etxt_az.HeaderText = aZ;
                ts.GridColumnStyles.Add(etxt_az);

                etxt_ux.ReadOnly = false;
                etxt_ux.HeaderText = uX;
                etxt_ux.CellEditBeginning += new CellEditEventHandler(etxt_ux_edit);
                ts.GridColumnStyles.Add(etxt_ux);

                etxt_uy.ReadOnly = false;
                etxt_uy.HeaderText = uY;
                etxt_uy.CellEditBeginning += new CellEditEventHandler(etxt_uy_edit);
                ts.GridColumnStyles.Add(etxt_uy);

                etxt_uz.ReadOnly = false;
                etxt_uz.HeaderText = uZ;
                etxt_uz.CellEditBeginning += new CellEditEventHandler(etxt_uz_edit);
                ts.GridColumnStyles.Add(etxt_uz);

                etxt_x.ReadOnly = true;
                etxt_x.HeaderText = X;
                ts.GridColumnStyles.Add(etxt_x);

                etxt_y.ReadOnly = true;
                etxt_y.HeaderText = Y;
                ts.GridColumnStyles.Add(etxt_y);

                etxt_z.ReadOnly = true;
                etxt_z.HeaderText = Z;
                ts.GridColumnStyles.Add(etxt_z);

                etxt_manacc.ReadOnly = false;
                etxt_manacc.HeaderText = ManAcc;
                etxt_manacc.CellEditBeginning += new CellEditEventHandler(etxt_manacc_edit);
                ts.GridColumnStyles.Add(etxt_manacc);

                etxt_fa.ReadOnly = false;
                etxt_fa.HeaderText = fA;
                etxt_fa.CellEditBeginning += new CellEditEventHandler(etxt_fa_edit);
                ts.GridColumnStyles.Add(etxt_fa);

                etxt_ba.ReadOnly = false;
                etxt_ba.HeaderText = bA;
                etxt_ba.CellEditBeginning += new CellEditEventHandler(etxt_ba_edit);
                ts.GridColumnStyles.Add(etxt_ba);

                etxt_sd.ReadOnly = false;
                etxt_sd.HeaderText = sD;
                etxt_sd.CellEditBeginning += new CellEditEventHandler(etxt_sd_edit);
                ts.GridColumnStyles.Add(etxt_sd);

                etxt_sa.ReadOnly = false;
                etxt_sa.HeaderText = sA;
                etxt_sa.CellEditBeginning += new CellEditEventHandler(etxt_sa_edit);
                ts.GridColumnStyles.Add(etxt_sa);

                etxt_hd.ReadOnly = true;
                etxt_hd.HeaderText = hD;
                ts.GridColumnStyles.Add(etxt_hd);

                ecbo_qdm.ReadOnly = false;
                ecbo_qdm.HeaderText = QL;
                ecbo_qdm.CellEditBeginning += new CellEditEventHandler(ecbo_qdm_CellEditBeginning);
                ecbo_qdm.SelectedValueChanged += new EventHandler(ecbo_qdm_SelectedValueChanged);
                ts.GridColumnStyles.Add(ecbo_qdm);

                ecbo_meta.ReadOnly = false;
                ecbo_meta.HeaderText = Meta;
                ecbo_meta.CellEditBeginning += new CellEditEventHandler(ecbo_meta_CellEditBeginning);
                ecbo_meta.SelectedValueChanged += new EventHandler(ecbo_meta_SelectedValueChanged);
                ts.GridColumnStyles.Add(ecbo_meta);

                etxt_cmt.ReadOnly = false;
                etxt_cmt.HeaderText = Cmt;
                etxt_cmt.CellEditBeginning += new CellEditEventHandler(etxt_cmt_CellEditBeginning);
                ts.GridColumnStyles.Add(etxt_cmt);

                etxt_cn.ReadOnly = true;
                etxt_cn.HeaderText = CN;
                ts.GridColumnStyles.Add(etxt_cn);

                edg.TableStyles.Add(ts);
                #endif
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTableFormLogic:SetupDataTable");
                return false;
            }

            return true;
        }

        //add data to table
        private void AddDataToTable()
        {
            try
            {
                GridPoints = new List<PointInfo>();
                OldGridPoints = new Dictionary<string, PointInfo>();

                TtMetaData meta = null;
                TtPoint addPoint = null;

                foreach (TtPoint point in _Points.Values)
                {

                    if (_Meta.ContainsKey(point.MetaDefCN))
                        meta = _Meta[point.MetaDefCN];
                    else
                        meta = _Meta.First().Value;

                    addPoint = TtUtils.GetConversion(point, meta);

                    _PointEdited.Add(addPoint.CN, false);

                    GridPoints.Add(new PointInfo(addPoint));
                    OldGridPoints.Add(addPoint.CN, new PointInfo(addPoint));
                    _PointNames.Add(String.Format("{0}, {1}", point.PolyName, point.PID));
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "EditPointTableFormLogic:AddDataToTable");
            }
        }

        private string GetPointCN(int row)
        {
            string cn = null;

            try
            {
                cn = GridPoints[row].CN;
            }
            catch
            {

            }

            return cn;
        }


        private void btnCancel_Click2(object sender, EventArgs e)
        {
            Kb.Hide(this);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click2(object sender, EventArgs e)
        {
            Kb.Hide(this);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}