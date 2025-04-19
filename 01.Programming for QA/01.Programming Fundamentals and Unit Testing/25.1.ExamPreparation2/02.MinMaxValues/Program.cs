using System.Globalization;

namespace _02.MinMaxValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            

            for (int i = 0; i < n; i++)
            {
                int current = numbers[i];
                if (current > maxNumber)
                {
                    maxNumber = current;                
                }
                if (current < minNumber)
                {
                    minNumber = current;
                }
            }
            Console.WriteLine(maxNumber);
            Console.WriteLine(minNumber);
        }
    }
}
