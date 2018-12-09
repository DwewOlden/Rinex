using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface.RinexObservations
{
    /// <summary>
    /// Functionality related to the parsing of the epoch header
    /// </summary>
    public interface IRinexObservationEpochHeaderParser
    {
        /// <summary>
        /// Extracts the record status flag from the epoch header
        /// </summary>
        /// <param name="line">A line of text represeting an epoch header</param>
        /// <returns>The epoch status flag</returns>
        int ExtractEpochFlag(string line);

        /// <summary>
        /// Extracts the number of satellites from the line
        /// </summary>
        /// <param name="line">A line of text represeting an epoch header</param>
        /// <returns>The number of satellites</returns>
        int ParseSatelliteCount(string line);

        /// <summary>
        /// Gets the prns for each of the satellites in the header
        /// </summary>
        /// <param name="Count">The numer of satellites</param>
        /// <returns>A collection of Satellite Ids</returns>
        IEnumerable<int> ParseSatellitePrns(string line, int Count);
    }
}
