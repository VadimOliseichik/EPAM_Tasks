using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_WatchWithTimer
{
    public class SubscriberOne
    {
        public void ActionOfSubscriberOne(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Message for objects SubscriberOne: {e.Message}");
        }
    }
}
