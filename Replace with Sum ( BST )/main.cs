using System;
using System.Collections.Generic;
 
 class MainClass
 {
 public static void Main()
 {
 int N = int.Parse(Console.ReadLine());
 int[] data = new int[N];
 for (int i = 0; i < N; i++)
 {
 data[i] = int.Parse(Console.ReadLine());
 }
 BST b = new BST();
 b.CreateBST(data);
 b.GreatestSumBST();
 b.PreOrderDisplay();
 }
 }
 
 class BST
 {
 Node root;
 
 
 public void PreOrderDisplay()
 {
 PreOrderDisplay(root);
 }
 private void PreOrderDisplay(Node root)
 {
 if (root == null)
 {
 return;
 }
 string output = "";
 if (root.Left == null)
 {
 output += "END => ";
 }
 else if (root.Left != null)
 {
 output += root.Left.Data + " => ";
 }
 
 output += root.Data;
 
 if (root.Right == null)
 {
 output += " <= END";
 }
 else if (root.Right != null)
 {
 output += " <= " + root.Right.Data;
 }
 Console.WriteLine(output);
 PreOrderDisplay(root.Left);
 PreOrderDisplay(root.Right);
 }
 
 public void GreatestSumBST()
 {
 int sum = 0;
 GreatestSumBST(root, ref sum);
 }
 
 private void GreatestSumBST(Node root, ref int sum)
 {
 if (root == null)
 {
 return;
 }
 GreatestSumBST(root.Right, ref sum);
 
 sum += root.Data;
 root.Data = sum - root.Data;
 
 GreatestSumBST(root.Left, ref sum);
 }
 
 public void CreateBST(int[] data)
 {
 root = new Node(data[0]);
 for (int i = 1; i < data.Length; i++)
 {
 Node curr = root, parent = null;
 while (curr != null)
 {
 parent = curr;
 if (data[i] <= curr.Data)
 {
 curr = curr.Left;
 }
 else
 {
 curr = curr.Right;
 }
 }
 if (data[i] <= parent.Data)
 {
 parent.Left = new Node(data[i]);
 }
 else
 {
 parent.Right = new Node(data[i]);
 }
 }
 //DisplayBST();
 }
 
 public void DisplayBST()
 {
 //Level order traversal...
 Queue<Node> nodes = new Queue<Node>();
 nodes.Enqueue(root);
 while (nodes.Count > 0)
 {
 nodes.Enqueue(null);
 List<int> level = new List<int>();
 while (true)
 {
 var front = nodes.Dequeue();
 if (front == null)
 {
 break;
 }
 level.Add(front.Data);
 if (front.Left != null)
 {
 nodes.Enqueue(front.Left);
 }
 if (front.Right != null)
 {
 nodes.Enqueue(front.Right);
 }
 }
 foreach (int val in level)
 {
 Console.Write(val + " ");
 }
 Console.WriteLine();
 }
 }
 class Node
 {
 int data;
 Node left, right;
 
 public int Data
 {
 set { this.data = value; }
 get { return data; }
 }
 public Node Left
 {
 set { left = value; }
 get { return left; }
 }
 public Node Right
 {
 set { right = value; }
 get { return right; }
 }
 
 public Node(int data)
 {
 this.data = data;
 left = null;
 right = null;
 }
 }
 }
