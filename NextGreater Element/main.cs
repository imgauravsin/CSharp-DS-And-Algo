using System;
using System.Collections.Generic;
 
class Program
{
 
 static void NextGreaterElement(int[] num)
 {
 Stack<int> s = new Stack<int>();
 
 int[] ans = new int[num.Length];
 
 for (int i = num.Length - 1; i >= 0; i--)
 {
 while (s.Count != 0 && s.Peek() <= num[i])
 s.Pop();
 if (s.Count == 0)
 ans[i] = -1;
 else
 ans[i] = s.Peek();
 
 s.Push(num[i]);
 }
 
 for (int i = 0; i < num.Length; i++)
 Console.WriteLine(num[i] + "," +ans[i]);
 }
 
 static void Main(string[] args)
 {
 int t = int.Parse(Console.ReadLine());
 
 while (t != 0)
 {
 int n = int.Parse(Console.ReadLine());
 string[] input = Console.ReadLine().Split(' ');
 int[] arr = new int[n];
 for (int i = 0; i < n; i++)
 {
 
 arr[i] = int.Parse(input[i]);
 
 }
 NextGreaterElement(arr);
 t--;
 }
 
 Console.ReadLine();
 }
}
