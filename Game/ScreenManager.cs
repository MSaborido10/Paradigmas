using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ScreenManager
    {
        //private static ScreenManager instance;
        //public static ScreenManager Instance { get { if (instance == null) { instance = new ScreenManager(); } return instance; } }


        //private Menu[] menus = new Menu[3];
        //private int currentScreen = Program.screen;

        //private Menu menu;

        //private void LoadScreens()
        //{
        //    menus[0] = new Menu(1);
        //    menus[1] = new Menu(2);
        //    menus[2] = new Menu(3);
        //}

        //public void Update()
        //{
        //    if (currentScreen > 0 && currentScreen !=1)
        //    {
        //        menus[currentScreen-1].Update();
        //    }
        //    else if (currentScreen == 0)
        //    {
        //        menus[currentScreen].Update();
        //    }
        //}



        //public void Render()
        //{
        //    if (currentScreen > 0 && currentScreen != 1)
        //    {
        //        menus[currentScreen - 1].Render();
        //    }
        //    else if (currentScreen == 0)
        //    {
        //        menus[currentScreen].Render();
        //    }
        //}




        private static ScreenManager instance;
        public static ScreenManager Instance { get { if (instance == null) { instance = new ScreenManager(); } return instance; } }


        private Screen[] screens = new Screen[4];
        public int currentScreen;
        private int currentScreen2;
        //public int CurrentScreen { get { return currentScreen; } set { currentScreen = value; } }

        private MainMenu mainMenu;
        private Level level;
        private WinScreen winScreen;
        private GameOverScreen gameOverScreen;

        private void LoadScreens()
        {
            screens[0] = mainMenu;
            screens[1] = level;
            screens[2] = winScreen;
            screens[3] = gameOverScreen;
        }

        public void Initialize()
        {
            currentScreen = 0;
            mainMenu = new MainMenu();
            mainMenu.Initialize();
            level = new Level();
            winScreen = new WinScreen();
            gameOverScreen = new GameOverScreen();

            LoadScreens();
        }

        public void Update()
        {
            if (currentScreen2 != currentScreen)
            {
                Initialize();
                screens[currentScreen].Initialize();
                currentScreen2 = currentScreen;
            }
            else if (currentScreen2 == currentScreen)
            {
                screens[currentScreen].Update();
            }
        }

        public void Render()
        {
            if (currentScreen2 == currentScreen)
            {
                screens[currentScreen].Render();
            }
        }

        public void GameOver(bool win)
        {
            if (win)
            {
                currentScreen = 2;
            }
            else {currentScreen = 3;}
        }

    }
}
