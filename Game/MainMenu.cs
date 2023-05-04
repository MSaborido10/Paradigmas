using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu : Screen, IScenes
    {
        private Promt title;
        private Promt startPromt;

        public override void Initialize()
        {
            CreatePromt();
        }
        public override void CreatePromt()
        {
            title = new Promt(3, new Vector2(Program.screenWidth / 2, 100));
            startPromt = new Promt(1, new Vector2(Program.screenWidth, 500));
        }

        public override void Render()
        {
            title.Render();
            startPromt.Render();
        }

        public void Start()
        {
            Initialize();
        }

        //public void Update()
        //{
            
        //}

        public override void SceneUpdate()
        {
            title.SceneUpdate();
            startPromt.SceneUpdate();
            Render();
        }
    }
}
