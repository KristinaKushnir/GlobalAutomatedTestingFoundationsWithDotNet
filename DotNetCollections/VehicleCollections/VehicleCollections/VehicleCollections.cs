using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace VehicleManagementApp
{
    public class VehicleCollection
    {
        static void Main(string[] args)
        {
            // Используем объекты из файла VehicleManagementApp.cs
            Car car = new Car(new Engine("100hp", 1.8, "Gasoline", "ABC123"), new Chassis(4, "1234", 1000), new Transmission("Manual", 5, "Manufacturer"));
            Truck truck = new Truck(new Engine("300hp", 5.0, "Diesel", "DEF456"), new Chassis(6, "5678", 5000), new Transmission("Automatic", 8, "Manufacturer"));
            Bus bus = new Bus(new Engine("200hp", 2.5, "Gasoline", "GHI789"), new Chassis(4, "4321", 2000), new Transmission("Manual", 6, "Manufacturer"));
            Scooter scooter = new Scooter(new Engine("50hp", 0.5, "Gasoline", "JKL012"), new Chassis(2, "9876", 100), new Transmission("Automatic", 1, "Manufacturer"));

            // Создаем коллекцию транспортных средств
            List<Car> vehicles = new List<Car>();

            // Добавляем объекты в коллекцию
            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);
            vehicles.Add(scooter);

            // Записываем информацию в XML файлы
            WriteFullInfoToXml(vehicles);
            WriteEngineInfoToXml(vehicles);
            WriteGroupedInfoToXml(vehicles);
        }

        public static void WriteFullInfoToXml(List<Car> vehicles)
        {
            // Создаем XML документ для полной информации
            XDocument fullInfoDocument = new XDocument(new XElement("Vehicles"));

            // Фильтруем транспортные средства с объемом двигателя более 1.5 литров
            var filteredVehicles = vehicles.Where(v => v.Engine.Volume > 1.5);

            foreach (Car vehicle in filteredVehicles)
            {
                XElement vehicleElement = new XElement("Vehicle",
                    new XElement("Type", vehicle.GetType().Name),
                    new XElement("EnginePower", vehicle.Engine.Power),
                    new XElement("EngineVolume", vehicle.Engine.Volume),
                    new XElement("EngineType", vehicle.Engine.Type),
                    new XElement("EngineSerialNumber", vehicle.Engine.SerialNumber),
                    new XElement("ChassisWheels", vehicle.Chassis.NumberOfWheels),
                    new XElement("ChassisNumber", vehicle.Chassis.Number),
                    new XElement("ChassisLoadCapacity", vehicle.Chassis.LoadCapacity),
                    new XElement("TransmissionType", vehicle.Transmission.Type),
                    new XElement("TransmissionGears", vehicle.Transmission.NumberOfGears),
                    new XElement("TransmissionManufacturer", vehicle.Transmission.Manufacturer));

                fullInfoDocument.Root?.Add(vehicleElement);
            }

            // Сохраняем XML документ с полной информацией
            fullInfoDocument.Save("full_info.xml");
        }

        public static void WriteEngineInfoToXml(List<Car> vehicles)
        {
            // Создаем XML документ для информации о двигателе
            XDocument engineInfoDocument = new XDocument(new XElement("Vehicles"));

            // Фильтруем автобусы и грузовики
            var filteredVehicles = vehicles.Where(v => v is Bus || v is Truck);

            foreach (Car vehicle in filteredVehicles)
            {
                XElement vehicleElement = new XElement("Vehicle",
                    new XElement("Type", vehicle.GetType().Name),
                    new XElement("EngineType", vehicle.Engine.Type),
                    new XElement("EngineSerialNumber", vehicle.Engine.SerialNumber),
                    new XElement("EnginePower", vehicle.Engine.Power));

                engineInfoDocument.Root?.Add(vehicleElement);
            }

            // Сохраняем XML документ с информацией о двигателе
            engineInfoDocument.Save("engine_info.xml");
        }

        public static void WriteGroupedInfoToXml(List<Car> vehicles)
        {
            // Создаем XML документ для группированной информации
            XDocument groupedInfoDocument = new XDocument(new XElement("Vehicles"));

            // Группируем транспортные средства по типу трансмиссии
            var groupedVehicles = vehicles.GroupBy(v => v.Transmission.Type);

            foreach (var group in groupedVehicles)
            {
                XElement transmissionElement = new XElement(group.Key);

                foreach (Car vehicle in group)
                {
                    XElement vehicleElement = new XElement("Vehicle",
                        new XElement("Type", vehicle.GetType().Name),
                        new XElement("EnginePower", vehicle.Engine.Power),
                        new XElement("EngineVolume", vehicle.Engine.Volume),
                        new XElement("ChassisWheels", vehicle.Chassis.NumberOfWheels),
                        new XElement("ChassisNumber", vehicle.Chassis.Number),
                        new XElement("ChassisLoadCapacity", vehicle.Chassis.LoadCapacity),
                        new XElement("TransmissionGears", vehicle.Transmission.NumberOfGears),
                        new XElement("TransmissionManufacturer", vehicle.Transmission.Manufacturer));

                    transmissionElement.Add(vehicleElement);
                }

                groupedInfoDocument.Root?.Add(transmissionElement);
            }

            // Сохраняем XML документ с группированной информацией
            groupedInfoDocument.Save("grouped_info.xml");
        }
    }
}