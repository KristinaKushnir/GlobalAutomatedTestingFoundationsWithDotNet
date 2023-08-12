using System;

namespace LongestUniqueSubsequenceFinderApp
{
    class LongestUniqueSubsequenceFinder
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please provide a non-empty sequence of characters in the command line arguments");
                return;
            }

            string sequence = args[0];

            try
            {
                string longestSubsequence = FindLongestSubsequence(sequence);
                int totalCount = longestSubsequence.Length;
                Console.WriteLine("Maximum unequal consecutive characters per line number: " + totalCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Метод для поиска самой длинной подпоследовательности без повторяющихся символов
        static string FindLongestSubsequence(string sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), "Input sequence cannot be null");
            }

            string longestSubsequence = "";
            string currentSubsequence = "";

            foreach (char c in sequence)
            {
                if (currentSubsequence.Contains(c))
                {
                    if (currentSubsequence.Length > longestSubsequence.Length)
                    {
                        longestSubsequence = currentSubsequence;
                    }

                    currentSubsequence = "";
                }

                currentSubsequence += c; //Добавление символа повторяющего символа в новую подпоследовательность после сброса старой и записи последней в переменную 'longestSubsequence'
            }

            if (currentSubsequence.Length > longestSubsequence.Length) //Проверка последней подпоследовательности
            {
                longestSubsequence = currentSubsequence;
            }

            return longestSubsequence;
        }
    }
}