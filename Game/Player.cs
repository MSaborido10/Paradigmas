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

        //public Character playerCharacter = new Character(pos, 0);

        //private List<Texture> frames = new List<Texture>();

        private int totalLives = 3;

        public int currentLives;

        public int totalDeaths = 0;

        public bool inmunity = false;

        private float inmunityTime = 0;

        public int animation;
        private Animation currentAnimation = null;
        private Animation alive;
        private Animation inmune;
        public Player(Vector2 pos) : base(pos,800)
        {
            transform.position = pos;

            List<Texture> frames = new List<Texture>();
            frames.Add(Engine.GetTexture($"Animations/PlayerAnimations/0.png"));
            alive = new Animation("alive", frames, 1, false);


            List<Texture> inmunityFrames = new List<Texture>();
            for (int i = 0; i <= 1; i++)
            {
                inmunityFrames.Add(Engine.GetTexture($"Animations/PlayerAnimations/{i}.png"));
            }

            inmune = new Animation("inmune", inmunityFrames, 0.3f, true);
            
            
            currentAnimation = alive;

            //currentAnimation.Reset();
        }

        private void Inputs()
        {
            if (Engine.GetKey(Keys.D) && transform.position.x + RealWidth <= 1380)
            {
                RightMovement();
            }
            else if (Engine.GetKey(Keys.A) && transform.position.x - RealWidth >= 190)
            {
                LeftMovement();
            }
        }

        public void LeftMovement()
        {
            transform.position.x -= cSpeed * Program.deltaTime;
            //playerCharacter.transform.position.x = transform.position.x;

        }

        public void RightMovement()
        {
            transform.position.x += cSpeed * Program.deltaTime;
            //playerCharacter.transform.position.x = transform.position.x;
        }

        public int ActualLives(int lives, int deaths)
        {
            int result = lives - deaths;
            return result;
        }

        public void InmunityTimer()
        {
            float timeLimit = 120;
            if (inmunity)
            {  
                if (inmunityTime < timeLimit)
                {
                    inmunityTime++;
                }
                else if (inmunityTime >= timeLimit)
                {
                    inmunity = false;
                }
            }
            else 
            {
                inmunityTime = 0; 
            }
        }

        public override void Update()
        {
            currentAnimation.Update();
            if (inmunity && currentAnimation != inmune) 
            { 
                currentAnimation = inmune;
            }
            else if (inmunity == false && currentAnimation != alive)
            {
                currentAnimation = alive;
            }
            Inputs();
            if (currentLives != ActualLives(totalLives, totalDeaths))
            {
                currentLives = ActualLives(totalLives, totalDeaths);
            };
            InmunityTimer();            
            //Console.WriteLine("Lives = "+currentLives);
            //Console.WriteLine("time = " + inmunityTime);
            //Console.WriteLine("animation =" + animation);
        }

        public override void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }

    }
}
