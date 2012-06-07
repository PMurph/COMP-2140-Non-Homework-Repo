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
            testCircularLinkedList();

            testQueue();

            Console.Out.WriteLine("====End of Processing====");
        }

        private static void testQueue()
        {
            Queue q = new Queue();
            string testData = "";

            Console.Out.WriteLine("======>Queue Test 1<======");
            Console.Out.WriteLine(">>Tests whether or not the addItem and removeItem methods work");
            q.addItem("element 1");
            testData = q.removeItem();
            Console.Out.WriteLine("removeItem() returned: " + testData);
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(testData, "element 1") && q.isEmpty());
            Console.Out.WriteLine("");

            Console.Out.WriteLine("======>Queue Test 2<======");
            Console.Out.WriteLine(">>Tests whether or not the getDataAtFront method works");
            q.addItem("element 1");
            q.addItem("element 2");
            q.addItem("element 3");
            q.removeItem();
            testData = q.itemAtFront();
            Console.Out.WriteLine("itemAtFront() returned: " + testData);
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(testData, "element 2") && q.isEmpty() == false);
            Console.Out.WriteLine("");
        }

        private static void testCircularLinkedList()
        {
            CircularLinkedList cll = new CircularLinkedList();

            Console.Out.WriteLine("======>CircularLinkedList Test 1<======");
            Console.Out.WriteLine(">>Tests whether or not the isEmpty method works for any empty CircularLinkedList");
            Console.Out.Write("isEmpty() returned: ");
            Console.Out.WriteLine(cll.isEmpty());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(cll.isEmpty());
            Console.Out.WriteLine("");

            Console.Out.WriteLine("======>CircularLinkedList Test 2<======");
            Console.Out.WriteLine(">>Tests whether or not the insertAtFront method works, the getSize method works and if the isEmpty method works if the CircularLinkedList has elements");
            cll.insertAtFront("node 1");
            cll.insertAtFront("node 2");
            cll.insertAtFront("node 3");
            Console.Out.Write("isEmpty() (on a CircularLinkedList with elements in it) returned: ");
            Console.Out.WriteLine(cll.isEmpty());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(cll.isEmpty() == false && cll.getSize() == 3);
            Console.Out.WriteLine("");

            Console.Out.WriteLine("======>CircularLinkedList Test 3<======");
            Console.Out.WriteLine(">>Tests whether or not the getSize and getDataFromBack methods work");
            Console.Out.Write("getSize() returned: ");
            Console.Out.WriteLine(cll.getSize());
            Console.Out.Write("getDataFromBack() returned: ");
            Console.Out.WriteLine(cll.getDataFromBack());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(String.Equals(cll.getDataFromBack(), "node 1"));
            Console.Out.WriteLine("");

            Console.Out.WriteLine("======>CircularLinkedList Test 4<======");
            Console.Out.WriteLine(">>Tests whether or not the deleteFromBack method worksand if the isEmpty method works on a CircularLinkedList that has had elements but all the elements have been deleted");
            cll.deleteFromBack();
            cll.deleteFromBack();
            cll.deleteFromBack();
            Console.Out.Write("isEmpty() (on a CircularLinkedList with elements in it) returned: ");
            Console.Out.WriteLine(cll.isEmpty());
            Console.Out.Write("Test Passed: ");
            Console.Out.WriteLine(cll.isEmpty());
            Console.Out.WriteLine("");
        }
    }

    class Queue
    {
        CircularLinkedList cll;

        public Queue()
        {
            cll = new CircularLinkedList();
        }

        public void addItem(string newData)
        {
            cll.insertAtFront(newData);
        }

        public string removeItem()
        {
            string toReturn = cll.getDataFromBack();

            cll.deleteFromBack();

            return toReturn;
        }

        public string itemAtFront()
        {
            return cll.getDataFromBack();
        }

        public bool isEmpty()
        {
            return cll.isEmpty();
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

        public int getSize()
        {
            return size;
        }

        public string getDataFromBack()
        {
            string toReturn = null;

            if (size > 0)
            {
                toReturn = dummyNode.getPrev().getData();
            }

            return toReturn;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void deleteFromBack()
        {
            if (size > 0)
            {
                dummyNode.getPrev().getPrev().setNext(dummyNode);
                dummyNode.setPrev(dummyNode.getPrev().getPrev());
                size--;
            }
        }

        public void insertAtFront(string newData)
        {
            BackLinkedNode newNode = null;
            if (!String.Equals(newData, "dUmMy"))
            {
                //If the new data is not the same as the data contained in the dummy node, create a new Node and insert it into the front of the LinkedList
                newNode = new BackLinkedNode(newData);
                newNode.setNext(dummyNode.getNext());
                dummyNode.getNext().setPrev(newNode);
                newNode.setPrev(dummyNode);
                dummyNode.setNext(newNode);
                size++;
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
