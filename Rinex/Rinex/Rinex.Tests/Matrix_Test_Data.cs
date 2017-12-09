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
    }
}
