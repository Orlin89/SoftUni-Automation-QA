namespace _09.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfTheFigure = Console.ReadLine();

            if (typeOfTheFigure == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double squareArea = squareSide * squareSide;
                Console.WriteLine($"{squareArea:F2}");
            }

            else if (typeOfTheFigure == "rectangle")
            {
                double rectangleWidth = double.Parse(Console.ReadLine());
                double rectangleLength = double.Parse(Console.ReadLine());
                double rectangleArea = rectangleWidth * rectangleLength;
                Console.WriteLine($"{rectangleArea:F2}");
            }

            else if (typeOfTheFigure == "circle")
            { 
                double circleRadius = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * circleRadius * circleRadius;
                Console.WriteLine($"{circleArea:F2}");
            
            
            }
        }
    }
}
