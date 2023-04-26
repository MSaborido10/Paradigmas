using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : Character
    {
        public static Vector2 pos = new Vector2();

        public Character playerCharacter = new Character(pos, 0);

        //private List<Texture> frames = new List<Texture>();

        private Animation currentAnimation = null;
        private Animation alive;
        public Player(Vector2 pos) : base(pos, 1000)
        {
            playerCharacter.transform.position = pos;

            List<Texture> frames = new List<Texture>();
            for (int i = 0; i <= 1; i++)
            {
                frames.Add(Engine.GetTexture($"Animations/PlayerAnimations/{i}.png"));
            }

            alive = new Animation("alive", frames, 1, true);
            currentAnimation = alive;
        }

        private void Inputs()
        {
            if (Engine.GetKey(Keys.D) && playerCharacter.transform.position.x + RealWidth <= 1920)
            {
                RightMovement();
            }
            else if (Engine.GetKey(Keys.A) && playerCharacter.transform.position.x - RealWidth >= 0)
            {
                LeftMovement();
            }
        }

        public void LeftMovement()
        {
            transform.position.x -= cSpeed * Program.deltaTime;
            playerCharacter.transform.position.x = transform.position.x;

        }

        public void RightMovement()
        {
            transform.position.x += cSpeed * Program.deltaTime;
            playerCharacter.transform.position.x = transform.position.x;
        }

        public void Start()
        {

        }
        public void Update()
        {
            Inputs();
        }

        public override void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }

    }
}
