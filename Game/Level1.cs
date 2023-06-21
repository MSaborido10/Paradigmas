﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level1 : IScenes
    {
        private Player player;
        private Background background = new Background();

        SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
        //myplayer.PlayLooping();
        public List<Character> characterCollisions = new List<Character>();

        private float timer = 0;
        private float timeObjective = 15f;
        private bool hasLost=false;

        public void Initialize()
        {
            ObstacleManager.Instance.Start();
            characterCollisions.Clear();
            ObstacleManager.Instance.OnObstacleCreation += AddToCollisionList;
            player = new Player(new Vector2(960, 540));
        }
        
        public void AddToCollisionList(Obstacle obstacle)
        {
            characterCollisions.Add(obstacle);
        }

        public void SceneUpdate()
        {
            ObstacleManager.Instance.Update();
            LevelConditions();
            LevelEntities();
            background.Update();
        }

        private void WinCondition()
        {
            timer += Program.deltaTime;
            if (timer >= timeObjective)
            {
                GameManager.Instance.WinCondition();
                timer = 0;
            }
        }

        private void LoseCondition()
        {            
            if(hasLost) 
            {
                GameManager.Instance.LoseCondition();
                hasLost = false;
            }
        }

        private void CheckCollision()
        {            
            foreach (var obstacle in characterCollisions)
            {
                if (player.IsBoxColliding(obstacle))
                {
                    Console.WriteLine("choca");
                    hasLost = true;
                }
            }
        }

        private void LevelEntities()
        {
            player.Update();
        }

        private void LevelConditions()
        {
            WinCondition();
            CheckCollision();
            LoseCondition();
        }

        public void SceneRender()
        {
            background.Render();
            player.Render();
            ObstacleManager.Instance.Render();
        }
    }
}
