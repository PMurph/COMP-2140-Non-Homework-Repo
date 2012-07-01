using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinarySearchTree
    {
        private BinaryNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public bool hasValue(int value)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                return hasValueRec(root, value);
            }
        }

        public int getHeight()
        {
            return getHeightRec(root);
        }

        public void add(int data)
        {
            BinaryNode toAdd = new BinaryNode(data);

            if (root == null)
            {
                root = toAdd;
            }else{
                addRec(root, toAdd);
            }
        }

        public void deleteValue(int value)
        {
            deleteValueRec(null, root, value);
        }

        public void preorderTraversal()
        {
            preOrderTraversalRec(root);
            Console.Out.WriteLine();
        }

        public void inOrderTraversal()
        {
            inOrderTraversalRec(root);
            Console.Out.WriteLine();
        }

        public void postOrderTraversal()
        {
            postOrderTraversalRec(root);
            Console.Out.WriteLine();
        }

        //======Private Methods======

        private void deleteValueRec(BinaryNode prevNode, BinaryNode subTree, int value)
        {
            BinaryNode nextNode = null;
            if (subTree != null)
            {
                if (subTree.getData() == value)
                {
                    deleteNode(prevNode, subTree, value);
                }
                else if (subTree.getData() > value)
                {
                    nextNode = subTree.getLeft();

                    deleteValueRec(subTree, nextNode, value);
                }
                else
                {
                    nextNode = subTree.getRight();

                    deleteValueRec(subTree, nextNode, value);
                }
            }
        }

        private void deleteNode(BinaryNode prev, BinaryNode curr, int value)
        {
            BinaryNode temp = null;
            if (prev == null)
            {
                if (root.getLeft() == null && curr.getRight() == null)
                {
                    root = null;
                }
                else if (root.getLeft() != null && curr.getRight() == null)
                {
                    root = root.getLeft();
                }
                else if (root.getLeft() == null && curr.getRight() != null)
                {
                    root = root.getRight();
                }
                else
                {
                    temp = root;
                    root = getNDelNextInOrderNode(null, root);
                    root.setLeft(temp.getLeft());
                    root.setRight(temp.getRight());
                }
            }
            else
            {
                if (curr.getLeft() != null && curr.getRight() == null)
                {
                    if (prev.getData() > value)
                    {
                        prev.setLeft(curr.getLeft());
                    }
                    else
                    {
                        prev.setRight(curr.getRight());
                    }
                }
                else if (curr.getLeft() == null && curr.getRight() != null)
                {
                    if (prev.getData() > value)
                    {
                        prev.setLeft(curr.getRight());
                    }
                    else
                    {
                        prev.setRight(curr.getRight());
                    }
                }
                else
                {
                    if (prev.getData() > value)
                    {
                        temp = curr;
                        prev.setLeft(getNDelNextInOrderNode(prev, curr));
                        prev.getLeft().setLeft(curr.getLeft());
                        prev.getLeft().setRight(curr.getRight());
                    }
                    else
                    {
                        temp = curr;
                        prev.setRight(getNDelNextInOrderNode(prev, curr));
                        prev.getRight().setLeft(curr.getLeft());
                        prev.getRight().setRight(curr.getRight());
                    }
                }
            }
        }

        private BinaryNode getNDelNextInOrderNode(BinaryNode prev, BinaryNode currNode)
        {
            BinaryNode prevNode = currNode;
            BinaryNode toReturn = currNode.getRight();
            bool executed = false;

            while (toReturn.getLeft() != null)
            {
                prevNode = toReturn;
                toReturn = toReturn.getLeft();
                executed = true;
            }

            if (executed == true)
            {
                prevNode.setLeft(null);
            }
            else
            {
                prevNode.setRight(null);
            }

            return toReturn;
        }

        private void postOrderTraversalRec(BinaryNode subTree)
        {
            if (subTree != null)
            {
                postOrderTraversalRec(subTree.getLeft());
                postOrderTraversalRec(subTree.getRight());
                Console.Out.Write(subTree.getData());
                Console.Out.Write(" ");
            }
        }

        private void inOrderTraversalRec(BinaryNode subTree)
        {
            if (subTree != null)
            {
                inOrderTraversalRec(subTree.getLeft());
                Console.Out.Write(subTree.getData());
                Console.Out.Write(" ");
                inOrderTraversalRec(subTree.getRight());
            }
        }

        private void preOrderTraversalRec(BinaryNode subTree)
        {
            if (subTree != null)
            {
                Console.Out.Write(subTree.getData());
                Console.Out.Write(" ");
                preOrderTraversalRec(subTree.getLeft());
                preOrderTraversalRec(subTree.getRight());
            }
        }

        private int getHeightRec(BinaryNode subTree)
        {
            if (subTree == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(getHeightRec(subTree.getLeft()), getHeightRec(subTree.getRight())) + 1;
            }
        }

        private bool hasValueRec(BinaryNode subTree, int value)
        {
            if (subTree == null)
            {
                return false;
            }
            else if (subTree.getData() == value)
            {
                return true;
            }
            else if (subTree.getData() > value)
            {
                return hasValueRec(subTree.getLeft(), value);
            }
            else
            {
                return hasValueRec(subTree.getRight(), value);
            }
        }

        private void addRec(BinaryNode subTree, BinaryNode toAdd){
            
            if (subTree.getData() > toAdd.getData())
            {
                if(subTree.getLeft() == null){
                    subTree.setLeft(toAdd);
                }else{
                    addRec(subTree.getLeft(), toAdd);
                }
            }else{
                if(subTree.getRight() == null){
                    subTree.setRight(toAdd);
                }else{
                    addRec(subTree.getRight(), toAdd);
                }
            }
        }

        //===============Main Method================
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();

            bst.add(5);
            bst.add(3);
            bst.add(4);
            bst.add(3);
            bst.add(6);
            bst.add(5);
            bst.add(7);

            Console.Out.WriteLine("======Binary Search Tree Test 1======");
            Console.Out.WriteLine(">Tests whether or not the tree contians all the values it was constructed with");
            Console.Out.WriteLine(bst.hasValue(5) && bst.hasValue(3) && bst.hasValue(4) && bst.hasValue(6) && bst.hasValue(7) && !bst.hasValue(10));
            Console.Out.WriteLine("");

            Console.Out.WriteLine("======Binary Search Tree Test 2======");
            Console.Out.WriteLine(">Tests whether or not the tree is of height 4");
            Console.Out.Write("bst.getHeight(): ");
            Console.Out.WriteLine(bst.getHeight());
            Console.Out.WriteLine(bst.getHeight() == 4);
            Console.Out.WriteLine("");

            Console.Out.WriteLine("======Binary Search Tree Test 3======");
            Console.Out.WriteLine(">Tests (by inspection) a preorder traversal");
            bst.preorderTraversal();
            Console.Out.WriteLine();

            Console.Out.WriteLine("======Binary Search Tree Test 4======");
            Console.Out.WriteLine(">Tests (by inspection) a inorder traversal");
            bst.inOrderTraversal();
            Console.Out.WriteLine();

            Console.Out.WriteLine("======Binary Search Tree Test 5======");
            Console.Out.WriteLine(">Tests (by inspection) a postorder traversal");
            bst.postOrderTraversal();
            Console.Out.WriteLine();

            bst.deleteValue(5);
            Console.Out.WriteLine("======Binary Search Tree Test 6======");
            Console.Out.WriteLine(">Tests (by inspection) whether or not a delete has worked");
            Console.Out.Write("Post-Order Traversal: ");
            bst.postOrderTraversal();
            Console.Out.Write("Pre-Order Traversal: ");
            bst.preorderTraversal();
            Console.Out.Write("In-Order Traversal: ");
            bst.inOrderTraversal();

        }
    }

    class BinaryNode
    {
        private BinaryNode left;
        private BinaryNode right;
        private int data;


        public BinaryNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public void setLeft(BinaryNode newLeft)
        {
            left = newLeft;
        }

        public void setRight(BinaryNode newRight)
        {
            right = newRight;
        }

        public int getData()
        {
            return data;
        }

        public BinaryNode getLeft()
        {
            return left;
        }

        public BinaryNode getRight()
        {
            return right;
        }

        public bool equals(int toCompare)
        {
            return toCompare == data;
        }
    }
}
