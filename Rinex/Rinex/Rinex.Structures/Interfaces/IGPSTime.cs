using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// Largely the same as a normal date time, but has extra funcionality
    /// for handling weeks and GPS seconds. The time is bordered on 1980.
    /// </summary>
    public interface IGPSTime
    {
        DateTime RegularDateTime { get; }

        int GPSWeek { get; }

        double GPSSeconds { get; }
        

    }
}
