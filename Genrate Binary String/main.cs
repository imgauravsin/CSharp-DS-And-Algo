using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryGen
{
    class Program
    {
        public static void WildBinaryGenration(char[] InputArray, int index)
        {
            if (index == InputArray.Length)//TBase  Condition :raverse the all the string 
            {
                Console.Write(InputArray);//Print the arrray
                Console.Write(" ");
                return;
            }
            if (InputArray[index] == '?')//if the urrent character of string is ? replace ? -> 0 and 1
            {
                InputArray[index] = '0'; //store the character as 0
                WildBinaryGenration(InputArray, index + 1);//Recursive Call for next Index
                InputArray[index] = '1';//store the character as 1
                WildBinaryGenration(InputArray, index + 1);//Recursive Call for next Index
                InputArray[index] = '?';//backtarck the condition

            }
            else
            {//if the current index is not wild character (?)
                WildBinaryGenration(InputArray, index + 1);
            }
        }
        public static void Main(String[] args)
        {
            int Test = Int32.Parse(Console.ReadLine()); //Test Value
            for (int i = 0; i < Test; i++)
            {
                string inputString = Console.ReadLine(); //Input String
                char[] input = inputString.ToCharArray();//change string to character array
                WildBinaryGenration(input, 0);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    
     
    }
}
