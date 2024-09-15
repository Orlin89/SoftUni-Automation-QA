namespace _02.FirstNNumbersSum2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            string expression = "";

            for (int i = 1; i <= n; i++)
            {
                sum += i;

                if (i == n)
                {
                    expression += $"{i}=";
                }
                else
                {
                    expression += $"{i}+";
                }


            }
            Console.WriteLine($"{expression}{sum}");
        }
    }
}
