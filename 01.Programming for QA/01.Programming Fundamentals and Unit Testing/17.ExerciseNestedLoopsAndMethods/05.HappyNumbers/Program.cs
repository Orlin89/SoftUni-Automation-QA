namespace _05.HappyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int d1 = 1; d1 <= n; d1++)
            {
                for (int d2 = 0; d2 <= n; d2++)
                {
                    for(int d3 = 0; d3 <= n; d3++)
                    {
                        for (int d4 = 0; d4 <= n ; d4++)
                        {
                          if ((d1 + d2 == n) && (d3 + d4 == n))
                            {
                                Console.Write($"{d1}{d2}{d3}{d4} ");
                            }    
                        }
                    }
                }
            }
        }
    }
}
