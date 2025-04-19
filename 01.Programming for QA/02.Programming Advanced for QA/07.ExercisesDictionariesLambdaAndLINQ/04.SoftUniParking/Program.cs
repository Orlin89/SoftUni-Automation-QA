namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingLot = new Dictionary<string, string>();
            int n  = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            
            for (int i = 1; i <= n; i++)
            {   string validate = command.Split(" ")[0];
                string username = command.Split(" ")[1];
                
                if (validate == "register") 
              {
                  string licensePlateNumber = command.Split(" ")[2];

                  if (parkingLot.ContainsKey(username))
                  {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingLot[username]}");
                  }
                  else if(!parkingLot.ContainsKey(username))
                  {
                        parkingLot.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                  }
              }
              if (validate == "unregister")
                {
                    if (!parkingLot.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else if (parkingLot.ContainsKey(username))
                    {
                        parkingLot.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
              }
                    command = Console.ReadLine();
            }
            foreach(KeyValuePair<string, string> entry in parkingLot)
            {
                string username = entry.Key;
                string licensePlateNumber = entry.Value;
                Console.WriteLine($"{username} => {licensePlateNumber}");
            }

        }
    }
}
