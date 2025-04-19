namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ")
                .Where(word => word.Length %2 == 0 )
                .ToArray();

            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
