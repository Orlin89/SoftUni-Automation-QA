namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> bannedWords = Console.ReadLine()
                .Split(", ")
                .ToList();
             string text = Console.ReadLine();
            foreach (string word in bannedWords)
            {
                string replacemend = "";
                for (int i = 1; i <= word.Length; i++)
                {
                    replacemend += "*";
                }
               text = text.Replace(word, replacemend);
            }
            Console.WriteLine(text);

        }
    }
}
