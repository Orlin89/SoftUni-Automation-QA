namespace _04.NumberOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();

            double sum = 0;

            if (operators == "+")
            {
                sum = num1 + num2;
            }
            else if (operators == "-")
            {
                sum = num1 - num2;
            }  
            else if(operators == "*")
            {
                sum = num1 * num2;
            }
            else if (operators == "/")
            {
                sum = num1 / num2;
            }

            Console.WriteLine($"{num1} {operators} {num2} = {sum:F2}");
        }   
    }
}
