namespace _04.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            RectangleArea(width, length);
        }

        static int RectangleArea(int sideA, int sideB)
        {
            int area = sideA * sideB;
            Console.WriteLine(area);
            return area;
        }
          
    }
}
