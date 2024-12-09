using System;

namespace ConsoleApp2
{
    class MyComplex : IMyNumber<MyComplex>
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
}
