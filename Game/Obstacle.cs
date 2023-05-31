using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Obstacle : Character, IObstacle
    {
        public bool active = false;
        public bool waitingToSpawn = false;
        public int obstacleID;

        Random rnd = new Random();
        public static Vector2 startPos = new Vector2();

       
        public Obstacle(Vector2 pos) : base(pos, 200)
        {
            transform.position = pos;
            startPos = pos;
        }

        public void TopToDownMovement()
        {
            transform.position.y += cSpeed * Program.deltaTime;
        }

        public void Reposition(float posX, float posY)
        {
            transform.position = new Vector2(posX, posY);
        }

        public void Reset()
        {
            transform.position = startPos;
        }

        public override void Update()
        {
            TopToDownMovement();           
            if(transform.position.y >= 1080)
            {
                Reposition(rnd.Next(100,1820),0);
                transform.position.y = 0;
            }
        }
    }
}
