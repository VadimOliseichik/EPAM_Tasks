using NUnit.Framework;
using Task_1_PolynomialClass;

namespace Task_1_PolynomialClass.Tests
{
    public class PolynomialTest
    {
        [TestCase(new double[] { -1, 2, 3 }, new double[] { -1, 2, 4 }, new double[] { 1, -4, -3, 14, 12 })]
        public void Multiplication_PolinomOne_and_PolinomTwo(double[] polinomOne, double[] polinomTwo, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);
            Polynomial polinomObjectTwo = new Polynomial(polinomTwo);

            Polynomial polinomObjectResult = polinomObjectOne * polinomObjectTwo;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 4, 3 }, 5, new double[] { 5, 20, 15 })]
        public void Multiplication_Polinom_and_Number(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = polinomObjectOne * number;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 5, -1, 9 }, -4, new double[] { -20, 4, -36 })]
        public void Multiplication_Number_and_Polinom(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = number * polinomObjectOne;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 10, 70, 20 }, 5, new double[] { 2, 14, 4 })]
        public void Division_Polinom_and_Number(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = polinomObjectOne / number;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 4, 3 }, new double[] { 1, 4, 3, 7 }, new double[] { 2, 8, 6, 7 })]
        public void Sum_PolinomOne_and_PolinomTwo(double[] polinomOne, double[] polinomTwo, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);
            Polynomial polinomObjectTwo = new Polynomial(polinomTwo);

            Polynomial polinomObjectResult = polinomObjectOne + polinomObjectTwo; 

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 4, 3 }, 5, new double[] { 6, 4, 3 })]
        public void Sum_Polinom_and_Number(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = polinomObjectOne + number;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 4, 3 }, 5, new double[] { 6, 4, 3 })]
        public void Sum_Number_and_Polinom(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = number + polinomObjectOne;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 7, 5, 3 }, new double[] { 1, 4, 3, 7 }, new double[] { 6, 1, 0, -7 })]
        public void Difference_PolinomOne_and_PolinomTwo(double[] polinomOne, double[] polinomTwo, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);
            Polynomial polinomObjectTwo = new Polynomial(polinomTwo);

            Polynomial polinomObjectResult = polinomObjectOne - polinomObjectTwo;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 7, 4, 3 }, 5, new double[] { -4, 7, 4, 3 })]
        public void Difference_Polinom_and_Number(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = polinomObjectOne - number;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 4, 3 }, 5, new double[] { 4, -4, -3 })]
        public void Difference_Number_and_Polinom(double[] polinomOne, int number, double[] polinomResult)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Polynomial polinomObjectResult = number - polinomObjectOne;

            CollectionAssert.AreEqual(polinomResult, polinomObjectResult.Arr);
        }

        [TestCase(new double[] { 1, 4, 3 }, new double[] { 1, 4, 3 }, true)]
        [TestCase(new double[] { 1, 7, 4, 3 }, new double[] { 1, 4, 3 }, false)]
        public void Ñomparison_PolinomOne_and_PolinomTwo(double[] polinomOne, double[] polinomTwo, bool result)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);
            Polynomial polinomObjectTwo = new Polynomial(polinomTwo);

            Assert.AreEqual(polinomObjectOne == polinomObjectTwo, result);
        }

        [TestCase(new double[] { 1, 4, 3 }, new double[] { 1, 4, 3 }, false)]
        [TestCase(new double[] { 1, 7, 4, 3 }, new double[] { 1, 4, 3 }, true)]
        public void No_Comparison_PolinomOne_and_PolinomTwo(double[] polinomOne, double[] polinomTwo, bool result)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);
            Polynomial polinomObjectTwo = new Polynomial(polinomTwo);

            Assert.AreEqual(polinomObjectOne != polinomObjectTwo, result);
        }

        [TestCase(new double[] { 1, 4, 3 }, "1+4*x^1+3*x^2")]
        [TestCase(new double[] { 1, 7, 4, 3 }, "1+7*x^1+4*x^2+3*x^3")]
        public void Polinom_ToString(double[] polinomOne, string result)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Assert.AreEqual(polinomObjectOne.ToString(), result);
        }

        [TestCase(new double[] { 1, 4, 3 }, new double[] { 1, 4, 3 }, true)]
        [TestCase(new double[] { 1, 7, 4, 3 }, new double[] { 1, 4, 3 }, false)]
        public void Polinom_Equals(double[] polinomOne, double[] polinomTwo, bool result)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);
            Polynomial polinomObjectOTwo = new Polynomial(polinomTwo);

            Assert.AreEqual(polinomObjectOne.Equals(polinomObjectOTwo), result);
        }

        [TestCase(new double[] { 1, 4, 3 }, 1080)]
        [TestCase(new double[] { 1, 7, 4, 3 }, 30240)]
        public void Polinom_Hash(double[] polinomOne, int result)
        {
            Polynomial polinomObjectOne = new Polynomial(polinomOne);

            Assert.AreEqual(polinomObjectOne.GetHashCode(), result);
        }
    }
}