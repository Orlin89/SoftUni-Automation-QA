namespace _07.SumOfDigitsCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string number = (Console.ReadLine());

                if (number =="End")
                {
                    Console.WriteLine("Goodbye");
                    break;
                }

                int n = int.Parse(number);
                int sum = 0;
                for (int i = 0; 0 < n; i++)
                {
                  int lastDigit = n % 10;
                    n /= 10;
                    sum += lastDigit;   
                }

                Console.WriteLine($"Sum of digits = {sum}");
            }
        }
    }
}
