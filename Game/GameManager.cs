using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        public static Level1 level1;
        public static MainMenu menu1;
        public static WinScreen winScreen;
        public static LoseScreen loseScreen;

        public IScenes[] scenes;

        public IScenes currentScene;

        private bool isInitialized = false;

        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void StartManager()
        {
            isInitialized = false;
            if(!isInitialized)
            {
                currentScene.Start();
                isInitialized = true;
            }
        }

        
        public void SceneChange(int levelIndex)
        {
            Console.WriteLine(scenes[levelIndex]);

            currentScene = scenes[levelIndex];
        }

        public void UpdateManager()
        {
            currentScene.Update();
        }

        public void WinCondition()
        {
            SceneChange(2);
            StartManager();
        }

        public void LoseCondition()
        {
            SceneChange(3);
            StartManager();
        }

        public void InitializeScene()
        {
            menu1 = new MainMenu();
            level1 = new Level1();
            winScreen = new WinScreen();
            loseScreen = new LoseScreen();
            scenes = new IScenes[] { menu1, level1, winScreen, loseScreen };
        }
    }
}
