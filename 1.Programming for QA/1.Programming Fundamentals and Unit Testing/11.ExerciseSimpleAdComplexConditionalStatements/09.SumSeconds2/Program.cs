﻿namespace _09.SumSeconds2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            int allTimes = time1 + time2 + time3;
            int minutes = allTimes / 60;
            int seconds = allTimes % 60;

            

                Console.WriteLine($"{minutes}:{seconds:D2}");

        }
    }
}