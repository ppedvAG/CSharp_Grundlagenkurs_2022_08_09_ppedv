namespace SampleApp_AnfrageVon2022_08_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Car());
            vehicles.Add(new Car());
            vehicles.Add(new Ship());
            vehicles.Add(new Plain());


            CheckVehicles(vehicles);
        }

        public static void CheckVehicles(IList<Vehicle> vehicles)
        {
            foreach(Vehicle vehicle in vehicles)
            {
                switch (vehicle)
                {
                    case Car:
                        Console.WriteLine("Car");
                        break;
                    case Ship:
                        Console.WriteLine("Ship");
                        break;
                    case Plain:
                        Console.WriteLine("Plain");
                        break;
                    default:
                        Console.WriteLine("Unsupported Object");
                        break;
                }
            }
        }
    }

    public class Vehicle
    {
        
    }

    public class Car : Vehicle
    {

    }

    public class Ship : Vehicle
    {

    }

    public class Plain : Vehicle
    {

    }
}