using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace AutomaticShutdownTimerUI {
    public partial class DashboardForm : Form {
        int hours;
        int minutes;
        int seconds;
        bool shutdownInitiated = false;
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        delegate void RefreshTextCallback();

        public DashboardForm() {
            InitializeComponent();
            InitializeFormValues();
        }

        private void InitializeFormValues() {
            SetAllUp();
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            if(CheckIfOver()) {
                if(!shutdownInitiated) {
                    shutdownInitiated = true;
                    MessageBox.Show("Turning off pc...");
                    //turn off pc
                }
            } else {
                SubtractTime();
                RefreshTextBox();
            }
        }

        private void SetAllUp() {
            timerTextBox.Visible = false;
            hoursPicker.Visible = true;
            minutesPicker.Visible = true;
            secondsPicker.Visible = true;
        }

        private void RefreshTextBox() {
            if(timerTextBox.InvokeRequired) {
                Invoke(new RefreshTextCallback(RefreshTextBox), new object[] { });
            } else {
                timerTextBox.Text = $"{FormatTimeNumber(hours)} : {FormatTimeNumber(minutes)} : {FormatTimeNumber(seconds)}";
            }
        }

        private void startButton_Click(object sender, EventArgs e) {
            hours = (int)hoursPicker.Value;
            minutes = (int)minutesPicker.Value;
            seconds = (int)secondsPicker.Value;
            hoursPicker.Visible = false;
            minutesPicker.Visible = false;
            secondsPicker.Visible = false;

            //set up timerTextBox text
            timerTextBox.Visible = true;
            RefreshTextBox();

            //start timer
            timer.Start();
        }

        private bool CheckIfOver() {
            return (seconds + minutes + hours > 0) ? false : true;
        }

        private void SubtractTime() {
            int timeValue = seconds + (minutes * 60) + (hours * 3600);
            timeValue--;
            int temp = timeValue % 3600;
            seconds = temp % 60;
            minutes = (temp - seconds) / 60;
            hours = (timeValue - temp) / 3600;
        }

        private static string FormatTimeNumber(int input) {
            return (input >= 10) ? $"{input}" : $"0{input}";
        }

        private void stopButton_Click(object sender, EventArgs e) {
            secondsPicker.Value = seconds;
            minutesPicker.Value = minutes;
            hoursPicker.Value = hours;
            SetAllUp();
            //stop timer
            timer.Stop();
        }
    }
}
