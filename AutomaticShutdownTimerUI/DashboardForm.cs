﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace AutomaticShutdownTimerUI {
    public partial class DashboardForm : Form {
        int hours;
        int minutes;
        int seconds;
        bool shutdownInitiated = false;
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        delegate void Callback();

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

                    //New thread to avoid stopping the process
                    var thread = new Thread(() => MessageBox.Show("Turning off pc..."));
                    thread.Start();

                    //turn off pc
                    var processInfo = new ProcessStartInfo("shutdown", "/s /t 10");
                    processInfo.UseShellExecute = true;
                    processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(processInfo);
                }
            } else {
                SubtractTime();
                RefreshTextBox();
            }
        }

        private void SetAllUp() {
            timerTextBox.Visible = false;
            hoursPicker.Visible = true;
            hoursLabel.Visible = true;
            minutesPicker.Visible = true;
            minutesLabel.Visible = true;
            secondsPicker.Visible = true;
            secondsLabel.Visible = true;
        }

        private void RefreshTextBox() {
            if(timerTextBox.InvokeRequired) {
                Invoke(new Callback(RefreshTextBox), new object[] { });
            } else {
                timerTextBox.Text = $"{FormatTimeNumber(hours)} : {FormatTimeNumber(minutes)} : {FormatTimeNumber(seconds)}";
            }
        }

        private void startButton_Click(object sender, EventArgs e) {
            hours = (int)hoursPicker.Value;
            minutes = (int)minutesPicker.Value;
            seconds = (int)secondsPicker.Value;
            hoursPicker.Visible = false;
            hoursLabel.Visible = false;
            minutesPicker.Visible = false;
            minutesLabel.Visible = false; 
            secondsPicker.Visible = false;
            secondsLabel.Visible = false;

            //set up timerTextBox text
            timerTextBox.Visible = true;
            RefreshTextBox();

            //start timer
            timer.Start();
        }

        private bool CheckIfOver() {
            int remainingTime = seconds + minutes + hours;

            if(remainingTime <= 30) {
                //steal focus to warn the user
                StealFocus();
            }

            return remainingTime <= 0;
        }

        private void StealFocus() {
            if(this.InvokeRequired) {
                Invoke(new Callback(StealFocus), new object[] { });
            } else {
                this.TopMost = true;
                this.Activate();
            }
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
            this.TopMost = false;
            secondsPicker.Value = seconds;
            minutesPicker.Value = minutes;
            hoursPicker.Value = hours;
            SetAllUp();
            //stop timer
            timer.Stop();
        }
    }
}
