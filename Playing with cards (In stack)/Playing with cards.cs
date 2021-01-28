using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playingwithcards
{
    public class PlayingWithCards
    {
        public static void Main(String[] args)
        {
            string[] temp = Console.ReadLine().Split(' ');
            int n = Int32.Parse(temp[0]);
            int q = Int32.Parse(temp[1]);
            List<Stack<int>> A = new List<Stack<int>>();
            for (int i = 0; i <= q; i++)
            {
                A.Add(new Stack<int>());
            }
            List<Stack<int>> B = new List<Stack<int>>();
            for (int i = 0; i <= q; i++)
            {
                B.Add(new Stack<int>());
            }
            string[] temp1 = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                int data = Int32.Parse(temp1[i]);
                A.ElementAt(0).Push(data);
            }
            for (int i = 1; i <= q; i++)
            {
                Stack<int> ps = A.ElementAt(i - 1);
                while (!(ps.Count() == 0))
                {
                    int val = ps.Pop();
                    if (val % ithPrime(i) == 0)
                    {
                        B.ElementAt(i).Push(val);
                    }
                    else
                    {
                        A.ElementAt(i).Push(val);
                    }
                }
            }
            for (int i = 1; i <= q; i++)
            {
                Stack<int> ps = B.ElementAt(i);
                while (!(ps.Count() == 0))
                {
                    Console.WriteLine(ps.Pop());
                }
            } while (!(A.ElementAt(q).Count()==0))
            {
                Console.WriteLine(A.ElementAt(q).Pop());
            }
        }
        public static int ithPrime(int i)
        {
            int count = 0; int n = 2;
            while (true)
            {
                if (isPrime(n))
                {
                    count++;
                }
                if (count == i)
                {
                    return n;
                }
                n++;
            }
        }
        public static bool isPrime(int n)
        {
            for (int div = 2;
                div <= Math.Sqrt(n); div++)
            {
                if (n % div == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
