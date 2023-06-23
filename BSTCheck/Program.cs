namespace BSTCheck
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        private TreeNode prev = null;

        public bool IsValidBST(TreeNode root)
        {
            // Inorder traversal
            if (root != null)
            {
                if (!IsValidBST(root.left))
                {
                    return false;
                }

                if (prev != null && root.val <= prev.val)
                {
                    return false;
                }

                prev = root;
                return IsValidBST(root.right);
            }

            return true;
        }

        public void PrintTree(TreeNode node, string indent = "")
        {
            if (node != null)
            {
                Console.WriteLine(indent + node.val);
                indent += "  ";  // increase the indent as we go deeper
                PrintTree(node.left, indent);
                PrintTree(node.right, indent);
            }
        }

    }

    internal class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();
            TreeNode node = new TreeNode(2);
            node.left = new TreeNode(1);
            node.right = new TreeNode(3);
            bool result = solution.IsValidBST(node);
            Console.WriteLine(result);  // It should print: True

            solution.PrintTree(node);   // This will print the tree
        }
    }
}