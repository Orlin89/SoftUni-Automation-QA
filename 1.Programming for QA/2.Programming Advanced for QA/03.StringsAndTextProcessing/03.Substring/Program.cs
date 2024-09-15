namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            while (second.IndexOf(first) != -1)
            {
                second = second.Remove(second.IndexOf(first), first.Length);
            }
            Console.WriteLine(second);
        }
    }
}
