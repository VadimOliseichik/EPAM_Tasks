using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task_2_WatchWithTimer
{
    public class OfficeTimer
    {
        public event EventHandler<TimerEventArgs> Advertisement = delegate { };

        public void ExpirationNotification(string message, int countdownTime)
        {
            if (countdownTime <= 0)
            {
                throw new ArgumentException();
            }

            Thread.Sleep(countdownTime * 1000);
            Advertisement?.Invoke(this, new TimerEventArgs(message, countdownTime));
        }
    }
}
