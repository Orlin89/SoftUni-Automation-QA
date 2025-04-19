namespace _05.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<double>> studentsGrade = new Dictionary<string,List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
              string studentName = Console.ReadLine();
              double grade = double.Parse(Console.ReadLine());

                if (!studentsGrade.ContainsKey(studentName))
                {
                    studentsGrade.Add(studentName, new List<double>());
                    studentsGrade[studentName].Add(grade);
                }
                else if (studentsGrade.ContainsKey(studentName))
                {
                    studentsGrade[studentName].Add(grade);
                }
            }
            foreach(KeyValuePair<string, List<double>> entry in studentsGrade)
            {
                string name = entry.Key;
                double average = entry.Value.Average();
                if (average >= 4.50) 
                {
                 Console.WriteLine($"{name} -> {average:F2}");
                }
            }
        }
    }
}
