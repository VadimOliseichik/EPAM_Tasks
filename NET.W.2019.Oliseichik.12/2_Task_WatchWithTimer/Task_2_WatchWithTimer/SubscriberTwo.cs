using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2_WatchWithTimer
{
    class SubscriberTwo
    {
        public void ActionOfSubscriberTwo(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Message for objects SubscriberTwo: {e.Message}");
        }
    }
}
