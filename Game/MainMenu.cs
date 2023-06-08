using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu : IScenes
    {
        private Promt title;
        private Promt startPromt;

        public void Initialize()
        {
            CreatePromt();
        }
        public void CreatePromt()
        {
            title = new Promt(3, new Vector2(Program.screenWidth / 2, 100));
            startPromt = new Promt(1, new Vector2(Program.screenWidth, 500));
        }

        public  void SceneRender()
        {
            title.Render();
            startPromt.Render();
        }


        public void SceneUpdate()
        {
            title.Update();
            startPromt.Update();
        }
    }
}
