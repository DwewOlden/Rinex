using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Math
{
    public class Matrix : IMatrix
    {
        /// <summary>
        /// The data in the matrix
        /// </summary>
        private double[,] mData;

        /// <summary>
        /// The  number of rows in the Matrix
        /// </summary>
        private int mRows;

        /// <summary>
        /// The number of columns in the Matrix
        /// </summary>
        private int mCols;

        /// <summary>
        /// Gets the number of rows in the matrix
        /// </summary>
        public int Rows
        {
            get
            {
                return mRows;
            }
        }

        /// <summary>
        /// Gets the number of columns in the matrix
        /// </summary>
        public int Columns
        {
            get
            {
                return mCols;
            }
        }

        /// <summary>
        /// Checks if the matrix is square (Number Rows == Number Columns)
        /// </summary>
        public bool IsSquare
        {
            get
            {
                return mRows == mCols;
            }
        }

        /// <summary>
        /// Default construcor
        /// </summary>
        /// <param name="Rows">The number of rows in the matrix</param>
        /// <param name="Columns">The number of columns in the matrix</param>
        public Matrix(int Columns,int Rows)
        {
            if (Rows < 1 || Columns < 1)
                throw new ArgumentOutOfRangeException("rows / columns", "the number of rows and columns must both be greater than zero");

            mData = new double[Rows, Columns];
            mRows = Rows;
            mCols = Columns;
        }

        /// <summary>
        /// Flips a matrix over its diagonal
        /// </summary>
        /// <param name="pMatrix">The matrix we want to transpose</param>
        /// <returns>The transposed matrix</returns>
        public static Matrix Transpose(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplys the two matrix
        /// </summary>
        /// <param name="pMatrix">The left hand side of the marix</param>
        /// <param name="pMatrix2">The right hand side of the matrix</param>
        /// <returns>The result of the matrix multiplation operation</returns>
        public static Matrix MultiplyMatrix(Matrix source, Matrix target)
        {
            // Constructor is columns and rows.

            Matrix m = new Matrix(target.Columns, source.Rows);

            for (int i = 0; i < source.Rows; i++)
                for (int j = 0; j < target.Columns; j++)
                    for (int k = 0; k < source.Columns; k++)
                    {
                        double d = m.GetValue(i, j);
                        d += source.GetValue(i,k) * target.GetValue(k,j);
                        m.SetValue(i, j, d); 
                    }
                
            return m;
        }

        public Matrix CholeskiInverse(Matrix pMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the passed two matrix
        /// </summary>
        /// <param name="source">The left hand side of the addition</param>
        /// <param name="target">The right hand side of the addition</param>
        /// <returns>The result of the addtion</returns>
        public static Matrix Add(Matrix source, Matrix target)
        {
            // Check the dimensions of the matrix
            if ((source.Columns != target.Columns) || (source.Rows != target.Rows))
                throw new ArgumentException("the matrix are not the same dimensions");

            // Create a new matrix of the required size
            Matrix m = new Matrix(source.Rows, source.Columns);
            
            // Generate a new matrix based on the two passed arrays.
            for (int i = 0;i<source.Rows;i++)
                for (int j=0;j<source.Columns;j++)
                {
                    double value = source.GetValue(i, j) + target.GetValue(i, j);
                    m.SetValue(i, j, value);
                }

            return m;
        }

        /// <summary>
        /// Subtracts the source matrix from the target matrix
        /// </summary>
        /// <param name="source">The left hand side of the subtraction</param>
        /// <param name="target">The righ hand side of the subtraction</param>
        /// <returns>The result of the subtraction</returns>
        public static Matrix Subtract(Matrix source, Matrix target)
        {
            // Check the dimensions of the matrix
            if ((source.Columns != target.Columns) || (source.Rows != target.Rows))
                throw new ArgumentException("the matrix are not the same dimensions");

            // Create a new matrix of the required size
            Matrix m = new Matrix(source.Rows, source.Columns);

            // Generate a new matrix based on the two passed arrays.
            for (int i = 0; i < source.Rows; i++)
                for (int j = 0; j < source.Columns; j++)
                {
                    double value = source.GetValue(i, j) - target.GetValue(i, j);
                    m.SetValue(i, j, value);
                }

            return m;
        }

        /// <summary>
        /// Returns the value in the passed row and column
        /// </summary>
        /// <param name="Row">The row containing the value we want to set</param>
        /// <param name="Col">The col containing the value we want to set</param>
        /// <returns>The value we want to get</returns>
        public double GetValue(int Row, int Col)
        {
            return mData[Row, Col];
        }

        /// <summary>
        /// Sets the row and column with the passed value
        /// </summary>
        /// <param name="Row">The row containing the value we want to set</param>
        /// <param name="Col">The col containing the value we want to set</param>
        /// <param name="Value">The value we want to set</param>
        public void SetValue(int Row, int Col, double Value)
        {
            mData[Row, Col] = Value;
        }
    }
}
