﻿using AutomaticShutdownTimerLibrary.Models;
using Xunit;

namespace AutomaticShutdownTimerTests {
    public class TimeTests {
    
    
        [Theory]
        [InlineData("02 : 15 : 03", 2, 15, 3)]
        [InlineData("12 : 00 : 00", 12, 0, 0)]
        [InlineData("00 : 00 : 09", 0, 0, 9)]
        public void CorrectFormat_ToString(string expected, int hours, int minutes, int seconds) {

            //arrange
            Time time = new Time(hours, minutes, seconds);
            string actual;

            //act
            actual = time.ToString();

            //assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("02 : 15 : 02", 2, 15, 3)]
        [InlineData("11 : 59 : 59", 12, 0, 0)]
        [InlineData("00 : 00 : 08", 0, 0, 9)]
        public void SubtractOneSuccessfully(string expected, int hours, int minutes, int seconds) {

            //arrange
            Time time = new Time(hours, minutes, seconds);
            string actual;

            //act
            time.SubtractOneSecond();
            actual = time.ToString();

            //assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(2, 15, 3)]
        [InlineData(12, 0, 0)]
        [InlineData(0, 0, 9)]
        public void GetCorrectSecondsAmount(int hours, int minutes, int seconds) {

            //arrange
            Time time = new Time(hours, minutes, seconds);
            int expected = seconds + (minutes * 60) + (hours * 3600);
            int actual;

            //act
            actual = time.ToSeconds();

            //assert
            Assert.Equal(expected, actual);

        }



    }
}
