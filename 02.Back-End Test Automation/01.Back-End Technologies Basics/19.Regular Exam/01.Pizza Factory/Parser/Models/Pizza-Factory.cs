using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PizzaFactory.Models
{
    public class Pizza
    {
        [JsonPropertyName("pizzaId")]
        public int PizzaId { get; set; } = 0;

        [JsonPropertyName("pizzaName")]
        public string PizzaName { get; set; } = string.Empty;

        [JsonPropertyName("size")]
        public string Size { get; set; } = string.Empty;

        [JsonPropertyName("ingredients")]
        public List<string> Ingredients { get; set; } = new List<string>();

        [JsonPropertyName("cookingMethod")]
        public string CookingMethod { get; set; } = string.Empty;
    }

    public class PizzaCollection
    {
        [JsonPropertyName("pizzas")]
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
