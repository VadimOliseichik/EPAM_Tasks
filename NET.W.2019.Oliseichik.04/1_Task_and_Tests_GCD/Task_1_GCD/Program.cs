using System;

namespace Task_1_GCD
{
    /// <summary>
    /// Class containing the Main method
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main () method is
        /// program entry point
        /// I call the EuclideanAlgorithmMethod method 
        /// Testing method overload and extension methods
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int gcd;
            int numberOne = 5; 
            string elapsedTime;

            (gcd, elapsedTime) = numberOne.EuclideanAlgorithmMethod(20);
            Console.WriteLine($"Euclidean Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");

            (gcd, elapsedTime) = numberOne.EuclideanAlgorithmMethod(10, 20);
            Console.WriteLine($"Euclidean Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");

            (gcd, elapsedTime) = FindGCD.EuclideanAlgorithmMethod(1, 2);
            Console.WriteLine($"Euclidean Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");

            (gcd, elapsedTime) = FindGCD.EuclideanAlgorithmMethod(10, 20, -20, 40, -80);
            Console.WriteLine($"Euclidean Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");

            (gcd, elapsedTime) = FindGCD.EuclideanBinaryAlgorithmMethod(40, -80);
            Console.WriteLine($"Euclidean Binary Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");

            (gcd, elapsedTime) = FindGCD.EuclideanBinaryAlgorithmMethod(20, 40, -80);
            Console.WriteLine($"Euclidean Binary Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");

            (gcd, elapsedTime) = FindGCD.EuclideanBinaryAlgorithmMethod(10, 20, -20, 40, -80);
            Console.WriteLine($"Euclidean Binary Algorithm\nGCD:{gcd}\nTime:{elapsedTime}\n");
        }
    }
}
