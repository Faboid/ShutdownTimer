using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomaticShutdownTimerLibrary {
    public static class Logic {

        private static bool shutdownInitiated = false;

        public static void MainLogic(Time time) {
            if(IsTimeUp(time)) {
                if(!shutdownInitiated) {
                    Countdown.Stop();
                    shutdownInitiated = true;

                    //turn off pc
                    Shutdown.Start();
                }
            } else {
                time.SubtractOneSecond();
            }
        }

        private static bool IsTimeUp(Time time) => time.GetTotalTimeValue() <= 0;

    }
}
