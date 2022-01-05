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
using AutomaticShutdownTimerLibrary.Models;
using AutomaticShutdownTimerLibrary.Services;
using AutomaticShutdownTimerLibrary.Services.Interfaces;
using AutomaticShutdownTimerLibrary.Models.Interfaces;

namespace AutomaticShutdownTimerUI {
    public partial class DashboardForm : Form {

        IAlarmsHandler alarmsHandler;
        TimeHandler timeHandler;

        readonly Shutdown shutdown = new Shutdown();
        delegate void Callback();

        public DashboardForm() {
            InitializeComponent();
            InitializeFormValues();
        }

        private void InitializeFormValues() {
            SetDefaultVisibilities();

            alarmsHandler = new AlarmsHandler();
            alarmsHandler.Register(shutdown.Start, 0, true);
            alarmsHandler.Register(StealFocus, 30, false);

            timeHandler = new TimeHandler(new Time(0, 0, 0), alarmsHandler);

            timeHandler.SecondHasPassed += (obj, time) => { RefreshTextBox(); };
        }

        private void RefreshTextBox() {
            if(timerTextBox.InvokeRequired) {
                Invoke(new Callback(RefreshTextBox), new object[] { });
                return;
            } 
            
            timerTextBox.Text = timeHandler.GetTimeAsReadOnly().ToString();
        }

        private void StealFocus() {
            if(this.InvokeRequired) {
                Invoke(new Callback(StealFocus), new object[] { });
                return;
            }

            this.TopMost = true;
            this.Activate();
        }

        private bool WarnIfZero() {
            if((secondsPicker.Value + minutesPicker.Value + hoursPicker.Value) == 0) {
                DialogResult result = MessageBox.Show("Turn off the computer now?", "Shutdown?", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes) {
                    shutdown.Start();
                }
                return true;
            }
            return false;
        }

        private void startButton_Click(object sender, EventArgs e) {
            if(!WarnIfZero()) {
                timeHandler.Start((int)hoursPicker.Value, (int)minutesPicker.Value, (int)secondsPicker.Value);

                SetRunningVisibilities();

                //set up timerTextBox text
                RefreshTextBox();
            }
        }

        private void stopButton_Click(object sender, EventArgs e) {
            this.TopMost = false;

            var time = timeHandler.GetTimeAsReadOnly();
            secondsPicker.Value = time.Seconds;
            minutesPicker.Value = time.Minutes;
            hoursPicker.Value = time.Hours;

            SetDefaultVisibilities();
            timeHandler.Stop();
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
