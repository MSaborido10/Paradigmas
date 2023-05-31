using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ObstacleFactory
    {
        public static IObstacles createObstacle(string obstacleName, Vector2 pos) 
        {
            IObstacles obstacles = null;
            switch ($"{obstacleName}")
            {
                case "car":
                    Obstacle car = new Obstacle(pos);
                    break;
                case "tree":
                    Obstacle tree = new Obstacle(pos);
                    break;
                case "rock":
                    Obstacle rock = new Obstacle(pos);
                    break;

            }
            return obstacles;
        }
    }
}
