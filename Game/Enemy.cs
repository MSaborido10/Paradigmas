using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {

        public static Vector2 pos = new Vector2();

        public Character enemyCharacters = new Character(pos);
        public Enemy() 
        {
            pos = enemyCharacters.Transform.position;
        }

        private void EnemyMovement()
        {
            enemyCharacters.TopToDownMovement();            
        }

        public void Start()
        {

        }
        public void Update()
        {
            EnemyMovement();

            if(enemyCharacters.transform.position.y >= 1080)
            {
                enemyCharacters.Reposition(960,0);
            }
        }
    }
}
