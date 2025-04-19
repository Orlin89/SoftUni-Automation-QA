namespace _05.DivisionTo2_3and4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int divisionTo2 = 0;
            int divisionTo3 = 0;
            int divisionTo4 = 0;
            int countOfNumbers = 0;

            for (int i = 0; i < n; i++)
            {
                 int numbers = int.Parse(Console.ReadLine());

                if (numbers % 2 == 0)
                {
                    divisionTo2 += 1;
                    
                }
                if (numbers %3 == 0)
                {
                    divisionTo3 += 1;
                }
                if (numbers %4 == 0)
                {
                    divisionTo4 += 1;
                }
                countOfNumbers++;
            }
            double percent2 = (double)divisionTo2 / countOfNumbers * 100;
            double percent3 = (double)divisionTo3 / countOfNumbers * 100;
            double percent4 = (double)divisionTo4 / countOfNumbers * 100;

            Console.WriteLine($"{percent2:F2}%");
            Console.WriteLine($"{percent3:F2}%");
            Console.WriteLine($"{percent4:F2}%");
        }
    }
}
