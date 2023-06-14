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

        SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
        //myplayer.PlayLooping();
        public List<Character> characterCollisions = new List<Character>();

        public delegate void Events();
        public event Events OnLoss;
        public event Events OnWin;

        private float timer;
        private float timeObjective = 15f;
        private bool hasLost=false;

        public void Initialize()
        {
            timer = 0;
            ObstacleManager.Instance.Start();
            characterCollisions.Clear();
            foreach(var obstacle in ObstacleManager.Instance.obstaclesOnScreen)
            {
                characterCollisions.Add(obstacle);
            }
            OnLoss += LoseCondition;
            OnWin += WinCondition;
            player = new Player(new Vector2(960, 540));           
        }

        public void Update()
        {
            timer += Program.deltaTime;
            Console.WriteLine(timer);
            ObstacleManager.Instance.Update();
            LevelConditions();
            LevelEntities();
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
                OnLoss -= LoseCondition;
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
            OnWin();
            OnLoss();
            CheckCollision();
        }

        public void Render()
        {
            player.playerCharacter.Render();
            ObstacleManager.Instance.Render();
        }
    }
}
