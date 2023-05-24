using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LoseScreen : Screen, IScenes
    {
        private Promt title;
        private Promt promt;

        public override void Initialize()
        {
            CreatePromt();
        }
        public void Start()
        {
            Initialize();
        }

        public override void CreatePromt()
        {
            title = new Promt(5, new Vector2(Program.screenWidth / 2, 100));
            promt = new Promt(2, new Vector2(Program.screenWidth / 2, 500));
        }

        public override void SceneUpdate()
        {
            title.SceneUpdate();
            promt.SceneUpdate();
        }

        public void Update()
        {
            title.Render();
            promt.Render();
            Render();

        }

        public override void Render()
        {

        }
    }
}
