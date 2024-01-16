namespace TestExercise
{
    internal class Program
    {
       enum FuelType
        {
            gasoline,
            diesel,
            electric,
            hybrid
        }

        struct Car
        {
            public string manufacturer;
            public string model;
            public int year;
            public string color;
            public FuelType fuelType;

            public Car(string manufacturer, string model, int year, string color, FuelType fuelType = FuelType.gasoline)
            {
                this.manufacturer = manufacturer;
                this.model = model;
                this.year = year;
                this.color = color;
                this.fuelType = fuelType;
            }
        }

        static void Main(string[] args)
        {
            Car car = new Car("Volkswagen", "Passat", 2018, "black");
            UpdateCarColor(ref car, "blue");

            Console.WriteLine(car.color);
            Console.Read();
        }

        static void UpdateCarColor(ref Car car, string newColor)
        {
            car.color = newColor;
        }
    }
}