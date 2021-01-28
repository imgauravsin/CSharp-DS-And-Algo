using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importantOfTime
{
    class Program
    {
        public static int solver(int[] calling,int[] exe,int n)
        {
            int count = 0;
            //Stack<int> s = new Stack<int>();
            Queue<int> q = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                q.Enqueue(calling[i]);
            }
            for(int i = 0; i < n; i++)
            {
                while (true)
                {
                    int top = q.Dequeue();
                    if (top == exe[i])
                    {
                        count += 1;
                        break;
                    }
                    else
                    {
                        count += 1;
                        q.Enqueue(top);
                    }

                }
                 

            }
            return count; ;


        } 
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] str1 = Console.ReadLine().Split(' ');
            string[] str2 = Console.ReadLine().Split(' ');
            int[] calling = new int[n];
            int[] exe = new int[n];
            for(int i = 0; i < n; i++)
            {
                calling[i] = int.Parse(str1[i]);
                exe[i] = int.Parse(str2[i]);
            }
            Console.WriteLine(solver(calling,exe,n));
            Console.ReadLine();

        }
    }
}
