//описваме всяка една кола
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //характеристики -> make, model, year -> описваме чрез properties или полета (fields)
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get;  set; }
        public double FuelQuantity { get; set; }   //количество налично гориво
        public double FuelConsumption { get; set; }  //разход на гориво за 1 км
        public Engine Engine { get; set; } 
        public Tire[] Tires { get; set; } 

        //действия -> описват се чрез методис
        public void Drive (double distance)
        {
          
            double needFuel = distance * FuelConsumption; //нужно гориво
            //1. не можем да преминем даденото разстояние = distance
            if (FuelQuantity <= needFuel)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            //2. ще успеем да преминем даденото разстояние: FuelQuantity >= needFuel
            else
            {
                FuelQuantity = FuelQuantity - needFuel;
                //FuelQuantity -= needFuel;
            }

        }

        public string WhoAmI()
        {
            StringBuilder sbInfoCar = new StringBuilder();

            sbInfoCar.Append("Make: " + Make).Append("\n");
            sbInfoCar.Append("Model: " + Model).Append("\n");
            sbInfoCar.Append("Year: " + Year).Append("\n");
            sbInfoCar.Append($"Fuel: {FuelQuantity:F2}");

            return sbInfoCar.ToString(); //текста, който имам конструиран в StringBuilder
        }

        //конструктор
        //1. default вграден конструктор -> празен обект от класа
        public Car()
        {
            //нов празен обект със статични стойности
            //използване:Car car = new Car();
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
            Engine = new Engine(0, 0);
            Tires = new Tire[4] { new Tire(0, 0), new Tire(0, 0), new Tire(0, 0), new Tire(0, 0) };
        }

        //custom constructors
        //1. приема производител, модел и година
        public Car (string make, string model, int year) : this()
        {
            //използване: Car car = new Car("BMW", "M3", 2005);

            //1. изпълняваме свързания конструктор Car() = this ()
            //Make = "VW";
            //Model = "Golf";
            //Year = 2025;
            //FuelQuantity = 200;
            //FuelConsumption = 10;

            //2. променяме само характеристиките, които ни трябват
            Make = make;
            Model = model;
            Year = year;
            //FuelQuantity = 200;
            //FuelConsumption = 10;

        }

        //2. приема производител, модел, година, налично гориво, разход
        public Car (string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {

            //използване: Car car = new Car("BMW", "M3", 2005, 34.60, 0.76);

            //1. изпълняваме свързания конструктор Car(string, string, int)
            //Make = make;
            //Model = model;
            //Year = year;
            //FuelQuantity = 200;
            //FuelConsumption = 10x

            //2. променяме само характеристиките, които ни трябват
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car (string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this( make, model, year, fuelQuantity, fuelConsumption) 
        {
            //Engine = engine;
            //Tires = tires;

            Engine = engine ?? new Engine(0, 0);
            Tires = tires ?? new Tire[4] { new Tire(0, 0), new Tire(0, 0), new Tire(0, 0), new Tire(0, 0) };
        }

    }
}

