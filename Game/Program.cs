using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        //variables deltatime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        public static int screen;

        static float _posY = 305;
        static float _posX = 305;
        static float _speed = 100;

        static float _rot = 0;

        static Character ship;
        static Character pp;

        //static MainMenu mainMenu;
        static ScreenManager screenManager;

        static List<Bullet> bullets = new List<Bullet>();

        static Animation currentAnimation = null;
        static Animation idle;

        static List<Character> characters = new List<Character>();

        static void Main(string[] args)
        {
            Engine.Initialize();

            pp = new Character(new Vector2(100,100));
            ship = new Character(new Vector2(150,100));

            //mainMenu = new MainMenu();
            //mainMenu.CreatePromt();
            screenManager = new ScreenManager();
            screenManager.Initialize();

            idle = CreateAnimation();
            currentAnimation = idle;

            characters.Add(pp);
            characters.Add(ship);

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
            screenManager.Update();
            Engine.Debug(screen);
            //switch (screen) 
            //{
            //    case 0:
            //        mainMenu.Update();
            //        break;
            //    case 1:
            //        //level Update
            //        break;
            //    case 2:
            //        //victory screen Update
            //        break;
            //    case 3:
            //        //defeat screen Update
            //        break;
            //}

            if (Engine.GetKey(Keys.SPACE))
            {
               pp.AddMove(new Vector2(10 * deltaTime, 10 * deltaTime));
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }


            foreach (var character in characters)
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    if(character != characters[i])
                        if (character.IsBoxColliding(characters[i]))
                        {
                            //Engine.Debug("ESTOY COLISIONANDO");
                        }
                }
            }

            //currentAnimation.Update();
            ship.Update();
            pp.Update();

            //startPromt.Update();
        }

        static void Draw()
        {
            Engine.Clear();

            screenManager.Render();
            //switch (screen)
            //{
            //    case 0:
            //        mainMenu.Render();
            //        break;
            //    case 1:
            //        //level Update
            //        break;
            //    case 2:
            //        //victory screen Update
            //        break;
            //    case 3:
            //        //defeat screen Update
            //        break;
            //}

            ship.Render();
            pp.Render();

            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }


        static void Shoot()
        {
            bullets.Add(new Bullet(_posX + 230, _posY + 60, _rot));
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