using System;

namespace _01.Marketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();


            if (product == "Banana")

                if (dayOfWeek == "Weekday")
                {
                    Console.WriteLine("2.50");
                }
                else
                {
                    Console.WriteLine("2.70");
                }
            else if (product == "Apple")

                if (dayOfWeek == "Weekday")
                {
                    Console.WriteLine("1.30");
                }
                else
                {
                    Console.WriteLine("1.60");
                }
            else if(product == "Kiwi")
                
                    if (dayOfWeek =="Weekday")
                {
                    Console.WriteLine("2.20");
                }
                    else
                {
                    Console.WriteLine("3.00");
                }



        }
    }
}
