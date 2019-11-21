using System;

namespace Task_2_DoubleToBinaryConvert
{
    public class Program
    {
        /// <summary>
        /// The Main () method is
        /// program entry point
        /// I call the BinaryFromDoubleMethod extension method
        /// for to test his
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            double number = double.MinValue;
            Console.WriteLine(number.BinaryFromDoubleMethod());
        }
    }
}
