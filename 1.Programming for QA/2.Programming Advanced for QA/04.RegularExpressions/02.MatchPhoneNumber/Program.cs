using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex validPhone = new Regex(@"[+]359([ -])2\1[0-9]{3}\1[0-9]{4}");
            MatchCollection collection = validPhone.Matches(text);

            for (int i = 0; i <= collection.Count -1; i++)
            {
                if (i == collection.Count -1)
                {
                    Console.Write(collection[i].Value);
                }
                else
                {
                    Console.Write(collection[i].Value + ", ");
                }
            }
        }
    }
}
