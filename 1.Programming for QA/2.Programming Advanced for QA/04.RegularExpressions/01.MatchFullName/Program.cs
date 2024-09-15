using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();

            Regex validName = new Regex(@"\b[A-Z][a-z]+[ ][A-Z][a-z]+\b");
            MatchCollection matches = validName.Matches(text);
            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
        }
    }
}
