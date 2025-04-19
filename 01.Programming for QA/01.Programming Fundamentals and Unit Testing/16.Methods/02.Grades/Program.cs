using System.Data;

namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            gradeCount(grade);
        }


        static double gradeCount(double gradeNumber)
        {
            if (gradeNumber >= 2.00 && gradeNumber <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (gradeNumber >= 3.00 && gradeNumber <= 3.49)
            {
                Console.WriteLine("Average");
            }
            else if (gradeNumber >= 3.50 && gradeNumber <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (gradeNumber >= 4.50 && gradeNumber <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (gradeNumber >= 5.50 && gradeNumber <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
            return gradeNumber;
        }
    }
}
