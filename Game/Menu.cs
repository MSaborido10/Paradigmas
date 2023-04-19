using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Menu
    {
        private Promt menuPromt;
        private int promtType;


        public Menu(int promtType)
        {
            this.promtType = promtType;
            CreateflashPromt();

        }

        public void CreateflashPromt()
        {
            menuPromt = new Promt(promtType, new Vector2(150, 150));
        }

        public void Render()
        {


            menuPromt.Render();

        }

        public void Update()
        {

            menuPromt.Update();

            if (Engine.GetKey(Keys.SPACE))
            {
                if (promtType == 1)
                {
                    Program.screen = 1;
                }
                else {Program.screen = 0;}
                
            }
        }

    }

}

