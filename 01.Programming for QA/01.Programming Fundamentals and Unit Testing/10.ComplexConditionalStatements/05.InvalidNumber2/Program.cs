namespace _05.InvalidNumber2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number = int.Parse(Console.ReadLine());

            if (!((Number >= 100 && Number <= 200) || Number == 0))
            {
                Console.WriteLine("invalid");
            }
           
        }
    }
}
