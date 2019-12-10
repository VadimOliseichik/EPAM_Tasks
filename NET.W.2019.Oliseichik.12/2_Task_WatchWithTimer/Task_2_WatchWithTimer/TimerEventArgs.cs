using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_WatchWithTimer
{
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string message, int countdownTime)
        {
            Message = message;
            CountdownTime = countdownTime;
        }

        public string Message { get; }

        public int CountdownTime { get; set; }
    }
}
