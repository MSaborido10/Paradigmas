﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager: IUpdate, IRender
    {
        public static Level1 level1;
        public static MainMenu menu1;
        public static WinScreen winScreen;
        public static LoseScreen loseScreen;

        public IScenes[] scenes;

        public IScenes currentScene;

        //public IUpdateAndRender updateAndRender;

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

  

        
        public void SceneChange(int levelIndex)
        {
            if(currentScene != scenes[levelIndex])
            {
                currentScene = scenes[levelIndex];
            }

            currentScene.Initialize();
        }

        public void Update()
        {
            currentScene.SceneUpdate();
        }

        public void Render()
        {
            currentScene.SceneRender();
        }

        public void WinCondition()
        {
            SceneChange(2);
        }

        public void LoseCondition()
        {
            SceneChange(3);
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
