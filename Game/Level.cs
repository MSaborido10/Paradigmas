using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level: Screen
    {
        private Player player;
        private Obstacle obstacle;

        SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
        //myplayer.PlayLooping();
        public List<Character> characterCollisions = new List<Character>();

        private float timer = 0;
        private float timeObjective = 15f;
        private ScreenManager screenManager = new ScreenManager();

        public override void Initialize()
        {
                player = new Player(new Vector2(960, 540));
                obstacle = new Obstacle(new Vector2(960, 100));
                characterCollisions.Add(player);
                characterCollisions.Add(obstacle);
        }


        public override void Update()
        {
            LevelConditions();
            LevelEntities();
        }

        private void WinCondition()
        {
            timer += Program.deltaTime;
            if (timer >= timeObjective)
            {
                timer = 0;
                ScreenManager.Instance.GameOver(true);
                Engine.Debug("You Win!");
            }
        }

        private void LoseCondition()
        {
            Console.WriteLine("CondicionDeDerrota");
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
                        if (character.IsBoxColliding(characterCollisions[i]))
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
            obstacle.Update();
            //Engine.Debug("Level Update done");
        }

        private void LevelConditions()//Esto ya se ejecuta en el update
        {
            WinCondition();
            CheckCollision();
        }

        public override void Render()
        {
            player.playerCharacter.Render();
            obstacle.enemyCharacters.Render();
        }
    }
}

