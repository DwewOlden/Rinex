using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    /// <summary>
    /// A simple little thing that stores the location of the reciever etc
    /// </summary>
    public interface IPosition
    {
        double X { get; }

        double Y { get; }

        double Z { get; }

        bool IsZero { get; }
    }
}
