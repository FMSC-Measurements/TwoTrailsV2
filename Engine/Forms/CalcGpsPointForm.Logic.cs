using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Engine;
using TwoTrails.GpsAccess;
using TwoTrails.Utilities;
using TwoTrails.DataAccess;
using TwoTrails.BusinessObjects;

namespace TwoTrails.Forms
{
    public partial class CalcGpsPointForm : Form
    {
        private const int DEFAULT_GROUP_SIZE = 10;
        private const double RMSE95_COEF = 1.7308;

        private int groupSize, start, currentZone;
        private bool calculated, canceled, recalculated, clearing;
        List<NmeaBurst> Bursts, ToUseBursts;
        private List<int> intRange;
        private double pointX, pointY, pointZ, pointRMSEr;
        private string pointCN;
        private DataAccessLayer DAL;

        public void Init(List<NmeaBurst> nb, int pointName, string cn, DataAccessLayer dal, int currentZone, bool recalc)
        {
            this.Icon = Properties.Resources.Map;

            this.currentZone = currentZone;

            for (int i = 0; i < nb.Count; i++)
            {
                nb[i].CalcZone(currentZone);
            }

            calculated = false;
            canceled = true;

            recalculated = recalc;

            pointCN = cn;

            DAL = dal;

            try
            {
                cboFixType.SelectedIndex = Values.Settings.DeviceOptions.Filter_GPS_FixType;
                cboDOP.SelectedIndex = Values.Settings.DeviceOptions.Filter_GPS_DOP_TYPE;

                txtDOP.Text = Values.Settings.DeviceOptions.Filter_GPS_DOP_VALUE.ToString();

#if (PocketPC || WindowsCE || Mobile)
                btnDOP.Text = cboDOP.Text;
                btnFixType.Text = cboFixType.Text;
                btnFixType.Visible = Values.Settings.DeviceOptions.UseSelection;
                btnDOP.Visible = Values.Settings.DeviceOptions.UseSelection;
#endif

                cboFixType.Visible = !Values.Settings.DeviceOptions.UseSelection;
                cboDOP.Visible = !Values.Settings.DeviceOptions.UseSelection;

                Bursts = nb;
                    
                pointX = pointY = pointZ = pointRMSEr = -1;

                ToUseBursts = new List<NmeaBurst>();
                intRange = new List<int>();


                txtRange.Text = String.Format("1-{0}", Bursts.Count);
                txtStart.Text = "1";

                if (Bursts.Count / 3.0 < 5)
                {
                    groupSize = DEFAULT_GROUP_SIZE;
                }
                else
                {
                    groupSize = Convert.ToInt32(Math.Floor(Bursts.Count / 3.0));
                }

                txtGroup.Text = groupSize.ToString();


                Calculate();
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "CalcGpsPointForm:Init");
            }
        }


