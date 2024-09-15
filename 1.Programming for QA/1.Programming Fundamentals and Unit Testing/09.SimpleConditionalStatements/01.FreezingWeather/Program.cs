namespace _01.FreezingWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double temp = int.Parse(Console.ReadLine());
            if (temp <= 0) 
            {
                Console.WriteLine("Freezing weather!");
            }
        }
    }
}
