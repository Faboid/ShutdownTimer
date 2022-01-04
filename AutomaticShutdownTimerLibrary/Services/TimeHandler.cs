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

        public TimeHandler(IAlarmsHandler alarms) {
            this.alarms = alarms;
            timer.Elapsed += SecondPassed;
            CheckAlarms();
        }

        private void SecondPassed(object sender, ElapsedEventArgs e) {
            time.SubtractOneSecond();
            SecondHasPassed?.Invoke(this, time.ToString());
        }

        public void Start() {
            timer.Start();
        }

        public void Start(int hours, int minutes, int seconds) {
            time ??= new Time(hours, minutes, seconds);

            time.Set(hours, minutes, seconds);
        }

        public void Stop() {
            timer.Stop();
        }

        public void ResetAlarms() => alarms.ResetAll();

        private void CheckAlarms() => alarms.RunAllBelow(time.ToSeconds());

    }
}
