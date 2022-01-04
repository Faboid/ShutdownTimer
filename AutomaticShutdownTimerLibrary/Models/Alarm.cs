using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Models {
    public class Alarm {

        public EventHandler Event { get; private set; }
        public int TimeToEvoke { get; private set; }
        public bool SingleFire { get; private set; }
        private bool fired = false;

        public Alarm(EventHandler eventHandler, int timeToEvoke, bool singleFire) {
            Event = eventHandler;
            TimeToEvoke = timeToEvoke;
            SingleFire = singleFire;
        }

        public void Invoke() {
            if(SingleFire == false || fired == false) {
                Event?.Invoke(this, EventArgs.Empty);
                fired = true;
            }
        }

        public void Reset() {
            fired = false;
        }

    }
}
