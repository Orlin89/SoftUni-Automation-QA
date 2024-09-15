namespace _05.VacationExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string accommodationType = Console.ReadLine();
            int countOfDays = int.Parse(Console.ReadLine());

            
            double totalPrice = 0;

            if (season =="Spring")
            {
                if (accommodationType == "Hotel")
                {
                    totalPrice = (countOfDays * 30) * 0.8;
                }
                else if (accommodationType == "Camping")
                {
                    totalPrice = (countOfDays * 10) * 0.8;
                }
            }
            else if (season == "Summer")
            {
                if(accommodationType == "Hotel")
                {
                    totalPrice = countOfDays * 50;
                }
                else if (accommodationType == "Camping")
                {
                    totalPrice = countOfDays * 30;
                }
            }
            else if (season == "Autumn")
            {
                if (accommodationType == "Hotel")
                {
                    totalPrice = (countOfDays * 20) * 0.7;
                }
                else if (accommodationType == "Camping")
                {
                    totalPrice = (countOfDays * 15) * 0.7;
                }


            }
            else if (season == "Winter")
            {
                if (accommodationType == "Hotel")
                {
                    totalPrice = (countOfDays * 40) * 0.9;
                }
                else if (accommodationType == "Camping")
                {
                    totalPrice = (countOfDays * 10) * 0.9;
                }
            }
            Console.WriteLine($"{totalPrice:F2}");
            


            








        }
    }
}
