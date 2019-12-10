using System;

namespace Task_2_WatchWithTimer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SubscriberOne subscriberOne = new SubscriberOne();
            SubscriberTwo subscriberTwo = new SubscriberTwo();
            SubscriberThree subscriberThree_One = new SubscriberThree();

            SubscriberThree subscriberThree_Two = new SubscriberThree();

            OfficeTimer timer = new OfficeTimer();

            timer.Advertisement += subscriberOne.ActionOfSubscriberOne;
            timer.Advertisement += subscriberTwo.ActionOfSubscriberTwo;
            timer.Advertisement += subscriberThree_One.ActionOfSubscriberThree;

            timer.Advertisement += subscriberThree_Two.ActionOfSubscriberThree;

            timer.ExpirationNotification("Вы выйграли миллион долларов!", 5);

            Console.ReadLine();
        }
    }
}
