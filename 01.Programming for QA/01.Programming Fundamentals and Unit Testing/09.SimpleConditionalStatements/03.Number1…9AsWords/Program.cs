using System;
using System.ComponentModel.Design;

namespace _03.Number1_9AsWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
               // one" – if the number is 1
                 // "two" – if the number is 2
              // "three" – if the number is 3
                  // "four" – if the number is 4
               // "five" – if the number is 5
             //  "six" – if the number is 6
                  //"seven" – if the number is 7
                  /// "eight" – if the number is 8
                // "nine" – if the number is 9





            int number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                Console.WriteLine("one");

            }
            else if (number == 2)
            {
                Console.WriteLine("two");

            }

            else if (number == 3)
            {
                Console.WriteLine("three");

            }

            else if (number == 4)
            {
                Console.WriteLine("four");
            }

            else if (number == 5)
            {
                Console.WriteLine("five");
            }

            else if (number == 6)
            {
                Console.WriteLine("six");

            }

            else if (number == 7)
            {
                Console.WriteLine("seven");
            }

            else if (number == 8)
            {
                Console.WriteLine("eight");
            }

            else if (number == 9)
            {
                Console.WriteLine("nine");
            }

            else
            { 
            Console.WriteLine("Out of range");
            }
        }
    }
}
