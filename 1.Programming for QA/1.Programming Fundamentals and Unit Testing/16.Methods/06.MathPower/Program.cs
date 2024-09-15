namespace _06.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int baseNumber = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            MathPower(baseNumber, power);
        }

        static double MathPower(int baseNum, int powerNum)
        {
            double result = Math.Pow(baseNum, powerNum);
            Console.WriteLine(result);
            return result;
        }
    }
}
