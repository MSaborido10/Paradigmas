using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class ObstacleFactory
    {
        public enum Obstacles {car}

        public static Obstacle CreateObstacle(Obstacles obstacle)
        {
            switch(obstacle)
            {
                case Obstacles.car:
                    return new Obstacle(new Vector2(0,0));

            }
            return null;
        }

    }
}
