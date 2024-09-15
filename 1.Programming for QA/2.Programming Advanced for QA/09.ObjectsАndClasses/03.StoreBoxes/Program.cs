public class Program
{
    public static void Main(string[] args)
    {
        //Main метода -> специален метод, който се изпълнява при стартиране на файла

        //основната логика на задачата

        List<Box> boxesList = new List<Box>(); //списък с кутии

        string input = Console.ReadLine();

        while (input != "end")
        {
            //входни данни: input = "86757035 Butter 7 3.20"
            //"86757035 Butter 7 3.20".Split()

            string[] inputData = input.Split();
            //inputData = ["86757035", "Butter", "7", "3.20"]

            string serialNumber = inputData[0]; //"86757035"
            string itemName = inputData[1]; //"Butter"
            int itemCount = int.Parse(inputData[2]); //"7" -> parse -> 7
            double itemPrice = double.Parse(inputData[3]); //"3.20" -> parse -> 3.20

            //артикул
            Item item = new Item(itemName, itemPrice); //вид на артикула, който ще се съхранява в кутията

            //кутия
            Box box = new Box(serialNumber, item, itemCount);

            //съхраняваме
            boxesList.Add(box);

            input = Console.ReadLine();
        }

        //сортираме в намаляващ ред (descending order) списъка с кутии по цена
        List<Box> sortedBoxesList = boxesList.OrderByDescending(box => box.Price).ToList();

        //принтираме сортирания списъка с кутии
        foreach (Box box in sortedBoxesList)
        {
            Console.WriteLine(box.SerialNumber);
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
            Console.WriteLine($"-- ${box.Price:F2}");
        }
    }
}
