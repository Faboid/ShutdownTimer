using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticShutdownTimerLibrary.Models.Interfaces {
    public interface IReadOnlyTime {

        int Seconds { get; }
        int Minutes { get; }
        int Hours { get; }

        int ToSeconds();
        string ToString();
    }
}
