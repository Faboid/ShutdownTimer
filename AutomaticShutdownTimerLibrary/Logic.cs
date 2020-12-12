using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomaticShutdownTimerLibrary {
    public static class Logic {

        private static bool shutdownInitiated = false;
        private const int endTimerValue = 0;

        public static void MainLogic(Time time) {
            if(CheckTime(time, endTimerValue)) {
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

        public static bool CheckTime(Time time, int timeValue) => time.GetTotalTimeValue() <= timeValue;

    }
}
