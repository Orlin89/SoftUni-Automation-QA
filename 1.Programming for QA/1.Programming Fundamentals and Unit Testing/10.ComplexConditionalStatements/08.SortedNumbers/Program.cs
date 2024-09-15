using System.ComponentModel.Design;

namespace _08.SortedNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number1 = int.Parse(Console.ReadLine());
            int Number2 = int.Parse(Console.ReadLine());
            int Number3 = int.Parse(Console.ReadLine());

            if (Number1 < Number2 && Number2 < Number3)
            {
                Console.WriteLine("Ascending");
            }
            else if (Number1 > Number2 && Number2 > Number3)
            {
                Console.WriteLine("Descending");
            }
            else
            {
                Console.WriteLine("Not sorted");
            }
        }   
            
    }
}
