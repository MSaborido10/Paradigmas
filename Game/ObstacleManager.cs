using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ObstacleManager
    {
        private static ObstacleManager instance;
        public static ObstacleManager Instance { get { if (instance == null) { instance = new ObstacleManager(); } return instance; } }

        public Obstacle[] obstaclesOnScreen = new Obstacle[5];

        private List<Obstacle> deactivatedObstacles = new List<Obstacle>();

        private int[] carriles = new int[5];

        private int carril = 0;

        private float timer = 0;

        private float spawnRate = 1f;

        public void Start()
        {
            carril = 0;
            for (int i = 0; i < obstaclesOnScreen.Length; i++)
            {
                Console.WriteLine(obstaclesOnScreen[i]);
                Obstacle obstacle = new Obstacle(new Vector2(carril += 200, 0));
                obstaclesOnScreen[i] = obstacle;
                obstaclesOnScreen[i].obstacleID = i;
                carriles[i] = carril;
            }
            Engine.Debug("Enemies started");
        }

        private int RandomNumber(bool oneintwo, int min, int max)
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

        private void UpdateList()
        {
            foreach (var obstacle in obstaclesOnScreen)
            {
                if (obstacle.active == false && obstacle.waitingToSpawn == false)
                {
                    deactivatedObstacles.Add(obstacle);
                    obstacle.waitingToSpawn = true;
                }
            }
            /*for (int i  = 0; i < obstaclesOnScreen.Length; i++)
            {
                Console.WriteLine(obstaclesOnScreen[i]);
                if (obstaclesOnScreen[i].active == false && obstaclesOnScreen[i].waitingToSpawn == false)
                {
                    deactivatedObstacles.Add(obstaclesOnScreen[i]);
                    obstaclesOnScreen[i].waitingToSpawn = true;
                }
            }*/
        }

        private void ObstacleActivation()
        {
            int index = RandomNumber(false, 0, deactivatedObstacles.Count);
            if (RandomNumber(false, 0, 5) > 1)
            {
                deactivatedObstacles[index].Reposition(carriles[deactivatedObstacles[index].obstacleID], 0);
                deactivatedObstacles[index].transform.position.y = 0;
                deactivatedObstacles[index].active = true;
                deactivatedObstacles[index].waitingToSpawn = false;
                deactivatedObstacles.Remove(deactivatedObstacles[index]);
            }
        }

        public void Update()
        {
            UpdateList();
            for (int i = 0; i < obstaclesOnScreen.Length; i++)
            {
                obstaclesOnScreen[i].SceneUpdate();
            }
            //ObstacleActivation();
            ActivationTimer();
        }

        public void Render()
        {
            for (int i = 0; i < obstaclesOnScreen.Length; i++)
            {
                obstaclesOnScreen[i].Render();
            }
        }
    }
}
