using System;

namespace _08.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {  
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        static int GetSumOfEvenDigits(int num)
        {
            int sumEven = 0; ;
            int digit = 0;
            for (int i = 0; 0 < num; i++)
            {
                digit = num % 10;

                if (digit % 2 == 0)
                {
                    sumEven += digit;
                }

                num /= 10;
            }  
            return sumEven;
        }

        static int GetSumOfOddDigits(int num)
        {
            int sumOdd = 0; ;
            int digit = 0;
            for (int i = 0; 0 < num; i++)
            {
                digit = num % 10;

                if (digit % 2 != 0)
                {
                    sumOdd += digit;
                }

                num /= 10;
            }
            return sumOdd;
        }
    }
}
