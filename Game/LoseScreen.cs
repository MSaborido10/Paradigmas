using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LoseScreen : IScenes
    {


        private Promt title;
        private Promt promt;

        public void Initialize()
        {
            CreatePromt();
        }

        public void CreatePromt()
        {
            title = new Promt(5, new Vector2(Program.screenWidth / 2, 100));
            promt = new Promt(2, new Vector2(Program.screenWidth / 2, 500));
        }

        public void Update()
        {
            title.Update();
            promt.Update();
        }

        public void Render()
        {
            title.Render();
            promt.Render();
        }
    }
}
