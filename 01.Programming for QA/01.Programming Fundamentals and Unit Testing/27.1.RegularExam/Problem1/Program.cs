namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            if (n <= 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    int caloric = int.Parse(Console.ReadLine());
                    sum += caloric;
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
