using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Promt
    {
        private Transform transform;

        private float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        private float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public Transform Transform => transform;

        private int animationID;

        private List<Texture> frames = new List<Texture>();

        Animation currentAnimation = null;
        Animation startPromt;

        public Promt(int animation_number, Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            if (animation_number == 1)
            {
                List<Texture> frames = new List<Texture>();
                for (int i = 0; i <= 1; i++)
                {
                    frames.Add(Engine.GetTexture($"Animations/MenuPrompt/{i}.png"));
                    Engine.Debug($"Loaded texture {i}");
                }

                startPromt = new Animation("startPromt", frames, 1, true);
                currentAnimation = startPromt;
            }
        }

        public void Update()
        {
            currentAnimation.Update();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }

    }
}
