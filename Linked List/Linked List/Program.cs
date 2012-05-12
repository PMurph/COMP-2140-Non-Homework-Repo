using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    class Program
    {

        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();

            NodeString toAdd = new NodeString("first");
            ll.AddNode(toAdd);
            toAdd = new NodeString("2nd");
            ll.AddNode(toAdd);
            toAdd = new NodeString("third");
            ll.AddToBack(toAdd);
            toAdd = new NodeString("4th");
            ll.AddAt(2, toAdd);
            toAdd = new NodeString("5th");
            ll.AddAt(7, toAdd);
            Console.WriteLine(ll.ToString());
            ll.Delete();
            ll.DeleteAt(8);
            ll.DeleteFromEnd();

            Console.WriteLine(ll.ToString());
            Console.WriteLine("");
            Console.WriteLine("======End of Program======");
        }
    }

    public class LinkedList
    {
        private Node top;
        private Node last;
        private int size;

        public LinkedList()
        {
            top = null;
            last = null;
            size = 0;
        }

        public int GetSize()
        {
            return size;
        }

        public void AddNode(NodeString dataToAdd)
        {
            Node toAdd = new Node(dataToAdd);

            if (top == null)
            {
                top = toAdd;
                last = toAdd;
            }
            else
            {
                toAdd.SetNext(top);

                top = toAdd;
            }
            size++;
        }

        public void AddToBack(NodeString dataToAdd)
        {
            Node toAdd = new Node(dataToAdd);

            if (top == null)
            {
                top = toAdd;
                last = toAdd;
            }
            else
            {
                last.SetNext(toAdd);
            }
            size++;
        }

        public void AddAt(int index, NodeString dataToAdd)
        {
            int count = 0;
            Node currNode = top;
            Node toAdd = new Node(dataToAdd);

            while (currNode != null && count < index)
            {
                count++;
                currNode = currNode.GetNext();
            }

            if (currNode != null && count == index - 1)
            {
                if (currNode.GetNext() != null)
                {
                    toAdd.SetNext(currNode.GetNext());
                    currNode.SetNext(toAdd);
                }
                else
                {
                    currNode.SetNext(toAdd);
                    last = toAdd;
                }
                size++;
            }
        }

        public void DeleteAt(int position)
        {
            int count = 0;
            Node currNode = top;

            while (count < position && currNode != null)
            {
                count++;
                currNode = currNode.GetNext();
            }

            if (currNode != null && count == position - 1)
            {
                if (currNode.GetNext() != null)
                {
                    if (currNode.GetNext().GetNext() != null)
                    {
                        currNode.SetNext(currNode.GetNext().GetNext());
                    }
                    else
                    {
                        currNode.SetNext(null);
                        last = currNode;
                    }
                    size--;
                }
            }
        }

        public void Delete()
        {
            if (top != null)
            {
                if (top.GetNext() != null)
                {
                    top = top.GetNext();
                }
                else
                {
                    top = null;
                    last = null;
                }
                size--;
            }
        }

        public void DeleteFromEnd()
        {
            Node prevNode = null;
            Node currNode = top;

            if (currNode != null)
            {
                if (currNode.GetNext() != null)
                {
                    while (currNode.GetNext() != null)
                    {
                        prevNode = currNode;
                        currNode = currNode.GetNext();
                    }

                    prevNode.SetNext(null);
                    last = prevNode;
                }
                else
                {
                    top = null;
                    last = null;
                }
                size--;
            }
        }

        public Object getDataAt(int index)
        {
            int count = 0;
            Node currNode = top;

            while (currNode != null && count < index)
            {
                currNode = currNode.GetNext();
                count++;
            }

            if (currNode != null && currNode.GetNext() != null && count == index - 1)
            {
                return currNode.GetNext().GetData();
            }
            else
            {
                return null;
            }
        }

        public String ToString()
        {
            String toReturn = "[ ";
            Node currNode = top;

            while (currNode != null)
            {
                if (currNode.GetNext() != null)
                {
                    toReturn += currNode.ToString() + ", ";
                }
                else
                {
                    toReturn += currNode.ToString();
                }
                currNode = currNode.GetNext();
            }

            toReturn += " ]";

            return toReturn;
        }
    }

    public class Node
    {
        private NodeString data;
        private Node nextNode;

        public Node(NodeString data)
        {
            this.data = data;
            nextNode = null;
        }

        public void SetData(NodeString newData)
        {
            this.data = newData;
        }

        public void SetNext(Node newNext)
        {
            nextNode = newNext;
        }

        public NodeString GetData()
        {
            return data;
        }

        public Node GetNext()
        {
            return nextNode;
        }
        
        public String ToString()
        {
            if(data == null)
            {
                return "null";
            }else{
                return data.ToString();
            }
        }

        public bool Equals(Object toCompare)
        {
            return toCompare.Equals(toCompare);
        }
    }

    public class NodeString
    {
        private String content;

        public NodeString(String initial)
        {
            content = initial;
        }

        public String ToString()
        {
            return content;
        }

        public bool Equals(Object toCompare)
        {
            bool toReturn = false;

            if (toCompare.GetType().Equals(toCompare.GetType()))
            {
                if (content.Equals(toCompare.ToString()))
                {
                    toReturn = true;
                }
            }

            return toReturn;
        }
    }
}
