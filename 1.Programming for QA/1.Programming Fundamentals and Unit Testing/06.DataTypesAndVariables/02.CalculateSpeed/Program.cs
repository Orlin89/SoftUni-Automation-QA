namespace _02.CalculateSpeed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine()); 
            double time = double.Parse(Console.ReadLine());
            double speed = distance / time;
            Console.WriteLine($"{speed:F2}");


        }
    }
}
