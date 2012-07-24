using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class PriorityQueue
    {
        private int[] priorities;
        private int items;

        public PriorityQueue()
        {
            priorities = new int[1];
            items = 0;
        }

        public void addItem(int newItem)
        {
            priorities[items] = newItem;

            siftUp(items);

            items++;

            if (priorities.Length == items)
            {
                priorities = increaseArraySize(priorities);
            }
        }

        public int removeItem()
        {
            int toReturn = 0;

            toReturn = priorities[0];

            siftDown(0);

            items--;

            return toReturn;
        }

        public void printPQueue()
        {
            Console.Out.WriteLine(toString());
        }

        public bool isEmpty()
        {
            bool toReturn = false;

            if (items == 0)
            {
                toReturn = true;
            }

            return toReturn;
        }

        public string toString()
        {
            string toReturn = "[ ";

            for (int i = 0; i < items; i++)
            {
                if (i == items - 1)
                {
                    toReturn += priorities[i].ToString();
                }
                else
                {
                    toReturn += priorities[i].ToString() + ", ";
                }
            }

            toReturn += " ]";

            return toReturn;
        }

        private void siftDown(int toSift){
            if(toSift < items){
                if (toSift * 2 + 2 < items)
                {
                    if (priorities[toSift * 2 + 1] >= priorities[toSift * 2 + 2])
                    {
                        priorities[toSift] = priorities[toSift * 2 + 1];
                        toSift = toSift * 2 + 1;
                        siftDown(toSift);
                    }
                    else
                    {
                        priorities[toSift] = priorities[toSift * 2 + 2];
                        toSift = toSift * 2 + 2;
                        siftDown(toSift);
                    }
                }
                else if (toSift * 2 + 1 < items)
                {
                    priorities[toSift] = priorities[toSift * 2 + 1];
                    toSift = toSift * 2 + 1;
                    siftDown(toSift * 2 + 1);
                }
                else if (toSift < items - 1)
                {
                    priorities[toSift] = priorities[items - 1];
                    siftUp(toSift);
                }
            }
        }

        private void siftUp(int toSift)
        {
            int tmp = 0;

            if (toSift != 0)
            {
                if (priorities[toSift] > priorities[(toSift - 1) / 2])
                {
                    tmp = priorities[toSift];
                    priorities[toSift] = priorities[(toSift - 1) / 2];
                    priorities[(toSift - 1) / 2] = tmp;

                    siftUp((toSift - 1) / 2);
                }
            }
        }

        private int[] increaseArraySize(int[] old)
        {
            int[] toReturn = new int[old.Length * 2 + 1];

            for (int i = 0; i < old.Length; i++)
            {
                toReturn[i] = old[i];
            }

            return toReturn;
        }

        static void Main(string[] args)
        {
            PriorityQueue pq = new PriorityQueue();
            string input = "";

            while (!input.Equals("exit"))
            {
                Console.Out.WriteLine("Enter a command(add or remove): ");
                input = Console.In.ReadLine();
                if (!input.Equals("exit"))
                {
                    if (input.Equals("add"))
                    {
                        addToPQ(pq);
                    }
                    else if (input.Equals("remove"))
                    {
                        removeFromPQ(pq);
                    }
                    else
                    {
                        Console.Out.WriteLine(input + " is not a valid command");
                    }
                }
            }
            
        }

        private static void removeFromPQ(PriorityQueue pq)
        {
            int removed = 0;

            if (!pq.isEmpty())
            {
                removed = pq.removeItem();
                Console.Out.WriteLine(removed.ToString() + " was removed from the priority queue.");
                pq.printPQueue();
            }
            else
            {
                Console.Out.WriteLine("Priority Queue is empty. No item was removed");
            }
        }

        private static void addToPQ(PriorityQueue pq)
        {
            string input = "";
            int toAdd = 0;
            Console.Out.WriteLine("Enter an integer value you want to add to the priority queue: ");

            input = Console.In.ReadLine();
            if (!input.Equals("none"))
            {
                toAdd = Convert.ToInt32(input);

                pq.addItem(toAdd);

                Console.Out.WriteLine(input + " was added to priority queue.");
                pq.printPQueue();
            }
        }
    }
}
