using System.Globalization;

namespace _01.EnglishNameofEachDigit2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            for (int i = number.Length -1; i >= 0; i--)
            {
                string currentNum = number[i].ToString();

                switch (currentNum)
                {
                    case "1": Console.WriteLine("one"); break;
                    case "2": Console.WriteLine("two"); break;
                    case "3": Console.WriteLine("three"); break;
                    case "4": Console.WriteLine("four"); break;
                    case "5": Console.WriteLine("five"); break;
                    case "6": Console.WriteLine("six"); break;
                    case "7": Console.WriteLine("seven"); break;
                    case "8": Console.WriteLine("eight"); break;
                    case "9": Console.WriteLine("nine"); break;
                }
            }
        }
    }
}
