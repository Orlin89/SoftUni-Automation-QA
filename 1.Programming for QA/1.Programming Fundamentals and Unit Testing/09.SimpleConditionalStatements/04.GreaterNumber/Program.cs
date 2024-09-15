namespace _04.GreaterNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int a = int.Parse(Console.ReadLine());
          int b = int.Parse(Console.ReadLine());

            if (a > b) 
            {
                Console.WriteLine($"Greater number: {a}");
            }

            else 
            {
            Console.WriteLine($"Greater number: {b}");
            }
        }
    }
}
