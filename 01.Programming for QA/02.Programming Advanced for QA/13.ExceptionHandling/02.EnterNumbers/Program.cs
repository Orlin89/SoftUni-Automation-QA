namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1; 
            int end = 100;
            List<int> numbers = new List<int>();
            while (numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(start, end);
                    numbers.Add(number);
                    start = number;
                }
                catch (ArgumentException ae)
                { 
                  Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            try
            {
                int number = int.Parse(input);
                if (number <= start || number >= end)
                {
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");
                }
                return number;
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }
        }
    }
    
}
