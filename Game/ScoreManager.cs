using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ScoreManager
    {
        private static ScoreManager instance;

        private int score = 0;

        public int Score => score;

        public void AddPoints(int pointsToAdd)
        {
            score += pointsToAdd;
        }

        public static ScoreManager Instance 
        { 
            get 
            { 
                if (instance == null) 
                {
                    instance = new ScoreManager();
                }
                return instance; 
            } 
        }
    }
}
