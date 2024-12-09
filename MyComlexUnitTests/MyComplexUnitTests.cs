using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace MyComlexUnitTests
{
    [TestClass]
    public class MyComplexUnitTests
    {
        [TestMethod]
      
            public void TestAddition()
            {
                // Arrange
                var complex1 = new MyComplex(1, 2);
                var complex2 = new MyComplex(3, 4);
                var expected = new MyComplex(4, 6);

                // Act
                var result = complex1.Add(complex2);

                // Assert
                Assert.AreEqual(expected.ToString(), result.ToString(), "Addition failed.");
            }
        [TestMethod]
        public void TestSubtraction()
        {
            // Arrange
            var complex1 = new MyComplex(5, 7);
            var complex2 = new MyComplex(2, 4);
            var expected = new MyComplex(3, 3);

            // Act
            var result = complex1.Subtract(complex2);

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString(), "Subtraction failed.");
        }

        [TestMethod]
        public void TestMultiplication()
        {
            // Arrange
            var complex1 = new MyComplex(1, 2);
            var complex2 = new MyComplex(3, 4);
            var expected = new MyComplex(-5, 10);

            // Act
            var result = complex1.Multiply(complex2);

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString(), "Multiplication failed.");
        }

        [TestMethod]
        public void TestDivision()
        {
            // Arrange
            var complex1 = new MyComplex(1, 2);
            var complex2 = new MyComplex(3, 4);
            var expected = new MyComplex(0.44, 0.08); // Результат округлений до 2-х знаків після коми

            // Act
            var result = complex1.Divide(complex2);

            // Округлення до двох знаків після коми для порівняння
            var actualRounded = new MyComplex(Math.Round(result.Re, 2), Math.Round(result.Im, 2));

            // Assert
            Assert.AreEqual(expected.ToString(), actualRounded.ToString(), "Division failed.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZero()
        {
            // Arrange
            var complex1 = new MyComplex(1, 2);
            var complex2 = new MyComplex(0, 0);

            // Act
            var result = complex1.Divide(complex2);
        }

        [TestMethod]
        public void TestParseComplexPositive()
        {
            // Arrange
            var complexStr = "3+4i";
            var expected = new MyComplex(3, 4);

            // Act
            var result = new MyComplex();
            result.ParseComplex(complexStr);

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString(), "ParseComplex failed for positive imaginary part.");
        }

       

        [TestMethod]
        public void TestToStringPositiveImaginary()
        {
            // Arrange
            var complex = new MyComplex(3, 4);
            var expected = "3+4i";

            // Act
            var result = complex.ToString();

            // Assert
            Assert.AreEqual(expected, result, "ToString failed for positive imaginary part.");
        }

        [TestMethod]
        public void TestToStringNegativeImaginary()
        {
            // Arrange
            var complex = new MyComplex(3, -4);
            var expected = "3-4i";

            // Act
            var result = complex.ToString();

            // Assert
            Assert.AreEqual(expected, result, "ToString failed for negative imaginary part.");
        }

        [TestMethod]
        public void TestToStringOnlyImaginary()
        {
            // Arrange
            var complex = new MyComplex(0, 5);
            var expected = "5i";

            // Act
            var result = complex.ToString();

            // Assert
            Assert.AreEqual(expected, result, "ToString failed for only imaginary part.");
        }

        [TestMethod]
        public void TestToStringOnlyReal()
        {
            // Arrange
            var complex = new MyComplex(7, 0);
            var expected = "7";

            // Act
            var result = complex.ToString();

            // Assert
            Assert.AreEqual(expected, result, "ToString failed for only real part.");
        }
    }

}

    class MyComplex
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public MyComplex()
        {
            Re = 0;
            Im = 0;
        }
        public MyComplex(double re, double im)
        {
            Re = re;
            Im = im;
        }


        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.Re + that.Re, this.Im + that.Im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.Re - that.Re, this.Im - that.Im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            double re = this.Re * that.Re - this.Im * that.Im;
            double im = this.Re * that.Im + this.Im * that.Re;
            return new MyComplex(re, im);
        }

        public MyComplex Divide(MyComplex that)
        {
            double denominator = that.Re * that.Re + that.Im * that.Im;
            if (denominator == 0)
                throw new DivideByZeroException("Не можна ділити на нульовий комплексний модуль.");

            double re = (this.Re * that.Re + this.Im * that.Im) / denominator;
            double im = (this.Im * that.Re - this.Re * that.Im) / denominator;
            return new MyComplex(re, im);
        }
        public void ParseComplex(string complexStr)
        {
            complexStr = complexStr.Replace("i", "").Trim();
            string[] parts;

            if (complexStr.Contains("+"))
                parts = complexStr.Split('+');
            else if (complexStr.Contains("-"))
            {
                parts = complexStr.Split(new[] { '-' }, 2);
                parts[1] = "-" + parts[1];
            }
            else
                throw new FormatException("Невірний формат комплексного числа.");

            Re = double.Parse(parts[0]);
            Im = double.Parse(parts[1]);
        }
        public override string ToString()
        {
            if (Im == 0)
                return $"{Re}";
            else if (Re == 0)
                return $"{Im}i";
            else if (Im < 0)
                return $"{Re}{Im}i";
            else
                return $"{Re}+{Im}i";
        }
    }

