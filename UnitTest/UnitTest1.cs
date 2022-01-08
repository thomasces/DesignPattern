using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]


        public void Test_InJail_Move()
        {
            Player p = new Player("test");
            int[] dices = new int[] { 4, 5, 9 };
            p.pState = new InJail(p);

            p.pState.Move(dices);

            Assert.AreEqual(0, p.Position);
        }

        [TestMethod]
        public void Test_NotInJail_Move()
        {
            Player p = new Player("test");
            int[] dices = new int[] { 4, 5, 9 };

            p.pState.Move(dices);

            Assert.AreEqual(9, p.pos);
        }

        [TestMethod]
        public void Test_NotInJail_GoToJail()
        {
            Player p = new Player("test");

            p.pState.GoToJail();

            Assert.AreEqual(10, p.pos);
            Assert.IsInstanceOfType(p.pState, typeof(InJail));
            
        }

       
       [TestMethod]
       public void Test_InJail_GoToJail()
       {
            Player p = new Player("test");
            p.pState = new InJail(p);
            p.pos = 10;

            p.pState.GoToJail();

            Assert.AreEqual(10, p.pos);
            Assert.IsInstanceOfType(p.pState, typeof(InJail));
       }

        [TestMethod]
        public void Test_NotInJail_RollDices()
        {
            Player p = new Player("test");

            int[] dices = p.pState.RollDices();

            Assert.IsInstanceOfType(dices, typeof(int[]));
            Assert.IsTrue(dices[2] <= 12 && dices[2] >= 2);
        }

        
        [TestMethod]
        public void Test_InJail_RollDices()
        {
            Player p = new Player("test");
            p.pState = new InJail(p);
            p.pos = 10;

            p.pState.RollDices();

            Assert.IsInstanceOfType(p.pState, typeof(InJail));
            Assert.AreEqual(p.pos, 10);
        }


        [TestMethod]
        public void Test_InJail_RollDices_3InARow()
        {
            Player p = new Player("test");
            p.inJail = new InJail(p);
            p.pState = p.inJail;
            p.pos = 10;
            p.inJail.timer = 3;

            p.pState.RollDices();

            Assert.IsInstanceOfType(p.pState, typeof(NotInJail));
        }

    [TestMethod]
       public void Test_InJail_DoubleCheck_Double()
       {
            Player p = new Player("test");
            p.pState = new InJail(p);

            int[] dices = new int[] { 4, 4, 8 };

            p.pState.DoubleCheck(dices);

            Assert.IsInstanceOfType(p.pState, typeof(NotInJail));
            Assert.IsTrue(p.pos!=10);
       }

        [TestMethod]
        public void Test_InJail_DoubleCheck_WithoutDouble()
        {
            Player p = new Player("test");
            p.pState = new InJail(p);
            p.pos = 10;

            int[] dices = new int[] { 5, 3, 8 };

            p.pState.DoubleCheck(dices);

            Assert.IsInstanceOfType(p.pState, typeof(InJail));
            Assert.IsTrue(p.pos == 10);
        }

        [TestMethod]
        public void Test_NotInJail_DisplayPosition()
        {
            Player p = new Player("test");
            p.pos = 30;

            p.pState.DisplayPosition();

            Assert.IsInstanceOfType(p.pState, typeof(InJail));
            Assert.IsTrue(p.pos == 10);
        }
    }
}
