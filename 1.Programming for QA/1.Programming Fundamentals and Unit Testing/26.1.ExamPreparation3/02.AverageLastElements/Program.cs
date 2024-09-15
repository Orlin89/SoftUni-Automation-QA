using System.Diagnostics.CodeAnalysis;

namespace _02.AverageLastElements
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
            double sum = 0;
            for (int i = numbers.Length -1; i >= numbers.Length -n; i--)
            {
                sum += numbers[i];
            }
            double finalSum = sum / n;
            Console.WriteLine($"{finalSum:F2}");
        }
    }
}
