
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class MyFracUnitTests
    {
        [TestMethod]
       
        public void TestAddition()
        {
            // Arrange
            var frac1 = new MyFrac(1, 3);
            var frac2 = new MyFrac(1, 6);
            var expected = new MyFrac(1, 2);

            // Act
            var result = frac1.Add(frac2);

            // Assert
            Assert.AreEqual(expected, result, "Addition failed.");
        }
        [TestMethod]
        public void TestSubtraction()
        {
            // Arrange
            var frac1 = new MyFrac(1, 2);
            var frac2 = new MyFrac(1, 3);
            var expected = new MyFrac(1, 6);

            // Act
            var result = frac1.Subtract(frac2);

            // Assert
            Assert.AreEqual(expected, result, "Subtraction failed.");
        }

        [TestMethod]
        public void TestMultiplication()
        {
            // Arrange
            var frac1 = new MyFrac(1, 2);
            var frac2 = new MyFrac(2, 3);
            var expected = new MyFrac(1, 3);

            // Act
            var result = frac1.Multiply(frac2);

            // Assert
            Assert.AreEqual(expected, result, "Multiplication failed.");
        }

        [TestMethod]
        public void TestDivision()
        {
            // Arrange
            var frac1 = new MyFrac(1, 2);
            var frac2 = new MyFrac(2, 3);
            var expected = new MyFrac(3, 4);

            // Act
            var result = frac1.Divide(frac2);

            // Assert
            Assert.AreEqual(expected, result, "Division failed.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZero()
        {
            // Arrange
            var frac1 = new MyFrac(1, 2);
            var frac2 = new MyFrac(0, 1);

            // Act
            var result = frac1.Divide(frac2);
        }

        [TestMethod]
        public void TestReduce()
        {
            // Arrange
            var frac = new MyFrac(2, 4);
            var expected = new MyFrac(1, 2);

            // Assert
            Assert.AreEqual(expected, frac, "Reduce failed.");
        }

        [TestMethod]
        public void TestEquals()
        {
            // Arrange
            var frac1 = new MyFrac(1, 2);
            var frac2 = new MyFrac(2, 4);

            // Assert
            Assert.IsTrue(frac1.Equals(frac2), "Equals failed.");
        }

        [TestMethod]
        public void TestComparison()
        {
            // Arrange
            var frac1 = new MyFrac(1, 3);
            var frac2 = new MyFrac(1, 2);

            // Act
            int comparison = frac1.CompareTo(frac2);

            // Assert
            Assert.IsTrue(comparison < 0, "Comparison failed.");
        }

        [TestMethod]
        public void TestParseFraction()
        {
            // Arrange
            var frac = new MyFrac();
            var expected = new MyFrac(3, 4);

            // Act
            frac.ParseFraction("3/4");

            // Assert
            Assert.AreEqual(expected, frac, "ParseFraction failed.");
        }

        [TestMethod]
        public void TestParseWholeNumber()
        {
            // Arrange
            var frac = new MyFrac();
            var expected = new MyFrac(5, 1);

            // Act
            frac.ParseFraction("5");

            // Assert
            Assert.AreEqual(expected, frac, "ParseWholeNumber failed.");
        }
    }


}

