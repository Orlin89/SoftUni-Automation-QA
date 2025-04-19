namespace _03.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            List<int> positive = new List<int>();
            List<int> negative = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber < 0)
                {
                    negative.Add(numbers[i]);
                }
                if (currentNumber > 0)
                {
                  positive.Add(numbers[i]);
                }
            }
            if (negative.Count == numbers.Count)
            {
                Console.WriteLine("empty");
            }
            
            positive.Reverse();
            Console.WriteLine(string.Join(" ", positive));
        }
    }
}
