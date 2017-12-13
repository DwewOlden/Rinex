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
        public void Matrix_IsSingular_Test_1()
        {
            Matrix m = Matrix_Test_Data.Is_Singular_Test_1();
            Assert.AreEqual(false,m.IsSingular);
        }

        [Test]
        public void Matrix_IsSingular_Test_2()
        {
            Matrix m = Matrix_Test_Data.Is_Singular_Test_2();
            Assert.AreEqual(true, m.IsSingular);
        }

        [Test]
        public void Matrix_IsSingular_Test_3()
        {
            Matrix m = Matrix_Test_Data.Is_Singular_Test_3();
            Assert.AreEqual(true, m.IsSingular);
        }


        [Test]
        public void Matrix_Equals_Test()
        {
            Matrix m = new Matrix(4, 4);
            Matrix m2 = new Matrix(4, 4);

            for (int i = 0;i<4;i++)
                for (int j = 0;j<4;j++)
                {
                    m.SetValue(i, j, (int)i);
                    m2.SetValue(i, j, (int)i);
                }

            Assert.AreEqual(m, m2); 
        }

        [Test]
        public void Matrix_Equals_Must_Be_False()
        {
            Matrix m = new Matrix(4, 4);
            Matrix m2 = new Matrix(4, 4);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    m.SetValue(i, j, (int)i);
                    m2.SetValue(i, j, (int)i*2);
                }

            Assert.AreNotEqual(m, m2);
        }


        [Test]
        public void Matrix_IsZero_True_Test()
        {
            Matrix m = new Matrix(4, 4);
            Assert.AreEqual(true, m.IsZero);
        }

        [Test]
        public void Matrix_IsZero_False_Test()
        {
            Matrix m = new Matrix(4, 4);
            m.SetValue(0, 0, 1);
            Assert.AreEqual(false, m.IsZero);
        }

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
            Matrix m1 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(100, 100);
            Matrix m2 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(100, 100);

            Matrix m3 = Matrix.Add(m1, m2);

            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    Assert.AreEqual(((i+j)*2), m3.GetValue(i, j));
        }

        [Test]
        public void Matrix_Test_Subtraction_2()
        {
            Matrix m1 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(100, 100);
            Matrix m2 = Matrix_Test_Data.Get_Interativly_Matrix_Test_Data(100, 100);

            Matrix m3 = Matrix.Subtract(m1, m2);

            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
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

        [Test]
        public void Matrix_Multiplication_1()
        {
            Matrix m1 = new Matrix(3, 3);
            Matrix m2 = new Matrix(3, 3);

            for (int i = 0;i<3;i++)
                for (int j = 0;j<3;j++)
                {
                    m1.SetValue(i, j, i + 1);
                    m2.SetValue(i, j, i + 1);
                }

            Matrix m3 = Matrix.MultiplyMatrix(m1, m2);

            Assert.AreEqual(6, m3.GetValue(0, 0));
            Assert.AreEqual(6, m3.GetValue(0, 1));
            Assert.AreEqual(6, m3.GetValue(0, 2));
            Assert.AreEqual(12, m3.GetValue(1, 0));
            Assert.AreEqual(12, m3.GetValue(1, 1));
            Assert.AreEqual(12, m3.GetValue(1, 2));
            Assert.AreEqual(18, m3.GetValue(2, 0));
            Assert.AreEqual(18, m3.GetValue(2, 1));
            Assert.AreEqual(18, m3.GetValue(2, 2));

        }

        [Test]
        public void Matrix_Multiplication_2()
        {
            Matrix m1 = new Matrix(3, 3);
            Matrix m2 = new Matrix(3, 3);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    m1.SetValue(i, j, i + 1);
                    m2.SetValue(i, j, i + 1);
                }

            Matrix m3 = Matrix.MultiplyMatrix(m1, m2);

            Assert.AreEqual(6, m3.GetValue(0, 0));
            Assert.AreEqual(6, m3.GetValue(0, 1));
            Assert.AreEqual(6, m3.GetValue(0, 2));
            Assert.AreEqual(12, m3.GetValue(1, 0));
            Assert.AreEqual(12, m3.GetValue(1, 1));
            Assert.AreEqual(12, m3.GetValue(1, 2));
            Assert.AreEqual(18, m3.GetValue(2, 0));
            Assert.AreEqual(18, m3.GetValue(2, 1));
            Assert.AreEqual(18, m3.GetValue(2, 2));
        }

        [Test]
        public void Matrix_Multiplication_3()
        {
            Matrix m1 = Matrix_Test_Data.Get_Multiplication_Matrix1();
            Matrix m2 = Matrix_Test_Data.Get_Multiplication_Matrix2();

            Matrix m3 = Matrix.MultiplyMatrix(m1, m2);

            Assert.AreEqual(28, m3.GetValue(0, 0));
            Assert.AreEqual(30, m3.GetValue(0, 1));
            Assert.AreEqual(22, m3.GetValue(0, 2));
            Assert.AreEqual(39, m3.GetValue(1, 0));
            Assert.AreEqual(60, m3.GetValue(1, 1));
            Assert.AreEqual(51, m3.GetValue(1, 2));
            Assert.AreEqual(74, m3.GetValue(2, 0));
            Assert.AreEqual(72, m3.GetValue(2, 1));
            Assert.AreEqual(50, m3.GetValue(2, 2));
            Assert.AreEqual(17, m3.GetValue(3, 0));
            Assert.AreEqual(102, m3.GetValue(3, 1));
            Assert.AreEqual(107, m3.GetValue(3, 2));
            
        }

        [Test]
        public void Matrix_Multiplication_4()
        {
            Matrix m1 = Matrix_Test_Data.Get_Multiplication_Matrix4();
            Matrix m2 = Matrix_Test_Data.Get_Multiplication_Matrix3();

            Matrix m3 = Matrix.MultiplyMatrix(m2, m1);

            Assert.AreEqual(26, m3.GetValue(0, 0));
            Assert.AreEqual(24, m3.GetValue(0, 1));
            Assert.AreEqual(36, m3.GetValue(1, 0));
            Assert.AreEqual(34, m3.GetValue(1, 1));   
        }

        [Test]
        public void Matrix_Transpose_1()
        {
            Matrix m1 = Matrix_Test_Data.Get_Multiplication_Matrix4();
            Matrix m2 = m1.Transpose();

            Assert.AreEqual(2,m2.GetValue(0, 0));
            Assert.AreEqual(3,m2.GetValue(0, 1));
            Assert.AreEqual(2, m2.GetValue(0, 2));
            Assert.AreEqual(3, m2.GetValue(0, 3));
            Assert.AreEqual(3, m2.GetValue(1, 0));
            Assert.AreEqual(2, m2.GetValue(1, 1));
            Assert.AreEqual(3, m2.GetValue(1, 2));
            Assert.AreEqual(2, m2.GetValue(1, 3));
        }

        [Test]
        public void Matrix_Transpose_2()
        {
            Matrix m1 = Matrix_Test_Data.Get_Multiplication_Matrix3();
            Matrix m2 = m1.Transpose();

            Assert.AreEqual(1, m2.GetValue(0, 0));
            Assert.AreEqual(2, m2.GetValue(0, 1));
            Assert.AreEqual(2, m2.GetValue(1, 0));
            Assert.AreEqual(3, m2.GetValue(1, 1));
            Assert.AreEqual(3, m2.GetValue(2, 0));
            Assert.AreEqual(4, m2.GetValue(2, 1));
            Assert.AreEqual(4, m2.GetValue(3, 0));
            Assert.AreEqual(5, m2.GetValue(3, 1));
        }

        [Test]
        public void Matrix_CholeskiInverse_Test_1()
        {
           
            Matrix m = Matrix_Test_Data.Get_Inverse_Matrix_1();
            Matrix m2 = m.CholeskiInverse();

            Assert.AreEqual(3.3333333333333339, m2.GetValue(0, 0));
            Assert.AreEqual(-1.6666666666666670, m2.GetValue(0, 1));
            Assert.AreEqual(0.66666666666666685, m2.GetValue(0, 2));

            Assert.AreEqual(-1.6666666666666670, m2.GetValue(1, 0));
            Assert.AreEqual(1.3333333333333335, m2.GetValue(1, 1));
            Assert.AreEqual(-0.33333333333333343, m2.GetValue(1, 2));

            Assert.AreEqual(0.66666666666666685, m2.GetValue(2, 0));
            Assert.AreEqual(-0.33333333333333343, m2.GetValue(2, 1));
            Assert.AreEqual(0.33333333333333343, m2.GetValue(2, 2));
        }
    }
}
