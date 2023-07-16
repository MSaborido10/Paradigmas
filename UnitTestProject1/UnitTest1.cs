using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {      
        [TestMethod]
        public void TestMethod1()
        {
            int test1= ObstacleManager.Instance.RandomNumber(true, 1, 1);
            Assert.AreEqual(1, test1);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Player player = new Player(new Vector2(0, 0));
            int result = player.ActualLives(3, 2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]

        public void TestMethod3()
        {
           float result = ObstacleManager.Instance.SpawnRateDecrease(5, 5, 2f, 0.2f);
            Assert.AreEqual(1.8f, result);
        }
    }
}
