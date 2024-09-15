namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine()
                .Split(" ")
                .ToArray();

              Dictionary <string,int> oddWords = new Dictionary<string,int>();

            foreach(string word  in inputText)
            {
                string wordWithLowerCase = word.ToLower();
                if (!oddWords.ContainsKey(wordWithLowerCase))
                {
                    oddWords.Add(wordWithLowerCase, 1);
                }
                else
                {
                    oddWords[wordWithLowerCase]++;
                }
            }
            foreach(KeyValuePair <string, int> word in oddWords)
            {               
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
            
        }
    }
}
