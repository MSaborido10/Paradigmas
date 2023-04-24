using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class WinScreen : Screen
    {
        private Promt title;
        private Promt promt;

        public override void Initialize()
        {
            CreatePromt();
        }

        public override void CreatePromt()
        {
            title = new Promt(4, new Vector2(Program.screenWidth / 2, 100));
            promt = new Promt(2, new Vector2(Program.screenWidth / 2, 500));
        }

        public override void Update()
        {
            title.Update();
            promt.Update();
        }

        public override void Render()
        {
            title.Render();
            promt.Render();
        }
    }
}
