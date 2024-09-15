namespace _4.TrapezoidArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstBase = int.Parse (Console.ReadLine());
            int secondBase = int.Parse (Console.ReadLine());    
            int height = int.Parse (Console.ReadLine());
            int area = (firstBase + secondBase) / 2 * height;
            Console.WriteLine (area);
        }
    }
}
