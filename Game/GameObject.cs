using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameObject
    {
        private Transform transform;
        Animation currentAnimation = null;
        private float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        private float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;




        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }
    }
}
