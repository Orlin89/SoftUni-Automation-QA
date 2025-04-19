namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] weekDays = 
            {
              "Monday",
              "Tuesday", 
              "Wednesday", 
              "Thursday", 
              "Friday", 
              "Saturday", 
              "Sunday"
            };
            if (number >= 1 && number <= 7)
            {
              Console.WriteLine(weekDays[number - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
    }
}
}
