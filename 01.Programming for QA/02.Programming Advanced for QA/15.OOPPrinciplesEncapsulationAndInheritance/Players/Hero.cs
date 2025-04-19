namespace Players;

public class Hero
{
    private string userName;
    private int level;

    public string UserName { get; set; }
    public int Level { get; set; }

    public Hero(string userName, int level)
    {
        this.UserName = userName;
        this.Level = level;
    }
    public override string ToString()
    {
        return $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
    }
}
