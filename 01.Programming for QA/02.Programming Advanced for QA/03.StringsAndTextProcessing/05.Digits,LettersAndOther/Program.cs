using System.Text;

namespace _05.Digits_LettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sbDigit = new StringBuilder();
            StringBuilder sbLetter = new StringBuilder();
            StringBuilder sbOther = new StringBuilder();

            foreach (char symbol in text)
            {
                if (char.IsDigit(symbol))
                {
                    sbDigit.Append(symbol);
                }
                else if (char.IsLetter(symbol))
                {
                    sbLetter.Append(symbol);
                }
                else
                {
                    sbOther.Append(symbol);
                }
            }
            Console.WriteLine(sbDigit);
            Console.WriteLine(sbLetter);
            Console.WriteLine(sbOther);
        }
    }
}
