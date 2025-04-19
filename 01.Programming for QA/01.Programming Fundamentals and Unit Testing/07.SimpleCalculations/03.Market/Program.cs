namespace _03.Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal tomatoPrice = decimal.Parse(Console.ReadLine());
            decimal tomatoes = decimal.Parse(Console.ReadLine());   
            
            decimal cucumberPrice = decimal.Parse(Console.ReadLine());   
            decimal cucumbers = decimal.Parse(Console.ReadLine());

            decimal tomatoCost = tomatoPrice * tomatoes;
            decimal cucumberCost = cucumberPrice * cucumbers;

            decimal totalCosta = tomatoCost + cucumberCost;
            
            Console.WriteLine($"{totalCosta:F2}");
        }
    }
}
