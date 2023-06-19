using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Promt : GameObject
    {
        private float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        private float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        private List<Texture> frames = new List<Texture>();

        Animation currentAnimation = null;
        Animation startPromt;
        Animation continuePromt;
        Animation mainTitle;
        Animation winTitle;
        Animation gameoverTitle;

        public Promt(int animation_number, Vector2 initialPos)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));
            switch (animation_number)
            {
                case 1:
                    List<Texture> frames = new List<Texture>();
                    for (int i = 0; i <= 1; i++)
                    {
                        frames.Add(Engine.GetTexture($"Animations/MenuPrompt/{i}.png"));
                    }

                    startPromt = new Animation("startPromt", frames, 1, true);
                    currentAnimation = startPromt;
                    break;

                case 2:
                    List<Texture> frames2 = new List<Texture>();
                    for (int i = 0; i <= 1; i++)
                    {
                        frames2.Add(Engine.GetTexture($"Animations/ContinuePromt/{i}.png"));
                    }
                    continuePromt = new Animation("continuePromt", frames2, 1, true);
                    currentAnimation = continuePromt;
                    break;

                case 3:
                    List<Texture> frames3 = new List<Texture>();
                    frames3.Add(Engine.GetTexture($"Animations/Titles/{0}.png"));
                    mainTitle = new Animation("mainTitle", frames3, 2, false);
                    currentAnimation = mainTitle;
                    break;

                case 4:
                    List<Texture> frames4 = new List<Texture>();
                    frames4.Add(Engine.GetTexture($"Animations/Titles/{1}.png"));
                    winTitle = new Animation("winTitle", frames4, 2, false);
                    currentAnimation = winTitle;
                    break;

                case 5:
                    List<Texture> frames5 = new List<Texture>();
                    frames5.Add(Engine.GetTexture($"Animations/Titles/{2}.png"));
                    gameoverTitle = new Animation("gameoverTitle", frames5, 2, false);
                    currentAnimation = gameoverTitle;
                    break;
            }
        }

        public override void Update()
        {
            currentAnimation.Update();

            if (Engine.GetKey(Keys.SPACE))
            {
                GameManager.Instance.SceneChange(1);
            }
        }

        public override void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }
    }
}
