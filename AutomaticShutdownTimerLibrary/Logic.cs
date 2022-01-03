using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomaticShutdownTimerLibrary {
    public static class Logic {

        private static readonly Shutdown shutdown = new Shutdown();

        public static void MainLogic(Time time) {
            if(IsTimeUp(time)) {
                Countdown.Stop();

                //turn off pc
                shutdown.Start();
            } else {
                time.SubtractOneSecond();
            }
        }

        private static bool IsTimeUp(Time time) => time.ToSeconds() <= 0;

    }
}
