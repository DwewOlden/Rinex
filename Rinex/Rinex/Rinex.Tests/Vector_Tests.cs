using NUnit.Framework;
using Rinex.Processing.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Tests
{
    [TestFixture]
    public class Vector_Tests
    {
        [Test]
        public void Vector_SetGet_1()
        {
            Vector v = new Vector(100);
            Random r = new Random();

            for (int i = 0; i < 99; i++)
            {
                double d = r.NextDouble();
                v.SetValue(i, d);
                Assert.AreEqual(d, v.GetValue(i));
            }
        }

        [Test]
        public void Vector_IsEqual()
        {
            Vector v1 = new Vector(10);
            Vector v2 = new Vector(10);

            for (int i = 0; i < 9; i++)
            {
                v1.SetValue(i, (double)i);
                v2.SetValue(i, (double)i);
            }

            Assert.AreEqual(v1, v2);
        }

        [Test]
        public void Vector_IsEqual_Should_Be_False()
        {
            Vector v1 = new Vector(4);
            Vector v2 = new Vector(4);

            for (int i = 0; i < 4; i++)
            {
                v1.SetValue(i, (double)i);
                v2.SetValue(i, (double)i * 2);
            }

            Assert.AreNotEqual(v1, v2);
        }

        [Test]
        public void Vector_ToString()
        {
            Vector v1 = new Vector(4);

            for (int i = 0; i < 4; i++)
                v1.SetValue(i, (double)i);

            string s = v1.ToString();
            string E = "0->1->2->3";

            Assert.AreEqual(E, s);
        }

    }
}