        private bool CheckInput()
        {
            try
            {
                string range = txtRange.Text.ToString();

                if (!chkCustom.Checked)
                {
                    intRange.Clear();
                    intRange.Add(1);
                    intRange.Add(Bursts.Count);

                    //start = 1;

                    txtRange.Text = String.Format("1-{0}", Bursts.Count);
                    txtStart.Text = "1";

                    if (Bursts.Count / 3.0 < 5)
                    {
                        groupSize = DEFAULT_GROUP_SIZE;
                    }
                    else
                    {
                        groupSize = Convert.ToInt32(Math.Floor(Bursts.Count / 3.0));
                    }

                    txtGroup.Text = groupSize.ToString();
                }
                else
                {
                    if (!range.IsEmpty())
                    {
                        if (!range.Contains('-'))
                        {
                            MessageBox.Show("Range must be formated as such: ##-##");
                            return false;
                        }

                        string[] rSplit = range.Split(new char[] { '-', ',' });

                        if (rSplit.Length < 2)
                        {
                            MessageBox.Show("Range must contain at least 2 numbers.");
                            return false;
                        }

                        if (rSplit.Length % 2 == 1)
                        {
                            MessageBox.Show("Range must contain an even amount of parameters.");
                            return false;
                        }

                        intRange.Clear();

                        try
                        {
                            foreach (string s in rSplit)
                            {
                                int i = -1;

                                i = Convert.ToInt32(s);

                                if (i < 1 || i > Bursts.Count)
                                {
                                    throw new Exception();
                                }

                                intRange.Add(i);
                            }
                        }
                        catch
                        {
                            MessageBox.Show(String.Format("Range must must be between 1 and {0}.", Bursts.Count));
                            return false;
                        }
                    }
                    else
                    {
                        intRange.Clear();
                        intRange.Add(1);
                        intRange.Add(Bursts.Count);
                    }



                    if (txtGroup.Text.Length < 1)
                    {
                        groupSize = DEFAULT_GROUP_SIZE;
                        MessageBox.Show("Group Size must contain a number");
                        return false;
                    }
                    else
                    {
                        groupSize = Convert.ToInt32(txtGroup.Text);

                        if (groupSize < 1)
                        {
                            groupSize = DEFAULT_GROUP_SIZE;
                            MessageBox.Show("Group Size must be greater than 1.");
                            return false;
                        }
                    }

                    if (txtStart.Text.Length < 1)
                    {
                        MessageBox.Show("Start must contain a number");
                        return false;
                    }
                    else
                    {
                        start = Convert.ToInt32(txtStart.Text);
                        if (start < 1 || start > Bursts.Count)
                        {
                            groupSize = DEFAULT_GROUP_SIZE;
                            MessageBox.Show(String.Format("Start must be between 1 and {0}", Bursts.Count));
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "CalcGpsPointForm:CheckInput");
            }

            return true;
        }

        private bool Filter()
        {
            if (clearing)
                return false;

            int fType = 0;
            double dDOP = -1;
            bool DOP = false;   //PDOP true, HDOP false
            pointX = pointY = pointZ = -1;
            calculated = false;

            try
            {
                switch (cboFixType.SelectedIndex)
                {
                    case 4:
                        fType = 5;
                        break;
                    case 5:
                        fType = 4;
                        break;
                    default:
                        fType = cboFixType.SelectedIndex;
                        break;
                }

                fType = cboFixType.SelectedIndex;

                try
                {
                    if (txtDOP.Text.Length > 0)
                    {
                        dDOP = Convert.ToDouble(txtDOP.Text.ToString());
                    }
                }
                catch
                {
                    if (cboDOP.SelectedIndex == 0)
                        MessageBox.Show("Dilution of Precision must be a valid number.");
                    else
                        MessageBox.Show("Horizontal Dilution of Precision must be a valid number.");
                    return false;
                }

                if (cboDOP.SelectedIndex == 0)
                {
                    DOP = true;
                }

                ToUseBursts.Clear();

                for (int i = 0; i < intRange.Count; i += 2)
                {
                    int s = intRange[i], e = intRange[i + 1];

                    if (s > e)
                    {
                        int swap = s;
                        s = e;
                        e = swap;
                    }

                    for (int j = s - 1; j < e; j++)
                    {
                        if (j >= (start -1)) //start point
                        {
                            NmeaBurst burst = Bursts[j];

                            if (!burst.drop && filterFix(burst, fType))  //fix tpye
                            {
                                if (DOP)    //is PDOP
                                {
                                    if (burst._PDOP <= dDOP)   //if burst.PDOP <=
                                    {
                                        ToUseBursts.Add(burst);
                                    }
                                }
                                else        //is HDOP
                                {
                                    if (burst._HDOP <= dDOP)   //if burst.HDOP is <=
                                    {
                                        ToUseBursts.Add(burst);
                                    }
                                }
                            }
                        }
                    }
                }


                lblBurstInfo.Text = String.Format("{0} of {1}{2}Bursts used.", ToUseBursts.Count, Bursts.Count,
#if (PocketPC || WindowsCE || Mobile)
                    Values.WideScreen ? Environment.NewLine : " ");
#else
                    " ");
#endif
            
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "CalcGpsPointForm:Filter");
            }

            return true;
        }

