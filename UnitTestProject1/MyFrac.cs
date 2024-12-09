using System;
using System.Numerics;

namespace UnitTestProject1
{
        public class MyFrac : IComparable<MyFrac>
        {
            public int Nom { get; set; }
            public int Denom { get; set; }


            public MyFrac()
            {
                Nom = 0;
                Denom = 1;
            }

            public MyFrac(int nom, int denom)
            {
                if (denom == 0)
                    throw new DivideByZeroException("Знаменник не може бути нулем.");
                Nom = nom;
                Denom = denom;
                Reduce();
            }
          
            public MyFrac Add(MyFrac that)
            {
                int newNom = this.Nom * that.Denom + that.Nom * this.Denom;
                int newDenom = this.Denom * that.Denom;

                return new MyFrac(newNom, newDenom);
            }

            public MyFrac Divide(MyFrac that)
            {
                return new MyFrac(this.Nom * that.Denom, this.Denom * that.Nom);
            }

            public MyFrac Multiply(MyFrac that)
            {
                return new MyFrac(this.Nom * that.Nom, this.Denom * that.Denom);
            }

            public MyFrac Subtract(MyFrac that)
            {
                int newNom = this.Nom * that.Denom - that.Nom * this.Denom;
                int newDenom = this.Denom * that.Denom;
                return new MyFrac(newNom, newDenom);
            }

            private void Reduce()
            {
                int gcd = GCD(Math.Abs(Nom), Math.Abs(Denom));
                Nom /= gcd;
                Denom /= gcd;


                if (Denom < 0)
                {
                    Nom = -Nom;
                    Denom = -Denom;
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
                return Denom == 1 ? Nom.ToString() : $"{Nom}/{Denom}";
            }
            public int CompareTo(MyFrac other)
            {

                double thisValue = (double)this.Nom / this.Denom;
                double otherValue = (double)other.Nom / other.Denom;

                return thisValue.CompareTo(otherValue);
            }

            public override bool Equals(object obj)
            {
                if (obj is MyFrac other)
                {
                    return this.Nom == other.Nom && this.Denom == other.Denom;
                }
                return false;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 31 + Nom.GetHashCode();
                    hash = hash * 31 + Denom.GetHashCode();
                    return hash;
                }
            }
        }
    }

