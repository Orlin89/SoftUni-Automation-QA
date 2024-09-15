namespace _05.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal depositedAmount = decimal.Parse(Console.ReadLine());
            int depositTerm = int.Parse(Console.ReadLine());
            decimal interestRate = decimal.Parse(Console.ReadLine());

            decimal annualInterest = depositedAmount * interestRate / 100;
            decimal montlyInterest = annualInterest / 12;
            decimal amount = depositedAmount + (depositTerm * montlyInterest);

            Console.WriteLine(amount);

        }
    }
}
