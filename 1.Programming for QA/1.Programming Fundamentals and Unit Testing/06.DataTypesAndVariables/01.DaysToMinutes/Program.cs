namespace _01.DaysToMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = days * 24;
            int minutes = hours * 60;
            Console.WriteLine($"Minutes = {minutes}");
        }
    }
}
