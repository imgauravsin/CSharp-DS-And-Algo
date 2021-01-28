using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
    class Program
    {

        static void Main(string[] args)
        {
            int query = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < query; i++)
            {
                string[] str = (Console.ReadLine()).Split(' ');
                int m = str.Length;
                if (m == 1)
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Pop());
                    }
                    else
                    {
                        Console.WriteLine("No Code");
                    }

                }
                else if(m==2)
                {
                    stack.Push(int.Parse(str[1]));
                }
            }
            Console.ReadLine();
        }
    }
}
