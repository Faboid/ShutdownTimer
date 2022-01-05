using AutomaticShutdownTimerLibrary.Models;
using Xunit;

namespace AutomaticShutdownTimerTests {
    public class AlarmTests {

        [Fact]
        public void SingleEventCall() {

            //arrange
            int count = 0;
            int expected = 1;
            void ringAction () { count++; };
            var alarm = new Alarm(ringAction, 30, true);

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
            void ringAction() { count++; }
            var alarm = new Alarm(ringAction, 30, false);

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
            void ringAction () { count++; };
            var alarm = new Alarm(ringAction, 30, true);

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
