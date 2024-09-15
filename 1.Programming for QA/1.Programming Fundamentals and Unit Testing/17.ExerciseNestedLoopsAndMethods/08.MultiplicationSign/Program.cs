namespace _08.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                // Count the number of negative numbers
                int negativeCount = 0;
                if (num1 < 0) negativeCount++;
                if (num2 < 0) negativeCount++;
                if (num3 < 0) negativeCount++;

                // Determine if the product is negative or positive
                if (negativeCount % 2 == 0)
                {
                    Console.WriteLine("positive");
                }
                else
                {
                    Console.WriteLine("negative");
                }
            }
        }     
    }
}
