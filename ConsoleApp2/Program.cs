using System;
using System.Collections.Generic;
using System.Numerics;

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

            Console.WriteLine("Введіть перший операнд:");
            string arg1 = Console.ReadLine();

            Console.WriteLine("Введіть другий операнд:");
            string arg2 = Console.ReadLine();

            object obj1 = ParseOperand(arg1);
            object obj2 = ParseOperand(arg2);

            if (obj1 != null && obj2 != null)
            {
                
                object result = ChoiceOperations(obj1, obj2);
                if (result != null)
                {
                    Console.WriteLine("Результат :");
                    Console.WriteLine(result.ToString());
                }
            }
            else
            {
                Console.WriteLine("Помилка: один або обидва операнди не були розпізнані.");
            }
            Console.ReadKey();

        }

      
        static object ParseOperand(string operand)
        {
            try
            {
                if (operand.Contains("i"))
                {
                    MyComplex complex = new MyComplex();
                    complex.ParseComplex(operand);
                    return complex;
                }
                else if (operand.Contains("/"))
                {
                    string[] parts = operand.Split('/');
                    if (parts.Length != 2)
                        throw new FormatException("Дробовий формат повинен бути чисельник/знаменник.");

                    BigInteger numerator = BigInteger.Parse(parts[0]);
                    BigInteger denominator = BigInteger.Parse(parts[1]);

                    if (numerator > int.MaxValue || numerator < int.MinValue ||
                        denominator > int.MaxValue || denominator < int.MinValue)
                    {
                        return new MyFrac(numerator, denominator); // Використання BigInteger
                    }
                    else
                    {
                        return new MyFrac((int)numerator, (int)denominator); // Використання Int32
                    }
                }
                else if (BigInteger.TryParse(operand, out BigInteger bigValue))
                {
                    if (bigValue > int.MaxValue || bigValue < int.MinValue)
                    {
                        return new MyFrac(bigValue, 1);
                    }
                    else
                    {
                        return new MyFrac((int)bigValue, 1); 
                    }
                }
                else
                {
                    Console.WriteLine($"Помилка: неможливо розпізнати операнд \"{operand}\".");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при розборі операнда: {ex.Message}");
                return null;
            }
        }
        static object ChoiceOperations(object obj1, object obj2)
        {
            Console.WriteLine();
            Console.WriteLine("Enter operator:");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            try
            {
                if (obj1 is MyFrac frac1 && obj2 is MyFrac frac2)
                {
                    switch (choice)
                    {
                        case '+': return frac1.Add(frac2);
                        case '-': return frac1.Subtract(frac2);
                        case '*': return frac1.Multiply(frac2);
                        case '/': return frac1.Divide(frac2);
                        default: throw new Exception($"Невідомий оператор: {choice}");
                    }
                }
                else if (obj1 is MyComplex complex1 && obj2 is MyComplex complex2)
                {
                    switch (choice)
                    {
                        case '+': return complex1.Add(complex2);
                        case '-': return complex1.Subtract(complex2);
                        case '*': return complex1.Multiply(complex2);
                        case '/': return complex1.Divide(complex2);
                        default: throw new Exception($"Невідомий оператор: {choice}");
                    }
                }
                else
                {
                    throw new Exception("Непідтримувані типи операндів. Обидва операнди мають бути одного типу.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return null;
            }


        }
    }
}
