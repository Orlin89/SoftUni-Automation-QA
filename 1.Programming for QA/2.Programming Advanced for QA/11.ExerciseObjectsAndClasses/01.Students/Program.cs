namespace _01.Students
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Students> studentsList = new List<Students>();

            for (int i = 0; i < n; i++)
            {
                string[] currStudent = Console.ReadLine().Split();
                string firstName = currStudent[0];
                string lastName = currStudent[1];
                double grade = double.Parse(currStudent[2]);
                Students students = new Students(firstName, lastName, grade);
                studentsList.Add(students);
            }
            foreach (Students students in studentsList.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine($"{students.FirstName} {students.LastName}: {students.Grade:F2}");
            }
        }
    }
    public class Students
    {
        public Students(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; } 
    }
}
