using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixMathExpressions
{
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
            }
            else
            {
                //The LinkedList contains elements, so set the newNode.next to the top and set top to the newNode
                newNode.setNext(top);
                top = newNode;
                size++;
            }
        }

        public void deleteFromFront()
        {
            if (top != null)
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
