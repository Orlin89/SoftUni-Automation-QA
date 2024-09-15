namespace _04.Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNumber = 1;

            while (firstNumber <= n)
            {
                Console.WriteLine(firstNumber);
                firstNumber = firstNumber * 2 + 1;
            }

        }
    }
}
