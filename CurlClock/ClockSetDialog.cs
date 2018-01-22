using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CurlClock
{
    public partial class ClockSetDialog : Form
    {
        public ClockSetDialog() : this(73, 0, "Clock")
        {
        }

        public ClockSetDialog(int minutes, int seconds, string title)
        {
            InitializeComponent();
            this.Text = "Set " + title;
            minutesValue.Value = minutes;
            secondsValue.Value = seconds;
            secondsValue.Select();
        }

        private void secondsValue_ValueChanged(object sender, EventArgs e)
        {
            if (secondsValue.Value > 59)
            {
                secondsValue.Value = 0;
                minutesValue.Value = minutesValue.Value + 1;
            }
            else if (secondsValue.Value < 0)
            {
                if (minutesValue.Value > 0)
                {
                    secondsValue.Value = 59;
                    minutesValue.Value--;
                }
                else
                {
                    secondsValue.Value = 0;
                }
            }
        }
        public int Minutes
        {
            get
            {
                return (int)minutesValue.Value;
            }
        }

        public int Seconds
        {
            get
            {
                return (int)secondsValue.Value;
            }
        }

        private void minutesValue_Enter(object sender, EventArgs e)
        {
            minutesValue.Select(0, 10);
        }

        private void secondsValue_Enter(object sender, EventArgs e)
        {
            secondsValue.Select(0, 10);
        }
    }
}