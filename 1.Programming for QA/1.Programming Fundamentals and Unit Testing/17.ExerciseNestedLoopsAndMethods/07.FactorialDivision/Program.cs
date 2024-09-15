using System;
using System.Collections.Generic;

namespace _07.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine()); 
            int secondNum = int.Parse(Console.ReadLine());

            //int firstFactorial = CalculateTheFactorial(firstNum);
            //int secondFactorial = CalculateTheFactorial(secondNum);
            int result = DivisionOfFactorials(firstNum, secondNum);
            Console.WriteLine(result);
        }

        static int CalculateTheFactorial(int num)
        {
            int factorial = 1;
            for (int i = num; i >= 1; i--)
            {
             factorial *= i;
            }
            return factorial;
        }

        static int DivisionOfFactorials(int first, int second)
        {
            int result = CalculateTheFactorial(first) / CalculateTheFactorial(second);
            return result;
        }
    }
}
