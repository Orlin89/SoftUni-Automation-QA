using System.Diagnostics.Metrics;

namespace _06.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            FindTheCountOfTheVowels(text);
        }

        static void FindTheCountOfTheVowels(string text)
        {
            int Counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                switch (symbol)
                {
                    case 'a': Counter++; break;
                    case 'o': Counter++; break;
                    case 'u': Counter++; break;
                    case 'e': Counter++; break;
                    case 'i': Counter++; break; 
                    case 'A': Counter++; break; 
                    case 'O': Counter++; break; 
                    case 'U': Counter++; break; 
                    case 'E': Counter++; break; 
                    case 'I': Counter++; break; 
                }
                
            }
            Console.WriteLine(Counter);
        }
    }
}
