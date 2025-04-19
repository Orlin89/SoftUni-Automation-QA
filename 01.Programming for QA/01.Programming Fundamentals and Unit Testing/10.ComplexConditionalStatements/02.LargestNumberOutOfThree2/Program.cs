namespace _02.LargestNumberOutOfThree2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse (Console.ReadLine()); 
            int b = int.Parse (Console.ReadLine()); 
            int c = int.Parse (Console.ReadLine());

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine(a);
                }
            }
            else if (b > c)
            {
                Console.WriteLine(b);
            }

            else 
            { 
             Console.WriteLine (c);
            }
            
        }
    }
}
