namespace _04.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floor = int.Parse(Console.ReadLine());
            int estate = int.Parse(Console.ReadLine());
            
            for (int i = floor; i >= 1; i--)
            {
                for (int j = 0; j < estate; j++)
                {
                    if (i % 2 != 0 && i < floor)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                    else if (i % 2 == 0 && i < floor)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else if (i == floor)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
