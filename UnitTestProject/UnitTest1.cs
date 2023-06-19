using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Game;

namespace UnitTestProject 
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player.LeftMovement;
            Player.RightMovement;

            var expectedMove = RightMovement, LeftMovement;

            var movement = Player.Inputs();

            Assert.AreEqual(movement, expectedMove);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int cSpeed = 10;
            
            Player.
        }
    }
}
