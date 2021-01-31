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
        public static bool solver(Node root1,Node root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;
            if (root1.data != root2.data) return false;
            return solver(root1.left, root1.left) && solver(root2.right, root2.right);


        }
        public static void Main(string[] args)
        {
            BinaryTree bt1 = new BinaryTree();
            BinaryTree bt2 = new BinaryTree();
            string[] str1 = Console.ReadLine().Split(' ');
            string[] str2 = Console.ReadLine().Split(' ');
            bt1.CreateBinaryTree(str1);
            bt2.CreateBinaryTree(str2);
            //bt.display();
            if (solver(bt1.root, bt2.root) == true)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            Console.ReadLine();
        }
    }
}
