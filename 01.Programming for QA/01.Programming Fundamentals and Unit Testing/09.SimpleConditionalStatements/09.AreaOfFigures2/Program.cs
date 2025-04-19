namespace _09.AreaOfFigures2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double area = 0;
            if (figure == "square")
            { 
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }

            if (figure == "rectangle")
            { 
                double width = double.Parse(Console.ReadLine());
                double length = double.Parse(Console.ReadLine());   
                area = width * length;
            }

            if (figure == "circle") 
            { 
            double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;         
            }

            Console.WriteLine($"{area:F2}");
        }
    }
}
