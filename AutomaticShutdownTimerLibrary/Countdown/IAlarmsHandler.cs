using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Countdown {
    public interface IAlarmsHandler {

        void RunAllBelow(int currentTime);
        void Register(EventHandler eventHandler, int timeToEvoke, bool singleFire);
        void ResetAll();

    }
}
