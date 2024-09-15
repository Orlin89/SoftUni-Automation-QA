namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(" ")               
                .ToArray();
            string copyText = "";
            foreach (string s in text)
            {
                int length = s.Length;
                for (int i = 1; i <= length; i++)
                {
                  copyText += s;
                }
            }
            Console.WriteLine(copyText);
        }
    }
}
