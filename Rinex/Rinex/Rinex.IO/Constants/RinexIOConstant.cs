using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Constants
{
    /// <summary>
    /// Constants used when reading information from the files
    /// </summary>
    public class RinexIOConstant
    {
        /// <summary>
        /// The maximum length of a rinex line when reading from the files.
        /// </summary>
        public const int RinexLineWidth = 82;

        public const string VersionString = "RINEX VERSION / TYPE";

        public const string ApproximatePosition = "APPROX POSITION XYZ";

        public const string ProgramInformation = "PGM / RUN BY / DATE";

        public const string ObserverationTypes = "# / TYPES OF OBSERV";

        public const string AntennaDelta = "ANTENNA: DELTA H/E/N";

        public const string RinexVersion = "RINEX VERSION / TYPE";

        public const string MarkerName = "MARKER NAME";

        public const string EndOfHeader = "END OF HEADER";

        public const string TimeOfFirstObservation = "TIME OF FIRST OBS";

        public const string TimeOfLastObservation = "TIME OF LAST OBS";
    }
}
