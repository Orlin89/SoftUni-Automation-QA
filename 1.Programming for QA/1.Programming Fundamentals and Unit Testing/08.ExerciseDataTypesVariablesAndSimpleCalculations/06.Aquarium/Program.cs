namespace _06.Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine()); 
            int width = int.Parse(Console.ReadLine());  
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double volumeOfAquarium = length * width * height;
            double volumeInLiters = volumeOfAquarium * 0.001;   //   volumeInLiters = volumeOfAquarium / 1000
            double requiredLiters = volumeInLiters * (1 - (percentage / 100));

            Console.WriteLine($"{requiredLiters:F2}");
 
        }
    }
}
