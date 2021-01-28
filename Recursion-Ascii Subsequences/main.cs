using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIISUB
{
    class Program
    {
        static void FindSub(string str, string res,int i)
        {

            // Base Case
            if (i == str.Length)
            {

                // If length of the
                // subsequence exceeds 0
                if (res.Length > 0)
                {

                    // Print the subsequence
                    Console.Write(res + " ");
                }
                return;
            }

            // Stores character present at
            // i-th index of str
            char ch = str[i];

            // If the i-th character is not
            // included in the subsequence
            FindSub(str, res, i + 1);

            // Including the i-th characer
            // in the subsequence
            FindSub(str, res + ch, i + 1);

            // Include the ASCII value of the
            // ith character in the subsequence
            FindSub(str, res + (int)ch, i + 1);
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine("Enter the string");
            FindSub(input,"",0);
            Console.ReadLine();
        }
    }
}
