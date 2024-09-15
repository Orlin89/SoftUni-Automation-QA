namespace _05.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int traningFee = int.Parse(Console.ReadLine());
           

            double sneakersPrice = traningFee * 0.6;
            double uniformPrice = sneakersPrice * 0.8;
            double ballPrice = uniformPrice / 4;
            double accessoriesPrice = ballPrice / 5;

            double totalPrice = traningFee + sneakersPrice + uniformPrice + ballPrice + accessoriesPrice;
            
            Console.WriteLine(totalPrice);

         

        }
    }
}
