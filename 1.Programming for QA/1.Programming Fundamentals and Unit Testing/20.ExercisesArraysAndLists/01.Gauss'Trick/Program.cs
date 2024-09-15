namespace _01.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            List<int> output = new List<int>();

            int iteration = numbers.Length / 2;
            for (int i = 0; i < iteration; i++)
            {
                int currentNum = numbers[i] + numbers[numbers.Length - 1 - i];
                output.Add(currentNum);
            }
            if (numbers.Length % 2 != 0)
            {
                int index = numbers.Length / 2;
                output.Add(numbers[index]);
            }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
