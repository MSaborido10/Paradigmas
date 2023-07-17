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

        SoundPlayer BG_Music = new SoundPlayer("Sounds/BG_Music.wav");
        SoundPlayer collisionSound = new SoundPlayer("Sounds/car-collision.wav");
        
        public List<Character> characterCollisions = new List<Character>();

        private float timer;
        private float timeObjective = 105f;
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
            BG_Music.Play();
        }
        
        public void AddToCollisionList(Obstacle obstacle)
        {
            characterCollisions.Add(obstacle);
        }

        public void SceneUpdate()
        {
            LevelConditions();
            timer += Program.deltaTime;
            ObstacleManager.Instance.Update();
            player.Update();                       
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
                BG_Music.Stop();
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
                    if (player.currentLives > 0)
                    {
                        player.TakeDamage();                    
                        //collisionSound.Play();

                    }
                    else
                    {
                        hasLost = true;
                    }                     
                }
            }
        }

        //private void LevelEntities()
        //{
        //    player.Update();
        //}

        private void LevelConditions()
        {
            WinCondition();
            if (player.inmunity == false) { CheckCollision(); }        
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
