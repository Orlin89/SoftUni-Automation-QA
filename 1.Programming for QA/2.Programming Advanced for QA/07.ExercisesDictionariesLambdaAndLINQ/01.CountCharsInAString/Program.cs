namespace _01.CountCharsInAString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> textCount = new Dictionary<char, int>();

            foreach (char item in text)
            {
                if (item == ' ')
                {
                    continue;
                }
                else if (!textCount.ContainsKey(item))
                {
                    textCount.Add(item, 1);
                }
                else
                {
                    textCount[item]++;
                }
            }
            foreach (KeyValuePair<char, int> entry in textCount)
            {
                Console.WriteLine(entry.Key + " -> " + entry.Value);
            }
        }
    }
}

