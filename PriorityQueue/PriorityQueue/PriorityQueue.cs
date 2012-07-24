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
        }


    }
}
