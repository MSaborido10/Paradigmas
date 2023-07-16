using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class ObstacleFactory
    {
        public enum Obstacles {car1, car2, car3}

        public static Obstacle CreateObstacle(Obstacles obstacle)
        {
            switch(obstacle)
            {
                case Obstacles.car1:
                    return new Obstacle(new Vector2(0, 0), 2);
                    break;

                case Obstacles.car2:
                    return new Obstacle(new Vector2(0, 0), 3);
                    break;

                case Obstacles.car3:
                    return new Obstacle(new Vector2(0, 0), 4);
                    break;

                default:
                    return new Obstacle(new Vector2(0, 0), 2);
                    break;
            }
            return null;
        }
    }
}
