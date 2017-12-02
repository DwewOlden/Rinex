using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Math
{
    public interface IMatrix
    {
        int Rows { get; }

        int Columns { get; }

        bool IsSquare { get; }

        Matrix Transpose(Matrix pMatrix);

        Matrix MultiplyMatrix(Matrix pMatrix, Matrix pMatrix2);

        Matrix CholeskiInverse(Matrix pMatrix);

        Matrix Add(Matrix source, Matrix target);

        Matrix Subtract(Matrix source, Matrix target);
    }
}
