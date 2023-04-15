using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        public static Vector2 pos = new Vector2();

        public Character playerCharacter = new Character(pos);
        public Player()
        {
            pos = playerCharacter.Transform.position;
        }

        private void Inputs()
        {
            if (Engine.GetKey(Keys.D))
            {
                playerCharacter.RightMovement();
            }
            else if (Engine.GetKey(Keys.A))
            {
                playerCharacter.LeftMovement();
            }
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
