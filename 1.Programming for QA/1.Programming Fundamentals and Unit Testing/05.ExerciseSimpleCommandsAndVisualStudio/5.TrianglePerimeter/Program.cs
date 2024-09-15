namespace _5.TrianglePerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int sideC = int.Parse(Console.ReadLine());
            int perimeter = sideA + sideB + sideC;
            Console.WriteLine(perimeter);

        }
    }
}
