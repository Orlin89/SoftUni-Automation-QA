namespace CarManufacturer
{
    public class Engine
    {
        public int HorsePower {get; set;} 
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
    }
}
