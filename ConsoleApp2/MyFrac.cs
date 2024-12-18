
using System;
using System.Numerics;



namespace ConsoleApp2
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public int Nom { get; set; }
        public int Denom { get; set; }

        public BigInteger Nom_big { get; set; }
        public BigInteger Denom_big { get; set; }
        private bool IsBigInteger { get; set; }

       /* public MyFrac()
        {
            Nom = 0;
            Denom = 1;
        }*/
        public MyFrac()
        {
            Nom_big = 0;
            Denom_big = 1;
        }

        public MyFrac(int nom, int denom)
        {
            if (denom == 0)
                throw new 
                    DivideByZeroException("Знаменник не може бути нулем.");
            Nom = nom;
            Denom = denom;
            Reduce();
        }
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException("Знаменник не може бути нулем.");

            Nom_big = nom;
            Denom_big = denom;
            IsBigInteger = true;

        }
        private void CheckAndConvertToBigInteger()
        {
            if (Math.Abs((long)Nom) > int.MaxValue || Math.Abs((long)Denom) > int.MaxValue)
            {
                Nom_big = new BigInteger(Nom);
                Denom_big = new BigInteger(Denom);
                IsBigInteger = true;
            }
        }
        public MyFrac Add(MyFrac that)
        {
            if (this.IsBigInteger || that.IsBigInteger)
            {
                BigInteger newNom = this.GetBigNom() * that.GetBigDenom() + that.GetBigNom() * this.GetBigDenom();
                BigInteger newDenom = this.GetBigDenom() * that.GetBigDenom();
                return new MyFrac(newNom, newDenom);
            }
            else
            {
                int newNom = this.Nom * that.Denom + that.Nom * this.Denom;
                int newDenom = this.Denom * that.Denom;
                return new MyFrac(newNom, newDenom);
            }
        }

        public MyFrac Divide(MyFrac that)
        {
            if (this.IsBigInteger || that.IsBigInteger)
            {
                BigInteger newNom = this.GetBigNom() * that.GetBigDenom();
                BigInteger newDenom = this.GetBigDenom() * that.GetBigNom();
                return new MyFrac(newNom, newDenom);
            }
            else
            {
                int newNom = this.Nom * that.Denom;
                int newDenom = this.Denom * that.Nom;
                return new MyFrac(newNom, newDenom);
            }
        }

        public MyFrac Multiply(MyFrac that)
        {
            if (this.IsBigInteger || that.IsBigInteger)
            {
                BigInteger newNom = this.GetBigNom() * that.GetBigNom();
                BigInteger newDenom = this.GetBigDenom() * that.GetBigDenom();
                return new MyFrac(newNom, newDenom);
            }
            else
            {
                int newNom = this.Nom * that.Nom;
                int newDenom = this.Denom * that.Denom;
                return new MyFrac(newNom, newDenom);
            }
        }

        public MyFrac Subtract(MyFrac that)
        {
            if (this.IsBigInteger || that.IsBigInteger)
            {
                BigInteger newNom = this.GetBigNom() * that.GetBigDenom() - that.GetBigNom() * this.GetBigDenom();
                BigInteger newDenom = this.GetBigDenom() * that.GetBigDenom();
                return new MyFrac(newNom, newDenom);
            }
            else
            {
                int newNom = this.Nom * that.Denom - that.Nom * this.Denom;
                int newDenom = this.Denom * that.Denom;
                return new MyFrac(newNom, newDenom);
            }
        }

        private void Reduce()
        {
            if (IsBigInteger)
            {
                BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(Nom_big), BigInteger.Abs(Denom_big));
                Nom_big /= gcd;
                Denom_big /= gcd;

                if (Denom_big < 0)
                {
                    Nom_big = -Nom_big;
                    Denom_big = -Denom_big;
                }
            }
            else
            {
                int gcd = GCD(Math.Abs(Nom), Math.Abs(Denom));
                Nom /= gcd;
                Denom /= gcd;

                if (Denom < 0)
                {
                    Nom = -Nom;
                    Denom = -Denom;
                }

                CheckAndConvertToBigInteger();
            }
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private BigInteger GetBigNom() => IsBigInteger ? Nom_big : new BigInteger(Nom);
        private BigInteger GetBigDenom() => IsBigInteger ? Denom_big : new BigInteger(Denom);
        public void ParseFraction(string fracStr)
        {
            string[] parts = fracStr.Split('/');

            if (parts.Length <= 1)
            {
                Nom = int.Parse(parts[0]);
                Denom = 1;
            }
            else
            {

                Nom = int.Parse(parts[0]);
                Denom = int.Parse(parts[1]);
                if (Denom == 0)
                    throw new DivideByZeroException("Знаменник не може бути нулем.");
                Reduce();
            }
        }
        public override string ToString()
        {
            return IsBigInteger
                ? (Denom_big == 1 ? Nom_big.ToString() : $"{Nom_big}/{Denom_big}")
                : (Denom == 1 ? Nom.ToString() : $"{Nom}/{Denom}");
        }
        public int CompareTo(MyFrac other)
        {

            BigInteger thisValue = GetBigNom() * other.GetBigDenom();
            BigInteger otherValue = other.GetBigNom() * GetBigDenom();

            return thisValue.CompareTo(otherValue);
        }
        public override bool Equals(object obj)
        {
            if (obj is MyFrac other)
            {
                return GetBigNom() * other.GetBigDenom() == other.GetBigNom() * GetBigDenom();
            }
            return false;
        }

        public override int GetHashCode()
        {
           
                unchecked
                {
                    return GetBigNom().GetHashCode() ^ GetBigDenom().GetHashCode();
                }
            
        }
    }
}
