using System;

namespace ConsoleApp2
{
    internal class Tests
    {
        public static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b);
            curr = curr.Add(curr);

            Console.WriteLine("2*a*b = " + curr);

            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
        public static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)^2=a^2-2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);

            T leftPart = aMinusB.Multiply(aMinusB);
            Console.WriteLine("(a-b)^2 = " + leftPart);

            Console.WriteLine(" = = = ");

            T aSquared = a.Multiply(a);
            Console.WriteLine("a^2 = " + aSquared);

            T bSquared = b.Multiply(b);
            Console.WriteLine("b^2 = " + bSquared);

            T ab = a.Multiply(b);
            T minusTwoAB = ab.Add(ab).Subtract(ab.Add(ab)); // Формула для -2ab
            Console.WriteLine("-2*a*b = " + minusTwoAB);

            T rightPart = aSquared.Add(minusTwoAB).Add(bSquared);
            Console.WriteLine("a^2 - 2ab + b^2 = " + rightPart);
            Console.WriteLine("=== Finishing testing (a-b)^2=a^2-2ab+b^2 with a = " + a + ", b = " + b + " ===");

            //Результат виконання
            /*=== Starting testing (a-b)^2=a^2-2ab+b^2 with a = 1/3, b = 1/6 ===
            a = 1/3
            b = 1/6
           (a - b) = 1/6
           (a-b)^2 = 1/36
            = = =
            a^2 = 1/9
            b^2 = 1/36
           -2*a*b = -1/9
           a^2 - 2ab + b^2 = 1/36
           === Finishing testing (a-b)^2=a^2-2ab+b^2 with a = 1/3, b = 1/6 ===
  */
        }
    }
}
