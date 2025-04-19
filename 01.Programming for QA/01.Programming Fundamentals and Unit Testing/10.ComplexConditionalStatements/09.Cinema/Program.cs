using System.Runtime.ConstrainedExecution;

namespace _09.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieType = Console.ReadLine();  
            int rowsCount = int.Parse(Console.ReadLine());
            int seatsPerRow = int.Parse(Console.ReadLine());

            double allSeats = rowsCount * seatsPerRow;
            double finalPrice = 0;

            if (movieType == "Premiere")
            {
                finalPrice = allSeats * 12;
                
            }
            else if (movieType == "Normal")
            {  
                finalPrice = allSeats * 7.50;
                
            }
            else if (movieType == "Discount")
            {
                finalPrice = allSeats * 5;
                
            }
            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
