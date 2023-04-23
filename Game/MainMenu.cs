using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class MainMenu : Screen
    {
        private Promt title;
        private Promt startPromt;
        public void CreatePromt()
        {
            title = new Promt(3, new Vector2 (100,200));
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
