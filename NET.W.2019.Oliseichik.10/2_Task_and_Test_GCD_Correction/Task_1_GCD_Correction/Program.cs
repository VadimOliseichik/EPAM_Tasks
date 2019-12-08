using System;

namespace Task_1_GCD_Correction
{
    /// <summary>
    /// Main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Point of entry.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int gcd;
            int numberOne = 5;

            gcd = numberOne.EuclideanAlgorithmMethod(1, 2);
            Console.WriteLine($"Euclidean Algorithm\nGCD:{gcd}\n");

            gcd = FindGCD.EuclideanAlgorithmMethod(10, 20, -20, 40, -80);
            Console.WriteLine($"Euclidean Algorithm\nGCD:{gcd}\n");

            gcd = FindGCD.EuclideanAlgorithmMethod(40, -80);
            Console.WriteLine($"Euclidean Binary Algorithm\nGCD:{gcd}\n");

            gcd = FindGCD.EuclideanBinaryAlgorithmMethod(20, 40, -80);
            Console.WriteLine($"Euclidean Binary Algorithm\nGCD:{gcd}\n");

            gcd = FindGCD.EuclideanBinaryAlgorithmMethod(10, 20, -20, 40, -80);
            Console.WriteLine($"Euclidean Binary Algorithm\nGCD:{gcd}\n");
        }
    }
}
