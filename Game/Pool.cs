using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Pool <id, item>
    {
        private Queue<item> poolElements;
        private Func<id, item> CallFactory;

        public Pool (Func<id, item> callFactory)
        {
            poolElements = new Queue<item> ();

            CallFactory = callFactory;
        }

        public item GetItem(id ID)
        {
            item Item;

            if (poolElements.Count > 0)
            {
                Item = poolElements.Dequeue();
            }
            else
            {
                Item = CallFactory(ID);
            }

            return Item;
        }

        public void AddItem(item Item)
        {
            poolElements.Enqueue(Item);
        }
    }
}
