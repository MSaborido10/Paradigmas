using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game.ObstacleFactory;

namespace Game
{
    public class Obstacle : Character
    {
        public bool active = true;
        public int obstacleID;

        private Animation obstacleAnimation;

        Random rnd = new Random();
        public static Vector2 startPos = new Vector2();

        public Obstacle(Vector2 pos, int sprite) : base(pos, 200)
        {
            transform.position = pos;
            List<Texture> frames = new List<Texture>();
            for (int i = 0; i <= 1; i++)
            {
                frames.Add(Engine.GetTexture($"Animations/ObstacleAnimations/{sprite}.png"));
            }
            obstacleAnimation = new Animation("obstacle01", frames, 1, false);
        }

        public void TopToDownMovement()
        {
            transform.position.y += cSpeed * Program.deltaTime;
        }

        public void Reposition(float posX, float posY)
        {
            transform.position = new Vector2(posX, posY);
            active = true;
        }

        public override void Update()
        {
            TopToDownMovement();           
            if(transform.position.y >= 1080)
            {
                active = false;
            }
            
        }

        public override void Render() 
        {
            Engine.Draw(obstacleAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }

    }
}
