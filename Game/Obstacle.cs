using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Obstacle : Character
    {
        public bool active = false;
        public bool waitingToSpawn = false;
        public int obstacleID;

        Random rnd = new Random();
        public static Vector2 pos = new Vector2();

        public Character enemyCharacters = new Character(pos, 0);
        public Obstacle(Vector2 pos) : base(pos, 200)
        {
            enemyCharacters.transform.position = pos;
        }

        private void EnemyMovement()
        {
            TopToDownMovement();      
        }

        public void Start() { }

        public void TopToDownMovement()
        {
            transform.position.y += cSpeed * Program.deltaTime;
            enemyCharacters.transform.position.y = transform.position.y;
        }

        public void Reposition(float posX, float posY)
        {
            enemyCharacters.transform.position = new Vector2(posX, posY);
        }

        public override void UpdateAlt()
        {
            EnemyMovement();           
            transform.position.x = enemyCharacters.transform.position.x;
            if(enemyCharacters.transform.position.y >= 1080)
            {
                Reposition(rnd.Next(100,1820),0);
                transform.position.y = 0;
            }
        }
    }
}