        bool filterFix(NmeaBurst burst, int filter)
        {
            //no fix
            if (filter == 0)
                return true;

            if (burst._fix == 3 && burst._fix_quality >= filter)
            {
                return true;
            }

            //if (burst._fix == 3 &&
            //    (burst._fix_quality >= filter ||
            //    (filter == 4 && burst._fix_quality == 5) ||
            //    (filter == 5 && burst._fix_quality == 4)))
            //{
            //    return true;
            //}

            return false;
        }

        private void Calculate()
        {
            calculated = false;

            try
            {
                if (CheckInput())
                {
                    if (Filter())
                    {
                        int i = 0, count = 0;

                        double x = 0, y = 0;
                        double dRMSEx = 0, dRMSEy = 0, dRMSEr;

                        #region 1st
                        if (ToUseBursts.Count > 0)
                        {
                            for (i = 0; i < ToUseBursts.Count && i < groupSize; i++)
                            {
                                x += ToUseBursts[i]._X;
                                y += ToUseBursts[i]._Y;
                            }

                            x /= i;
                            y /= i;

                            for (i = 0; i < ToUseBursts.Count && i < groupSize; i++)
                            {
                                dRMSEx += Math.Pow(ToUseBursts[i]._X - x, 2);
                                dRMSEy += Math.Pow(ToUseBursts[i]._Y - y, 2);
                                count++;
                            }

                            dRMSEx = Math.Sqrt(dRMSEx/count);
                            dRMSEy = Math.Sqrt(dRMSEy / count);
                            dRMSEr = Math.Sqrt(Math.Pow(dRMSEx,2) + Math.Pow(dRMSEy, 2));
                            dRMSEr *= RMSE95_COEF;

                            lblNssda1.Text = dRMSEr.ToString("F2").Truncate(4);
                            lblutmX1.Text = x.ToString("F2").Truncate(9);
                            lblutmY1.Text = y.ToString("F2").Truncate(10);

                            chk1.Enabled = true;
                            chk1.Checked = true;
                        }
                        else
                        {
                            lblutmX1.Text = "000000.00";
                            lblutmY1.Text = "0000000.00";
                            lblNssda1.Text = "00.0";
                        }
                        #endregion

                        #region 2rd
                        if (ToUseBursts.Count > groupSize)
                        {
                            x = 0; y = 0; count = 0;

                            for (i = groupSize; i < ToUseBursts.Count && i < groupSize * 2; i++)
                            {
                                x += ToUseBursts[i]._X;
                                y += ToUseBursts[i]._Y;
                            }

                            x /= (i - groupSize);
                            y /= (i - groupSize);

                            dRMSEx = 0;
                            dRMSEy = 0;
                            dRMSEr = 0;

                            for (i = groupSize; i < ToUseBursts.Count && i < groupSize * 2; i++)
                            {
                                dRMSEx += Math.Pow(ToUseBursts[i]._X - x, 2);
                                dRMSEy += Math.Pow(ToUseBursts[i]._Y - y, 2);
                                count++;
                            }

                            dRMSEx = Math.Sqrt(dRMSEx / count);
                            dRMSEy = Math.Sqrt(dRMSEy / count);
                            dRMSEr = Math.Sqrt(Math.Pow(dRMSEx, 2) + Math.Pow(dRMSEy, 2));
                            dRMSEr *= RMSE95_COEF;

                            lblNssda2.Text = dRMSEr.ToString("F2").Truncate(4);

                            if (x.ToString().Length > 9)
                                lblutmX2.Text = x.ToString("F2").Truncate(9);

                            if (y.ToString().Length > 10)
                                lblutmY2.Text = y.ToString("F2").Truncate(10);

                            chk2.Enabled = true;
                            chk2.Checked = true;
                        }
                        else
                        {
                            lblutmX2.Text = "000000.00";
                            lblutmY2.Text = "0000000.00";
                            lblNssda2.Text = "00.0";
                            chk2.Enabled = false;
                            chk2.Checked = false;
                        }
                        #endregion

                        #region 3rd
                        if (ToUseBursts.Count > groupSize * 2)
                        {
                            x = 0; y = 0; count = 0;

                            for (i = groupSize * 2; i < ToUseBursts.Count; i++)
                            {
                                x += ToUseBursts[i]._X;
                                y += ToUseBursts[i]._Y;
                            }

                            x /= (i - groupSize * 2);
                            y /= (i - groupSize * 2);

                            dRMSEx = 0;
                            dRMSEy = 0;
                            dRMSEr = 0;

                            for (i = groupSize * 2; i < ToUseBursts.Count; i++)
                            {
                                dRMSEx += Math.Pow(ToUseBursts[i]._X - x, 2);
                                dRMSEy += Math.Pow(ToUseBursts[i]._Y - y, 2);
                                count++;
                            }

                            dRMSEx = Math.Sqrt(dRMSEx / count);
                            dRMSEy = Math.Sqrt(dRMSEy / count);
                            dRMSEr = Math.Sqrt(Math.Pow(dRMSEx, 2) + Math.Pow(dRMSEy, 2));
                            dRMSEr *= RMSE95_COEF;

                            lblNssda3.Text = dRMSEr.ToString("F2").Truncate(4);
                            lblutmX3.Text = x.ToString("F2").Truncate(9);
                            lblutmY3.Text = y.ToString("F2").Truncate(10);

                            chk3.Enabled = true;
                            chk3.Checked = true;
                        }
                        else
                        {
                            lblutmX3.Text = "000000.00";
                            lblutmY3.Text = "0000000.00";
                            lblNssda3.Text = "00.0";
                            chk3.Enabled = false;
                            chk3.Checked = false;
                        }
                        #endregion

                        calculated = true;
                        CalculatePoint();
                    }
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "CalcGpsPointForm:Calculate");
            }

        }

