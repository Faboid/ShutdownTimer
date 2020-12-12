using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary {
    public static class TimeConverter {

        public static string ConvertTimeValuesToString(Time time) {
            return $"{FormatTimeNumber(time.Hours)} : {FormatTimeNumber(time.Minutes)} : {FormatTimeNumber(time.Seconds)}";
        }

        private static string FormatTimeNumber(int input) => (input >= 10) ? $"{input}" : $"0{input}";

    }
}
