namespace ConsoleApp1
{
    public class Vehicle
    {
        protected string brand;
        protected string models;
        protected int year;

        public Vehicle(string brand, string model, int year)
        {
            this.brand = brand;
            this.models = model;
            this.year = year;
        }
        public void start()
        {
            Console.WriteLine("Vehicle is starting.............");
        }
        public void stop()
        {
            Console.WriteLine("Vehicle is stopped!!!!!!!!!!!!!!");
        }
        public void displayDetails()
        {
            Console.WriteLine("Brand: " + this.brand);
            Console.WriteLine("Model: " + this.models);
            Console.WriteLine("Year: " + this.year);
        }
    }
    public class Car : Vehicle
    {
        private int noOfDoors;
        public Car(string brand, string models, int year, int doors) : base(brand, models, year)
        {
            noOfDoors = doors;
        }
        public void displayDetails()
        {
            Console.WriteLine("Car details:");
            Console.WriteLine("Brand: " + brand);
            Console.WriteLine("Model: " + models);
            Console.WriteLine("Year: " + year);
            Console.WriteLine("No Of Doors: " + noOfDoors);
            base.start();
            base.stop();
        }

    }
    public class Bike : Vehicle
    {
        bool HasGears;
        public Bike(string brand, string model, int year, bool hasGears) : base(brand, model, year)
        {
            HasGears = hasGears;
        }
        public void displayDetails()
        {
            Console.WriteLine("Bike Details:");
            Console.WriteLine("Brand: " + brand);
            Console.WriteLine("Model: " + models);
            Console.WriteLine("Year: " + year);
            Console.WriteLine("Has Gears: " + HasGears);
            base.start();
            base.stop();
        }
    }
}
