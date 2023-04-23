using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;

namespace Game
{
    public class Program
    {
        //variables deltatime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;
        private static int screenWidth = 1920;
        private static int screenHeight = 1080;


        static Animation currentAnimation = null;
        static Animation idle;

        

        static void Main(string[] args)
        {
            Engine.Initialize("Pruebas", screenWidth, screenHeight);
            GameManager.Instance.InitializeScene();
            GameManager.Instance.StartManager();

            while (true)
            {
                calcDeltatime();
                GameManager.Instance.UpdateManager();
                //Update();
                //Draw();
            }
        }

        //static void Update()
        //{
        //    foreach (var character in characters)
        //    {
        //        for (int i = 0; i < characters.Count; i++)
        //        {
        //            if (character != characters[i])
        //                if (character.IsBoxColliding(characters[i]))
        //                {
        //                    Engine.Debug("ESTOY COLISIONANDO");
        //                }
        //        }
        //    }
        //}

        //public static void Draw()
        //{
        //    Engine.Clear();
        //    player.playerCharacter.Render();
        //    obstacle.enemyCharacters.Render();
        //    Engine.Show();
        //}

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

               

        //private static Animation CreateAnimation()
        //{
        //    // Idle Animation
        //    List<Texture> idleFrames = new List<Texture>();

        //    for (int i = 0; i < 4; i++)
        //    {
        //        idleFrames.Add(Engine.GetTexture($"{i}.png"));
        //    }

        //    Animation idleAnimation = new Animation("Idle", idleFrames, 2, true);

        //    return idleAnimation;
        //}
    }
}