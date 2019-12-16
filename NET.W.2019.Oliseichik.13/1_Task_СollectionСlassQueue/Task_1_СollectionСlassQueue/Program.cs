using System;

namespace Task_1_СollectionСlassQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(5);

            queue.Enqueue(4);

            queue.Enqueue(2);

            Console.WriteLine($"Peek (достали из начала очереди, но не удалили): {queue.Peek()}");

            Console.WriteLine($"Dequeue (достали из начала очереди и удалили): {queue.Dequeue()}");

            queue.Enqueue(3);

            Console.WriteLine($"Count (количество элементов в очереди): {queue.Count()}");

            foreach (object item in queue)
            {
                Console.Write(item + " ");
            }
        }
    }
}
