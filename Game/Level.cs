using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level : Screen
    {
        private Player player;
        private Obstacle obstacle;

        SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
        //myplayer.PlayLooping();
        public List<Character> characterCollisions = new List<Character>();

        private float timer = 0;
        private float timeObjective = 15f;

        public override void Initialize()
        {
            player = new Player(new Vector2(960, 540));
            ObstacleManager.Instance.Start();
            foreach (var obstacle in ObstacleManager.Instance.obstaclesOnScreen)
            {
                characterCollisions.Add(obstacle);
            }
            LevelReset();
        }


        public override void Update()
        {
            LevelConditions();
            ObstacleManager.Instance.Update();
            LevelEntities();
        }

        private void WinCondition()
        {
            timer += Program.deltaTime;
            if (timer >= timeObjective)
            {
                ScreenManager.Instance.GameOver(true);
                timer = 0;
            }
        }


        private void LevelReset()
        {
            foreach (var obstacle in ObstacleManager.Instance.obstaclesOnScreen)
            {
                obstacle.Reposition(obstacle.transform.position.x, Program.screenHeight);
            }
        }

        private void LoseCondition()
        {
            ScreenManager.Instance.GameOver(false);
        }

        private void CheckCollision()
        {

            foreach (var character in characterCollisions)
            {
                for (int i = 0; i < characterCollisions.Count; i++)
                {
                    if (character != characterCollisions[i])
                    {
                        if (character.IsBoxColliding(player))
                        {
                            LoseCondition();
                            
                        }
                    }
                }
            }
        }


        private void LevelEntities()//Esto ya se ejecuta en el update
        {
            player.Update();
        }

        private void LevelConditions()//Esto ya se ejecuta en el update
        {
            WinCondition();
            CheckCollision();
        }

        public override void Render()
        {
            player.playerCharacter.Render();
            //obstacle.enemyCharacters.Render();
            ObstacleManager.Instance.Render();
        }
    }
}

