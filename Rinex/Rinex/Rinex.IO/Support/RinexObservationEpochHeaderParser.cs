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
        /// The starting point in the string of the Satellite information
        /// </summary>
        /// <remarks>
        /// Each satellite is dediated thre characters, but the first is just a marker
        /// when using only gps that can be ignored. Yay!</remarks>
        private const int SatStartPos = 31;

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

        /// <summary>
        /// Gets the prns for each of the satellites in the header
        /// </summary>
        /// <param name="line">A line of text represeting an epoch header</param>
        /// <param name="Count">The numer of satellites</param>
        /// <returns>A collection of Satellite Ids</returns>
        public IEnumerable<int> ParseSatellitePrns(string line,int Count)
        {
            int index = 32;
            List<int> prns = new List<int>();

            for (int i=0;i < Count;i++)
            {
                string SatType = line.Substring(index, 1);
                string sPrn = line.Substring(index + 1, 2);
                int prn = Convert.ToInt32(sPrn);
                prns.Add(prn);

                index = index + 3;
            }

            return prns;

            

        }
    }
}
