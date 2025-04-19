namespace _07.NumberProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();   

            while (text != "End")
            {
                if (text == "Inc")
                {
                    number++;
                    text = Console.ReadLine();
                    
                }
                else if (text == "Dec")
                {
                    number--;
                    text = Console.ReadLine();
                    
                }

            }
            Console.WriteLine(number);
        }   
    }    
}
