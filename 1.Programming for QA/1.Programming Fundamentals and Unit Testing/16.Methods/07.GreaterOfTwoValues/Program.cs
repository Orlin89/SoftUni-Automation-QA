namespace _07.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();

            if (values == "string") 
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                Console.WriteLine(GetMax(first, second));
            }
            else if (values == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));
            }
            else if (values == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));
            }
        }

        static string GetMax(string a, string b)
        {
           int result = a.CompareTo(b);
            if (result >= 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        static char GetMax(char a, char b) 
        {
         if (a > b)
            {
                return a;
            }
         else
            {
                return b;
            }

        }
        static int GetMax(int a, int b) 
        {
            int result = b;
         if (a > b)
            {
                result = a;
            }
         return result;
        }
    }
}
