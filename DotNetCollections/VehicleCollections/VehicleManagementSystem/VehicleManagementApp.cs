using System;

namespace VehicleManagementApp
{
    public class Engine
    {
        public string Power { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }

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
        public int NumberOfWheels { get; set; }
        public string Number { get; set; }
        public double LoadCapacity { get; set; }

        public Chassis(int numberOfWheels, string number, double loadCapacity)
        {
            NumberOfWheels = numberOfWheels;
            Number = number;
            LoadCapacity = loadCapacity;
        }
    }

    public class Transmission
    {
        public string Type { get; set; }
        public int NumberOfGears { get; set; }
        public string Manufacturer { get; set; }

        public Transmission(string type, int numberOfGears, string manufacturer)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }
    }

    public class Car
    {
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }

        public Car(Engine engine, Chassis chassis, Transmission transmission)
        {
            Engine = engine;
            Chassis = chassis;
            Transmission = transmission;
        }

        public string GetCarInfo()
        {
            // Возвращает информацию о машине в виде строки
            return $"Engine Power: {Engine.Power}, Volume: {Engine.Volume}, Type: {Engine.Type}, Serial Number: {Engine.SerialNumber}\n" +
                   $"Chassis Wheels: {Chassis.NumberOfWheels}, Number: {Chassis.Number}, Load Capacity: {Chassis.LoadCapacity}\n" +
                   $"Transmission Type: {Transmission.Type}, Gears: {Transmission.NumberOfGears}, Manufacturer: {Transmission.Manufacturer}";
        }
    }

    public class Truck : Car
    {
        public Truck(Engine engine, Chassis chassis, Transmission transmission)
            : base(engine, chassis, transmission)
        {
        }

        public string GetTruckInfo()
        {
            // Возвращает информацию о грузовике, вызывая метод GetCarInfo() базового класса
            return GetCarInfo();
        }
    }

    public class Bus : Car
    {
        public Bus(Engine engine, Chassis chassis, Transmission transmission)
            : base(engine, chassis, transmission)
        {
        }

        public string GetBusInfo()
        {
            // Возвращает информацию о автобусе, вызывая метод GetCarInfo() базового класса
            return GetCarInfo();
        }
    }

    public class Scooter : Car
    {
        public Scooter(Engine engine, Chassis chassis, Transmission transmission)
            : base(engine, chassis, transmission)
        {
        }

        public string GetScooterInfo()
        {
            // Возвращает информацию о скутере, вызывая метод GetCarInfo() базового класса
            return GetCarInfo();
        }
    }

    class VehicleManagementSystem
    {
        static void Main(string[] args)
        {
            // Метод для парсинга аргументов и создания объектов для определенного типа транспортного средства
            static void ParseVehicleArguments(string[] args, out Engine engine, out Chassis chassis, out Transmission transmission)
            {
                // Парсинг аргументов и создание объектов Engine, Chassis и Transmission
                engine = new Engine(args[0], double.Parse(args[1]), args[2], args[3]);
                chassis = new Chassis(int.Parse(args[4]), args[5], double.Parse(args[6]));
                transmission = new Transmission(args[7], int.Parse(args[8]), args[9]);
            }

            Engine carEngine, truckEngine, busEngine, scooterEngine;
            Chassis carChassis, truckChassis, busChassis, scooterChassis;
            Transmission carTransmission, truckTransmission, busTransmission, scooterTransmission;

            // Парсинг аргументов для автомобиля
            ParseVehicleArguments(args[0..10], out carEngine, out carChassis, out carTransmission);

            // Парсинг аргументов для грузовика
            ParseVehicleArguments(args[10..20], out truckEngine, out truckChassis, out truckTransmission);

            // Парсинг аргументов для автобуса
            ParseVehicleArguments(args[20..30], out busEngine, out busChassis, out busTransmission);

            // Парсинг аргументов для скутера
            ParseVehicleArguments(args[30..40], out scooterEngine, out scooterChassis, out scooterTransmission);

            // Создание объектов транспортных средств
            Car car = new Car(carEngine, carChassis, carTransmission);
            Truck truck = new Truck(truckEngine, truckChassis, truckTransmission);
            Bus bus = new Bus(busEngine, busChassis, busTransmission);
            Scooter scooter = new Scooter(scooterEngine, scooterChassis, scooterTransmission);

            // Вывод информации о транспортных средствах
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
}