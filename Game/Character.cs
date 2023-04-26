using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character : GameObject
    {
        protected float cSpeed = 100f;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        Animation currentAnimation = null;
        Animation idle;

        public Character(Vector2 initialPos, float speed)
        {
            idle = CreateAnimation("Idle", "", 4, 2);
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            cSpeed = speed;
            currentAnimation = idle;
            currentAnimation.Reset();
        }

        public void Start()
        {

        }

        public override void Update()
        {
            currentAnimation.Update();
        }

        public override void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }


        private Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed)
        {
            // Idle Animation
            List<Texture> animationFrames = new List<Texture>();

                animationFrames.Add(Engine.GetTexture($"{p_path}{0}.png"));
        

            Animation animation = new Animation(p_animationID, animationFrames, p_animationSpeed, true);

            return animation;
        }

      


        public bool IsBoxColliding(Character p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.transform.position.y);

            float sumHalfWidths = RealWidth / 2 + p_objB.RealWidth / 2;
            float sumHalfHeights = RealHeight / 2 + p_objB.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }


    }
}
