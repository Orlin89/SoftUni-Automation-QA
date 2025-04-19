namespace _09.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            int quantityCount = int.Parse(Console.ReadLine());

            CalculatePriceOfAnOrder(productName, quantityCount);
        }

        static void CalculatePriceOfAnOrder(string product, int quantity)
        {
            double coffeePrice = 1.50;
            double waterPrice = 1.00;
            double cokePrice = 1.40;
            double snacksPrice = 2.00;
            double result = 0;

            if (product == "coffee")
            {
              result = quantity * coffeePrice;
            }
            else if (product == "water")
            {
              result = quantity * waterPrice;
            }
            else if(product == "coke")
            {
              result = quantity * cokePrice;
            }
            else if (product == "snacks")
            {
              result = quantity * snacksPrice;
            }
            Console.WriteLine($"{result:F2}");
            return;
        }

    }
}
