using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class MainMenu
    {
        private Promt startPromt;
        private bool keyWasPressed;
        public bool KeyWasPressed { get { return keyWasPressed;}}

        public void CreatePromt()
        {
            startPromt = new Promt(1, new Vector2(150, 150));
        }

        public void Render() {
          
          
          startPromt.Render();

        }

        public void Update()
        {
            
            startPromt.Update();

            if (Engine.GetKey(Keys.SPACE))
            {
                keyWasPressed = true;
            }
        }

    }
}
