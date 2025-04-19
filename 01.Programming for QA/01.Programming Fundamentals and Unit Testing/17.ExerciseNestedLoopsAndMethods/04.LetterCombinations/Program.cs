using System.Diagnostics.Metrics;

namespace _04.LetterCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char excludingLetter = char.Parse(Console.ReadLine());
            int counter = 0;
            for (char i = startLetter; i <= endLetter; i++)
            {
                for (char j = startLetter; j <= endLetter; j++)
                {
                    for(char k = startLetter; k <= endLetter; k++)
                    {
                        if (i == excludingLetter || j == excludingLetter || k == excludingLetter)
                        {
                            continue;
                        }
                        Console.Write($"{i}{j}{k} ");
                        counter++; 
                    }
                } 
            }
            Console.WriteLine();
            Console.WriteLine(counter);
        }
    }
}
