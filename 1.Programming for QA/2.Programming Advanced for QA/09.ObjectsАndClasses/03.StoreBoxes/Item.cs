public class Item
{
    //характеристики -> описваме чрез properties
    public string Name { get; set; }
    public double Price { get; set; }

    //конструктор -> създаваме обекти от класа

    //default конструктор (вграден) -> нов празен обект -> new Item()

    //custom конструктор -> нов обект, на който да му задаваме определени стойности
    public Item(string name, double price)
    {
        //нов празен обект
        //Name = null
        //Price = 0.0
        Name = name;
        Price = price;
    }

}