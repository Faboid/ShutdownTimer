using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Diagnostics;
using AutomaticShutdownTimerLibrary;

namespace AutomaticShutdownTimerUI {
    public partial class DashboardForm : Form {
        Time time;
        delegate void Callback();

        public DashboardForm() {
            InitializeComponent();
            InitializeFormValues();
        }

        private void InitializeFormValues() {
            SetDefaultVisibilities();
            Countdown.timer.Elapsed += Timer_Elapsed;

            //set to 0 to avoid null-reference exceptions
            time = new Time(0, 0, 0);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            Logic.MainLogic(time);

            RefreshTextBox();
            if(time.ToSeconds() <= 30) {
                StealFocus();
            }
        }

        private void RefreshTextBox() {
            if(timerTextBox.InvokeRequired) {
                Invoke(new Callback(RefreshTextBox), new object[] { });
            } else {
                timerTextBox.Text = time.ToString();
            }
        }

        private void StealFocus() {
            if(this.InvokeRequired) {
                Invoke(new Callback(StealFocus), new object[] { });
            } else {
                this.TopMost = true;
                this.Activate();
            }
        }

        private bool WarnIfZero() {
            if((secondsPicker.Value + minutesPicker.Value + hoursPicker.Value) == 0) {
                DialogResult result = MessageBox.Show("Turn off the computer now?", "Shutdown?", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes) {
                    //todo - introduce different way of handling this
                    Logic.MainLogic(new Time(0, 0, 0));
                }
                return true;
            }
            return false;
        }

        private void startButton_Click(object sender, EventArgs e) {
            if(!WarnIfZero()) {
                time = new Time((int)hoursPicker.Value, (int)minutesPicker.Value, (int)secondsPicker.Value);

                SetRunningVisibilities();

                //set up timerTextBox text
                RefreshTextBox();

                //start timer
                Countdown.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e) {
            this.TopMost = false;

            secondsPicker.Value = time.Seconds;
            minutesPicker.Value = time.Minutes;
            hoursPicker.Value = time.Hours;

            SetDefaultVisibilities();
            //stop timer
            Countdown.Stop();
        }

        private void SetRunningVisibilities() {
            startButton.Enabled = false;
            stopButton.Enabled = true;

            hoursPicker.Visible = false;
            hoursLabel.Visible = false;
            minutesPicker.Visible = false;
            minutesLabel.Visible = false;
            secondsPicker.Visible = false;
            secondsLabel.Visible = false;

            timerTextBox.Visible = true;
        }

        private void SetDefaultVisibilities() {
            timerTextBox.Visible = false;

            startButton.Enabled = true;
            stopButton.Enabled = false;

            hoursPicker.Visible = true;
            hoursLabel.Visible = true;
            minutesPicker.Visible = true;
            minutesLabel.Visible = true;
            secondsPicker.Visible = true;
            secondsLabel.Visible = true;
        }
    }
}
