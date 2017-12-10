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
        /// Checks if all the elements in the matrix are zero
        /// </summary>
        /// <returns>True if all elements are zero, false if they are not</returns>
        public bool IsZero
        {
            get
            {
                for (int i = 0; i < this.Rows; i++)
                    for (int j = 0; j < this.Columns; j++)
                        if (this.GetValue(i, j) != 0)
                            return false;

                return true;
            }
        }

        /// <summary>
        /// Determines if the matrix is Singular, a matrix is singular when its determinate is zero
        /// </summary>
        /// <remarks>See Vector class</remarks>
        public bool IsSingular
        {
            get
            {
                
                return true;
            }
        }

        /// <summary>
        /// Default construcor
        /// </summary>
        /// <param name="Rows">The number of rows in the matrix</param>
        /// <param name="Columns">The number of columns in the matrix</param>
        public Matrix(int Columns, int Rows)
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
        /// <returns>The transposed matrix</returns>
        public Matrix Transpose()
        {
            // Create a new matrix
            Matrix m = new Matrix(this.Rows, this.Columns);

            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Columns; j++)
                {
                    double d = this.GetValue(i, j);
                    m.SetValue(j, i, d);
                }

            return m;
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
                        d += source.GetValue(i, k) * target.GetValue(k, j);
                        m.SetValue(i, j, d);
                    }

            return m;
        }

        public Matrix CholeskiInverse()
        {
            double[,] m = new double[this.mRows, this.mCols];
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Columns; j++)
                    m[i, j] = this.GetValue(i, j);

            if (!CInverse(ref m))
                return null;
            else
            {
                Matrix m2 = new Matrix(this.mCols, this.mRows);
                for (int i = 0; i < this.Rows; i++)
                    for (int j = 0; j < this.Columns; j++)
                        m2.SetValue(i, j, m[i, j]);

                return m2;
            }
        }

        private bool CInverse(ref double[,] pMatrix)
        {
            if ((pMatrix.GetUpperBound(0) != pMatrix.GetUpperBound(1)) || (pMatrix.GetUpperBound(0) < 2))                   // must be square
            {
                return false;
            }

            const double singular = 1.0E-13;
            double det, sum, dp;
            int i, j, k;

            det = pMatrix[0, 0];
            pMatrix[0, 0] = System.Math.Sqrt(pMatrix[0, 0]);

            for (i = 1; i < pMatrix.GetUpperBound(0) + 1; i++)
            {
                pMatrix[i, 0] = pMatrix[i, 0] / pMatrix[0, 0];
            }

            for (i = 1; i < pMatrix.GetUpperBound(0) + 1; i++)
            {
                sum = 0.0;
                for (j = 0; j <= (i - 1); j++)
                {
                    sum += (pMatrix[i, j] * pMatrix[i, j]);
                }

                dp = pMatrix[i, i] - sum;

                if ((det * dp) > 1.0E300)
                {
                    det = 1.0E300;
                }
                else
                {
                    det *= dp;
                }

                if ((dp < singular) || (System.Math.Abs(det) < singular))
                {
                    return false;
                }

                pMatrix[i, i] = System.Math.Sqrt(dp);

                if (i < (pMatrix.GetUpperBound(0)))
                {
                    for (j = (i + 1); j < pMatrix.GetUpperBound(1) + 1; j++)
                    {
                        sum = 0.0;
                        for (k = 0; k <= (i - 1); k++)
                        {
                            sum += pMatrix[j, k] * pMatrix[i, k];
                        }
                        pMatrix[j, i] = (pMatrix[j, i] - sum) / pMatrix[i, i];
                    }
                }
            }

            for (i = 0; i < pMatrix.GetUpperBound(0) + 1; i++)
            {
                pMatrix[i, i] = 1.0 / pMatrix[i, i];
            }

            for (i = 0; i < (pMatrix.GetUpperBound(0)); i++)
            {
                for (j = i + 1; j < pMatrix.GetUpperBound(0) + 1; j++)
                {
                    sum = 0.0;
                    for (k = i; k <= (j - 1); k++)
                    {
                        sum += pMatrix[j, k] * pMatrix[k, i];
                    }
                    pMatrix[j, i] = -(pMatrix[j, j] * sum);
                }
            }

            for (i = 0; i < pMatrix.GetUpperBound(0) + 1; i++)
            {
                if (i != 0)
                    for (j = 0; j <= (i - 1); j++)
                        pMatrix[j, i] = pMatrix[i, j];
                for (j = i; j < pMatrix.GetUpperBound(0) + 1; j++)
                {
                    sum = 0.0;
                    for (k = j; k < pMatrix.GetUpperBound(0) + 1; k++)
                        sum += pMatrix[k, j] * pMatrix[k, i];
                    pMatrix[j, i] = sum;
                }
            }

            return true;
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
            for (int i = 0; i < source.Rows; i++)
                for (int j = 0; j < source.Columns; j++)
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
