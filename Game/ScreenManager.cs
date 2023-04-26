using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public static ScreenManager Instance { get { if (instance == null) { instance = new ScreenManager(); } return instance; } }


        private Screen[] screens = new Screen[4];
        public int currentScreen;
        private int currentScreen2;

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
            else { currentScreen = 3; }
        }

    }
}
