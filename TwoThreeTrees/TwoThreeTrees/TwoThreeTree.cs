using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoThreeTrees
{
    class TwoThreeTree
    {


        static void Main(string[] args)
        {
        }
    }

    class TwoThreeNode
    {
        private bool twoNode;
        private TwoThreeNode left;
        private TwoThreeNode mid;
        private TwoThreeNode right;
        private int firstKey;
        private int secondKey;

        //======Constructors======

        public TwoThreeNode(TwoThreeNode l, TwoThreeNode m, int k1)
        {
            twoNode = true;
            left = l;
            mid = m;
            firstKey = k1;
        }

        public TwoThreeNode(TwoThreeNode l, TwoThreeNode m, TwoThreeNode r, int k1, int k2)
        {
            twoNode = false;
            left = l;
            mid = m;
            right = r;
            firstKey = k1;
            secondKey = k2;
        }

        //======Accessors======

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
