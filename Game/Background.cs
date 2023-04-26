using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Background : GameObject
    {
        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        Animation currentAnimation = null;
        Animation backgroundAnimation;

        public Background()
        {
            transform.position = new Vector2(Program.screenWidth / 2, Program.screenHeight / 2);
            transform.scale = new Vector2(2, 2);
            List<Texture> frames = new List<Texture>();
            for (int i = 0; i <= 1; i++)
            {
                frames.Add(Engine.GetTexture($"Animations/BackgroundAnimations/{i}.png"));
            }

            backgroundAnimation = new Animation("backgroundAnimation", frames, 0.4f, true);
            currentAnimation = backgroundAnimation;
        }
        public override void Update()
        {
            currentAnimation.Update();
        }
        public override void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }
    }
}
