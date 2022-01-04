using AutomaticShutdownTimerLibrary.Models;
using AutomaticShutdownTimerLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Services {
    public class AlarmsHandler : IAlarmsHandler {

        private readonly List<Alarm> alarms = new List<Alarm>();

        public void RunAllBelow(int currentTime) {
            var toInvoke = alarms.Where(x => x.TimeToEvoke >= currentTime);
            foreach(var alarm in toInvoke) {
                alarm.Event?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Register(EventHandler eventHandler, int timeToEvoke, bool singleFire) {
            alarms.Add(new Alarm(eventHandler, timeToEvoke, singleFire));
        }

        public void ResetAll() {
            foreach(var alarm in alarms) {
                alarm.Reset();
            }
        }

    }
}
