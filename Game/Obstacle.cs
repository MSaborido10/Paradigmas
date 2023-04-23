using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Obstacle : Character
    {

        public static Vector2 pos = new Vector2();

        public Character enemyCharacters = new Character(pos);
        public Obstacle(Vector2 pos) : base(pos)
        {
            pos = enemyCharacters.Transform.position;
        }

        private void EnemyMovement()
        {
            TopToDownMovement();      
        }

        public void Start()
        {

        }

        public void TopToDownMovement()
        {
            enemyCharacters.transform.position.y++;
        }

        public void Reposition(float posX, float posY)
        {
            enemyCharacters.transform.position = new Vector2(posX, posY);
        }

        public override void Update()
        {
            EnemyMovement();

            if(enemyCharacters.transform.position.y >= 1080)
            {
                Reposition(960,0);
            }
        }
    }
}
