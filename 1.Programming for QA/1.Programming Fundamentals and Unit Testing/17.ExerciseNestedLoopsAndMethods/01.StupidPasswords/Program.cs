namespace _01.StupidPasswords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int even = 2; even <= n; even += 2)
            {
              for (int odd = 1; odd <= n; odd += 2)
                {
                    int product = even * odd;
                    Console.Write($"{even}{odd}{product} ");
                }
            }
        }
    }
}
