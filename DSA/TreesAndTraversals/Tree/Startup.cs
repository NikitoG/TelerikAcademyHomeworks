namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static Stack<int> postOrderTraverse = new Stack<int>();
        private static List<int> subTree = new List<int>();

        public static void Main()
        {
            Console.Write("Enter number of nodes: ");
            var n = int.Parse(Console.ReadLine());

            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i < n; i++)
            {
                var edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                var parent = int.Parse(edgeParts[0]);
                var child = int.Parse(edgeParts[1]);

                nodes[parent].Children.Add(nodes[child]);
                nodes[child].HasParent = true;
            }

            // Problem 1. The root Node
            var root = FindRoot(nodes);
            Console.WriteLine("Root: {0}", root.Value);

            // Problem 2. All Leaf nodes
            var leafs = FindLeafs(nodes).Select(l => l.Value);
            Console.WriteLine("Leafs: {0}", string.Join(", ", leafs));

            // Problem 3. All middle nodes
            var allMiddleNodes = FindAllMiddleNodes(nodes).Select(m => m.Value);
            Console.WriteLine("All middles nodes: {0}", string.Join(", ", allMiddleNodes));

            // Problem 4. The longest Path in tree
            var longestPath = FindLongestPath(root);
            Console.WriteLine("Longest path: {0}", longestPath);

            // Problem 5.(*) all paths in the tree with given sum `S` of their nodes
            var givenSum = 6;
            foreach (var node in nodes)
            {
                GetAllPathWithGivenSum(node, givenSum);
            }

            // Problem 6.(*) all subtrees with given sum `S` of their nodes
            var sum = 6;
            foreach (var node in nodes)
            {
                subTree.Clear();
                GetAllSubTreeWithGivenSum(node);
                var subTreeSum = subTree.Sum();

                if (subTreeSum == sum)
                {
                    Console.WriteLine("Subtree with sum {0}: {1}", sum, string.Join(", ", subTree));
                }
            }
        }

        private static void GetAllSubTreeWithGivenSum(Node<int> node)
        {
            subTree.Add(node.Value);

            foreach (var child in node.Children)
            {
                GetAllSubTreeWithGivenSum(child);
            }
        }

        private static void GetAllPathWithGivenSum(Node<int> node, int givenSum)
        {
            postOrderTraverse.Push(node.Value);
            var sum = postOrderTraverse.Sum();
            if (sum == givenSum)
            {
                Console.WriteLine("Path with sum {0}: {1}", givenSum, string.Join(", ", postOrderTraverse));
            }

            foreach (var item in node.Children)
            {
                GetAllPathWithGivenSum(item, givenSum);
            }

            postOrderTraverse.Pop();
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count != 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root.");
        }
    }
}