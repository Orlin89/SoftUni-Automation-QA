namespace _06.MandatoryLiterature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int .Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int readingHours = pages / pagesPerHour;
            int hoursPerDay  = readingHours / days;

            Console.WriteLine(hoursPerDay);

        }
    }
}
