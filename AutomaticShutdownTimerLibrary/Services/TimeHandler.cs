using AutomaticShutdownTimerLibrary.Models;
using AutomaticShutdownTimerLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AutomaticShutdownTimerLibrary.Services {
    public class TimeHandler {

        public event EventHandler<string> SecondHasPassed;

        private readonly Timer timer = new Timer(1000); // one second

        private readonly IAlarmsHandler alarms;
        private Time time;

        public TimeHandler(Time time, IAlarmsHandler alarms) {
            this.time = time;
            this.alarms = alarms;
            timer.Elapsed += SecondPassed;
        }

        private void SecondPassed(object sender, ElapsedEventArgs e) {
            time.SubtractOneSecond();
            SecondHasPassed?.Invoke(this, time.ToString());
            alarms.RunAllBelow(time.ToSeconds());
        }

        public void Start() {
            alarms.ResetAll();
            timer.Start();
        }

        public void Start(int hours, int minutes, int seconds) {
            time.Set(hours, minutes, seconds);
        }

        public void Stop() {
            timer.Stop();
        }

    }
}
