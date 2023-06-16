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
                    int result = 0;
                    Random rnd = new Random();
                    result = rnd.Next(2, 5);
                    return new Obstacle(new Vector2(0,0), result);

            }
            return null;
        }

    }
}
