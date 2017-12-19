using Rinex.Processing.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Tests
{
    public class Matrix_Test_Data
    {
        /// <summary>
        /// Generates a uniform matrix
        /// </summary>
        /// <param name="R">The number of rows in a matrix</param>
        /// <param name="C">The number of columns in a matirx</param>
        /// <param name="BaseValue">The base value for the matrix</param>
        /// <returns></returns>
        public static Matrix Get_Uniform_Matrix_Test_Data(int R,int C,int BaseValue)
        {
            Matrix m = new Matrix(R, C);
            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    m.SetValue(i, j, BaseValue);

            return m;
        }

        /// <summary>
        /// Generates a uniform matrix
        /// </summary>
        /// <param name="R">The number of rows in a matrix</param>
        /// <param name="C">The number of columns in a matirx</param>
        /// <returns></returns>
        public static Matrix Get_Interativly_Matrix_Test_Data(int R, int C)
        {
            Matrix m = new Matrix(R, C);
            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    m.SetValue(i, j, (double)i+j);

            return m;
        }

        /// <summary>
        /// Generates a uniform matrix
        /// </summary>
        /// <param name="R">The number of rows in a matrix</param>
        /// <param name="C">The number of columns in a matirx</param>
        /// <param name="BaseValue">The base value for the matrix</param>
        /// <returns></returns>
        public static Matrix Get_Random_Matrix_Test_Data(int R, int C, int LowerBounds,int UppperBounds)
        {
            Random r = new Random();
            Matrix m = new Matrix(R, C);
            for (int i = 0; i < R; i++)
                for (int j = 0; j < C; j++)
                    m.SetValue(i, j, (double)r.Next(LowerBounds,UppperBounds));

            return m;
        }

        public static Matrix Get_Multiplication_Matrix1()
        {
            Matrix m = new Matrix(2, 4);
            m.SetValue(0, 0, 1);
            m.SetValue(0, 1, 3);
            m.SetValue(1, 0, 3);
            m.SetValue(1, 1, 4);
            m.SetValue(2, 0, 2);
            m.SetValue(2, 1, 8);
            m.SetValue(3, 0, 8);
            m.SetValue(3, 1, 1);

            return m;
        }

        public static Matrix Get_Multiplication_Matrix2()
        {
            Matrix m = new Matrix(3, 2);
            m.SetValue(0, 0, 1);
            m.SetValue(0, 1, 12);
            m.SetValue(0, 2, 13);
            m.SetValue(1, 0, 9);
            m.SetValue(1, 1, 6);
            m.SetValue(1, 2, 3);
            
            return m;
        }

        public static Matrix Get_Multiplication_Matrix3()
        {
            Matrix m = new Matrix(4, 2);
            m.SetValue(0, 0, 1);
            m.SetValue(0, 1, 2);
            m.SetValue(0, 2, 3);
            m.SetValue(0, 3, 4);
            m.SetValue(1, 0, 2);
            m.SetValue(1, 1, 3);
            m.SetValue(1, 2, 4);
            m.SetValue(1, 3, 5);

            return m;
        }

        public static Matrix Get_Multiplication_Matrix4()
        {
            Matrix m = new Matrix(2, 4);
            m.SetValue(0, 0, 2);
            m.SetValue(0, 1, 3);
            m.SetValue(1, 0, 3);
            m.SetValue(1, 1, 2);
            m.SetValue(2, 0, 2);
            m.SetValue(2, 1, 3);
            m.SetValue(3, 0, 3);
            m.SetValue(3, 1, 2);

            return m;
        }

        public static Matrix Get_Inverse_Matrix_1()
        {
            Matrix m = new Matrix(3, 3);
            m.SetValue(0, 0, 1);
            m.SetValue(0, 1, 1);
            m.SetValue(0, 2, -1);
            m.SetValue(1, 0, 1);
            m.SetValue(1, 1, 2);
            m.SetValue(1, 2, 0);
            m.SetValue(2, 0, -1);
            m.SetValue(2, 1, 0);
            m.SetValue(2, 2, 5);

            return m;
        }

        public static Matrix Is_Singular_Test_1()
        {
            Matrix temp = new Matrix(5, 5);
            temp.SetValue(0, 0, 1);
            temp.SetValue(0, 1, 2);
            temp.SetValue(0, 2, 3);
            temp.SetValue(0, 3, 4);
            temp.SetValue(0, 4, 5);

            temp.SetValue(1, 0, 1);
            temp.SetValue(1, 1, 2);
            temp.SetValue(1, 2, 3);
            temp.SetValue(1, 3, 4);
            temp.SetValue(1, 4, 5);

            temp.SetValue(2, 0, 1);
            temp.SetValue(2, 1, 2);
            temp.SetValue(2, 2, 3);
            temp.SetValue(2, 3, 4);
            temp.SetValue(2, 4, 5);

            temp.SetValue(3, 0, 1);
            temp.SetValue(3, 1, 2);
            temp.SetValue(3, 2, 3);
            temp.SetValue(3, 3, 4);
            temp.SetValue(3, 4, 5);

            temp.SetValue(4, 0, 1);
            temp.SetValue(4, 1, 2);
            temp.SetValue(4, 2, 3);
            temp.SetValue(4, 3, 4);
            temp.SetValue(4, 4, 5);

            return temp;
        }

        public static Matrix Is_Singular_Test_2()
        {
            Matrix temp = new Matrix(5, 5);
            temp.SetValue(0, 0, 0);
            temp.SetValue(0, 1, 2);
            temp.SetValue(0, 2, 3);
            temp.SetValue(0, 3, 4);
            temp.SetValue(0, 4, 5);

            temp.SetValue(1, 0, 0);
            temp.SetValue(1, 1, 2);
            temp.SetValue(1, 2, 3);
            temp.SetValue(1, 3, 4);
            temp.SetValue(1, 4, 5);

            temp.SetValue(2, 0, 0);
            temp.SetValue(2, 1, 2);
            temp.SetValue(2, 2, 3);
            temp.SetValue(2, 3, 4);
            temp.SetValue(2, 4, 5);

            temp.SetValue(3, 0, 0);
            temp.SetValue(3, 1, 2);
            temp.SetValue(3, 2, 3);
            temp.SetValue(3, 3, 4);
            temp.SetValue(3, 4, 5);

            temp.SetValue(4, 0, 0);
            temp.SetValue(4, 1, 2);
            temp.SetValue(4, 2, 3);
            temp.SetValue(4, 3, 4);
            temp.SetValue(4, 4, 5);

            return temp;
        }

        public static Matrix Is_Singular_Test_3()
        {
            Matrix temp = new Matrix(5, 5);
            temp.SetValue(0, 0, 1);
            temp.SetValue(0, 1, 2);
            temp.SetValue(0, 2, 3);
            temp.SetValue(0, 3, 4);
            temp.SetValue(0, 4, 5);

            temp.SetValue(1, 0, 1);
            temp.SetValue(1, 1, 2);
            temp.SetValue(1, 2, 3);
            temp.SetValue(1, 3, 4);
            temp.SetValue(1, 4, 5);

            temp.SetValue(2, 0, 1);
            temp.SetValue(2, 1, 2);
            temp.SetValue(2, 2, 3);
            temp.SetValue(2, 3, 4);
            temp.SetValue(2, 4, 5);

            temp.SetValue(3, 0, 1);
            temp.SetValue(3, 1, 2);
            temp.SetValue(3, 2, 3);
            temp.SetValue(3, 3, 4);
            temp.SetValue(3, 4, 5);

            temp.SetValue(4, 0, 0);
            temp.SetValue(4, 1, 0);
            temp.SetValue(4, 2, 0);
            temp.SetValue(4, 3, 0);
            temp.SetValue(4, 4, 0);

            return temp;
        }

        public static Matrix Is_Singular_Test_4()
        {
            Matrix temp = new Matrix(5, 5);
            temp.SetValue(0, 0, 1);
            temp.SetValue(0, 1, 2);
            temp.SetValue(0, 2, 3);
            temp.SetValue(0, 3, 67);
            temp.SetValue(0, 4, 5);

            temp.SetValue(1, 0, 1);
            temp.SetValue(1, 1, 2);
            temp.SetValue(1, 2, 3);
            temp.SetValue(1, 3, 4);
            temp.SetValue(1, 4, 5);

            temp.SetValue(2, 0, 1);
            temp.SetValue(2, 1, 56);
            temp.SetValue(2, 2, 3);
            temp.SetValue(2, 3, 4);
            temp.SetValue(2, 4, 5);

            temp.SetValue(3, 0, 3);
            temp.SetValue(3, 1, 2);
            temp.SetValue(3, 2, 3);
            temp.SetValue(3, 3, 4);
            temp.SetValue(3, 4, 5);

            temp.SetValue(4, 0, 23);
            temp.SetValue(4, 1, 2);
            temp.SetValue(4, 2, 3);
            temp.SetValue(4, 3, 4);
            temp.SetValue(4, 4, 5);

            return temp;
        }

        public static Matrix Is_Singular_Test_5()
        {
            Matrix temp = new Matrix(2, 2);
            temp.SetValue(0, 0, 1);
            temp.SetValue(0, 1, 4);
            
            temp.SetValue(1, 0, 2);
            temp.SetValue(1, 1, 5);
            
            return temp;
        }
    }
}
