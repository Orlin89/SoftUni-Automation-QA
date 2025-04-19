namespace _01.ConvertorUSDToEUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal dollars = decimal.Parse(Console.ReadLine());
            decimal euro = dollars * 0.88m;
            Console.WriteLine($"{euro:F2}");

        }
    }
}
