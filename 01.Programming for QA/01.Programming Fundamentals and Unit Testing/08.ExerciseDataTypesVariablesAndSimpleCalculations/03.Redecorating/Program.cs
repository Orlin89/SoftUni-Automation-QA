namespace _03.Redecorating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylonSqM = int.Parse(Console.ReadLine());
            int paintLiter = int.Parse(Console.ReadLine());
            int thinnerLiters = int.Parse(Console.ReadLine());  
            int  craftsmenHours = int.Parse(Console.ReadLine());

            double nylonTotal = (nylonSqM + 2) * 1.50;
            double paintTotal = (paintLiter * 1.10) * 14.50;
            double thinenrTotal = thinnerLiters * 5.00;
            double bags = 0.40;
            double materialsTotal = nylonTotal + paintTotal + thinenrTotal + bags;
            double craftsmenTotal = (materialsTotal * 0.30)  * craftsmenHours;
            double totalCosts = materialsTotal + craftsmenTotal;

            Console.WriteLine (totalCosts);
        }
    }
}
