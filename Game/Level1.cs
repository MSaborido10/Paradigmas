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

        public void Initialize()
        {
            player = new Player(new Vector2(960, 540));
            characterCollisions.Add(player);
            ObstacleManager.Instance.Start();
            foreach(var obstacle in ObstacleManager.Instance.obstaclesOnScreen)
            {
                characterCollisions.Add(obstacle);
            }
           
        }

        public void Update()
        {
            LevelConditions();
            ObstacleManager.Instance.Update();
            LevelEntities();
            Render();
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
            GameManager.Instance.LoseCondition();            
        }

        private void CheckCollision()
        {            
            foreach (var character in characterCollisions)
            {
                for (int i = 0; i < characterCollisions.Count; i++)
                {
                    if (character != characterCollisions[i])
                    {
                        if (character.IsBoxColliding(characterCollisions[i]))
                        {
                            LoseCondition();
                        }
                    }                        
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
        }

        public void Render()
        {
            Engine.Clear();
            player.playerCharacter.Render();
            ObstacleManager.Instance.Render();
            Engine.Show();
        }
    }
}
