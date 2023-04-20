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

        public Character playerCharacter = new Character(pos);
        public Player(Vector2 pos) : base(pos)
        {
            pos = playerCharacter.Transform.position;
        }

        private void Inputs()
        {
            if (Engine.GetKey(Keys.D) && playerCharacter.transform.position.x <= 1920)
            {
                RightMovement();
            }
            else if (Engine.GetKey(Keys.A) && playerCharacter.transform.position.x >= 0)
            {
                LeftMovement();
            }
        }

        public void LeftMovement()
        {
            playerCharacter.transform.position.x -= speed * Program.deltaTime;
        }

        public void RightMovement()
        {
            playerCharacter.transform.position.x += speed * Program.deltaTime;
        }

        public void Start()
        {

        }
        public void Update()
        {            
            Inputs();
        }

    }
}
