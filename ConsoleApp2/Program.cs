using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program:Tests
    {
      
        static void Main(string[] args)
        {
            
            testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            testSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
            testSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

            List<MyFrac> fractions = new List<MyFrac>
            {
                new MyFrac(1, 2),
                new MyFrac(3, 4),
                new MyFrac(1, 3),
                new MyFrac(5, 6),
                new MyFrac(2, 3)
            };

            Console.WriteLine("Before sorting:");
            foreach (var frac in fractions)
            {
                Console.WriteLine(frac);
            }
            fractions.Sort();
            Console.WriteLine("\nAfter sorting:");
            foreach (var frac in fractions)
            {
                Console.WriteLine(frac);
            }
            /*Console.WriteLine("Enter the first argument");
            string arg1 = Console.ReadLine();

            Console.WriteLine("Enter the second argument");
            string arg2 = Console.ReadLine();

            object obj1 = ParseOperand(arg1);
            object obj2 = ParseOperand(arg2);

            if (obj1 != null && obj2 != null)
            {
                object result = ChoiceOperations(obj1, obj2);
               // Console.WriteLine(result.ToString());

                

                *//* Console.WriteLine(obg1.ToString());
                 Console.WriteLine(obg2.ToString());*//*
            }*/
            Console.ReadKey();

        }

      
        static object ParseOperand(string operand)
        {
            if (operand.Contains("i"))
            {
                MyComplex complex = new MyComplex();
                complex.ParseComplex(operand);
                return complex;
            }
            else if (operand.Contains("/"))
            {
                MyFrac frac = new MyFrac();
                frac.ParseFraction(operand);
                return frac;
            }

            else
            {

                if (int.TryParse(operand, out int result))
                {
                    MyFrac frac = new MyFrac(result, 1);
                    return frac;
                }
                else
                {
                    Console.WriteLine("Not Correct");
                    return null;
                }
            }



        }
        static object ChoiceOperations(object obj1, object obj2)
        {
            Console.WriteLine();
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (obj1 is MyFrac && obj2 is MyFrac)
            {
                MyFrac frac_1 = (MyFrac)obj1;
                MyFrac frac_2 = (MyFrac)obj2;

                switch (choice)
                {
                    case '+': return frac_1.Add(frac_2);
                    case '-': return frac_1.Subtract(frac_2);
                    case '*': return frac_1.Multiply(frac_2);
                    case '/': return frac_1.Divide(frac_2);
                    default: throw new Exception($"Невідомий оператор: {choice}");
                }
            }
            else if (obj1 is MyComplex && obj2 is MyComplex)
            {
                MyComplex complex_1 = (MyComplex)obj1;
                MyComplex complex_2 = (MyComplex)obj2;
                switch (choice)
                {
                    case '+': return complex_1.Add(complex_2);
                    case '-': return complex_1.Subtract(complex_2);
                    case '*': return complex_1.Multiply(complex_2);
                    case '/': return complex_1.Divide(complex_2);
                    default: throw new Exception($"Невідомий оператор: {choice}");

                }

            }
            else
            {
                throw new Exception("Непідтримувані типи операндів.");
            }

        }
    }
}
