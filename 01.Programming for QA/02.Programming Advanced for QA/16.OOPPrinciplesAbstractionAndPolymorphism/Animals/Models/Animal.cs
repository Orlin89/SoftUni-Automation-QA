namespace Animals.Models;

public abstract class Animal
{
   public string name;
   public string favouriteFood;

    public string Name { get; set; }
    public string FavouriteFood { get; set; }

    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }
    public virtual string ExplainSelf()
    {
        return "hello";
    }
}
