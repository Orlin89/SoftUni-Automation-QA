using System.Text;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text != "end")
            {               
                string reverse = "";
                for (int i = text.Length - 1; i >=0; i-- )
                {
                    reverse += text[i];
                }
                Console.WriteLine(text + " = " + reverse);
                text = Console.ReadLine();               
            }
        }
    }
}
