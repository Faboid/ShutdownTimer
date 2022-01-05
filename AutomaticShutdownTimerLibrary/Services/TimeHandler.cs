using AutomaticShutdownTimerLibrary.Models;
using AutomaticShutdownTimerLibrary.Models.Interfaces;
using AutomaticShutdownTimerLibrary.Services.Interfaces;
using System;
using System.Timers;

namespace AutomaticShutdownTimerLibrary.Services {
    public class TimeHandler {

        public event EventHandler<IReadOnlyTime> SecondHasPassed;

        private readonly Timer timer = new Timer(1000); // one second

        private readonly IAlarmsHandler alarms;
        private readonly Time time;

        public TimeHandler(Time time, IAlarmsHandler alarms) {
            this.time = time;
            this.alarms = alarms;
            timer.Elapsed += SecondPassed;
        }

        public IReadOnlyTime GetTimeAsReadOnly() {
            return time;
        }

        public void Start(int hours, int minutes, int seconds) {
            time.Set(hours, minutes, seconds);
            timer.Start();
        }

        public void Stop() {
            timer.Stop();
        }

        private void SecondPassed(object sender, ElapsedEventArgs e) {
            time.SubtractOneSecond();
            SecondHasPassed?.Invoke(this, time);
            alarms.RunAllBelow(time.ToSeconds());
        }

    }
}
