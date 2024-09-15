namespace _06.PetsFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFoodPackages = int.Parse(Console.ReadLine());
            int catFoodPackages = int.Parse(Console.ReadLine());
            double dogFoodCosts = dogFoodPackages * 2.50;
            double catFoodCosts = catFoodPackages * 4.00;
            double expenses = dogFoodCosts + catFoodCosts;
            Console.WriteLine($"{expenses:F2} lv.");

        }
    }
}
