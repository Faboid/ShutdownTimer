using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AutomaticShutdownTimerLibrary {
    public static class DeprecatedCountdown {

        public static Timer timer = new Timer(1000);

        public static void Start() {
            timer.Start();
        }

        public static void Stop() {
            timer.Stop();
        }

    }
}
