using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace _05.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                  .Split(" ")
                  .Select(int.Parse)
                  .ToList();
           
            string command = "";
            while ((command = Console.ReadLine()) != "end") 
            {
                string[] tokens = command
                    .Split(" ")
                    .ToArray();
                if (tokens[0] == "Contains")
                {
                    int num = int.Parse(tokens[1]);
                    if (numbers.Contains(num))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (tokens[0] == "PrintEven")
                {
                    List<int> evenNumbers = new List<int>();
                    for (int i = 0; i < numbers.Count; i ++)
                    {
                      if (numbers[i] % 2 == 0)
                      {
                            evenNumbers.Add(numbers[i]);   
                      }
                    }
                    Console.WriteLine(string.Join(" ", evenNumbers));

                }
                else if (tokens[0] == "PrintOdd")
                {
                    List<int> oddNumbers = new List<int>();
                     for (int i = 0; i < numbers.Count; i++)
                     {
                        if (numbers[i] % 2 != 0)
                        {
                            oddNumbers.Add(numbers[i]);
                        }
                     }
                    Console.WriteLine(string.Join(" ", oddNumbers));

                }
                else if (tokens[0] == "GetSum")
                {
                      int sum = 0;
                     for(int i = 0;i < numbers.Count; i ++)
                     {
                        sum += numbers[i];  
                     }
                    Console.WriteLine(sum);
                }
                else if (tokens[0] == "Filter")
                {
                    string condition = tokens[1];
                    int num = int.Parse(tokens[2]);
                    if (condition == "<")
                    {
                        for(int i = 0; i < numbers.Count ; i ++)
                        {
                            if (numbers[i] >= num)
                            {
                                numbers.Remove(numbers[i]);
                                i--;
                            }                           
                        }                       
                    }
                    else if (condition == ">")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= num)
                            {
                                numbers.Remove(numbers[i]);
                                i --;
                            }
                        }                       
                    }
                    else if (condition == "<=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > num)
                            {
                                numbers.Remove(numbers[i]);
                                i --;
                            }

                        }                       
                    }
                    else if (condition == ">=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < num)
                            {
                                numbers.Remove(numbers[i]);
                                i --;
                            }
                        }                       
                    }                   
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
