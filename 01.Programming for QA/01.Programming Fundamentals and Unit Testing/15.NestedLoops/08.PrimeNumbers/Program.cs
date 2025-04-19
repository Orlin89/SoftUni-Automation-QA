namespace _08.PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i ; j++)
                {
                    if (i % j == 0)
                    {
                      isPrime = false;
                    }
                    
                }
                if (isPrime)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
