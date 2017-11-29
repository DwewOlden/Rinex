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
        public Matrix(int Rows,int Columns)
        {
            if (Rows < 1 || Columns < 1)
                throw new ArgumentOutOfRangeException("rows / columns", "the number of rows and columns must both be greater than zero");

            mData = new double[Rows, Columns];
        }
    }
}
