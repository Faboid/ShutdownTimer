using AutomaticShutdownTimerLibrary.Countdown;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AutomaticShutdownTimerLibrary {
    public class TimeHandler {

        public event EventHandler<string> SecondHasPassed;

        private AlarmsHandler alarms = new AlarmsHandler();

        private readonly Time time;
        private readonly Timer timer = new Timer(1000); // one second

        public TimeHandler(int hours, int minutes, int seconds) {
            time = new Time(hours, minutes, seconds);
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

        public void Stop() {
            timer.Stop();
        }

        public void SetAlarm(EventHandler eventHandler, int secondsLeft, bool singleFire) {
            alarms.Register(eventHandler, secondsLeft, singleFire);
        }

        public void ResetAlarms() => alarms.ResetAll();

        private void CheckAlarms() => alarms.RunAllBelow(time.ToSeconds());

    }
}
