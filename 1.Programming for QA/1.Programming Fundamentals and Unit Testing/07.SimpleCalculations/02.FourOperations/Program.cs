namespace _02.FourOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double addition = firstNumber + secondNumber;
            double subtraction = firstNumber - secondNumber;
            double multiplication = firstNumber * secondNumber;
            double division = firstNumber / secondNumber;
            Console.WriteLine($"{firstNumber:F2} + {secondNumber:F2} = {addition:F2}");
            Console.WriteLine($"{firstNumber:F2} - {secondNumber:F2} = {subtraction:F2}");
            Console.WriteLine($"{firstNumber:F2} * {secondNumber:F2} = {multiplication:F2}");
            Console.WriteLine($"{firstNumber:F2} / {secondNumber:F2} = {division:F2}");

        }
    }
}
