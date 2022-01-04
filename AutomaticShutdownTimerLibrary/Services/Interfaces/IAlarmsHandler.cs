using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Services.Interfaces {
    public interface IAlarmsHandler {

        void RunAllBelow(int currentTime);
        void Register(EventHandler<EventArgs> eventHandler, int timeToEvoke, bool singleFire);
        void ResetAll();

    }
}
