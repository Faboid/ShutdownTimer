using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AutomaticShutdownTimerLibrary {
    public static class Shutdown {

        public static void Start() {
            var processInfo = new ProcessStartInfo("shutdown", "/s /t 10");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(processInfo);
        }

    }
}
