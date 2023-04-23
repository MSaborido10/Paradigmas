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
        private Obstacle obstacle;

        SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
        //myplayer.PlayLooping();
        public List<Character> characterCollisions = new List<Character>();

        private float timer = 0;
        private float timeObjective = 15f;

        public void Start()
        {
            player = new Player(new Vector2(960, 540));
            obstacle = new Obstacle(new Vector2(960, 100));
            characterCollisions.Add(player);
            characterCollisions.Add(obstacle);
        }

        public void Update()
        {
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
            Console.WriteLine("CondicionDeDerrota");
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
            obstacle.Update();
        }

        private void LevelConditions()
        {
            WinCondition();
            CheckCollision();
        }

        private void Draw()
        {
            Engine.Clear();
            player.playerCharacter.Render();
            obstacle.enemyCharacters.Render();
            Engine.Show();
        }
    }
}
