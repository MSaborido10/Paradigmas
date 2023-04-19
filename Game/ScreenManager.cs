using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class ScreenManager
    {
        private static ScreenManager instance;
        public static ScreenManager Instance { get { if (instance == null) { instance = new ScreenManager(); } return instance; } }


        private Menu[] menus = new Menu[3];
        private int currentScreen = Program.screen;

        private Menu menu;

        private void LoadScreens()
        {
            menus[0] = new Menu(1);
            menus[1] = new Menu(2);
            menus[2] = new Menu(3);
        }

        public void Update()
        {
            if (currentScreen > 0 && currentScreen !=1)
            {
                menus[currentScreen-1].Update();
            }
            else if (currentScreen == 0)
            {
                menus[currentScreen].Update();
            }
        }



        public void Render()
        {
            if (currentScreen > 0 && currentScreen != 1)
            {
                menus[currentScreen - 1].Render();
            }
            else if (currentScreen == 0)
            {
                menus[currentScreen].Render();
            }
        }




        //private static ScreenManager instance;
        //public static ScreenManager Instance { get {if (instance == null) { instance = new ScreenManager();} return instance; } }


        //private Screen[] screens = new Screen[4];
        //private int currentScreen = 0;        
        //public int CurrentScreen {get{return CurrentScreen;} set{ currentScreen = CurrentScreen;}}

        //private MainMenu mainMenu;

        //private void LoadScreens()
        //{
        //    screens[0] = mainMenu;
        //}

        //public void Initialize()
        //{
        //    mainMenu = new MainMenu();
        //    mainMenu.CreatePromt();
        //}

        //public void Update() 
        //{
        //   screens[currentScreen].Update();

        //   if (mainMenu.KeyWasPressed == true)
        //   {
        //    Engine.Debug("Change screen");
        //   }

        // }



        //public void Render()
        //{
        //    screens[currentScreen].Render();
        //}

    }
}
