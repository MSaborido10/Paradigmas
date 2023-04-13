using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        private static GameManager instance;

        private int score = 0;

        public int Score => score;

        public void AddPoints(int pointsToAdd)
        {
            score += pointsToAdd;
        }

        public static GameManager Instance 
        { 
            get 
            { 
                if (instance == null) 
                {
                    instance = new GameManager();
                }
                return instance; 
            } 
        }
    }
}
