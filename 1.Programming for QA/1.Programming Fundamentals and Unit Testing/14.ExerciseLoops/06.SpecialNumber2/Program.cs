namespace _06.SpecialNumber2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numCopy = num;
            bool isSpecial = true;

            while (num > 0)
            {
                int lastDigit = num % 10;
                if (numCopy % lastDigit != 0)
                {
                    isSpecial = false;
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
