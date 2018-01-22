using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CurlClock
{
    public partial class PracticeTimer : Form
    {
        private SimpleClock practiceClock;
        private const int PRACTICE_TIME = 9;
        
        public PracticeTimer()
        {
            InitializeComponent();
            AdjustFontSizes();
            practiceClock = new SimpleClock(PRACTICE_TIME, 0);

            // clock refresh timing
            System.Windows.Forms.Timer clockTick = new System.Windows.Forms.Timer();
            clockTick.Interval = 100;
            clockTick.Tick += new EventHandler(forceRedraw);
            clockTick.Enabled = true;
        }

        private void forceRedraw(object obj, EventArgs a)
        {
            this.Invalidate();
        }

        private void AdjustFontSizes()
        {
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            const float MAX_SIZE = 500;
            System.Drawing.Font workingFont = new System.Drawing.Font("Microsoft Sans Serif", MAX_SIZE, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            string textToMeasure = "10:00";
            float newSize = MAX_SIZE;
            float strw = graphics.MeasureString(textToMeasure, workingFont).Width;

            while (strw > practiceClockLabel.Width)
            {
                newSize = newSize * 0.9f;
                workingFont = new System.Drawing.Font("Microsoft Sans Serif", newSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                strw = graphics.MeasureString(textToMeasure, workingFont).Width;
            }

            practiceClockLabel.Font = workingFont;
        }

        private void PracticeTimer_Paint(object sender, PaintEventArgs e)
        {
            practiceClockLabel.Text = practiceClock.getTimeString(false);
        }

        private void PracticeTimer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                practiceClock.reset();
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (practiceClock.isRunning()) practiceClock.stop(); 
                else practiceClock.start();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (!practiceClock.isRunning()) this.Close();
            }
            else if (e.KeyCode == Keys.Up)
            {
                practiceClock.setNextMinute();
            }
            else if (e.KeyCode == Keys.Down)
            {
                practiceClock.setLastMinute();
            }
        }
    }
}
