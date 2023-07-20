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

        private float spawnRateDecrease = 0.186f;

        private int decreaseInterval = 3;

        private float actualSpawnRate;

        private Pool<ObstacleFactory.Obstacles, Obstacle> obstaclePool;

        public delegate void CollisionSubscription(Obstacle obstacle);

        public event CollisionSubscription OnObstacleCreation;

        private int totalObstaclesSpawned = 0;

        public void Start()
        {
            actualSpawnRate = spawnRate;
            totalObstaclesSpawned = 0;

            OnObstacleCreation = null;
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
                float carril = 150;
                carriles = new float[7];

                for (int i = 0; i < carriles.Length; i++)
                {
                    carriles[i] = (carril += 160);
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
            if (timer >= actualSpawnRate)
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

            
            Random rnd = new Random();

            ObstacleFactory.Obstacles obsRnd = (ObstacleFactory.Obstacles)rnd.Next(0, Enum.GetValues(typeof(ObstacleFactory.Obstacles)).Length);

            obstacle = obstaclePool.GetItem(obsRnd);

            while (positionCheck == false)
            {
                int index = RandomNumber(false, 0, carriles.Length);
                float carril = carriles[index];
                positionCheck = ObstacleSpawnCheck(carril);
                obstacle.Reposition(carril, 0);
            }
            obstaclesOnScreen.Add(obstacle);
            totalObstaclesSpawned++;
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

        public float SpawnRateDecrease(int obstaclesSpawned, int interval,float sRate, float decreaseRate)
        {            
            float amount = decreaseRate * (obstaclesSpawned/interval);
            return sRate - amount;
        }

        public void Update()
        {
            SendToPool();
            for (int i = 0; i < obstaclesOnScreen.Count; i++)
            {
                obstaclesOnScreen[i].Update();
            }
            ActivationTimer();

            if (totalObstaclesSpawned > 1 && actualSpawnRate > 0.2f)
            {
                {
                    if (actualSpawnRate != SpawnRateDecrease(totalObstaclesSpawned,decreaseInterval, spawnRate, spawnRateDecrease))
                    {
                        actualSpawnRate = SpawnRateDecrease(totalObstaclesSpawned, decreaseInterval, spawnRate, spawnRateDecrease);
                    }
                }
            }
            Console.WriteLine("SpawnRate = " + actualSpawnRate);
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
