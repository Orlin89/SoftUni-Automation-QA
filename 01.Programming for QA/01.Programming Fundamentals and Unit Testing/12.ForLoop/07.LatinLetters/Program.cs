namespace _07.LatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letterOne = char.Parse(Console.ReadLine());
            char letterTwo = char.Parse(Console.ReadLine());

            for (int i = letterOne;  i <= letterTwo; i++) 
            {
             Console.Write($"{(char)i} ");
            }

        }
    }
}
