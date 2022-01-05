using AutomaticShutdownTimerLibrary.Models;
using AutomaticShutdownTimerLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticShutdownTimerLibrary.Services {
    public class AlarmsHandler : IAlarmsHandler {

        private readonly List<Alarm> alarms = new List<Alarm>();

        public void RunAllBelow(int currentTime) {
            var toInvoke = alarms.Where(x => x.TimeToEvoke >= currentTime);
            foreach(var alarm in toInvoke) {
                alarm.Invoke();
            }
        }

        public void Register(Action ringAction, int timeToEvoke, bool singleFire) {
            alarms.Add(new Alarm(ringAction, timeToEvoke, singleFire));
        }

        public void ResetAll() {
            foreach(var alarm in alarms) {
                alarm.Reset();
            }
        }

    }
}
