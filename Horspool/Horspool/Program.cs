using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorspoolAlgorithm
{
    class Program
    {
        static int MAX = 500;
        static int[] table = new int[MAX];
        //static Dictionary<char, int> table = new Dictionary<char, int>();

        static void ShiftTable(char[] pattern)
        {
            int i, j, m;
            m = pattern.Length;
            for (i = 0; i < MAX; i++)
            {
                table[i] = m;
            }
            for (j = 0; j < m - 1; j++)
            {
                table[pattern[j]] = m - 1 - j;
            }
        }

        /// <summary>
        /// Returns the position which the pattern p occurs in the
        /// text src
        /// </summary>
        static int Horspool(char[] text, char[] pattern)
        {
            // Create the shift table from the pattern
            int m = pattern.Length;
            int n = text.Length;
            int i = m - 1;
            while (i <= n - 1)
            {
                int k = 0;
                while (k <= m - 1 && pattern[m - 1 - k] == text[i - k])
                {
                    k = k + 1; // Keep moving to the left
                }
                if (k == m) // Found the match
                {
                    return i - m + 1;
                } 
                else // Shift
                {
                    i += table[text[i]];
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int pos;

            Console.Clear();
            Console.Write("Enter the text in which pattern is to be searched: ");
            char[] src = Console.ReadLine().ToCharArray();
            Console.Write("Enter the pattern to be searched: ");
            char[] p = Console.ReadLine().ToCharArray();

            ShiftTable(p);
            pos = Horspool(src, p);
            if (pos >= 0)
                Console.Write("\n The desired pattern was found starting from position {0}", pos + 1);
            else
                Console.Write("\n The pattern was not found in the given text\n");
            Console.ReadKey();
        }
    }
}
