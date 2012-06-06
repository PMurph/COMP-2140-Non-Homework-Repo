using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            nodeTest();

            linkedlistTest();

            Console.Out.WriteLine("====End of Processing====");
        }

        private static void linkedlistTest()
        {
            LinkedList ll = new LinkedList();

            Console.Out.WriteLine("======>LinkedList Test 1<======");
            Console.Out.WriteLine(">>Tests whether or not nodes can be added to a linked list and that the getSize method works");
            ll.insertAtFront("node 4");
            ll.insertAtFront("node 3");
            ll.insertAtFront("node 2");
            ll.insertAtFront("node 1");
            Console.Out.WriteLine("getSize() returned: " + ll.getSize());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(ll.getSize() == 4);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>LinkedList Test 2<======");
            Console.Out.WriteLine(">>Tests whether or not the linkedlist's toString method works");
            Console.Out.WriteLine("toString() returned: " + ll.toString());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(ll.toString(), "( node 1 , node 2 , node 3 , node 4 )"));

            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>LinkedList Test 3<======");
            Console.Out.WriteLine(">>Tests whether or not the linkedlist's contains method works");
            Console.Out.Write("contains(\"node 1\") returned: ");
            Console.Out.WriteLine(ll.contains("node 1"));
            Console.Out.Write("contains(\"node 5\") returned: ");
            Console.Out.WriteLine(ll.contains("node 5"));
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(ll.contains("node 1") == true && ll.contains("node 5") == false);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>LinkedList Test 4<======");
            Console.Out.WriteLine(">>Tests whether or not the linkedlist's deleteFromfront and delete methods work");
            ll.deleteFromFront();
            ll.delete("node 4");
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(ll.contains("node 1") == false && ll.contains("node 2") == true && ll.contains("node 3") == true && ll.contains("node 4") == false &&
                ll.getSize() == 2 && String.Equals(ll.toString(), "( node 2 , node 3 )"));

        }

        private static void nodeTest()
        {
            Node node1 = new Node("test");
            Node node1_2 = new Node("test");
            Node node2 = new Node("another test node");

            Console.Out.WriteLine("======>Node Test 1<======");
            Console.Out.WriteLine(">>Test whether or not a node returns the correct data");
            Console.Out.WriteLine("returned: " + node2.getData());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(node2.getData(), "another test node"));


            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>Node Test 2<======");
            Console.Out.WriteLine(">>Test whether or not the node equals method works");
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(node1.Equals(node1_2.getData()));
            
            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>Node Test 3<======");
            Console.Out.WriteLine(">>Test whether or not the node setNext and getNext methods work");
            node1.setNext(node2);
            node2.setNext(node1_2);
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(node1.getData(), node1.getNext().getNext().getData()));
            Console.Out.WriteLine("");
        }
    }

    class LinkedList
    {
        private Node top;
        private int size;

        public LinkedList()
        {
            top = null;
            size = 0;
        }

        public void insertAtFront(String data)
        {
            Node newNode = new Node(data);

            if (top == null)
            {
                //The LinkedList is empty so set top to the new node
                top = newNode;
                size++;
            }else{
                //The LinkedList contains elements, so set the newNode.next to the top and set top to the newNode
                newNode.setNext(top);
                top = newNode;
                size++;
            }
        }

        public void deleteFromFront()
        {
            if(top != null)
            {
                top = top.getNext();
                size--;
            }
        }

        public void delete(string toDelete)
        {
            Node currNode = top;
            bool found = false;

            if (currNode != null)
            {
                //If there are items in the list, look for node to delete
                if (currNode.Equals(toDelete))
                {
                    //If the top node is the node to delete, set top to top.next
                    top = currNode.getNext();
                    size--;
                }
                else
                {
                    //If the top node is not the node to delete, check through the linked list and delete the node if found
                    while (currNode != null && currNode.getNext() != null && found == false)
                    {
                        if (currNode.getNext().Equals(toDelete))
                        {
                            currNode.setNext(currNode.getNext().getNext());
                            size--;
                            found = true;
                        }
                        currNode = currNode.getNext();
                    }
                }
            }
            //If there are no items in the list, do nothing
        }

        public bool contains(string toFind)
        {
            Node currNode = top;
            bool toReturn = false;

            while (currNode != null && toReturn == false)
            {
                if (currNode.Equals(toFind))
                {
                    toReturn = true;
                }
                currNode = currNode.getNext();
            }
            return toReturn;
        }

        public int getSize()
        {
            return size;
        }

        public string toString()
        {
            string toReturn = "";
            Node currNode = top;

            toReturn += "( ";

            while (currNode != null)
            {
                if (currNode.getNext() == null)
                {
                    //If the node is the last node in the list, don't append a , to toReturn
                    toReturn += currNode.toString();
                }
                else
                {
                    //If the node is not the last node in the list, append a , to toReturn
                    toReturn += currNode.toString() + " , ";
                }
                currNode = currNode.getNext();
            }

            toReturn += " )";

            return toReturn;
        }
    }

    class Node
    {
        private string data;
        private Node next;

        public Node(string newData)
        {
            data = newData;
            next = null;
        }

        public void setNext(Node newNext)
        {
            next = newNext;
        }

        public string getData()
        {
            return data;
        }

        public Node getNext()
        {
            return next;
        }

        public string toString()
        {
            return data;
        }

        public bool Equals(string toTest)
        {
            return String.Equals(data, toTest);
        }
    }
}
