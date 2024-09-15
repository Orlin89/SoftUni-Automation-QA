using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex valid = new Regex(@"(?<day>[0-9]{2})(?<separator>[\/\.\-])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})");

            MatchCollection collection = valid.Matches(text);
            foreach (Match match in collection)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
