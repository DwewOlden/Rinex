using Rinex.IO.Interface.RinexObservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Support
{
    /// <summary>
    /// Functionality related to the parsing of the epoch header
    /// </summary>
    public class RinexObservationEpochHeaderParser : IRinexObservationEpochHeaderParser
    {
        /// <summary>
        /// Extracts a flag from a epoch header record
        /// </summary>
        /// <param name="line">The line we want to extract the epoch header from</param>
        /// <returns>An integer giving the epoch flag</returns>
        public int ExtractEpochFlag(string line)
        {
            string sFlag = line.Substring(28, 1);

            int flag = Convert.ToInt32(sFlag);
            return flag;
        }

        /// <summary>
        /// Extracts the number of satellites from the line
        /// </summary>
        /// <param name="line">A line of text represeting an epoch header</param>
        /// <returns>The number of satellites</returns>
        public int ParseSatelliteCount(string line)
        {
            string sCount = line.Substring(29, 3);

            int satCount = Convert.ToInt32(sCount);
            return satCount;
        }
    }
}
