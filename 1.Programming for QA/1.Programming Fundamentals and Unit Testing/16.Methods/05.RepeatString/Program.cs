using static System.Net.Mime.MediaTypeNames;

namespace _05.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());
            
            RepeatingText(text, repeatCount);
            
        }

        static void RepeatingText(string someText, int repeatNumber)
        {
            for (int i = 0; i < repeatNumber; i++)
            {
                Console.Write(someText);  
            }
            return;
        }
    }
}
