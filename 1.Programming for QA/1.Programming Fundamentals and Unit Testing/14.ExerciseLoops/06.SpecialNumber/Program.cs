using System.Diagnostics.CodeAnalysis;

namespace _06.SpecialNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numCopy = num;
            bool isSpecial = false; 
            
            while (num > 0)
            {
                int lastDigit = num % 10;
                if (numCopy % lastDigit == 0)
                {
                    isSpecial = true;
                }
                else 
                {
                    isSpecial = false;
                    break;
                }
                num /= 10;
            }
            if (isSpecial)
            {
                Console.WriteLine($"{numCopy} is special");
            }
            else
            {
                Console.WriteLine($"{numCopy} is not special");
            }
      
        }
    }
}
