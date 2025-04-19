namespace _08.TicketPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tickettype = Console.ReadLine();

            decimal price = 0;

            if (tickettype == "student") 
            {
                price = 1.00m;
                Console.WriteLine($"${price:F2}");
            }

            else if (tickettype == "regular") 
            {
                price = 1.60m;
            Console.WriteLine($"${price:F2}");
            }

            else
            {
                Console.WriteLine("Invalid ticket type!");
            }
        }
    }
}
