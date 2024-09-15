namespace _03.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max1 = int.Parse(Console.ReadLine());
            int max2 = int.Parse(Console.ReadLine());
            int max3 = int.Parse(Console.ReadLine());

            for (int i = 2; i <= max1; i+= 2)
            {
                for (int j = 2; j <= max2; j++)
                {
                    if (j == 2 || j == 3 || j == 5 || j == 7) 
                    { 
                      for(int k = 2; k <= max3; k+= 2)
                      {
                            Console.Write($"{i}{j}{k}");
                            Console.WriteLine();
                      }
                    }
                }
            }
        }
    }
}
