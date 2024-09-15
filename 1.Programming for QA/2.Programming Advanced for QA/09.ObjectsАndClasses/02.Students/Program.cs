public class Program
{
   public static void Main(string[] args)
   {
        string command = Console.ReadLine();
        List<Students> studentsList = new List<Students>();
        while (command != "end")
        {
            string firstName = command.Split()[0];
            string lastName = command.Split()[1];
            int age = int.Parse(command.Split()[2]);
            string homeTown = command.Split()[3];

            Students student = new Students(firstName, lastName, age, homeTown); 
            studentsList.Add(student);

            command = Console.ReadLine();
        }
        string townName = Console.ReadLine();
        foreach (Students item in studentsList)
        {
            if(townName == item.HomeTown)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }
    }
}

