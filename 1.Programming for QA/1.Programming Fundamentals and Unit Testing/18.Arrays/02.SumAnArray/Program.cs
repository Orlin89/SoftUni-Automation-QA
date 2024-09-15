namespace _02.SumAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            foreach (int i in n) 
            {
             sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
