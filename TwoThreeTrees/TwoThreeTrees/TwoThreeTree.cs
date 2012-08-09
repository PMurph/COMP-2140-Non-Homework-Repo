using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoThreeTrees
{
    class TwoThreeTree
    {
        private TwoThreeNode root;

        public TwoThreeTree()
        {
            root = null;
        }

        public void printTree()
        {
            if (root == null)
            {
                Console.Out.WriteLine("tree is empty");
            }
            else
            {
                printTreeRec(root);
                Console.Out.WriteLine("");
            }
        }

        //======Mutators======

        public void addNode(int key){
            TwoThreeNode toAdd = null;

            if (root == null)
            {
                //Adding the first node in the tree
                root = new TwoThreeNode(key);
            }
            else
            {
                toAdd = addRec(root, key);

                if (toAdd != null)
                {
                    root = toAdd;
                }
            }
        }

        //======Helpers=======
        private void printTreeWithLevels()
        {
            Queue<TwoThreeNode> cur = new Queue<TwoThreeNode>();
            Queue<TwoThreeNode> next = new Queue<TwoThreeNode>();
            Queue<TwoThreeNode> toCheck = new Queue<TwoThreeNode>();
            TwoThreeNode curNode = null;
            int level = 0;

            Console.Out.Write("Level " + level.ToString() + ": ");
            cur.Enqueue(root);

            while (cur.Count() > 0)
            {
                curNode = cur.Dequeue();

                if (curNode.isLeafNode())
                {
                    Console.Out.Write("[" + curNode.getFirstKey() + "] ");
                    toCheck.Enqueue(curNode);
                }
                else
                {
                    if (curNode.hasTwoNodes())
                    {
                        Console.Out.Write("[" + curNode.getFirstKey() + "] ");
                        next.Enqueue(curNode.getLeft());
                        next.Enqueue(curNode.getMid());
                    }
                    else
                    {
                        Console.Out.Write("[ " + curNode.getFirstKey() + ", " + curNode.getSecondKey() + "] ");
                        next.Enqueue(curNode.getLeft());
                        next.Enqueue(curNode.getMid());
                        next.Enqueue(curNode.getRight());
                    }
                }

                if (cur.Count() == 0)
                {
                    cur = next;
                    next = new Queue<TwoThreeNode>();
                    level++;
                    Console.Out.WriteLine();
                    Console.Out.Write("Level " + level.ToString() + ": ");
                }
            }

            if (!checkRep(toCheck))
            {
                Console.Out.WriteLine("ERROR! The current representation of the two-three tree is incorrect");

            }
        }

        private bool checkRep(Queue<TwoThreeNode> toCheck)
        {
            bool toReturn = true;
            int lastKey = -1;
            int key = 0;

            while (toCheck.Count() > 1)
            {
                lastKey = key;
                key = toCheck.Dequeue().getFirstKey();
                //Console.Out.WriteLine("Key = " + key.ToString());
                //Console.Out.WriteLine("LastKey = " + lastKey.ToString());
                if (key <= lastKey)
                {
                    toReturn = false;
                    break;
                }
            }

            return toReturn;
        }

        private void printTreeRec(TwoThreeNode curNode)
        {
            if (curNode.isLeafNode())
            {
                Console.Out.Write(curNode.getFirstKey().ToString() + " ");
            }
            else
            {
                //Console.Out.Write("Getting Left ");
                printTreeRec(curNode.getLeft());
                //Console.Out.Write("Getting Mid ");
                printTreeRec(curNode.getMid());
                if (curNode.hasTwoNodes() == false)
                {
                    //Console.Out.Write("Getting Right ");
                    printTreeRec(curNode.getRight());
                }
            }

        }

        private TwoThreeNode addRec(TwoThreeNode curNode, int key)
        {
            TwoThreeNode toReturn = null;
            TwoThreeNode returned = null;
            TwoThreeNode newLeft = null;
            TwoThreeNode newRight = null;
            TwoThreeNode newParent = null;

            if(!curNode.isLeafNode()){
                //A key has been pushed up, which needs to be added to the curNode node
                if (curNode.hasTwoNodes() == true)
                {
                    if(key < curNode.getFirstKey()){
                        returned = addRec(curNode.getLeft(), key);
                    }else{
                        returned = addRec(curNode.getMid(), key);
                    }

                    if(returned != null){
    
                        if (returned.getFirstKey() < curNode.getFirstKey())
                        {
                            curNode.toggleNodeNum();
                            curNode.setRight(curNode.getMid());
                            curNode.setMid(returned.getMid());
                            curNode.setLeft(returned.getLeft());
                            curNode.setSecondKey(curNode.getFirstKey());
                            curNode.setFirstKey(minKeyInTree(curNode.getMid()));
                        }else if(returned.getFirstKey() >= curNode.getFirstKey()){
                            curNode.toggleNodeNum();
                            curNode.setRight(returned.getMid());
                            curNode.setMid(returned.getLeft());
                            curNode.setFirstKey(minKeyInTree(returned.getLeft()));
                            curNode.setSecondKey(minKeyInTree(returned.getMid()));
                        }
                    }
                }
                else
                {
                    if(key < curNode.getFirstKey()){
                        returned = addRec(curNode.getLeft(), key);
                    }else if(key < curNode.getSecondKey()){
                        returned = addRec(curNode.getMid(), key);
                    }else{
                        returned = addRec(curNode.getRight(), key);
                    }

                    if(returned != null){
                        if (returned.getFirstKey() < curNode.getFirstKey())
                        {
                            newLeft = new TwoThreeNode(returned.getLeft(), returned.getMid(), minKeyInTree(returned.getMid()));
 
                            newRight = new TwoThreeNode(curNode.getMid(), curNode.getRight(), minKeyInTree(curNode.getRight()));
                        }
                        else if (returned.getFirstKey() >= curNode.getFirstKey() && returned.getFirstKey() < curNode.getSecondKey())
                        {
                            newLeft = new TwoThreeNode(curNode.getLeft(), returned.getLeft(), minKeyInTree(returned.getLeft()));
                            newRight = new TwoThreeNode(returned.getMid(), curNode.getRight(), minKeyInTree(curNode.getRight()));
                        }else{
                           
                            if (returned.getFirstKey() >= curNode.getSecondKey())
                            {
                                newLeft = new TwoThreeNode(curNode.getLeft(), curNode.getMid(), minKeyInTree(curNode.getMid()));
                                newRight = new TwoThreeNode(returned.getLeft(), returned.getMid(), minKeyInTree(returned.getMid()));
                            }
                            else
                            {
                                newLeft = new TwoThreeNode(curNode.getLeft(), curNode.getMid(), minKeyInTree(curNode.getMid()));
                                newRight = new TwoThreeNode(returned.getLeft(), returned.getMid(), minKeyInTree(returned.getMid()));
                            }
                        }

                        newParent = new TwoThreeNode(newLeft, newRight, minKeyInTree(newRight));
                        toReturn = newParent;
                    }
                }
             }else{
                //Base Case: Return a the parent node consisting of two child nodes, the leaf node 
                if(key < curNode.getFirstKey()){
                    toReturn = new TwoThreeNode(new TwoThreeNode(key), curNode, curNode.getFirstKey());
                }else if(key > curNode.getFirstKey()){
                    toReturn = new TwoThreeNode(curNode, new TwoThreeNode(key), key);
                }
            }

            return toReturn;
        }

        private int minKeyInTree(TwoThreeNode toSearch){
            int toReturn = toSearch.getFirstKey();

            if( !toSearch.isLeafNode() ){
                toReturn = minKeyInTree(toSearch.getLeft());
            }

            return toReturn;
        }

        //======Main Method======

        static void Main(string[] args)
        {
            testAdd();

            Console.Out.WriteLine();
            Console.Out.WriteLine("======End of Processing======");
        }

        //======Test Methods======
        private static void testAdd()
        {
            TwoThreeTree ttt = new TwoThreeTree();
            Random r = new Random();
            int adding = 0;

            Console.Out.WriteLine("====Test1====");
            Console.Out.WriteLine(">Tests adding to an empty tree");
            ttt.addNode(5);
            ttt.printTreeWithLevels();
            Console.Out.WriteLine("");

            Console.Out.WriteLine("====Test2====");
            Console.Out.WriteLine(">Tests adding two more nodes to the previously established tree");
            ttt.addNode(7);
            ttt.addNode(6);
            ttt.printTreeWithLevels();
            Console.Out.WriteLine();

            Console.Out.WriteLine("====Test3====");
            Console.Out.WriteLine(">Tests whether a split in the root node works");
            ttt.addNode(10);
            ttt.addNode(7);
            ttt.addNode(7);
            ttt.addNode(6);
            ttt.addNode(4);
            ttt.addNode(3);
            ttt.addNode(8);
            ttt.printTreeWithLevels();
            ttt.addNode(9);
            ttt.addNode(11);
            ttt.printTreeWithLevels();
            Console.Out.WriteLine();
            
            
            Console.Out.WriteLine("====Test4===");
            Console.Out.WriteLine(">Tests adding 100 random values to the tree");
            for (int i = 0; i < 1000; i++)
            {
                adding = r.Next(4500) + 1;
                Console.Out.WriteLine("Adding " + adding.ToString());
                ttt.addNode(adding);
                ttt.printTreeWithLevels();
                Console.Out.WriteLine();
            }
            ttt.printTree();
            Console.Out.WriteLine();
            
        }
    }

    class TwoThreeNode
    {
        private bool twoNode;
        private bool leafNode;
        private TwoThreeNode left;
        private TwoThreeNode mid;
        private TwoThreeNode right;
        private int firstKey;
        private int secondKey;

        //======Constructors======

        public TwoThreeNode(int k1)
        {
            twoNode = false;
            leafNode = true;
            firstKey = k1;
        }

        public TwoThreeNode(TwoThreeNode l, TwoThreeNode m, int k1)
        {
            twoNode = true;
            leafNode = false;
            left = l;
            mid = m;
            firstKey = k1;
        }

        public TwoThreeNode(TwoThreeNode l, TwoThreeNode m, TwoThreeNode r, int k1, int k2)
        {
            twoNode = false;
            leafNode = false;
            left = l;
            mid = m;
            right = r;
            firstKey = k1;
            secondKey = k2;
        }

        //======Accessors======

        public bool isLeafNode()
        {
            return leafNode;
        }

        public bool hasTwoNodes()
        {
            return twoNode;
        }

        public TwoThreeNode getLeft()
        {
            return left;
        }

        public TwoThreeNode getMid()
        {
            return mid;
        }

        public TwoThreeNode getRight()
        {
            return right;
        }

        public int getFirstKey()
        {
            return firstKey;
        }

        public int getSecondKey()
        {
            return secondKey;
        }

        //======Mutators======

        public void noLongerLead()
        {
            leafNode = false;
        }

        public void toggleNodeNum()
        {
            twoNode = !twoNode;
        }

        public void setLeft(TwoThreeNode newLeft)
        {
            left = newLeft;
        }

        public void setMid(TwoThreeNode newMid){
            mid = newMid;
        }

        public void setRight(TwoThreeNode newRight)
        {
            right = newRight;
        }

        public void setFirstKey(int newKey)
        {
            firstKey = newKey;
        }

        public void setSecondKey(int newKey)
        {
            secondKey = newKey;
        }

    }
}
