using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Tests.Position_Tests
{
    [TestFixture]
    public class Position_Tests
    {
        [Test]
        public void Position_Test_1()
        {
            Position p = new Position(1, 2, 3);

            Assert.AreEqual(1, p.X);
            Assert.AreEqual(2, p.Y);
            Assert.AreEqual(3, p.Z);    
        }

        public void Position_Test_2()
        {
            Position p = new Position(1, 2, 3);
            Position p2 = new Position(1, 2, 3);

            Assert.AreEqual(p, p2);
        }

        public void Position_Test_3()
        {
            Position p = new Position(1, 2, 3);
            string s = "X: 1, Y:2, Z:3";

            Assert.AreEqual(s, p.ToString());
        }

        public void Position_Test_4()
        {
            Position p = new Position(0, 2, 3);
            Position p2 = new Position(1, 2, 3);

            Assert.AreNotEqual(p, p2);
        }

        public void Position_Test_5()
        {
            Position p = new Position(1, 2, 0);
            Position p2 = new Position(1, 2, 3);

            Assert.AreNotEqual(p, p2);
        }

        public void Position_Test_6()
        {
            Position p = new Position(1, 2, 3);
            Position p2 = new Position(p);

            Assert.AreEqual(p, p2);
        }
    }
}
