namespace _06.TravelSavings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double budgetNeeded = double.Parse(Console.ReadLine());
                double colectedMoney = 0;

                while (true)
                {
                    string colected = Console.ReadLine();
                    double amountOfMoney = double.Parse(colected);

                    colectedMoney += amountOfMoney;
                    Console.WriteLine($"Collected: {colectedMoney:F2}");

                    if (colectedMoney >= budgetNeeded)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                    
                }
                
            }
        }    
    }
}
