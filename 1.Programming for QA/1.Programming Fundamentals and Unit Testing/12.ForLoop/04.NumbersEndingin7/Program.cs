﻿namespace _04.NumbersEndingin7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse (Console.ReadLine());

            for (int i = 7; i <= number; i+=10) 
            {
             Console.WriteLine (i);
            }
        }
    }
}
