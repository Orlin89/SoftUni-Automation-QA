namespace _06.NumberInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (number < 1 || number > 100) 
            {
              number = int.Parse (Console.ReadLine());
            }
            Console.WriteLine(number);

        }
    }
}
