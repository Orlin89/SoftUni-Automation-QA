using System.Text.Json;
using PizzaFactory.Models;

namespace PizzaFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ParsePizzas();
        }

        // Parses and displays pizza data
        private static void ParsePizzas()
        {
            string jsonFilePath = Path.Combine("Datasets", "Pizza-Factory.json");
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                PizzaCollection? pizzaCollection = JsonSerializer.Deserialize<PizzaCollection>(json);
                DisplayPizzas(pizzaCollection);
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        // Displays the list of pizzas
        private static void DisplayPizzas(PizzaCollection? pizzaCollection)
        {
            if (pizzaCollection == null || pizzaCollection.Pizzas == null)
            {
                Console.WriteLine("No pizza data found or data is not in the expected format.");
                return;
            }

            Console.WriteLine("Pizzas:");
            for(int i = 0; i < pizzaCollection.Pizzas.Count; i++)
            {
                Console.WriteLine($"Pizza #{i+1}");
                Console.WriteLine($"ID: {pizzaCollection.Pizzas[i].PizzaId}, Name: {pizzaCollection.Pizzas[i].PizzaName}");
                Console.WriteLine($"Size: {pizzaCollection.Pizzas[i].Size}");
                Console.WriteLine($"Ingredients: {string.Join(", ", pizzaCollection.Pizzas[i].Ingredients)}");
                Console.WriteLine($"Cooking Method: {pizzaCollection.Pizzas[i].CookingMethod}");
            }
        }

        // Handles errors that occur during JSON parsing
        private static void HandleError(Exception e)
        {
            if (e is JsonException)
            {
                Console.WriteLine($"JSON Parsing Error: {e.Message}");
            }
            else
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }
        }
    }
}
