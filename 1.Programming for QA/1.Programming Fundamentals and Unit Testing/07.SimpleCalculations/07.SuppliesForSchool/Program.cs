namespace _07.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal pensPackagePrice = 5.80m;
            decimal markersPackagePrice = 7.20m;
            decimal boardCleanerPrice = 1.20m;

            double penPackages = double.Parse(Console.ReadLine());
            double markerPackages = double.Parse(Console.ReadLine());
            double boardCleanerLiters = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            decimal penPackagesCosts = (decimal)penPackages * pensPackagePrice;
            decimal markerPackagesCosts = (decimal)markerPackages * markersPackagePrice;
            decimal boardCleanerCosts = (decimal)boardCleanerLiters * boardCleanerPrice;

            decimal totalCosts = penPackagesCosts + markerPackagesCosts + boardCleanerCosts;
            decimal discountAmount = totalCosts * ((decimal)discount / 100);
            decimal totalCostsAfterDiscount = totalCosts - discountAmount;

            Console.WriteLine(totalCostsAfterDiscount);
        }
    }
}
