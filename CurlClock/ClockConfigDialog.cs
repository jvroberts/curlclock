using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CurlClock
{
    public partial class ClockConfigDialog : Form
    {
        private Color clockColor, textColor;
        private Keys startKeyCode;
        public ClockConfigDialog() : this("", Color.Black, Color.White, "Clock", 0, "")
        {
        }
        public ClockConfigDialog(string teamName, Color clockColor, Color textColor, string title, Keys startKeyCode, string startKeyChar)
        {
            InitializeComponent();
            this.Text = "Configure " + title;
            teamNameTextBox.Text = teamName;
            this.clockColor = clockColor;
            clockColorComboBox.BackColor = clockColor;
            this.textColor = textColor;
            textColorComboBox.BackColor = textColor;
            this.startKeyCode = startKeyCode;
            startKeyTextBox.Text = startKeyChar;
        }

        public Color ClockColor
        {
            get
            {
                return clockColor;
            }
        }
        public Color TextColor
        {
            get
            {
                return textColor;
            }
        }
        public Keys StartKey
        {
            get
            {
                return startKeyCode;
            }
        }
        public string StartKeyChar
        {
            get
            {
                return startKeyTextBox.Text;
            }
        }
        public string TeamName
        {
            get
            {
                return teamNameTextBox.Text;
            }
        }

        private void clockColorComboBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.clockColor = colorDialog1.Color;
                clockColorComboBox.BackColor = colorDialog1.Color;
            }
        }

        private void clockColorComboBox_TextUpdate(object sender, EventArgs e)
        {
            clockColorComboBox.Text = "";
        }

        private void textColorComboBox_TextUpdate(object sender, EventArgs e)
        {
            textColorComboBox.Text = "";
        }

        private void textColorComboBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textColor = colorDialog1.Color;
                textColorComboBox.BackColor = colorDialog1.Color;
            }      
        }

        private void startKeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            startKeyCode = e.KeyCode;
            startKeyTextBox.Text = "";
        }

        private void startKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            startKeyTextBox.Text = startKeyTextBox.Text.ToUpper();
        }
    }
}