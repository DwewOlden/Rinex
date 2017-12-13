using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing
{
    /// <summary>
    /// These contants are used thorougth out the process of turning the pseudo ranges 
    /// into location information
    /// </summary>
    public class GPSConstants
    {
        public const double GPSPI = 3.1415926535898e0;

        public const double RAD = 180.0 / System.Math.PI;

        public const double SOL = 299792458.0;

        public const double F1 = 1575.42e6;

        public const double F2 = 1227.60e6;

        public const double W1 = SOL / F1;

        public const double W2 = SOL / F2;

        public const double WE = 7.2921151467e-5;

        public const double GM = 3.986005e14;

        public const double _BIGF = -4.442807633e-10;
    }
}
