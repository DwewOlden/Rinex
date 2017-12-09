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
    public class Matrix_Tests
    {
        [Test]
        public void Matrix_Test_Addition_1()
        {
            Matrix m1 = Matrix_Test_Data.Get_Uniform_Matrix_Test_Data(10, 10, 10);
            Matrix m2 = Matrix_Test_Data.Get_Uniform_Matrix_Test_Data(10, 10, 10);

            Matrix m3 = Matrix.Add(m1, m2);

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(20, m3.GetValue(i, j));
        }

        [Test]
        public void Matrix_Test_Addition_2()
        {
            Matrix m1 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(1000, 1000);
            Matrix m2 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(1000, 1000);

            Matrix m3 = Matrix.Add(m1, m2);

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    Assert.AreEqual(((i+j)*2), m3.GetValue(i, j));
        }

        [Test]
        public void Matrix_Test_Subtraction_2()
        {
            Matrix m1 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(1000, 1000);
            Matrix m2 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(1000, 1000);

            Matrix m3 = Matrix.Subtract(m1, m2);

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    Assert.AreEqual(0, m3.GetValue(i, j));
        }

        [Test]
        public void Matrix_Test_Subtraction_1()
        {
            Matrix m1 = Matrix_Test_Data.Get_Uniform_Matrix_Test_Data(10, 10, 10);
            Matrix m2 = Matrix_Test_Data.Get_Uniform_Matrix_Test_Data(10, 10, 10);

            Matrix m3 = Matrix.Subtract(m1, m2);

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(0, m3.GetValue(i, j));
        }

        [Test]
        public void Matrix_GetValue_1()
        {
            Matrix m1 = Matrix_Test_Data.Get_Uniform_Matrix_Test_Data(10, 10, 10);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Assert.AreEqual(10, m1.GetValue(i, j));

        }

        [Test]
        public void Matrix_GetSetValue()
        {
            Random r = new Random();

            Matrix m1 = Matrix_Test_Data.Get_Uniform_Matrix_Test_Data(1000, 1000, 10);
            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                {
                    int v = r.Next(300, 6000);
                    m1.SetValue(i, j, v);
                    Assert.AreEqual(v, m1.GetValue(i, j));
                }
        }


    }
}
