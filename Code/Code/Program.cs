using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceStringMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "SPEED";
            string text = "THERE_IS_MORE_TO_LIFE_THAN_INCREASING_ITS_SPEED";

            Console.Clear();
            int result = BruteForceStringMatch(text, pattern);
            if (result != -1)
            {
                Console.WriteLine("The number of comparisons made is " + result);
            }
            else
            {
                Console.WriteLine("The algorithm failed in doing the comparisons");
            }

            Console.ReadKey();
        }

        static int BruteForceStringMatch
            (string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;
            for (int i = 0; i <= n - m; i++)
            {
                int j;
                for (j = 0; j < m && pattern[j] == text[i + j]; j++) { }
                if (j == m) return i;
            }
            return -1;
        }
    }
}
