using System;
using System.Linq;
using System.Text;

namespace Task_1_PolynomialClass
{
    /// <summary>
    /// Closed class Polynomial
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Polynomial class constructor
        /// </summary>
        /// <param name="arr"></param>
        public Polynomial(double[] arr)
        {
            Arr = arr;
        }

        /// <summary>
        /// Class field for storing the transmitted polynomial
        /// SZ-array for storing coefficients
        /// </summary>
        public double[] Arr { get; set; }

        /// <summary>
        /// Multiplication operation overload for two polynomials
        /// </summary>
        /// <param name="polinomOne"></param>
        /// <param name="polinomTwo"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polinomOne, Polynomial polinomTwo)
        {
            double[] resultPolinom = new double[polinomOne.Arr.Length + polinomTwo.Arr.Length - 1];
            for (int i = 0; i < polinomOne.Arr.Length; ++i)
            {
                for (int j = 0; j < polinomTwo.Arr.Length; ++j)
                {
                    resultPolinom[i + j] += polinomOne.Arr[i] * polinomTwo.Arr[j];
                }
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Overloading the multiplication operation for a polynomial and a number
        /// </summary>
        /// <param name="polinom"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polinom, int number)
        {
            double[] resultPolinom = new double[polinom.Arr.Length];
            for (int i = 0; i < polinom.Arr.Length; i++)
            {
                resultPolinom[i] = polinom.Arr[i] * number;
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Multiplication operation overload for number and polynomial
        /// </summary>
        /// <param name="number"></param>
        /// <param name="polinom"></param>
        /// <returns></returns>
        public static Polynomial operator *(int number, Polynomial polinom)
        {
            return polinom * number;
        }

        /// <summary>
        /// Division operation overload for polynomial and number
        /// </summary>
        /// <param name="polinom"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial polinom, int number)
        {
            double[] resultPolinom = new double[polinom.Arr.Length];
            for (int i = 0; i < polinom.Arr.Length; i++)
            {
                resultPolinom[i] = polinom.Arr[i] / number;
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Add operation overload for two polynomials
        /// </summary>
        /// <param name="polinomOne"></param>
        /// <param name="polinomTwo"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial polinomOne, Polynomial polinomTwo)
        {
            double[] sizeMinArray = polinomOne.Arr.Length > polinomTwo.Arr.Length ? polinomTwo.Arr : polinomOne.Arr;
            double[] sizeMaxArray = polinomOne.Arr.Length > polinomTwo.Arr.Length ? polinomOne.Arr : polinomTwo.Arr;
            double[] resultPolinom = new double[sizeMaxArray.Length];

            for (int i = 0; i < sizeMinArray.Length; i++)
            {
                resultPolinom[i] += sizeMaxArray[i] + sizeMinArray[i];
            }

            for (int i = sizeMinArray.Length; i < sizeMaxArray.Length; i++)
            {
                resultPolinom[i] += sizeMaxArray[i];
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Overloading the addition operation for polynomial and number
        /// </summary>
        /// <param name="polinom"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial polinom, int number)
        {
            double[] resultPolinom = new double[polinom.Arr.Length];
            for (int i = 0; i < polinom.Arr.Length; i++)
            {
                if (i == 0)
                {
                    resultPolinom[i] = polinom.Arr[i] + number;
                }
                else
                {
                    resultPolinom[i] = polinom.Arr[i];
                }
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Overloading the addition operation for a number and polynomial
        /// </summary>
        /// <param name="number"></param>
        /// <param name="polinom"></param>
        /// <returns></returns>
        public static Polynomial operator +(int number, Polynomial polinom)
        {
            return polinom + number;
        }

        /// <summary>
        /// Subtraction overload for two polynomials
        /// </summary>
        /// <param name="polinomOne"></param>
        /// <param name="polinomTwo"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polinomOne, Polynomial polinomTwo)
        {
            double[] sizeMinArray = polinomOne.Arr.Length > polinomTwo.Arr.Length ? polinomTwo.Arr : polinomOne.Arr;
            double[] sizeMaxArray = polinomOne.Arr.Length > polinomTwo.Arr.Length ? polinomOne.Arr : polinomTwo.Arr;
            double[] resultPolinom = new double[sizeMaxArray.Length];

            if (polinomOne.Arr.Length >= polinomTwo.Arr.Length)
            {
                for (int i = 0; i < sizeMinArray.Length; i++)
                {
                    resultPolinom[i] += polinomOne.Arr[i] - polinomTwo.Arr[i];
                }

                for (int i = sizeMinArray.Length; i < sizeMaxArray.Length; i++)
                {
                    resultPolinom[i] += polinomOne.Arr[i] * -1;
                }
            }
            else
            {
                for (int i = 0; i < sizeMinArray.Length; i++)
                {
                    resultPolinom[i] += polinomOne.Arr[i] - polinomTwo.Arr[i];
                }

                for (int i = sizeMinArray.Length; i < sizeMaxArray.Length; i++)
                {
                    resultPolinom[i] += polinomTwo.Arr[i] * -1;
                }
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Subtraction overload for polynomial and number
        /// </summary>
        /// <param name="polinom"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polinom, int number)
        {
            double[] resultPolinom = new double[polinom.Arr.Length];
            for (int i = 0; i < polinom.Arr.Length; i++)
            {
                if (i == 0)
                {
                    resultPolinom[i] = polinom.Arr[i] - number;
                }
                else
                {
                    resultPolinom[i] = polinom.Arr[i];
                }
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Subtraction overload for number and polynomial
        /// </summary>
        /// <param name="number"></param>
        /// <param name="polinom"></param>
        /// <returns></returns>
        public static Polynomial operator -(int number, Polynomial polinom)
        {
            double[] resultPolinom = new double[polinom.Arr.Length];
            for (int i = 0; i < polinom.Arr.Length; i++)
            {
                if (i == 0)
                {
                    resultPolinom[i] = number - polinom.Arr[i];
                }
                else
                {
                    resultPolinom[i] = polinom.Arr[i] * -1;
                }
            }

            return new Polynomial(resultPolinom);
        }

        /// <summary>
        /// Overloading comparison (==) operation for two polynomials
        /// </summary>
        /// <param name="polinomOne"></param>
        /// <param name="polinomTwo"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial polinomOne, Polynomial polinomTwo)
        {
            if (polinomOne.Arr.Length == polinomTwo.Arr.Length)
            {
                for (int i = 0; i < polinomOne.Arr.Length; i++)
                {
                    if (polinomOne.Arr[i] != polinomTwo.Arr[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Overloading no comparison (!=) operation for two polynomials
        /// </summary>
        /// <param name="polinomOne"></param>
        /// <param name="polinomTwo"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial polinomOne, Polynomial polinomTwo)
        {
            if (polinomOne.Arr.Length == polinomTwo.Arr.Length)
            {
                for (int i = 0; i < polinomOne.Arr.Length; i++)
                {
                    if (polinomOne.Arr[i] != polinomTwo.Arr[i])
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// overriding the virtual ToString() method of the Object class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strt = string.Empty;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (i == 0 && Arr[i] != 0)
                {
                    strt += $"{Arr[i]}";
                    continue;
                }

                if (i != 0 && Arr[i] != 0)
                {
                    if (Arr[i] > 0 && strt.Length > 0)
                    {
                        strt += $"+{Arr[i]}*x^{i}";
                    }
                    else
                    {
                        strt += $"{Arr[i]}*x^{i}";
                    }
                }
            }

            return strt.Trim();
        }

        /// <summary>
        /// overriding the virtual GetHashCode() method of the Object class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int count = 0;
            int hashCode = 1;
            foreach (var itemArr in Arr)
            {
                count++;
                if ((int)itemArr != 0)
                {
                    hashCode *= (int)itemArr;
                }

                hashCode *= count;
            }

            hashCode *= 15;
            return hashCode;
        }

        /// <summary>
        /// overriding the virtual Equals() method of the Object class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial))
            {
                return false;
            }

            Polynomial objt = (Polynomial)obj;
            if (this.Arr.Length == objt.Arr.Length)
            {
                for (int i = 0; i < this.Arr.Length; i++) 
                {
                    if (this.Arr[i] != objt.Arr[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private static void Main()
        {
        }
    }
}
