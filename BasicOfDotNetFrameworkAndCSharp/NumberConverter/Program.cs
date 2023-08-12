using System;

class NumberConverter
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("You need to provide the number and the base of the new numeral system in the command line arguments");
            return;
        }

        int number;
        if (!int.TryParse(args[0], out number))
        {
            Console.WriteLine("Invalid number format");
            return;
        }

        int baseNumber;
        if (!int.TryParse(args[1], out baseNumber) || baseNumber < 2 || baseNumber > 20)
        {
            Console.WriteLine("The base of the numeral system should be an integer from 2 to 20");
            return;
        }

        string convertedNumber = ConvertToBase(number, baseNumber);
        Console.WriteLine("Converted number:" + convertedNumber);
    }

    static string ConvertToBase(int number, int baseNumber)
    {
        string digits = "0123456789ABCDEFGHIJ"; // Цифры новой системы счисления до основания 20

        string result = string.Empty;
        while (number > 0)
        {
            int remainder = number % baseNumber;
            result = digits[remainder] + result;
            number /= baseNumber;
        }

        return result;
    }
}