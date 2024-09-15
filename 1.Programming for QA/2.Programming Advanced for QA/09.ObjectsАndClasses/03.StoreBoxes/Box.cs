public class Box
{
    //характеристики -> описваме ги чрез properties
    public string SerialNumber { get; set; }
    public Item Item { get; set; } //Item -> name и price -> описваме какъв вид артикули имаме в кутията
    public int ItemQuantity { get; set; }
    public double Price { get; set; }

    //конструктор -> създаваме обекти от класа

    //1. default констуктор (вграден) -> създаваме празен обект от класа

    //2. custom конструктор -> създаваме обект с определени стойности на характеристиките
    public Box(string serialNumber, Item item, int count)
    {
        //нов празен обект
        //SerialNumber = null
        //Item = null
        //ItemQuantity = 0
        //Price = 0.0
        SerialNumber = serialNumber;
        Item = item;
        ItemQuantity = count;
        Price = count * item.Price;
    }
}
