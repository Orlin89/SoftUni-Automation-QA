using System.Diagnostics.Metrics;

namespace _06.BoilingWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());

            if (temperature > 100 )
            {
                Console.WriteLine("The water is boiling");
            }

            else
            {
                Console.WriteLine("The water is not hot enough");
            }
        }
    }
}
