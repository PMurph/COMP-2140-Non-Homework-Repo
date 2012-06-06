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
        Node dummyNode;
        int size;

        public CircularLinkedList()
        {
            dummyNode = new Node("dUmMy");
            dummyNode.setNext(dummyNode);
            size = 0;
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
