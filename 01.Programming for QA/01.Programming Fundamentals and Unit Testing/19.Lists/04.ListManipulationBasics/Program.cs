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
                string[] tokens = command.Split(" ");
                if (tokens[0] == "Add")
                {
                    int num = int.Parse(tokens[1]);
                    numbers.Add(num);
                }
                else if (tokens[0] == "Remove")
                {
                    int num = int.Parse(tokens[1]);
                    numbers.Remove(num);
                }
                else if (tokens[0] == "RemoveAt")
                {
                    int index = int.Parse(tokens[1]);
                    numbers.RemoveAt(index);
                }
                else if (tokens[0] == "Insert")
                {
                    int num = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, num);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

