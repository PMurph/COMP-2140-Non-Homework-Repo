using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{


    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class CircularLinkedList
    {
        BackLinkedNode dummyNode;
        int size;

        public CircularLinkedList()
        {
            dummyNode = new BackLinkedNode("dUmMy");
            dummyNode.setNext(dummyNode);
            size = 0;
        }

        public void insertAtFront(string newData)
        {
            BackLinkedNode newNode = null;
            if(!String.Equals(newData, "dUmMy"))
            {
                //If the new data is not the same as the data contained in the dummy node, create a new Node and insert it into the front of the LinkedList
                newNode = new BackLinkedNode(newData);
                newNode.setNext(dummyNode.getNext());
                dummyNode.getNext().setPrev(newNode);
                newNode.setPrev(dummyNode);
                dummyNode.setNext(newNode);
            }
        }

    }

    class BackLinkedNode
    {
        private string data;
        private BackLinkedNode next;
        private BackLinkedNode prev;

        public BackLinkedNode(string newData)
        {
            data = newData;
            next = null;
            prev = null;
        }

        public void setNext(BackLinkedNode newNext)
        {
            next = newNext;
        }

        public void setPrev(BackLinkedNode newPrev)
        {
            prev = newPrev;
        }

        public string getData()
        {
            return data;
        }

        public BackLinkedNode getNext()
        {
            return next;
        }

        public BackLinkedNode getPrev()
        {
            return prev;
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
