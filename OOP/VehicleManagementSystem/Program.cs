using System;


public class Engine
{
    // Fields
    public string Power { get; set; }
    public double Volume { get; set; }
    public string Type { get; set; }
    public string SerialNumber { get; set; }

    // Constructor
    public Engine(string power, double volume, string type, string serialNumber)
    {
        Power = power;
        Volume = volume;
        Type = type;
        SerialNumber = serialNumber;
    }
}

public class Chassis
{
    // Fields
    public int NumberOfWheels { get; set; }
    public string Number { get; set; }
    public double LoadCapacity { get; set; }

    // Constructor
    public Chassis(int numberOfWheels, string number, double loadCapacity)
    {
        NumberOfWheels = numberOfWheels;
        Number = number;
        LoadCapacity = loadCapacity;
    }
}

public class Transmission
{
    // Fields
    public string Type { get; set; }
    public int NumberOfGears { get; set; }
    public string Manufacturer { get; set; }

    // Constructor
    public Transmission(string type, int numberOfGears, string manufacturer)
    {
        Type = type;
        NumberOfGears = numberOfGears;
        Manufacturer = manufacturer;
    }
}

public class Car
{
    // Fields
    public Engine Engine { get; set; }
    public Chassis Chassis { get; set; }
    public Transmission Transmission { get; set; }

    // Constructor
    public Car(Engine engine, Chassis chassis, Transmission transmission)
    {
        Engine = engine;
        Chassis = chassis;
        Transmission = transmission;
    }

    // Methods
    public string GetCarInfo()
    {
        string engineInfo = $"Engine Power: {Engine.Power}, Volume: {Engine.Volume}, Type: {Engine.Type}, Serial Number: {Engine.SerialNumber}";
        string chassisInfo = $"Chassis Wheels: {Chassis.NumberOfWheels}, Number: {Chassis.Number}, Load Capacity: {Chassis.LoadCapacity}";
        string transmissionInfo = $"Transmission Type: {Transmission.Type}, Gears: {Transmission.NumberOfGears}, Manufacturer: {Transmission.Manufacturer}";

        return $"{engineInfo}\n{chassisInfo}\n{transmissionInfo}";
    }
}

public class Truck : Car
{
    // Constructor
    public Truck(Engine engine, Chassis chassis, Transmission transmission)
        : base(engine, chassis, transmission)
    {
        // No additional truck-specific initialization
    }

    // Method
    public string GetTruckInfo()
    {
        return GetCarInfo(); // Call base class method to get car information
    }
}

public class Bus : Car
{
    // Constructor
    public Bus(Engine engine, Chassis chassis, Transmission transmission)
        : base(engine, chassis, transmission)
    {
        // No additional bus-specific initialization
    }

    // Method
    public string GetBusInfo()
    {
        return GetCarInfo(); // Call base class method to get car information
    }
}

public class Scooter : Car
{
    // Constructor
    public Scooter(Engine engine, Chassis chassis, Transmission transmission)
        : base(engine, chassis, transmission)
    {
        // No additional bus-specific initialization
    }

    // Method
    public string GetScooterInfo()
    {
        return GetCarInfo(); // Call base class method to get car information
    }
}
public class VehicleManagementSystem
{
    static void Main(string[] args)
    {
        // Parse arguments and create objects for a specific type of vehicle
        static void ParseFleetArguments(string[] args, out Engine engine, out Chassis chassis, out Transmission transmission)
        {
            string enginePower = args[0];
            double engineVolume = double.Parse(args[1]);
            string engineType = args[2];
            string engineSerialNumber = args[3];
            engine = new Engine(enginePower, engineVolume, engineType, engineSerialNumber);

            int chassisWheels = int.Parse(args[4]);
            string chassisNumber = args[5];
            double chassisLoadCapacity = double.Parse(args[6]);
            chassis = new Chassis(chassisWheels, chassisNumber, chassisLoadCapacity);

            string transmissionType = args[7];
            int transmissionGears = int.Parse(args[8]);
            string transmissionManufacturer = args[9];
            transmission = new Transmission(transmissionType, transmissionGears, transmissionManufacturer);
        }

        // Parse arguments for cars
        Engine carEngine;
        Chassis carChassis;
        Transmission carTransmission;
        ParseFleetArguments(args[0..10], out carEngine, out carChassis, out carTransmission);

        // Parse arguments for trucks
        Engine truckEngine;
        Chassis truckChassis;
        Transmission truckTransmission;
        ParseFleetArguments(args[10..20], out truckEngine, out truckChassis, out truckTransmission);

        // Parse arguments for buses
        Engine busEngine;
        Chassis busChassis;
        Transmission busTransmission;
        ParseFleetArguments(args[20..30], out busEngine, out busChassis, out busTransmission);

        // Parse arguments for scooters
        Engine scooterEngine;
        Chassis scooterChassis;
        Transmission scooterTransmission;
        ParseFleetArguments(args[30..40], out scooterEngine, out scooterChassis, out scooterTransmission);

        //Create vehicle objects
        Car car = new Car(carEngine, carChassis, carTransmission);
        Truck truck = new Truck(truckEngine, truckChassis, truckTransmission);
        Bus bus = new Bus(busEngine, busChassis, busTransmission);
        Scooter scooter = new Scooter(scooterEngine, scooterChassis, scooterTransmission);

        // Display vehicle information
        Console.WriteLine("Car specifications:");
        Console.WriteLine(car.GetCarInfo());

        Console.WriteLine("Truck specifications:");
        Console.WriteLine(truck.GetTruckInfo());

        Console.WriteLine("Bus specifications:");
        Console.WriteLine(bus.GetBusInfo());

        Console.WriteLine("Scooter specifications:");
        Console.WriteLine(scooter.GetCarInfo());
    }
}