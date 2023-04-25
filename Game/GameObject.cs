using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameObject
    {
        public Transform transform;
        public virtual void Update() { }
        public virtual void Render() { }
    }
}
