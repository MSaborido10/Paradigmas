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

        private IScenes currentScene;

        //private IScenes[] scenes = {}

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
            if (!isInitialized)
            {
                currentScene.Start();
                isInitialized = true;
            }
        }

        public void SceneChange(int levelIndex)
        {

        }

        public void UpdateManager()
        {
            currentScene.Update();
        }

        public void WinCondition()
        {
            Console.WriteLine("Ganaste pibe, sos un crack");
        }

        public void LoseCondition()
        {
            level1 = new Level1();
            StartManager();
        }

        public void InitializeScene()
        {
            level1 = new Level1();
            currentScene = level1;
        }
    }
}
