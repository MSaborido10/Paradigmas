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
            Character char1 = new Character(new Vector2(0, 0), 0);
            Character char2 = new Character(new Vector2(100, 100), 0);

            bool test2 = char1.IsBoxColliding(char2);
            Assert.IsFalse(test2);
        }
    }
}
