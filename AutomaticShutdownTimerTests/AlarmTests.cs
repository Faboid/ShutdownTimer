using AutomaticShutdownTimerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutomaticShutdownTimerTests {
    public class AlarmTests {

        event EventHandler<EventArgs> randomEvent;

        [Fact]
        public void SingleEventCall() {

            //arrange
            int count = 0;
            int expected = 1;
            randomEvent += (s, e) => { count++; };
            var alarm = new Alarm(randomEvent, 30, true);

            //act
            alarm.Invoke();
            alarm.Invoke();

            //assert
            Assert.Equal(expected, count);

        }

        [Fact]
        public void MultipleEventCall() {

            //arrange
            int count = 0;
            int expected = 3;
            randomEvent += (s, e) => { count++; };
            var alarm = new Alarm(randomEvent, 30, false);

            //act
            alarm.Invoke();
            alarm.Invoke();
            alarm.Invoke();

            //assert
            Assert.Equal(expected, count);

        }

        [Fact]
        public void ResetEventCall() {

            //arrange
            int count = 0;
            int expected = 2;
            randomEvent += (s, e) => { count++; };
            var alarm = new Alarm(randomEvent, 30, true);

            //act
            alarm.Invoke();
            alarm.Reset();
            alarm.Invoke();
            alarm.Invoke();

            //assert
            Assert.Equal(expected, count);

        }

    }
}
