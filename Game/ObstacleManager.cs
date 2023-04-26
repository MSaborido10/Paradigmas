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
            if (obstaclesOnScreen[0] == null)
            {
                for (int i = 0; i < obstaclesOnScreen.Length; i++)
                {
                    obstaclesOnScreen[i] = new Obstacle(new Vector2(carril += 200, -200), Program.RandomNumber(false, 0, 4));
                    obstaclesOnScreen[i].obstacleID = i;
                    carriles[i] = carril;
                }
            }            
        }

        public void RestartAllObstacles()
        {
            foreach (var obstacle in obstaclesOnScreen)
            {
                obstacle.Reposition(carriles[obstacle.obstacleID], 0);
            }
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
        }

        

        private void ObstacleActivation()
        {
            int index = Program.RandomNumber(false, 0, deactivatedObstacles.Count);
            if (Program.RandomNumber(false, 0, 5) > 1 && index < deactivatedObstacles.Count)
            {
                deactivatedObstacles[index].Reposition(carriles[deactivatedObstacles[index].obstacleID], 0);
                deactivatedObstacles[index].transform.position.y = 0;
                deactivatedObstacles[index].active = true;
                deactivatedObstacles[index].waitingToSpawn = false;
                deactivatedObstacles[index].SwitchAnimation(Program.RandomNumber(false, 0, 4));
                deactivatedObstacles.Remove(deactivatedObstacles[index]);
            }
        }

        public void Update()
        {
            UpdateList();
            for (int i = 0; i < obstaclesOnScreen.Length; i++)
            {
                obstaclesOnScreen[i].Update();
            }
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
