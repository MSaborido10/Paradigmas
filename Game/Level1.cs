using System;
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

        private float timer;
        private float timeObjective = 15f;
        private bool hasLost=false;

        public delegate void Events();
        public event Events OnLoss;
        public event Events OnWin;


        public void Initialize()
        {
            timer = 0;
            ObstacleManager.Instance.Start();
            characterCollisions.Clear();
            ObstacleManager.Instance.OnObstacleCreation += AddToCollisionList;
            OnLoss += LoseCondition;
            OnWin += WinCondition;
            player = new Player(new Vector2(960, Program.screenHeight-250));
        }
        
        public void AddToCollisionList(Obstacle obstacle)
        {
            characterCollisions.Add(obstacle);
        }

        public void SceneUpdate()
        {
            timer += Program.deltaTime;
            ObstacleManager.Instance.Update();
            LevelConditions();
            LevelEntities();
            background.Update();
        }

        private void WinCondition()
        {            
            if (timer >= timeObjective)
            {
                OnWin -= WinCondition; 
                timer = 0;
                GameManager.Instance.WinCondition();
            }
        }

        private void LoseCondition()
        {            
            if(hasLost) 
            {
                timer = 0;
                hasLost = false;
                OnLoss -= WinCondition;
                GameManager.Instance.LoseCondition();
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
