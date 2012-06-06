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

            stackTest();

            Console.Out.WriteLine("====End of Processing====");
        }

        private static void stackTest()
        {
            Stack s = new Stack();
            string popped = null;
            bool fullList = false;

            Console.Out.WriteLine("======>Stack Test 1<======");
            Console.Out.WriteLine(">>Tests whether or not the isEmpty method works with an empty stack");
            Console.Out.Write("isEmpty() returned: ");
            Console.Out.WriteLine(s.isEmpty());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(s.isEmpty() == true);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>Stack Test 2<======");
            Console.Out.WriteLine(">>Tests whether or not the push and pop methods work for an one element stack");
            s.push("element 1");
            popped = s.pop();
            Console.Out.WriteLine("pop() returned: " + popped);
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(popped, "element 1"));
            
            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>Stack Test 3<======");
            Console.Out.WriteLine(">>Tests whether or not the multiple pushes and top methods work");
            s.push(popped);
            s.push("element 2");
            Console.Out.WriteLine("top() returned: " + s.top());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(s.top(), "element 2"));

            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>Stack Test 4<======");
            Console.Out.WriteLine(">>Tests whether or not multiple pushes and pops work and isEmpty works for a stack with items in it" +
                "and a stack with all of its items removed");
            s.push("element 3");
            fullList = s.isEmpty();
            Console.Out.Write("isEmpty() (on stack with 3 items in it) returned: ");
            Console.Out.WriteLine(fullList);
            s.pop();
            s.pop();
            s.pop();
            Console.Out.Write("isEmpty() (on stack with all items removed) returned: ");
            Console.Out.WriteLine(s.isEmpty());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(s.isEmpty() == true && fullList == false);
                
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

            Console.Out.WriteLine("");
            Console.Out.WriteLine("======>LinkedList Test 5<======");
            Console.Out.WriteLine(">>Tests whether or not the linkedlist's getDataAtFront method works");
            Console.Out.WriteLine("getDataAtFront() returned: " + ll.getDataAtFront());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(ll.getDataAtFront(), "node 2"));
            Console.Out.WriteLine("");

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

    class Stack
    {
        LinkedList stackElements;

        public Stack()
        {
            stackElements = new LinkedList();
        }

        public void push(string toAdd)
        {
            stackElements.insertAtFront(toAdd);
        }

        public string pop()
        {
            string toReturn = null;

            if (stackElements.getSize() > 0)
            {
                toReturn = stackElements.getDataAtFront();
                stackElements.deleteFromFront();
            }

            return toReturn;
        }

        public string top()
        {
            return stackElements.getDataAtFront();
        }

        public bool isEmpty()
        {
            if (stackElements.getSize() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public string getDataAtFront()
        {
            string toReturn = null;

            if (top != null)
            {
                toReturn = top.getData();
            }

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
