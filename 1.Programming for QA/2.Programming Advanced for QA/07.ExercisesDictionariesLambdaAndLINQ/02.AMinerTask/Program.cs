namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            Dictionary<string, int> miner = new Dictionary<string, int>(); 
            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if(!miner.ContainsKey(resource))
                {
                    miner.Add(resource, quantity);
                }
                else
                {
                    miner[resource]+= quantity;
                }

                resource = Console.ReadLine();
            }
            foreach(KeyValuePair <string, int> entry in miner)
            {
                Console.WriteLine(entry.Key + " -> " + entry.Value);
            }
        }
    }
}
