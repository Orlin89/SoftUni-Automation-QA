namespace _01.SumFactorialEvenDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            
           
            int sum = 0;

            while (numbers > 0)
            {
                int digit = numbers % 10;
                numbers /= 10; 
                if (digit % 2 == 0)
                {
                    int factorial = digit;
                    for (int i = digit - 1; i >= 1; i--)
                    {
                      factorial *= i;    
                    }
                    sum += factorial;
                }
                 
            }
            Console.WriteLine(sum);
        }
    }
}
