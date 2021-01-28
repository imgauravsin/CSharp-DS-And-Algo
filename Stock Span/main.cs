using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSpan
{
    class Program
    {
        static void calculateSpan(int[] price)
        {
            // Create a stack and Push 
            // index of first element to it 
            int n = price.Length;
            int[] S = new int[n];
            Stack<int> st = new Stack<int>();
            st.Push(0);

            // Span value of first 
            // element is always 1 
            S[0] = 1;

            // Calculate span values 
            // for rest of the elements 
            for (int i = 1; i < n; i++)
            {

                // Pop elements from stack 
                // while stack is not empty 
                // and top of stack is smaller 
                // than price[i] 
                while (st.Count > 0 && price[(int)st.Peek()] <= price[i])
                    st.Pop();

                // If stack becomes empty, then price[i] is 
                // greater than all elements on left of it, i.e., 
                // price[0], price[1], ..price[i-1]. Else price[i] 
                // is greater than elements after top of stack 
                S[i] = (st.Count == 0) ? (i + 1) : (i - (int)st.Peek());

                // Push this element to stack 
                st.Push(i);
            }
            string ans = "";
            for(int i = 0; i < S.Length; i++)
            {
                ans+=(S[i])+" ";
            }
            ans += "END";
            Console.WriteLine(ans);
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }
            calculateSpan(arr);
            Console.ReadLine();
        }
    }
}
