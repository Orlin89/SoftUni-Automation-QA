namespace _01.PowerОfNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            int sum = 1;
            for (int i = 0; i < power; i++)
            {
                sum *= n;
            }
            Console.WriteLine(sum);
        }
    }
}
