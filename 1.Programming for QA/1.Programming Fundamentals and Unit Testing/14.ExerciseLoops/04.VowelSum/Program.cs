namespace _04.VowelSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
           
            int value = 0;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                
                if (letter == 'a')
                {
                    value += 1;
                }
                else if (letter == 'e')
                {
                    value += 2;
                }
                else if (letter == 'i')
                {
                    value += 3;
                }
                else if (letter == 'o')
                {
                    value += 4;
                }
                else if (letter == 'u')
                {
                    value += 5;
                }
            }
            Console.WriteLine(value);
        }
    }
}
