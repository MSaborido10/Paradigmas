using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;
        public static int screenWidth = 1920;
        public static int screenHeight = 1080;


        static Animation currentAnimation = null;
        static Animation idle;

        

        static void Main(string[] args)
        {
            Engine.Initialize("Pruebas", screenWidth, screenHeight);
            GameManager.Instance.InitializeScene();
            GameManager.Instance.SceneChange(0);

            while (true)
            {

                GameManager.Instance.Update();
                Render();
                calcDeltatime();
            }
        }

        static void Render()
        {
            Engine.Clear();
            GameManager.Instance.Render();
            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }
    }
}