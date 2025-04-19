namespace _04.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int even = 0;
            int odd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] %2 == 0)
                {
                    even += numbers[i];
                }
                if (numbers[i] % 2 != 0) 
                {
                   odd += numbers[i];
                }
            }
            Console.WriteLine(even - odd);  
        }
    }
}
