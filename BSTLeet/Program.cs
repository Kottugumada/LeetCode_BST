using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTLeet
{
    class BSTLeet
    {
        static void Main(string[] args)
        {
            TreeNode t = new TreeNode(3);
            t.left = new TreeNode(9);
            t.right = new TreeNode(20);
            t.right.left = new TreeNode(15);
            t.right.right = new TreeNode(7);
            AverageOfLevels(t);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x)
            {
                val = x;
            }
        }

        /// <summary>
        /// Merge Trees Recursive 
        /// https://leetcode.com/problems/merge-two-binary-trees/description/
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TreeNode MergeTreesRecurcive(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }
            TreeNode mergedTreeNode = new TreeNode(t1.val + t2.val);
            mergedTreeNode.left = MergeTreesRecurcive(t1.left, t2.left);
            mergedTreeNode.right = MergeTreesRecurcive(t1.right, t2.right);
            return mergedTreeNode;
        }
        /// <summary>
        /// Merge Trees Iterative 
        /// https://leetcode.com/problems/merge-two-binary-trees/description/
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TreeNode MergeTreesIterative(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }
            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });
            while (stack.Count != 0)
            {
                TreeNode[] t = stack.Pop();
                if (t[0] == null || t[1] == null)
                {
                    continue;
                }
                t[0].val = t[0].val + t[1].val;
                if (t[0].left == null)
                {
                    t[0].left = t[1].left;
                }
                else
                {
                    stack.Push(new TreeNode[] { t[0].left, t[1].left });
                }
                if (t[0].right == null)
                {
                    t[0].right = t[1].right;
                }
                else
                {
                    stack.Push(new TreeNode[] { t[0].right, t[1].right });
                }
            }
            return t1;
        }
        /// <summary>
        /// Average of Levels
        /// https://leetcode.com/problems/average-of-levels-in-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> res = new List<double>();
            double sum;
            int nodeN = 0;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            while (que.Count != 0)
            {
                nodeN = que.Count;
                sum = 0.0;
                for (int i = 0; i < nodeN; i++)
                {
                    TreeNode temp = que.Dequeue();
                    sum = sum + temp.val;
                    if (temp.left != null) que.Enqueue(temp.left);
                    if (temp.right != null) que.Enqueue(temp.right);
                }
                res.Add(sum / nodeN);
            }
            return res;
        }
        /// <summary>
        /// Level Order Traveral BFS Iterative
        /// https://leetcode.com/problems/binary-tree-level-order-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> LevelOrder_BFS_Iterative(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
            {
                return res;
            }
            Queue<TreeNode> que = new Queue<TreeNode>();
            int nodeN = 0;
            que.Enqueue(root);
            while (que.Count != 0)
            {
                nodeN = que.Count;
                List<int> currentLevel = new List<int>();
                for (int i = 0; i < nodeN; i++)
                {
                    TreeNode temp = que.Dequeue();
                    currentLevel.Add(temp.val);
                    if (temp.left != null) que.Enqueue(temp.left);
                    if (temp.right != null) que.Enqueue(temp.right);
                }
                res.Add(currentLevel);
            }
            return res;
        }
        /// <summary>
        /// Level Order Traveral DFS Recursive
        /// https://leetcode.com/problems/binary-tree-level-order-traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> LevelOrder_DFS_Recursive(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            LevelOrder(root, 0, res);
            return res;
        }

        static void LevelOrder(TreeNode root, int depth, IList<IList<int>> list)
        {
            if (root == null) return;
            while (list.Count < depth + 1)
            {
                list.Add(new List<int>());
            }
            list[depth].Add(root.val);
            LevelOrder(root.left, depth + 1, list);
            LevelOrder(root.right, depth + 1, list);
        }
        /// <summary>
        /// Invert a BST or Flip a BST Recursive
        /// https://leetcode.com/problems/invert-binary-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree_Recursive(TreeNode root)
        {
            if (root == null) return null;
            TreeNode left = InvertTree_Recursive(root.left);
            TreeNode right = InvertTree_Recursive(root.right);
            root.right = left;
            root.left = right;
            return root;
        }
        /// <summary>
        /// Invert a BST or Flip a BST Iterative
        /// https://leetcode.com/problems/invert-binary-tree/description/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode InvertTree_Iterative(TreeNode root)
        {
            if (root == null) return null;
            TreeNode temp = root.left;
            root.left = InvertTree_Iterative(root.right);
            root.right = InvertTree_Iterative(temp);
            return root;
        }
        /// <summary>
        /// Sorted Array to BST
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null) return null;
           return SortedArrayToBST(nums,0,nums.Length -1);
        }
        static internal TreeNode SortedArrayToBST(int[] nums, int start,int end)    
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = SortedArrayToBST(nums,start,mid-1);
            root.right = SortedArrayToBST(nums,mid+1,end);
            return root;
        }
    }
}
