using System;

class LongestUniqueSubsequenceFinder
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide a sequence of characters in the command line arguments");
            return;
        }

        string sequence = args[0];
        string longestSubsequence = FindLongestSubsequence(sequence);
        int totalCount = longestSubsequence.Length;
        Console.WriteLine("Maximum unequal consecutive characters per line number: " + totalCount);
    }

    static string FindLongestSubsequence(string sequence)
    {
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
            //добавление символа повторяющего символа в новую подпоследовательность после сброса старой и записи последней в переменную 'longestSubsequence'
            currentSubsequence += c;
        }
        //проверка последней подпоследовательности
        if (currentSubsequence.Length > longestSubsequence.Length)
        {
            longestSubsequence = currentSubsequence;
        }

        return longestSubsequence;
    }
}