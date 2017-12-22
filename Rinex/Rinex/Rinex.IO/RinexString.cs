using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO
{
    public class RinexString
    {
        public const string RinexTypeString = "RINEX VERSION / TYPE";

        public const string RinexObservationIndicator = "O";

        /// <summary>
        /// We will not be using this first thing.
        /// </summary>
        public const string RinexVersion3Marker = "3.";

        public const string RinexVersion212Marker = "2.12";

        public const string RinexVersion2Marker = "2";

        public const string RinexObservaitonTypes = "# / TYPES OF OBSERV";

        public const string RinexFirstTime = "TIME OF FIRST OBS";

        public const string RinexApproxos = "APPROX POSITION XYZ";

        public const string RinexAntennaDelta = "ANTENNA: DELTA H/E/N";

        public const string RinexEndOfHeader = "END OF HEADER";

        /// <summary>
        /// We will not be using this first thing.
        /// </summary>
        public const string RinexV3Version = "SYS / # / OBS TYPES";
    }
}
