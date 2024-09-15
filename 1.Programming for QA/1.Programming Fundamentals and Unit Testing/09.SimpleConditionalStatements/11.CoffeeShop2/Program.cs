namespace _11.CoffeeShop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string extra = Console.ReadLine();

            decimal price = 0m;
            if (drink == "tea")
            {
                price = 0.60m;
            }
            else  // coffee
            {
                price = 1.00m;
            }

            if (extra == "sugar")
            {
                price += 0.40m;       //  price = price + 0.40m; 
            }

            Console.WriteLine($"Final price: ${price:F2}");
        }
    }
}
