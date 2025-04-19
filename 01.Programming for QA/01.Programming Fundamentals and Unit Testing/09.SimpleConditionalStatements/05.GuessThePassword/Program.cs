namespace _05.GuessThePassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string passwor = Console.ReadLine();

            if (passwor == "s3cr3t!")
            {
                Console.WriteLine("Welcome");
            }

            else 
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
