using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu : Screen
    {
        private Promt title;
        private Promt startPromt;

        public override void Initialize()
        {
            CreatePromt();
        }
        public void CreatePromt()
        {
            title = new Promt(3, new Vector2 (Program.screenWidth/2,100));
            startPromt = new Promt(1, new Vector2(250, 250));
        }

        public override void Render() {

          title.Render();
          startPromt.Render();

        }

        public override void Update()
        {
            title.Update();
            startPromt.Update();
        }

    }
}