        private void CalculatePoint()
        {
            if (clearing)
                return;

            int count = 0, i = 0;
            double x = 0, y = 0, z = 0;
            double dRMSEx = 0, dRMSEy = 0, dRMSEr = 0;

            pointX = 0;
            pointY = 0;
            pointZ = 0;
            pointRMSEr = 0;

            NmeaBurst tmpBurst;

            try
            {
                for (i = 0; i < ToUseBursts.Count; i++)
                {
                    ToUseBursts[i]._Used = false;
                }

                if (chk1.Enabled && chk1.Checked)
                {
                    for (i = 0; i < ToUseBursts.Count && i < groupSize; i++)
                    {
                        ToUseBursts[i]._Used = true;
                        tmpBurst = ToUseBursts[i];

                        x += tmpBurst._X;
                        y += tmpBurst._Y;
                        z += tmpBurst._Z;
                        count++;
                    }
                }

                if (chk2.Enabled && chk2.Checked)
                {
                    for (i = groupSize; i < ToUseBursts.Count && i < groupSize * 2; i++)
                    {
                        ToUseBursts[i]._Used = true;
                        tmpBurst = ToUseBursts[i];

                        x += tmpBurst._X;
                        y += tmpBurst._Y;
                        z += tmpBurst._Z;
                        count++;
                    }
                }

                if (chk3.Enabled && chk3.Checked)
                {
                    for (i = groupSize * 2; i < ToUseBursts.Count; i++)
                    {
                        ToUseBursts[i]._Used = true;
                        tmpBurst = ToUseBursts[i];

                        x += tmpBurst._X;
                        y += tmpBurst._Y;
                        z += tmpBurst._Z;
                        count++;
                    }
                }

                if (count > 0)
                {
                    pointX = x / count;
                    pointY = y / count;
                    pointZ = z / count;

                    for (i = 0; i < ToUseBursts.Count; i++)
                    {
                        tmpBurst = ToUseBursts[i];

                        if (tmpBurst._Used)
                        {
                            dRMSEx += Math.Pow(tmpBurst._X - pointX, 2);
                            dRMSEy += Math.Pow(tmpBurst._Y - pointY, 2);
                        }
                    }

                    dRMSEx = Math.Sqrt(dRMSEx / count);
                    dRMSEy = Math.Sqrt(dRMSEy / count);
                    dRMSEr = Math.Sqrt(Math.Pow(dRMSEx, 2) + Math.Pow(dRMSEy, 2));
                    dRMSEr *= RMSE95_COEF;

                    pointRMSEr = dRMSEr;

                    lblNssda.Text = pointRMSEr.ToString("F2").Truncate(4);
                    lblUtmX.Text = pointX.ToString("F2").Truncate(9);
                    lblUtmY.Text = pointY.ToString("F2").Truncate(10);

                    lblBurstInfo.Text = String.Format("{0} of {1}{2}Bursts used.", count, Bursts.Count,
#if (PocketPC || WindowsCE || Mobile)
                    Values.WideScreen ? Environment.NewLine : " ");
#else
 " ");
#endif
                }
                else
                {
                    lblNssda.Text = "000000.00";
                    lblUtmX.Text = "0000000.00";
                    lblUtmY.Text = "00000000.00";
                }
            }
            catch (Exception ex)
            {
                TtUtils.WriteError(ex.Message, "CalcGpsPointForm:CalculatePoint");
            }
        }


        private void Clear()
        {
            if (calculated)
            {
                clearing = true;

                lblutmX1.Text = "000000.00";
                lblutmY1.Text = "0000000.00";
                lblNssda1.Text = "0.00";
                lblutmX2.Text = "000000.00";
                lblutmY2.Text = "0000000.00";
                lblNssda2.Text = "0.00";
                lblutmX3.Text = "000000.00";
                lblutmY3.Text = "0000000.00";
                lblNssda3.Text = "0.00";

                lblUtmX.Text = "000000.00";
                lblUtmY.Text = "0000000.00";
                lblNssda.Text = String.Empty;

                lblBurstInfo.Text = String.Empty;

                chk1.Checked = false;
                chk1.Enabled = false;
                chk2.Checked = false;
                chk2.Enabled = false;
                chk3.Checked = false;
                chk3.Enabled = false;

                calculated = false;

                clearing = false;
            }
        }

        #region Controls

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            canceled = true;
            this.Close();
        }

        private void btnCalc_Click2(object sender, EventArgs e)
        {
            TtUtils.ShowWaitCursor();
            chk1.Enabled = false;
            chk2.Enabled = false;
            chk3.Enabled = false;
            Filter();
            Calculate();
            TtUtils.HideWaitCursor();
        }

        private void btnOk_Click2(object sender, EventArgs e)
        {
            if (calculated)
            {
                if (pointX > 0 && pointY > 0)
                {
                    try
                    {
                        if (!recalculated)
                            DAL.SaveNmeaBursts(ToUseBursts, pointCN);   //save bursts
                        else
                        {
                            DAL.UpdateNmeaBursts(ToUseBursts, pointCN); //update bursts that are used
                        }
                    }
                    catch (Exception ex)
                    {
                        TtUtils.WriteError(ex.Message, "CalcGpsPointFormLogic:SaveNmea");
                    }

                    Values.Settings.DeviceOptions.Filter_GPS_DOP_TYPE = cboDOP.SelectedIndex;
                    Values.Settings.DeviceOptions.Filter_GPS_FixType = cboFixType.SelectedIndex;
                    Values.Settings.DeviceOptions.Filter_GPS_DOP_VALUE = Convert.ToDouble(txtDOP.Text);

                    canceled = false;
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show("This Point does not have a value. Are you sure you want to continue? Otherwise please refilter and recalcualte the point.",
                        "Point has no value", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                        canceled = true;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("You have not calculated a position. Would you like to calculate it now?","Point not calculated",MessageBoxButtons.YesNo,MessageBoxIcon.Hand,MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Yes)
                {
                    Calculate();
                }
                else
                {
                    canceled = true;
                    this.Close();
                }
            }
        }

#if (PocketPC || WindowsCE || Mobile)
        private void btnDOP_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (object item in cboDOP.Items)
            {
                cboItems.Add(item.ToString());
            }

            using (Selection form = new Selection("Dilution of Precision", cboItems, cboDOP.SelectedIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnDOP.Text = cboItems[form.selection].ToString();
                    cboDOP.SelectedIndex = form.selection;
                }
            }

            Clear();
        }

        private void btnFixType_Click2(object sender, EventArgs e)
        {
            List<string> cboItems = new List<string>();

            foreach (object item in cboFixType.Items)
            {
                cboItems.Add(item.ToString());
            }

            using (Selection form = new Selection("Fix Type", cboItems, cboFixType.SelectedIndex))
            {
               if (form.ShowDialog() == DialogResult.OK)
                {
                    btnFixType.Text = cboItems[form.selection].ToString();
                    cboFixType.SelectedIndex = form.selection;
                }
            }

            Clear();
        }
#endif

        private void cboDOP_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Clear();
#if (PocketPC || WindowsCE || Mobile)
            btnDOP.Text = cboDOP.Text;
#endif
        }

        private void cboFixType_SelectedIndexChanged2(object sender, EventArgs e)
        {
            Clear();
#if (PocketPC || WindowsCE || Mobile)
            btnFixType.Text = cboFixType.Text;
#endif

            Calculate();
        }

        private void chkCustom_CheckStateChanged2(object sender, EventArgs e)
        {
            Clear();
            txtGroup.Enabled = chkCustom.Checked;
            txtRange.Enabled = chkCustom.Checked;
            txtStart.Enabled = chkCustom.Checked;
        }

        private void chk1_CheckStateChanged2(object sender, EventArgs e)
        {
            if (calculated)
            {
                CalculatePoint();
            }
        }

        private void chk2_CheckStateChanged2(object sender, EventArgs e)
        {
            if (calculated)
            {
                CalculatePoint();
            }
        }

        private void chk3_CheckStateChanged2(object sender, EventArgs e)
        {
            if (calculated)
            {
                CalculatePoint();
            }
        }

        private void txtDOP_TextChanged2(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtGroup_TextChanged2(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtRange_TextChanged2(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtStart_TextChanged2(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion

        #region Focus

        private void txtDOP_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtDOP);
        }

        private void txtDOP_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtGroup_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtGroup);
        }

        private void txtGroup_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtRange_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtRange);
        }

        private void txtRange_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        private void txtStart_GotFocus2(object sender, EventArgs e)
        {
            Kb.ShowNumeric(this, txtStart);
        }

        private void txtStart_LostFocus2(object sender, EventArgs e)
        {
            Kb.Hide(this);
        }

        #endregion


        public bool IsCalaculated
        {
            get{ return (calculated && pointX != -1 && pointY != -1); }
        }

        public bool Canceled
        {
            get { return canceled; }
        }

        public GpsPoint _GpsPoint
        {
            get
            {
                GpsPoint p = new GpsPoint();
                p.UnAdjX = pointX;
                p.UnAdjY = pointY;
                p.UnAdjZ = pointZ;
                p.X = p.UnAdjX;
                p.Y = p.UnAdjY;
                p.Z = p.UnAdjZ;
                p.RMSEr = (pointRMSEr > Values.Settings.DeviceOptions.MIN_POINT_ACCURACY) ?
                    pointRMSEr : Values.Settings.DeviceOptions.DEFAULT_POINT_ACCURACY; ;

                return p;
            }
        }
    }
}