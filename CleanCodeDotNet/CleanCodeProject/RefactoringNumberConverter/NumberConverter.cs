using System;

namespace NumberConverterApp
{
    class NumberConverter
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 || string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine("You need to provide a non-empty number and base of the new numeral system in the command line arguments");
                return;
            }

            if (!int.TryParse(args[0], out int number))
            {
                Console.WriteLine("Invalid number format");
                return;
            }

            if (!int.TryParse(args[1], out int baseNumber) || baseNumber < 2 || baseNumber > 20)
            {
                Console.WriteLine("The base of the numeral system should be an integer from 2 to 20");
                return;
            }

            try
            {
                string convertedNumber = ConvertToBase(number, baseNumber);
                Console.WriteLine("Converted number:" + convertedNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Метод для конвертации числа в новую систему счисления
        static string ConvertToBase(int number, int baseNumber)
        {
            // Проверяем, находится ли базовое число в допустимом диапазоне
            if (baseNumber < 2 || baseNumber > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(baseNumber), "Основание системы счисления должно быть целым числом от 2 до 20");
            }

            const string digits = "0123456789ABCDEFGHIJ"; // Цифры новой системы счисления до основания 20
            const int maxDigits = 7; // Максимальное количество цифр в числе

            char[] result = new char[maxDigits]; // Массив для хранения цифр результата
            int digitIndex = maxDigits - 1; // Начинаем с правой цифры

            do
            {
                // Вычисляем остаток и присваиваем соответствующую цифру в массив результатов
                result[--digitIndex] = digits[number % baseNumber];
                number /= baseNumber;
            } while (number > 0);

            // Создаем новую строку, используя соответствующую часть массива результата
            return new string(result, digitIndex + 1, maxDigits - digitIndex - 1);
        }
    }
}