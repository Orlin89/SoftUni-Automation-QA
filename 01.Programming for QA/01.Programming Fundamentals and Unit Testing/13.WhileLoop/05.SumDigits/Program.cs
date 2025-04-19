namespace _05.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digit = 0;
            int sum = 0;

            while (number > 0)
            {
                digit = number % 10;
                number /= 10;
                sum += digit;  

            }
            Console.WriteLine(sum);
        }
    }
}
