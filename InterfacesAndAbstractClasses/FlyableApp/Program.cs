using System;

public struct Coordinate
{
    public double X;
    public double Y;
    public double Z;
}

public interface IFlyable
{
    void FlyTo(Coordinate newPoint);
    TimeSpan GetFlyTime(Coordinate newPoint);
}

public class Bird : IFlyable
{
    public Coordinate CurrentPosition { get; set; }

    public void FlyTo(Coordinate newPoint)
    {
        Console.WriteLine("Птица летит в новую точку.");
        CurrentPosition = newPoint;
    }

    public TimeSpan GetFlyTime(Coordinate newPoint)
    {
        Console.WriteLine("Расчет времени полета птицы.");
        return TimeSpan.Zero;
    }
}

public class Airplane : IFlyable
{
    public Coordinate CurrentPosition { get; set; }
    private double currentSpeed = 200; // Начальная скорость в км/ч

    public void FlyTo(Coordinate newPoint)
    {
        Console.WriteLine("Самолет летит в новую точку.");
        CurrentPosition = newPoint;

        if (CalculateDistance(CurrentPosition, newPoint) % 10 == 0)
        {
            currentSpeed += 10;
        }
    }

    public TimeSpan GetFlyTime(Coordinate newPoint)
    {
        Console.WriteLine("Расчет времени полета самолета.");
        return TimeSpan.Zero;
    }

    private double CalculateDistance(Coordinate point1, Coordinate point2)
    {
        // Логика расчета расстояния между двумя точками
        return 0;
    }
}

public class Drone : IFlyable
{
    public Coordinate CurrentPosition { get; set; }
    private int flightTime = 0; // Время полета в минутах

    public void FlyTo(Coordinate newPoint)
    {
        Console.WriteLine("Дрон летит в новую точку.");

        double distance = CalculateDistance(CurrentPosition, newPoint);
        if (distance > 1000)
        {
            throw new Exception("Дрон не может лететь на такую дальность.");
        }

        CurrentPosition = newPoint;

        if (flightTime % 10 == 0)
        {
            // Добавить логику зависания в воздухе на 1 минуту
        }

        flightTime++;
    }

    public TimeSpan GetFlyTime(Coordinate newPoint)
    {
        Console.WriteLine("Расчет времени полета дрона.");
        return TimeSpan.Zero;
    }

    private double CalculateDistance(Coordinate point1, Coordinate point2)
    {
        // Логика расчета расстояния между двумя точками
        return 0;
    }
}

class FleetManagementSystem
{
    static void Main(string[] args)
    {
        Coordinate initialPosition = new Coordinate { X = 0, Y = 0, Z = 0 };

        Bird bird = new Bird();
        bird.FlyTo(initialPosition);

        Airplane airplane = new Airplane();
        airplane.FlyTo(initialPosition);

        Drone drone = new Drone();
        drone.FlyTo(initialPosition);
    }
}