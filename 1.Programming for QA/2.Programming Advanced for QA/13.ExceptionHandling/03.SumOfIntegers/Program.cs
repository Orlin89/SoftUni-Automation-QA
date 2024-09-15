namespace _03.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string elements = Console.ReadLine();
            string[] currElements = elements.Split();
            int sum = 0;
            
             foreach (string item in currElements)
             {
                try
                {
                    int num = int.Parse(item);
                    sum += num;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }
                catch(OverflowException)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }

                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
             }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
