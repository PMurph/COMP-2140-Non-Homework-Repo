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

        public void deleteNode(int key)
        {
            if (root != null)
            {
                if (root.isLeafNode())
                {
                    root = null;
                }
                else
                {
                    deleteRec(key, root, null);
                }
            }
        }

        //======Helpers=======
        private TwoThreeNode deleteRec(int key, TwoThreeNode parent, TwoThreeNode grandparent)
        {
            TwoThreeNode toReturn = null;
            TwoThreeNode cur = null;
            TwoThreeNode returned = null;
            TwoThreeNode temp = null;
            int pstate = -1;
            int state = -1;

            if (key < parent.getFirstKey())
            {
                cur = parent.getLeft();
                state = 0;
            }
            else if ((key >= parent.getFirstKey() && parent.hasTwoNodes()) || (parent.hasTwoNodes() == false && key >= parent.getFirstKey() && key < parent.getSecondKey()))
            {
                cur = parent.getMid();
                state = 1;
            }
            else if (parent.hasTwoNodes() == false && key >= parent.getSecondKey())
            {
                cur = parent.getRight();
                state = 2;
            }

            if (cur.isLeafNode() && cur.getFirstKey() == key)
            {
                if (parent.hasTwoNodes() == false)
                {
                    //Parent is a three node, toggle the Node numbers, delete the key node, shift children as necessary and change key as necessary
                    parent.toggleNodeNum();

                    if (state == 0)
                    {
                        parent.setLeft(parent.getMid());
                        parent.setMid(parent.getRight());
                        parent.setRight(null);
                        parent.setFirstKey(parent.getSecondKey());
                    }
                    else if (state == 1)
                    {
                        parent.setMid(parent.getRight());
                        parent.setRight(null);
                        parent.setFirstKey(parent.getSecondKey());
                    }
                    else if (state == 2)
                    {
                        parent.setRight(null);
                    }
                }
                else
                {
                    if (grandparent == null)
                    {
                        //Parent node is the root
                        if (state == 0)
                        {
                            root = parent.getMid();
                        }
                        else if (state == 1)
                        {
                            root = parent.getLeft();
                        }
                    }else if(grandparent.hasTwoNodes()  == false){
                        if (state == 0)
                        {
                            temp = parent.getMid();
                        }
                        else if(state == 1)
                        {
                            temp = parent.getLeft();
                        }
                        
                        //Grandparent node is a three node
                        if (parent == grandparent.getLeft())
                        {
                            if (grandparent.getMid().hasTwoNodes())
                            {
                                //Closest sibling of parent is a two node, so merge other child of parent with parent's sibling and remove parent then change key as necessary
                                grandparent.getMid().toggleNodeNum();
                                grandparent.getMid().setRight(grandparent.getMid().getMid());
                                grandparent.getMid().setMid(grandparent.getMid().getLeft());
                                grandparent.getMid().setLeft(temp);
                                grandparent.getMid().setSecondKey(grandparent.getMid().getFirstKey());
                                grandparent.getMid().setFirstKey(grandparent.getMid().getMid().getFirstKey());
                                grandparent.toggleNodeNum();
                                grandparent.setLeft(grandparent.getMid());
                                grandparent.setMid(grandparent.getRight());
                                grandparent.setFirstKey(grandparent.getSecondKey());
                            }
                            else
                            {
                                //Closest sibling of parent has three nodes, so take the left most node of the sibling and attach it to the parent, fix sibling push key up to grandparent node
                                parent.setLeft(temp);
                                parent.setMid(grandparent.getMid().getLeft());
                                parent.setFirstKey(parent.getMid().getFirstKey());
                                grandparent.getMid().toggleNodeNum();
                                grandparent.getMid().setLeft(grandparent.getMid().getMid());
                                grandparent.getMid().setMid(grandparent.getMid().getRight());
                                grandparent.getMid().setFirstKey(grandparent.getSecondKey());
                            }
                        }
                        else if (parent == grandparent.getMid())
                        {
                            if (grandparent.getLeft().hasTwoNodes())
                            {
                                //The left sibling of the parents has two nodes, so take the one node left in the middle after deleting a merge it with the parent's left sibling, adjust grandparent node as necessary
                                grandparent.getLeft().toggleNodeNum();
                                grandparent.getLeft().setRight(temp);
                                grandparent.getLeft().setSecondKey(temp.getFirstKey());
                                grandparent.toggleNodeNum();
                                grandparent.setMid(grandparent.getRight());
                                grandparent.setFirstKey(minKeyInTree(grandparent.getMid()));
                                grandparent.setRight(null);
                            }
                            else
                            {
                                //The left sibling of the parent has three nodes, so take its right most node and bring it into the center, adjust left sibling as necessary and adjust grandparent as necessary
                                if (state == 0)
                                {
                                    parent.setLeft(grandparent.getLeft().getRight());
                                }
                                else
                                {
                                    parent.setMid(temp);
                                    parent.setFirstKey(temp.getFirstKey());
                                    parent.setLeft(grandparent.getLeft().getRight());
                                }

                                grandparent.setFirstKey(grandparent.getLeft().getRight().getFirstKey());
                                grandparent.getLeft().toggleNodeNum();
                                grandparent.getLeft().setRight(null);
                                
                            }
                        }
                        else if (parent == grandparent.getRight())
                        {
                            if (grandparent.getMid().hasTwoNodes())
                            {
                                //The parents middle sibling has two nodes, so merge the remaining node with the parent's middle sibling, and adjust the grandparent as necessary
                                grandparent.getMid().setRight(temp);
                                grandparent.getMid().toggleNodeNum();
                                grandparent.getMid().setSecondKey(temp.getFirstKey());
                                grandparent.setRight(null);
                                grandparent.toggleNodeNum();
                            }
                            else
                            {
                                //The parents middle sibling has three nodes, so take the middle siblings right most node and add it to the parent node
                                if (state == 0)
                                {
                                    parent.setLeft(grandparent.getMid().getRight());
                                }
                                else if (state == 1)
                                {
                                    parent.setRight(temp);
                                    parent.setLeft(grandparent.getMid().getRight());
                                    parent.setFirstKey(temp.getFirstKey());
                                }

                                grandparent.setSecondKey(grandparent.getMid().getRight().getFirstKey());
                                grandparent.getMid().toggleNodeNum();
                                grandparent.getMid().setRight(null);
                            }
                        }
                    }
                    else if (grandparent.hasTwoNodes())
                    {
                        if (cur == parent.getLeft())
                        {
                            state = 0;
                            temp = parent.getMid();
                        }
                        else if (cur == parent.getMid())
                        {
                            state = 1;
                            temp = parent.getLeft();
                        }

                        if (parent == grandparent.getLeft())
                        {
                            if (grandparent.getMid().hasTwoNodes() == false)
                            {
                                //The parent's sibling has three nodes, so take one node from the sibling and merge it with the parent node
                                if (state == 0)
                                {
                                    parent.setLeft(parent.getMid());
                                    parent.setMid(grandparent.getMid().getLeft());
                                    parent.setFirstKey(parent.getMid().getFirstKey());
                                    grandparent.getMid().setLeft(grandparent.getMid().getMid());
                                    grandparent.getMid().setMid(grandparent.getMid().getRight());
                                    grandparent.getMid().toggleNodeNum();
                                    grandparent.getMid().setFirstKey(grandparent.getMid().getSecondKey());
                                }
                                else if (state == 1)
                                {
                                    parent.setMid(grandparent.getMid().getLeft());
                                    parent.setFirstKey(parent.getMid().getFirstKey());
                                    grandparent.getMid().setLeft(grandparent.getMid().getMid());
                                    grandparent.getMid().setMid(grandparent.getMid().getRight());
                                    grandparent.getMid().toggleNodeNum();
                                    grandparent.getMid().setFirstKey(grandparent.getMid().getSecondKey());
                                }
                            }
                            else
                            {
                                //The parent's sibling has two nodes, so merge all leafs into a three node, and push it up the tree
                                grandparent.getMid().toggleNodeNum();
                                grandparent.getMid().setRight(grandparent.getMid().getMid());
                                grandparent.getMid().setMid(grandparent.getMid().getLeft());
                                grandparent.getMid().setLeft(temp);
                                grandparent.getMid().setSecondKey(grandparent.getMid().getFirstKey());
                                grandparent.getMid().setFirstKey(grandparent.getMid().getMid().getFirstKey());
                                toReturn = grandparent.getMid();
                            }
                        }
                        else if (parent == grandparent.getMid())
                        {
                            if (grandparent.getLeft().hasTwoNodes() == false)
                            {
                                if (state == 0)
                                {
                                    parent.setLeft(grandparent.getLeft().getRight());
                                    grandparent.getLeft().toggleNodeNum();
                                    grandparent.getLeft().setRight(null);
                                }
                                else if (state == 1)
                                {
                                    parent.setMid(temp);
                                    parent.setLeft(grandparent.getLeft().getRight());
                                    grandparent.getLeft().toggleNodeNum();
                                    grandparent.getLeft().setRight(null);
                                }
                            }
                            else
                            {
                                grandparent.getLeft().toggleNodeNum();
                                grandparent.getLeft().setRight(temp);
                                grandparent.getLeft().setSecondKey(temp.getFirstKey());
                                toReturn = grandparent.getLeft();
                            }
                        }
                    }
                }
            }
            else
            {

                returned = deleteRec(key, cur, parent);

                if (returned != null)
                {
                    if(grandparent == null){
                        //Pushed up to the root Node
                        root = returned;
                    }
                    else if (grandparent.hasTwoNodes())
                    {
                        if (parent == grandparent.getLeft())
                        {
                            state = 0;
                        }
                        else if (parent == grandparent.getMid())
                        {
                            state = 1;
                        }
                        else if (parent == grandparent.getRight())
                        {
                            state = 2;
                        }

                        if (state == 0 && grandparent.getMid().hasTwoNodes() == false)
                        {
                            //The left node has been pushed up, the grand parent is a two nodes, the grandparents middle node is three node, so take the left subtree of the middle node merge it with the pushed up node,
                            //then set the middle node's keys and grandparent's key as necessary
                            temp = new TwoThreeNode(returned, grandparent.getMid().getLeft(), minKeyInTree(grandparent.getMid().getLeft()));
                            grandparent.setLeft(temp);
                            grandparent.getMid().toggleNodeNum();
                            grandparent.getMid().setLeft(grandparent.getMid().getMid());
                            grandparent.getMid().setMid(grandparent.getMid().getRight());
                            grandparent.getMid().setFirstKey(grandparent.getMid().getSecondKey());
                            grandparent.getMid().setRight(null);
                            grandparent.setFirstKey(minKeyInTree(grandparent.getMid()));
                        }
                        else if (state == 0 && grandparent.getMid().hasTwoNodes())
                        {
                            //The left node has been pushed up, the grand parent is a two node, the grand parents middle node is a two node, so merge grandparents children into a single node and push it up
                            
                            grandparent.getMid().toggleNodeNum();
                            grandparent.getMid().setRight(grandparent.getMid().getMid());
                            grandparent.getMid().setMid(grandparent.getMid().getLeft());
                            grandparent.getMid().setLeft(returned);
                            grandparent.getMid().setSecondKey(grandparent.getMid().getFirstKey());
                            grandparent.getMid().setFirstKey(minKeyInTree(grandparent.getMid().getMid()));
                            toReturn = grandparent.getMid();
                        }
                        else if (state == 1 && grandparent.getLeft().hasTwoNodes() == false)
                        {
                            temp = new TwoThreeNode(grandparent.getMid().getRight(), returned, minKeyInTree(returned));
                            grandparent.setMid(temp);
                            grandparent.getLeft().toggleNodeNum();
                            grandparent.getLeft().setRight(null);
                        }
                        else if (state == 1 && grandparent.getLeft().hasTwoNodes())
                        {
                            grandparent.getLeft().toggleNodeNum();
                            grandparent.getLeft().setRight(returned);
                            grandparent.getLeft().setSecondKey(minKeyInTree(returned));
                            toReturn = grandparent.getLeft();

                        }
                    }
                    else
                    {
                        if (state == 0 && grandparent.getMid().hasTwoNodes() == false)
                        {
                            temp = new TwoThreeNode(new TwoThreeNode(returned.getLeft(), returned.getMid(), minKeyInTree(returned.getLeft())), new TwoThreeNode(returned.getRight(), grandparent.getMid().getLeft(),
                                minKeyInTree(grandparent.getMid().getLeft())), minKeyInTree(returned.getRight()));
                            grandparent.setLeft(temp);
                            grandparent.getMid().toggleNodeNum();
                            grandparent.getMid().setLeft(grandparent.getMid().getMid());
                            grandparent.getMid().setMid(grandparent.getMid().getRight());
                            grandparent.getMid().setFirstKey(grandparent.getMid().getFirstKey());
                        }else if(state == 0 && grandparent.getMid().hasTwoNodes()){
                            grandparent.getMid().toggleNodeNum();
                            grandparent.getMid().setRight(grandparent.getMid().getMid());
                            grandparent.getMid().setMid(grandparent.getMid().getLeft());
                            grandparent.getMid().setLeft(returned);
                            grandparent.getMid().setSecondKey(grandparent.getMid().getFirstKey());
                            grandparent.getMid().setFirstKey(minKeyInTree(grandparent.getMid().getMid()));
                            grandparent.setLeft(grandparent.getMid());
                            grandparent.setMid(grandparent.getRight());
                            grandparent.toggleNodeNum();
                            grandparent.setFirstKey(grandparent.getSecondKey());
                        }
                        else if (state == 1 && grandparent.getLeft().hasTwoNodes()==false)
                        {
                            //State when all three children of the grandparent are two nodes
                            temp = new TwoThreeNode(new TwoThreeNode(grandparent.getLeft().getRight(), returned.getLeft(), minKeyInTree(grandparent.getLeft().getRight())), new TwoThreeNode(returned.getMid(),
                                returned.getRight(), minKeyInTree(returned.getRight())), minKeyInTree(returned.getMid()));
                            grandparent.setMid(temp);
                            grandparent.setFirstKey(minKeyInTree(temp));
                            grandparent.getLeft().toggleNodeNum();
                            grandparent.getLeft().setRight(null);
                        }else if(state == 1 && grandparent.getLeft().hasTwoNodes()){
                            grandparent.getLeft().toggleNodeNum();
                            grandparent.getLeft().setRight(returned);
                            grandparent.getLeft().setSecondKey(minKeyInTree(returned));
                            grandparent.setMid(grandparent.getRight());
                            grandparent.toggleNodeNum();
                            grandparent.setFirstKey(grandparent.getSecondKey());
                            grandparent.setRight(null);
                        }
                        else if (state == 2 && grandparent.getMid().hasTwoNodes() == false)
                        {
                            temp = new TwoThreeNode(new TwoThreeNode(grandparent.getMid().getRight(), returned.getLeft(), minKeyInTree(returned.getLeft())), new TwoThreeNode(returned.getMid(), returned.getRight(),
                                minKeyInTree(returned.getRight())), minKeyInTree(returned.getMid()));
                            grandparent.setRight(temp);
                            grandparent.setSecondKey(minKeyInTree(temp));
                        }
                        else if (state == 2 && grandparent.getMid().hasTwoNodes())
                        {
                            grandparent.getMid().toggleNodeNum();
                            grandparent.getMid().setRight(returned);
                            grandparent.setSecondKey(minKeyInTree(returned));
                            grandparent.setRight(null);
                            grandparent.toggleNodeNum();
                        }
                    }
                }
            }

            return toReturn;
        }

        private void printTreeWithLevels()
        {
            Queue<TwoThreeNode> cur = new Queue<TwoThreeNode>();
            Queue<TwoThreeNode> next = new Queue<TwoThreeNode>();
            Queue<TwoThreeNode> toCheck = new Queue<TwoThreeNode>();
            TwoThreeNode curNode = null;
            int level = 0;

            Console.Out.Write("Level " + level.ToString() + ": ");
            cur.Enqueue(root);

            while (cur.Count() > 0 && root != null)
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

            deleteTest(ttt);
        }

        private static void deleteTest(TwoThreeTree ttt)
        {
            TwoThreeTree ttt2 = new TwoThreeTree();
            Random r = new Random();
            int temp = 0;

            Console.Out.WriteLine("====Test 5====");
            Console.Out.WriteLine(">Tests creating a tree and deleting from it");
            for (int i = 0; i < 10; i++)
            {
                ttt2.addNode(i + 1);
            }
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();
            ttt2.deleteNode(1);
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();

            Console.Out.WriteLine("====Test 6====");
            Console.Out.WriteLine(">Tests deleteing nodes from the temp tree");
            ttt2.deleteNode(10);
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();
            ttt2.deleteNode(7);
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();
            ttt2.deleteNode(3);
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();
            ttt2.deleteNode(5);
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();
            ttt2.deleteNode(4);
            ttt2.deleteNode(8);
            ttt2.deleteNode(9);
            ttt2.deleteNode(2);
            ttt2.deleteNode(6);
            ttt2.deleteNode(1);
            ttt2.printTreeWithLevels();
            Console.Out.WriteLine();

            Console.Out.WriteLine("====Test 7====");
            Console.Out.WriteLine(">Tests removing lots of nodes from a big tree");
            for (int i = 0; i < 1000000; i++)
            {
                temp = r.Next(4500) + 1;
                try
                {
                    ttt.deleteNode(temp);
                }
                catch (Exception e)
                {
                    ttt.printTreeWithLevels();
                    Console.Out.WriteLine();
                    Console.Out.WriteLine("Number: " + temp);
                    break;
                }
            }
            ttt.printTreeWithLevels();
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
