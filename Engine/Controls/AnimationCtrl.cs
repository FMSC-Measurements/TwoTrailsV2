using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

//http://msdn.microsoft.com/en-us/library/aa446483.aspx

namespace TwoTrails.Controls
{
    public class AnimationCtrl : System.Windows.Forms.Control
    {
        private Timer fTimer;
        Rectangle rect;
        private Graphics graphics;
        private int loopCount = -1, frameWidth = 0, frameHeight = 0, loopCounter = 0;
        private int currentFrame = 0, frameCount = 0;

        private List<Bitmap> bitmaps;
        public List<Bitmap> Bitmaps { get { return bitmaps; } }

        public AnimationCtrl()
        {
            //Cache the Graphics object
            graphics = this.CreateGraphics();
            //Instantiate the Timer
            fTimer = new System.Windows.Forms.Timer();
            //Hook up to the Timer's Tick event
            fTimer.Tick += new System.EventHandler(this.timer1_Tick);
            Visible = false;
        }

        ~AnimationCtrl()
        {
            Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            fTimer.Dispose();
            graphics.Dispose();
            base.Dispose(disposing);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (loopCount == -1) //loop continuously
            {
                this.DrawFrame();
            }
            else
            {
                if (loopCount == loopCounter) //stop the animation
                    fTimer.Enabled = false;
                else
                    this.DrawFrame();
            }
        }

        private void Draw(int iframe)
        {
            //Draw image
            graphics.DrawImage(resizeBitmap(bitmaps[iframe], frameWidth, frameHeight), 0, 0, rect, GraphicsUnit.Pixel);
        }

        private void DrawFrame()
        {
            if (currentFrame < frameCount -1)
            {
                //move to the next frame
                currentFrame++;
            }
            else
            {
                //increment the loopCounter
                loopCounter++;
                currentFrame = 0;
            }
            Draw(currentFrame);
        }

        public void LoadImage(List<Bitmap> bitmaps, int DelayInterval, int LoopCount)
        {
            LoadImage(bitmaps, DelayInterval, LoopCount, 0, 0);
        }

        public void LoadImage(List<Bitmap> bitmaps, int resizeWidth, int resizeHeight , int DelayInterval, int LoopCount)
        {
            if (bitmaps == null || bitmaps.Count < 1)
                return;

            this.bitmaps = bitmaps;

            //How many times to loop
            loopCount = LoopCount;
            //Calculate the frameCount
            frameCount = this.bitmaps.Count;

            if (resizeWidth > 0)
            {
                frameWidth = resizeWidth;
            }
            else
                frameWidth = this.bitmaps[0].Width;

            if (resizeHeight > 0)
            {
                frameHeight = resizeHeight;
            }
            else
                frameHeight = this.bitmaps[0].Height;

            currentFrame = 0;
            //Reset loop counter
            loopCounter = 0;
            //Resize the control
            this.Size = new Size(frameWidth, frameHeight);
            //Assign delay interval to the timer
            fTimer.Interval = DelayInterval;
            rect = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public void StartAnimation()
        {
            Visible = true;

            if (fTimer != null && !fTimer.Enabled && bitmaps != null && bitmaps.Count > 0)
            {
                //Start the timer
                fTimer.Enabled = true;
            }
        }

        public void StopAnimation()
        {
            //Start the timer
            fTimer.Enabled = false;
        }


        public static Bitmap resizeBitmap(Bitmap original, int newX, int newY)
        {
            Rectangle recSrc = new Rectangle(0, 0, original.Width, original.Height);
            Rectangle recDest = new Rectangle(0, 0, newX, newY);
            Bitmap target = new Bitmap(newX, newY);
            Graphics g = Graphics.FromImage(target);
            g.DrawImage(original, recDest, recSrc, GraphicsUnit.Pixel);
            return target;
        }
    }
}
