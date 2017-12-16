using Rinex.Processing.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Models
{
    public interface ITroposphericModelMatrix
    {
        IMatrix PressureMatrix { get; }

        IMatrix HeightMatrix { get; }

        IMatrix ZentithMatrix { get; }

        IMatrix RangeMatrix { get; }


    }
}
