namespace _01.ChangeList
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
            while ((command = Console.ReadLine())!= "end")
            {
                string[] tokens = command.Split(" ");
                string operation = tokens[0];
                if (operation == "Delete")
                {
                    int number = int.Parse(tokens[1]);
                    while (numbers.Contains(number))
                    {
                        numbers.Remove(number);
                    }
                }
                else if (operation == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    numbers.Insert(position, number);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
