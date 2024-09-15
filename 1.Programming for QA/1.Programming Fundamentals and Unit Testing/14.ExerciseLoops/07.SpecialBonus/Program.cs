namespace _07.SpecialBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int lastNumber = 0;
            while (true)
            {
                int stopNumber = int.Parse(Console.ReadLine()) ;
                
                if (stopNumber == n) 
                {
                 break;
                }
                lastNumber = stopNumber;
            }
            double result = lastNumber * 1.2;
            Console.WriteLine(result);
        }
    }
}
