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

        bool IsZero { get; }

        Matrix CholeskiInverse();

        double GetValue(int Row, int Col);

        void SetValue(int Row, int Col,double Value);

        Matrix Transpose();
    }
}
