using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Screen : GameObject
    {
        public List<GameObject> objectsOnScreen;

        public virtual void Initialize() { }

        public virtual void CreatePromt() { }
        protected virtual void LoadObjectsOnScreen() { }

    }
}
