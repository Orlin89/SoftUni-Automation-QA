namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombInfo = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombNum = bombInfo[0];
            int bombPower = bombInfo[1];

           for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];

                if (currentNum == bombNum)
                {
                    int startIndex = i - bombPower;
                    int endIndex = i + bombPower;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }
                    int countToRemove = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, countToRemove);
                    i = startIndex - 1;
                }
            }
            Console.WriteLine(numbers.Sum());

        }
    }
}
