using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwoTrails.Utilities;

namespace TwoTrails.Forms
{
    public partial class SplashScreen : Form
    {
        bool close = false;//, painted = false;
        Timer timer;


        public SplashScreen()
        {
            InitializeComponent();
#if DEBUG
            btnExit.Visible = true;
#endif

            timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (!close)
                close = true;
            else
            {
                timer.Stop();
                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //if (painted) return;

            Bitmap bmp = new Bitmap(Properties.Resources.MapImage.ResizeImage2(new Size(324, 234), true));

            Brush brush = new SolidBrush(Color.FromArgb(255, 88, 135, 97));

            Point[] points = new Point[6];

            points[0] = new Point(12, 22);
            points[1] = new Point(300, 22);
            points[2] = new Point(370, 90);
            points[3] = new Point(370, 200);
            points[4] = new Point(300, 268);
            points[5] = new Point(12, 268);


            e.Graphics.FillPolygon(brush, points);

            e.Graphics.DrawImage(bmp, new Point(130, 51));

            e.Graphics.DrawString("TwoTrails V2", new Font("Chiller", 48, FontStyle.Bold),
                new SolidBrush(Color.Black), new PointF(12, 20));


            //e.Graphics.DrawString(String.Format("Version: {0}", Engine.Values.TwoTrailsVersion), new Font("Chiller", 18, FontStyle.Bold),
                //new SolidBrush(Color.Black), new PointF(12, 194)); ;

            e.Graphics.DrawString("USFS FMSC", new Font("Chiller", 18, FontStyle.Bold),
                new SolidBrush(Color.Black), new PointF(12, 216)); ;

            e.Graphics.DrawString(String.Format("Version: {0}", Engine.Values.TwoTrailsVersion), new Font("Chiller", 18, FontStyle.Bold),
                new SolidBrush(Color.Black), new PointF(12, 238));

            //painted = true;

            //base.OnPaintBackground(e);
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //painted = false;
            //this.Refresh();
            timer.Stop();
            this.Close();
        }
    }
}
