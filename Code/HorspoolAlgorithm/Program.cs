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
        static int[] shiftTable = new int[MAX];

        static void ShiftTable(char[] pattern)
        {
            int i, j, m;
            m = pattern.Length;
            for (i = 0; i < MAX; i++)
            {
                shiftTable[i] = m;
            }
            for (j = 0; j < m - 1; j++)
            {
                shiftTable[pattern[j]] = m - 1 - j;
            }
        }

        static int Horspool(char[] text, char[] pattern)
        {
            int m = pattern.Length;
            int n = text.Length;
            Console.WriteLine("Length of text = {0}", n);
            Console.Write("Length of pattern = {0}", m);
            for (int i = m - 1; i <= n - 1; i += shiftTable[text[i]])
            {
                int k;
                for (k = 0; k <= m - 1 && pattern[m - 1 - k] == text[i - k]; k++) { }
                if (k == m) return i - m + 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            char[] text = new char[100];
            char[] pattern = new char[100];
            int position;

            Console.Clear();
            Console.Write("Enter the text in which pattern is to be searched: ");
            text = Console.ReadLine().ToCharArray();
            Console.Write("Enter the pattern to be searched: ");
            pattern = Console.ReadLine().ToCharArray();

            ShiftTable(pattern);
            position = Horspool(text, pattern);
            if (position >= 0)
                Console.Write("\n The desired pattern was found starting from position {0}", position + 1);
            else
                Console.Write("\n The pattern was not found in the given text\n");
            Console.ReadKey();
        }
    }
}
