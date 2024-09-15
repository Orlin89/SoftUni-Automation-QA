namespace Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]prices = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
             
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());
            double sum = 0;
            double counter = 0;            
            for (int i = startIndex; i <= endIndex ; i++)
            {               
                sum += prices[i];
                counter++;
            }
            double finalSum = sum / counter;
            Console.WriteLine($"{finalSum:F2}");
        }
    }
}
