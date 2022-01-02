using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AutomaticShutdownTimerLibrary {
    public class TimeHandler {

        public event EventHandler<string> SecondHasPassed;

        private readonly Time time;
        private readonly Timer timer = new Timer(1000); // one second

        public TimeHandler(int hours, int minutes, int seconds) {
            time = new Time(hours, minutes, seconds);
            timer.Elapsed += SecondPassed;
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

    }
}
