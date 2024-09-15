using System.Diagnostics;

namespace _08.FruitOrVegetable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine(); 

            switch (product)
            {  
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                    Console.WriteLine("fruit");
                    break;

                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }











        }
    }
}
