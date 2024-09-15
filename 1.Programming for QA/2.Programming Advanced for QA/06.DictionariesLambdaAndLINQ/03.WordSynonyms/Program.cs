namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary <string, List<string>> wordsWithSynonyms = new Dictionary<string, List<string>>();
            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                string synonyms = Console.ReadLine();

                if (!wordsWithSynonyms.ContainsKey(word))
                {
                    wordsWithSynonyms.Add(word, new List<string>());
                    wordsWithSynonyms[word].Add(synonyms);
                }
                else
                {
                    wordsWithSynonyms[word].Add(synonyms);
                }
            }
            foreach (KeyValuePair <string, List<string>>word in wordsWithSynonyms)
            {
                Console.WriteLine(word.Key + " - " + string.Join(", ", word.Value));
            }
        }
    }
}
