using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_WatchWithTimer
{
    public class SubscriberThree
    {
        public void ActionOfSubscriberThree(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Message for objects SubscriberThree: {e.Message}");
        }
    }
}
