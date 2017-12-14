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
        int Year { get; }

        int Month { get; }

        int Day { get; }

        int Hour { get; }

        int Minute { get; }

        int DayOfYear { get; }

        double Seconds { get; }

        double GPSSeconds { get; }

        int Week { get; }

        bool IsZero { get; }


    }
}
