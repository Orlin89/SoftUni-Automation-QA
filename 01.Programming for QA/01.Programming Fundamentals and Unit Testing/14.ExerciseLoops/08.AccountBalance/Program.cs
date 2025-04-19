namespace _08.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0;

            while (input != "End")
            {
                double currentAmount = double.Parse(input);
               
                if (currentAmount > 0)
                {
                    Console.WriteLine($"Increase: {currentAmount:F2}");
                    balance += currentAmount;     
                }
                else if (currentAmount < 0)
                {
                    Console.WriteLine($"Decrease: {Math.Abs(currentAmount):F2}");
                    balance += currentAmount;      
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Balance: {balance:F2}");
        }
    }
}
