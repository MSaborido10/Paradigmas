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

        private float timer = 0;
        private float timeObjective = 15f;
        private bool hasLost=false;

        public void Start()
        {
            ObstacleManager.Instance.Start();
            characterCollisions.Clear();
            foreach(var obstacle in ObstacleManager.Instance.obstaclesOnScreen)
            {
                characterCollisions.Add(obstacle);
            }
            player = new Player(new Vector2(960, 540));
           
        }

        public void SceneUpdate()
        {
            ObstacleManager.Instance.Update();
            LevelConditions();
            LevelEntities();
            Draw();
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
            LoseCondition();
            CheckCollision();
        }

        private void Draw()
        {
            Engine.Clear();
            player.playerCharacter.Render();
            ObstacleManager.Instance.Render();
            Engine.Show();
        }
    }
}
