using System;
using System.Collections.Generic;

namespace BTDS
{
    public class BinaryTree
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

        public void display(int target)
        {
             solver(root,target,"");
        }



        private void solver(Node root,int target,string ans) // 1k
        {
            if (root == null)
            {
                 
                return;
            }
            ans += root.data + " ";
            if (root.left==null && root.right==null && target-root.data==0)
            {
                Console.WriteLine(ans);
                return;

            }
            solver(root.left,target-root.data,ans);
            solver(root.right, target-root.data, ans);



        }


    }

    public class Client
    {
        public static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            string[] str = Console.ReadLine().Split(' ');

            bt.CreateBinaryTree(str);
            int target = int.Parse(Console.ReadLine());
            bt.display(target);
            Console.ReadLine();
        }
    }
}

