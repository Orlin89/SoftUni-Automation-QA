namespace CarManufacturer
{
    public class StartUp
    {
        //основната логика на задачата
        //при стартиране на клас StartUp -> изпълнява Main
        //Main метода си пишем, кода, който искаме да се изпълни при стартиране
        public static void Main (string [] args)
        {
           Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3),
            };
            Engine engine = new Engine(560, 6300);
            Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}

