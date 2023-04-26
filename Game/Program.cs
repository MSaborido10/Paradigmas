using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static int screenWidth = 1920;
        public static int screenHeight = 1080;

        //variables deltatime

        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        public static int screen;

        static List<Bullet> bullets = new List<Bullet>();

        static Animation currentAnimation = null;
        static Animation idle;


        static void Main(string[] args)
        {
            Engine.Initialize("Pruebas", screenWidth, screenHeight);

            ScreenManager.Instance.Initialize();

            idle = CreateAnimation();
            currentAnimation = idle;

            SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");

            while (true)
            {
                calcDeltatime();

                Update();
                Draw();
            }
        }

        static void Update()
        {
            ScreenManager.Instance.Update();
            //Engine.Debug(ScreenManager.Instance.currentScreen);
        }

        static void Draw()
        {
            Engine.Clear();

            ScreenManager.Instance.Render();
           
            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        public static int RandomNumber(bool oneintwo, int min, int max)
        {
            int result = 0;
            Random rnd = new Random();
            result = rnd.Next(min, max);
            if (oneintwo)
            {
                result = result % 2;
            }
            return result;
        }

        private static Animation CreateAnimation()
        {
            // Idle Animation
            List<Texture> idleFrames = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                idleFrames.Add(Engine.GetTexture($"{i}.png"));
            }

            Animation idleAnimation = new Animation("Idle", idleFrames, 2, true);

            return idleAnimation;
        }
    }
}