using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CurlClock
{
    public partial class CurlClockForm : Form
    {
        private const int TEN_END_GAME_MINS = 73;
        private const int TEN_END_GAME_DELAYED_START_MINS = 7;
        private const int MIXED_DOUBLES_MINS = 46;
        private const int MIXED_DOUBLES_EXTRA_END_MINS = 8;
        private const int MIXED_DOUBLES_DELAYED_START_MINS = 6;
        private const int WHEELCHAIR_MINS = 68;
        private const int WHEELCHAIR_DELAYED_START_MINS = 8;
        private const int WHEELCHAIR_EXTRA_END_MINS = 10;
        private const int EIGHT_END_GAME_MINS = 59;
        private const int EIGHT_END_DELAYED_START_MINS = 7;
        private const int EXTRA_END_MINS = 9;
        private const int THINKING_TEN_END_GAME_MINS = 40;
        private const int THINKING_TEN_END_GAME_DELAYED_START_MINS = 4;
        private const int THINKING_EIGHT_END_GAME_MINS = 32;
        private const int THINKING_EIGHT_END_GAME_DELAYED_START_MINS = 4;
        private const int THINKING_EXTRA_END_MINS = 5;

        private GameType selectedGame;

        private enum GameType
        {
            TenEndGame,
            MixedDoubles,
            EightEndGame,
            Wheelchair,
            ThinkingTime10End,
            ThinkingTime8End
        }

        private SimpleClock clock1, clock2, clock3;
        public CurlClockForm()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //menuStrip1.Visible = false;
            //AdjustFontSizes();

            // try to read game from settings
            try
            {
                GameType game = (GameType)Enum.Parse(typeof(GameType), Properties.Settings.Default.GameType);
                SelectedGame = game;
            }
            catch (Exception)
            {
                SelectedGame = GameType.TenEndGame;
            }
            
            clock1 = new SimpleClock(gameStartClockTime(), 0, 
                                     Properties.Settings.Default.UpperClockName, 
                                     Properties.Settings.Default.UpperClockColor,
                                     Properties.Settings.Default.UpperClockTextColor,
                                     Properties.Settings.Default.UpperClockStartKey,
                                     Properties.Settings.Default.UpperClockStartKeyChar);
            clock2 = new SimpleClock(gameStartClockTime(), 0,
                                     Properties.Settings.Default.LowerClockName,
                                     Properties.Settings.Default.LowerClockColor,
                                     Properties.Settings.Default.LowerClockTextColor,
                                     Properties.Settings.Default.LowerClockStartKey,
                                     Properties.Settings.Default.LowerClockStartKeyChar); 
            clock3 = new SimpleClock(1, 0, "Timeout", Color.Gray, Color.Black, Keys.T, "T");
            updateKeyShortcuts();
            clockLabel1.Text = clock1.getTimeString();
            clockLabel2.Text = clock2.getTimeString();
            clockLabel3.Text = clock3.getTimeString();
            AdjustFontSizes();

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

        private void CurlClock_Resize(object sender, EventArgs e)
        {
            AdjustFontSizes();
        }
        private void AdjustFontSizes()
        {
            // resize the clock text size if the window is resized.
            clockLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", clockPanel1.Height > 20 ? clockPanel1.Height - 20 : 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            clockLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", clockPanel2.Height > 20 ? clockPanel2.Height - 20 : 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            clockLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", clockPanel3.Height > 20 ? clockPanel3.Height - 20 : 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            //clockTeamLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", clockTeamLabel1.Width * 0.1 > 1 ? (int)(clockTeamLabel1.Width * 0.1) : 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            //clockTeamLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", clockTeamLabel2.Width * 0.1 > 1 ? (int)(clockTeamLabel2.Width * 0.1) : 1, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            const float MAX_SIZE = 200;
            System.Drawing.Font workingFont = new System.Drawing.Font("Microsoft Sans Serif", MAX_SIZE, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            string textToMeasure = graphics.MeasureString(clock1.ClockName, workingFont).Width > graphics.MeasureString(clock2.ClockName, workingFont).Width ? clock1.ClockName : clock2.ClockName;
            float newSize = MAX_SIZE;
            float strw = graphics.MeasureString(textToMeasure, workingFont).Width;

            while (strw > clockTeamLabel1.Width) {
                newSize = newSize * 0.9f;
                workingFont = new System.Drawing.Font("Microsoft Sans Serif", newSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                strw = graphics.MeasureString(textToMeasure, workingFont).Width;
            }

            clockTeamLabel1.Font = workingFont;
            clockTeamLabel2.Font = workingFont;
        }

        private void CurlClockForm_Paint(object sender, PaintEventArgs e)
        {
            clockLabel1.Text = clock1.getTimeString();
            clockLabel2.Text = clock2.getTimeString();
            clockLabel3.Text = clock3.getTimeString();
            clockTeamLabel1.Text = clock1.ClockName;
            clockTeamLabel2.Text = clock2.ClockName;
            clockLabel1.ForeColor = clock1.TextColor;
            clockTeamLabel1.ForeColor = clock1.isRunning() ? clock1.ClockColor : clock1.TextColor;
            clockLabel2.ForeColor = clock2.TextColor;
            clockTeamLabel2.ForeColor = clock2.isRunning() ? clock2.ClockColor : clock2.TextColor;
            clockPanel1.BackColor = clock1.ClockColor;
            teamPanel1.BackColor = clock1.isRunning() ? clock1.TextColor : clock1.ClockColor;
            clockPanel2.BackColor = clock2.ClockColor;
            teamPanel2.BackColor = clock2.isRunning() ? clock2.TextColor : clock2.ClockColor;
        }
        private Color dimColor(Color col)
        {
            int d = 128;
            return Color.FromArgb(col.R > d ? col.R - d : 0, 
                col.G > d ? col.G - d : 0, 
                col.B > d ? col.B - d : 0);
        }
        private void startClock(int clock)
        {
            if (clock == 1)
            {
                clock1.start();
                clock2.stop();
                clock3.stop();
            }
            else if (clock == 2)
            {
                clock1.stop();
                clock2.start();
                clock3.stop();
            }
            else if (clock == 3)
            {
                clock1.stop();
                clock2.stop();
                clock3.start();
            }
            else
            {
                clock1.stop();
                clock2.stop();
                clock3.stop();
            }
        }
        private void CurlClockForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == clock1.StartKey)
            {
                startClock(1);
            }
            else if (e.KeyCode == clock2.StartKey)
            {
                startClock(2);
            }
            else if (e.KeyCode == clock3.StartKey)
            {
                startClock(3);
            }
            else if (e.KeyCode == Keys.X || e.KeyCode == Keys.Space)
            {
                startClock(0);
            }
            else if (e.KeyCode == Keys.Up) clock3.setNextMinute();
            else if (e.KeyCode == Keys.Down) clock3.setLastMinute();
            else if (e.KeyCode == Keys.P) showPracticeClock();
        }
        private void startClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startClock(1);
        }

        private void stopClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startClock(0);
        }

        private void startClockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            startClock(2);
        }

        private void stopClockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            startClock(0);
        }

        private void startClockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            startClock(3);
        }

        private void stopClockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            startClock(0);
        }

        private void setClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setClockDialog(clock1, "Upper Clock");
        }
        private void setClockDialog(SimpleClock clock, string title)
        {
            if (!clock.isRunning())
            {
                string[] currtime = clock.getTimeString().Split(':');
                ClockSetDialog csd = new ClockSetDialog(Int32.Parse(currtime[0]), Int32.Parse(currtime[1]), title);
                if (csd.ShowDialog() == DialogResult.OK)
                {
                    clock.setTime(csd.Minutes, csd.Seconds);
                }
            }
        }

        private void setClockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            setClockDialog(clock2, "Lower Clock");
        }

        private void setClockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setClockDialog(clock3, "Timeout Clock");
        }

        private void configureClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configClockDialog(clock1, "Upper Clock");
        }
        private void configClockDialog(SimpleClock clock, string title)
        {
            ClockConfigDialog ccd = new ClockConfigDialog(clock.ClockName, clock.ClockColor, clock.TextColor, title, clock.StartKey, clock.StartKeyChar);
            if (ccd.ShowDialog() == DialogResult.OK)
            {
                clock.ClockName = ccd.TeamName;
                clock.ClockColor = ccd.ClockColor;
                clock.TextColor = ccd.TextColor;
                clock.StartKey = ccd.StartKey;
                clock.StartKeyChar = ccd.StartKeyChar;
                updateKeyShortcuts();
                AdjustFontSizes();
            }
        }

        private void configureClockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            configClockDialog(clock2, "Lower Clock");
            
        }

        private void addMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock3.setNextMinute();
        }

        private void minuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock3.setLastMinute();
        }
        private void updateKeyShortcuts()
        {
            clock1StartClockToolStripMenuItem.ShortcutKeyDisplayString = clock1.StartKeyChar;
            clock2StartClockToolStripMenuItem.ShortcutKeyDisplayString = clock2.StartKeyChar;
        }

        private void extraEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confirmClockReset(extraEndClockTime());
        }

        private bool confirmClockReset(int minutes)
        {
            bool changed = false;
            if (!clock1.isRunning() && !clock2.isRunning())
            {
                if (MessageBox.Show("Reset both clocks to " + minutes.ToString() + " minutes?",
                    "Confirm Clock Reset",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clock1.setTime(minutes, 0);
                    clock2.setTime(minutes, 0);
                    changed = true;
                }

            }
            return changed;
        }

        private void CurlClockForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void saveCurrentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save current properties
            Properties.Settings.Default.GameType = SelectedGame.ToString();
            Properties.Settings.Default.UpperClockName = clock1.ClockName;
            Properties.Settings.Default.UpperClockColor = clock1.ClockColor;
            Properties.Settings.Default.UpperClockTextColor = clock1.TextColor;
            Properties.Settings.Default.UpperClockStartKey = clock1.StartKey;
            Properties.Settings.Default.UpperClockStartKeyChar = clock1.StartKeyChar;
            Properties.Settings.Default.LowerClockName = clock2.ClockName;
            Properties.Settings.Default.LowerClockColor = clock2.ClockColor;
            Properties.Settings.Default.LowerClockTextColor = clock2.TextColor;
            Properties.Settings.Default.LowerClockStartKey = clock2.StartKey;
            Properties.Settings.Default.LowerClockStartKeyChar = clock2.StartKeyChar;
            Properties.Settings.Default.Save();
        }

        private void resetAllSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }

        private void setUpperClockToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            setClockDialog(clock1, "Upper Clock");
        }

        private void configureClockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            configClockDialog(clock1, "Upper Clock");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setClockDialog(clock2, "Lower Clock");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            configClockDialog(clock2, "Lower Clock");
        }

        private GameType SelectedGame
        {
            get { return selectedGame; }
            set
            {
                endGameToolStripMenuItem.Checked = false;
                mixedDoublesToolStripMenuItem1.Checked = false;
                endGameToolStripMenuItem1.Checked = false;
                wheelchairToolStripMenuItem1.Checked = false;
                thinkingEightEndGameToolStripMenuItem3.Checked = false;
                thinkingTenEndGameToolStripMenuItem2.Checked = false;   

                switch (value)
                {
                    case GameType.TenEndGame:
                        endGameToolStripMenuItem.Checked = true;
                        this.Text = "CurlClock - 10-End Game";
                        break;
                    case GameType.MixedDoubles:
                        mixedDoublesToolStripMenuItem1.Checked = true;
                        this.Text = "CurlClock - Mixed Doubles";
                        break;
                    case GameType.EightEndGame:
                        endGameToolStripMenuItem1.Checked = true;
                        this.Text = "CurlClock - 8-End Game";
                        break;
                    case GameType.Wheelchair:
                        wheelchairToolStripMenuItem1.Checked = true;
                        this.Text = "CurlClock - Wheelchair Curling";
                        break;
                    case GameType.ThinkingTime10End:
                        thinkingTenEndGameToolStripMenuItem2.Checked = true;
                        this.Text = "CurlClock - 10-End Game (Thinking Time)";
                        break;
                    case GameType.ThinkingTime8End:
                        thinkingEightEndGameToolStripMenuItem3.Checked = true;
                        this.Text = "CurlClock - 8-End Game (Thinking Time)";
                        break;
                    default:
                        throw new Exception("Unrecognized game selected.");
                }
                selectedGame = value;
            }
        }

        private void mixedDoublesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedGame = GameType.MixedDoubles;
        }

        private void endGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedGame = GameType.EightEndGame;
        }

        private void wheelchairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectedGame = GameType.Wheelchair;
        }

        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedGame = GameType.TenEndGame;
        }

        private void thinkingTenEndGameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SelectedGame = GameType.ThinkingTime10End;
        }

        private void thinkingEightEndGameToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SelectedGame = GameType.ThinkingTime8End;
        }

        private int extraEndClockTime()
        {
            if (selectedGame == GameType.MixedDoubles) {
                return MIXED_DOUBLES_EXTRA_END_MINS;
            }
            else if (selectedGame == GameType.Wheelchair)
            {
                return WHEELCHAIR_EXTRA_END_MINS;
            }
            else if (selectedGame == GameType.ThinkingTime8End || selectedGame == GameType.ThinkingTime10End)
            {
                return THINKING_EXTRA_END_MINS;
            }
            else return EXTRA_END_MINS;
        }
        private int gameStartClockTime()
        {
            switch (selectedGame)
            {
                case GameType.TenEndGame:
                    return TEN_END_GAME_MINS;
                case GameType.MixedDoubles:
                    return MIXED_DOUBLES_MINS;
                case GameType.EightEndGame:
                    return EIGHT_END_GAME_MINS;
                case GameType.Wheelchair:
                    return WHEELCHAIR_MINS;
                case GameType.ThinkingTime10End:
                    return THINKING_TEN_END_GAME_MINS;
                case GameType.ThinkingTime8End:
                    return THINKING_EIGHT_END_GAME_MINS;
                default:
                    throw new Exception("Unrecognized game selected.");
            }

        }

        private void startOfGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confirmClockReset(gameStartClockTime());
        }

        private int delayedStartClockDeduction()
        {
            switch (selectedGame)
            {
                case GameType.TenEndGame:
                    return TEN_END_GAME_DELAYED_START_MINS;
                case GameType.MixedDoubles:
                    return MIXED_DOUBLES_DELAYED_START_MINS;
                case GameType.EightEndGame:
                    return EIGHT_END_DELAYED_START_MINS;
                case GameType.Wheelchair:
                    return WHEELCHAIR_DELAYED_START_MINS;
                case GameType.ThinkingTime10End:
                    return THINKING_TEN_END_GAME_DELAYED_START_MINS;
                case GameType.ThinkingTime8End:
                    return THINKING_EIGHT_END_GAME_DELAYED_START_MINS;
                default:
                    throw new Exception("Unrecognized game selected.");
            }
        }
        private void delayedStart1EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confirmClockReset(gameStartClockTime() - delayedStartClockDeduction());
        }

        private void delayedStart2EndsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confirmClockReset(gameStartClockTime() - 2 * delayedStartClockDeduction());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit CurlClock?",
                    "Confirm Quit",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void showPracticeClock()
        {
            if (!clock1.isRunning() && !clock2.isRunning() && !clock3.isRunning())
            {
                PracticeTimer pt = new PracticeTimer();
                pt.ShowDialog();
            }
        }




    }
}