using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Models {
    public class Alarm {

        public Action RingAction { get; private set; }
        public int TimeToEvoke { get; private set; }
        public bool SingleFire { get; private set; }
        private bool fired = false;

        public Alarm(Action ringAction, int timeToEvoke, bool singleFire) {
            RingAction = ringAction;
            TimeToEvoke = timeToEvoke;
            SingleFire = singleFire;
        }

        public void Invoke() {
            if(SingleFire == false || fired == false) {
                RingAction?.Invoke();
                fired = true;
            }
        }

        public void Reset() {
            fired = false;
        }

    }
}
