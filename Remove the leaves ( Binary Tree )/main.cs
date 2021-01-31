using System;
using System.Collections.Generic;

namespace BTDS
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
    public class BinaryTree
    {


        public Node root;

        public void CreateBinaryTree(string[] input)
        {
            Stack<KeyValuePair<Node, bool>> nodeAddress = new Stack<KeyValuePair<Node, bool>>();

            root = new Node(int.Parse(input[0]));
            nodeAddress.Push(new KeyValuePair<Node, bool>(root, false));
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == "true")
                {
                    if (nodeAddress.Peek().Value == false)
                    {
                        Node temp = new Node(int.Parse(input[i + 1]));
                        var top = nodeAddress.Pop();
                        top.Key.left = temp;
                        nodeAddress.Push(new KeyValuePair<Node, bool>(top.Key, true));
                        nodeAddress.Push(new KeyValuePair<Node, bool>(temp, false));
                        i++;
                    }
                    else
                    {
                        Node temp = new Node(int.Parse(input[i + 1]));
                        var top = nodeAddress.Pop();
                        top.Key.right = temp;
                        nodeAddress.Push(new KeyValuePair<Node, bool>(temp, false));
                        i++;
                    }
                }
                else
                {
                    if (nodeAddress.Peek().Value == false)
                    {
                        var top = nodeAddress.Pop();
                        nodeAddress.Push(new KeyValuePair<Node, bool>(top.Key, true));
                    }
                    else
                    {
                        nodeAddress.Pop();
                    }
                }
            }
        }




    }

    public class Client
    {
        
        public static Node solver(Node root)
        {
            if (root == null) return null;

            if (root.left == null && root.right == null) return null;
            root .left = solver(root.left);
            root.right = solver(root.right);
            return root;

            
        }
        public static void display(Node node) // 1k
        {
            if (node == null)
                return;

            string str = "";

            if (node.left == null)
                str += "END";
            else
                str += node.left.data; // 1k.left.data -> 2k->data -> 20

            str += " => " + node.data + " <= "; // 1k.data -> 10

            if (node.right == null)
                str += "END";
            else
                str += node.right.data;

            Console.WriteLine(str);

            display(node.left); // 2k
            display(node.right); // 3k
        }
        public static void Main(string[] args)
        {
            BinaryTree bt1 = new BinaryTree();

            string[] str1 = Console.ReadLine().Split(' ');

            bt1.CreateBinaryTree(str1);

            solver(bt1.root);
            display(bt1.root);
             

            Console.ReadLine();
        }
    }
}
