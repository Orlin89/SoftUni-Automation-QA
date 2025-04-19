namespace _02.MiddleElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int middle = numbers.Length / 2;
            int firstElement = numbers[middle];
            int secondElement = numbers[middle - 1];
            int sum = secondElement + firstElement;
            double result = sum / 2.0;
            Console.WriteLine($"{result:F2}");
            

            
        }
    }
}
