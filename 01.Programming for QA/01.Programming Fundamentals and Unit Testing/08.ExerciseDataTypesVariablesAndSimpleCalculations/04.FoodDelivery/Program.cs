namespace _04.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChickenMenu = int.Parse(Console.ReadLine());
            int numberOfFishMenu = int.Parse(Console.ReadLine());
            int numberOfVegetarianMenu = int.Parse(Console.ReadLine());

            double chickenMenuPrice = 10.35;
            double fishMenuPrice = 12.40;
            double vegetarianMenuPrice = 8.15;
            double deliveryPrice = 2.50;

            double chickenMenuCosts = numberOfChickenMenu * chickenMenuPrice;
            double fishMenuCosts = numberOfFishMenu * fishMenuPrice;
            double vegetarianCosts = numberOfVegetarianMenu * vegetarianMenuPrice;

            double allMenuesPrice = chickenMenuCosts + fishMenuCosts + vegetarianCosts;
            double dessertPrice = allMenuesPrice * 0.2;
            double totalPrice = allMenuesPrice + dessertPrice + deliveryPrice;

            Console.WriteLine(totalPrice);



        }
    }
}
