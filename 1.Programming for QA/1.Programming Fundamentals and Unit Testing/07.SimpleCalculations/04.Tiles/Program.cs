namespace _04.Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bathW = double.Parse(Console.ReadLine());
            double bathH = double.Parse(Console.ReadLine());

            double tileW = double.Parse(Console.ReadLine());
            double tileH = double.Parse(Console.ReadLine());

            double bathArea = bathW * bathH * 1.10;
            double tileArea = tileW * tileH;

            double tilesNeeded = bathArea / tileArea;
            Console.WriteLine($"{tilesNeeded:F0}");

        }
    }
}
