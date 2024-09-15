using System.ComponentModel.Design;
using System.Diagnostics;

namespace _11.CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string extra = Console.ReadLine();
            double sugar = 0.40;
            double coffeePrice = 1.00;
            double teaPrice = 0.60;
            double finalPrice = 0;

            if (drink == "coffee")
            {
                if (extra == "sugar")
                {
                    finalPrice = coffeePrice + sugar;
                }

                else if (extra == "no")
                {
                    finalPrice = coffeePrice;
                }
            }

            else if (drink == "tea")
            {
                if (extra == "sugar")

                {
                    finalPrice += teaPrice + sugar;
                }
                 
                else if(extra == "no")
                {
                    finalPrice = teaPrice;
                }
            }
            Console.WriteLine($"Final price: ${finalPrice:F2}");
        }
    }
}