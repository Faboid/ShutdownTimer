using AutomaticShutdownTimerLibrary.Services;
using AutomaticShutdownTimerLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutomaticShutdownTimerTests {
    public class AlarmsHandlerTests {

        [Fact]
        public void EventIsRaised() {

            //arrange
            IAlarmsHandler alarms = new AlarmsHandler();
            bool IsInvoked = false;
            void SomeEvent() { IsInvoked = true; };

            //act
            alarms.Register(SomeEvent, 30, true);

            //assert
            Assert.False(IsInvoked);
            alarms.RunAllBelow(30);
            Assert.True(IsInvoked);
        }

        [Fact]
        public void EventIsNotRaised() {

            //arrange
            IAlarmsHandler alarms = new AlarmsHandler();
            bool IsInvoked = false;
            void SomeEvent() { IsInvoked = true; };

            //act
            alarms.Register(SomeEvent, 30, true);

            //assert
            Assert.False(IsInvoked);
            alarms.RunAllBelow(50);
            Assert.False(IsInvoked);
        }

        event EventHandler<EventArgs> SomeEvent1;
        event EventHandler<EventArgs> SomeEvent2;
        event EventHandler<EventArgs> SomeEvent3;


        [Fact]
        public void CorrectMultipleEventsAreRaised() {

            //arrange
            IAlarmsHandler alarms = new AlarmsHandler();
            bool IsInvoked1 = false;
            bool IsInvoked2 = false;
            bool IsInvoked3 = false;

            void SomeEvent1() { IsInvoked1 = true; }; 
            void SomeEvent2() { IsInvoked2 = true; }; 
            void SomeEvent3() { IsInvoked3 = true; };

            //act
            alarms.Register(SomeEvent1, 1, true);
            alarms.Register(SomeEvent2, 2, true);
            alarms.Register(SomeEvent3, 3, true);

            //assert
            Assert.False(IsInvoked1);
            Assert.False(IsInvoked2);
            Assert.False(IsInvoked3);

            alarms.RunAllBelow(2);

            Assert.False(IsInvoked1);
            Assert.True(IsInvoked2);
            Assert.True(IsInvoked3);

        }

    }
}
