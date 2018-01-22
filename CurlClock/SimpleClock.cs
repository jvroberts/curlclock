using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CurlClock
{
    enum ClockState
    {
        Running,
        Stopped
    }
    class SimpleClock
    {
        private TimeSpan timeRemaining;
        private DateTime runStart;
        private ClockState state = ClockState.Stopped;
        private string clockName;
        private Color clockColor, textColor;
        private Keys startKey;
        private string startKeyChar;
        private int lastResetMinutes = 73;
        private int lastResetSeconds = 0;

        public SimpleClock() : this(73, 0)
        {
        }
        public SimpleClock(int minutes, int seconds) : this(minutes, seconds, "Team", Color.Gray, Color.White, 0, "") { }
        public SimpleClock(int minutes, int seconds, string clockName) : this(minutes, seconds, clockName, Color.Gray, Color.White, 0, "") { }
        public SimpleClock(int minutes, int seconds, string clockName, Color clockColor, Color textColor, Keys startKey, string startKeyChar)
        {
            this.clockName = clockName;
            this.clockColor = clockColor;
            this.textColor = textColor;
            this.startKey = startKey;
            this.startKeyChar = startKeyChar;
            setTime(minutes, seconds);
        }
        public Keys StartKey
        {
            get
            {
                return startKey;
            }
            set
            {
                this.startKey = value;
            }
        }
        public string StartKeyChar
        {
            get
            {
                return startKeyChar;
            }
            set
            {
                this.startKeyChar = value;
            }
        }

        public string ClockName
        {
            get
            {
                return clockName;
            }
            set
            {
                this.clockName = value;
            }
        }
        public Color ClockColor
        {
            get
            {
                return clockColor;
            }
            set
            {
                this.clockColor = value;
            }
        }
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                this.textColor = value;
            }
        }
        public bool isRunning()
        {
            if (state == ClockState.Running)
            {
                return true;
            }
            return false;
        }
        public bool setTime(int minutes, int seconds)
        {
            return (setTime(new TimeSpan(0, minutes, seconds)));
        }
        public bool setTime(TimeSpan newTime)
        {
            if (isRunning()) return false;
            lastResetMinutes = newTime.Minutes;
            lastResetSeconds = newTime.Seconds;
            timeRemaining = newTime;
            return true;
        }
        public bool setNextMinute()
        {
            // reset clock to next whole minute
            if (isRunning()) return false;
            setTime(timeRemaining.Minutes + 1, 0);
            return true;
        }
        public bool setLastMinute()
        {
            // reset clock to previous whole minute
            if (isRunning()) return false;
            if (timeRemaining.Minutes > 0) setTime(timeRemaining.Minutes - 1, 0);
            else setTime(0, 0);
            return true;
        }
        public bool reset()
        {
            if (isRunning()) return false;
            return setTime(lastResetMinutes, lastResetSeconds);
        }
        
        public string getTimeString(bool padded)
        {
            int minutes, seconds;
            if (isRunning())
            {
                TimeSpan currTime = timeRemaining - (DateTime.Now - runStart);
                if (currTime.TotalMilliseconds <= 0)
                {
                    stop();
                    currTime = new TimeSpan(0, 0, 0);
                }
                minutes = currTime.Hours * 60 + currTime.Minutes;
                seconds = currTime.Seconds;
                if (currTime.Milliseconds > 0 && currTime.Seconds < 59) seconds++;
                else if (currTime.Milliseconds > 0) { seconds = 0; minutes++; }
            }
            else {
                minutes = timeRemaining.Hours * 60 + timeRemaining.Minutes;
                seconds = timeRemaining.Seconds;
                if (timeRemaining.Milliseconds > 0 && timeRemaining.Seconds < 59) seconds++;
                else if (timeRemaining.Milliseconds > 0) { seconds = 0; minutes++; }
            }
            return (minutes < 10 && padded ? "  " : "") + minutes.ToString("D1") + ":" + seconds.ToString("D2");
        }
        public string getTimeString()
        {
            return getTimeString(true);
        }
        public bool isSet()
        {
            if (isRunning()) return true;
            if (timeRemaining.TotalMilliseconds > 0) return true;
            return false;
        }
        public void start()
        {
            if (isRunning() || !isSet()) return;
            state = ClockState.Running;
            runStart = DateTime.Now;
        }
        public void stop()
        {
            if (!isRunning()) return;
            state = ClockState.Stopped;
            timeRemaining = timeRemaining - (DateTime.Now - runStart);
        }
    }
}
