using System.Reflection.Metadata.Ecma335;

namespace _02.MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                       
               for (int j = 1; j <= n; j++)
               { 
                  for (int k = 1; k <= n; k++)
                  {
                    for (int l = 1; l <= n; l++)
                    {
                      if (j <= 9 && k <= 9 && l <= 9)
                      { 
                          if (j * k * l == n  )
                          {
                           Console.Write($"{j}{k}{l} ");
                          }
                      }
                      else
                      {
                            continue;
                      }
                    }
                  }
               }           
        }
    }
}
