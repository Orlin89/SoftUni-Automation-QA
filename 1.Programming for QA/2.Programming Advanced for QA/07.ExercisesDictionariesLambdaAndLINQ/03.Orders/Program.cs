namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> orderPrice = new Dictionary<string, double>();
            Dictionary<string, int> orderQuantity = new Dictionary<string, int>();

            string command = Console.ReadLine();
            while (command != "buy")
            {
                string[] productOrser = command.Split();
                string name = productOrser[0];
                double price = double.Parse(productOrser[1]);
                int quantity = int.Parse(productOrser[2]);
                if (orderPrice.ContainsKey(name) && orderQuantity.ContainsKey(name))
                {
                    orderPrice[name] = price;
                    orderQuantity[name] += quantity;
                }
                else
                {
                    orderPrice.Add(name, price);
                    orderQuantity.Add(name, quantity);
                }
                command = Console.ReadLine();
            }
            foreach(KeyValuePair <string, double> entry in orderPrice)
            {
                string name = entry.Key;
                double price = entry.Value;
                int quantity = orderQuantity[name];
                double totalPrice = price * quantity;
                Console.WriteLine($"{name} -> {totalPrice:F2}");
            }
        }
    }
}
