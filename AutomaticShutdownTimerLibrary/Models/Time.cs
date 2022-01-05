using AutomaticShutdownTimerLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Models {
    public class Time : IReadOnlyTime {

        public int Seconds { get; private set; }
        public int Minutes { get; private set; }
        public int Hours { get; private set; }

        public Time(int hours, int minutes, int seconds) {
            Set(hours, minutes, seconds);
        }

        public void Set(int hours, int minutes, int seconds) {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public void SubtractOneSecond() {
            int timeValue = ToSeconds();
            timeValue--;
            AssignValuesFromTotalTimeValue(timeValue);
        }

        public int ToSeconds() => Seconds + Minutes * 60 + Hours * 3600;

        public override string ToString() {
            return $"{Hours:00} : {Minutes:00} : {Seconds:00}";
        }

        private void AssignValuesFromTotalTimeValue(int timeValue) {
            int time = timeValue % 3600;
            int seconds = time % 60;
            int minutes = (time - seconds) / 60;
            int hours = (timeValue - time) / 3600;

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

    }
}
