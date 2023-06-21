using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game.ObstacleFactory;

namespace Game
{
    public class ObstacleManager
    {
        private static ObstacleManager instance;
        public static ObstacleManager Instance { get { if (instance == null) { instance = new ObstacleManager(); } return instance; } }

        public List<Obstacle> obstaclesOnScreen = new List<Obstacle>();

        private float[] carriles;

        private float timer = 0;

        private float spawnRate = 2f;

        private Pool<ObstacleFactory.Obstacles, Obstacle> obstaclePool;

        public delegate void CollisionSubscription(Obstacle obstacle);

        public event CollisionSubscription OnObstacleCreation;

        public void Start()
        {
            if (obstaclePool == null)
            {
                obstaclePool = new Pool<ObstacleFactory.Obstacles, Obstacle>(CallFactory);
            }
            else
            {
                obstaclePool.Empty();
            }

            if (carriles == null)
            {
                float carril = 0;
                carriles = new float[7];

                for (int i = 0; i < carriles.Length; i++)
                {
                    carriles[i] = (carril += 200);
                }
            }

            if (obstaclesOnScreen.Count > 0)
            {
                obstaclesOnScreen.Clear();
            }          
        }

        public Obstacle CallFactory (ObstacleFactory.Obstacles id)
        {
            return ObstacleFactory.CreateObstacle(id);
        }

        public int RandomNumber(bool oneintwo, int min, int max)
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

        private void ActivationTimer()
        {
            timer += Program.deltaTime;
            if (timer >= spawnRate)
            {
                ObstacleActivation();
                timer = 0;
            }
        }

        private void SendToPool()
        {
            for (int i = obstaclesOnScreen.Count - 1; i >= 0; i--)
            {                
                if (obstaclesOnScreen[i].active == false)
                {
                    obstaclePool.AddItem(obstaclesOnScreen[i]);
                    obstaclesOnScreen.Remove(obstaclesOnScreen[i]);
                }
            }
        }

        private void ObstacleActivation()
        {
            Obstacle obstacle;

            bool positionCheck = false;

            obstacle = obstaclePool.GetItem(ObstacleFactory.Obstacles.car);

            while (positionCheck == false)
            {
                int index = RandomNumber(false, 0, carriles.Length);
                float carril = carriles[index];
                positionCheck = ObstacleSpawnCheck(carril);
                obstacle.Reposition(carril, 0);
            }
            obstaclesOnScreen.Add(obstacle);
            OnObstacleCreation(obstacle);
        }

        private bool ObstacleSpawnCheck(float spawnPosX)
        {
            foreach (var obstacle in obstaclesOnScreen)
            {
                if (obstacle.transform.position.x == spawnPosX)
                {
                    if (obstacle.transform.position.y > 0 && obstacle.transform.position.y < 20)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Update()
        {
            SendToPool();
            for (int i = 0; i < obstaclesOnScreen.Count; i++)
            {
                obstaclesOnScreen[i].Update();
            }
            ActivationTimer();
        }

        public void Render()
        {
            for (int i = 0; i < obstaclesOnScreen.Count; i++)
            {
                obstaclesOnScreen[i].Render();
            }
        }
    }
}
