﻿using System;
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
    }
}
