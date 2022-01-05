using System.Diagnostics;

namespace AutomaticShutdownTimerLibrary {
    public class Shutdown {

        //note: this is static to make sure that Start() will execute only once even if there are multiple instances of Shutdown
        private static bool HasStarted = false;

        public void Start() {
            if(HasStarted) {
                return;
            }
            HasStarted = true;

            var processInfo = new ProcessStartInfo("shutdown", "/s /t 10");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(processInfo);
        }

    }
}
