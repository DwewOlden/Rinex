using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Support.Interfaces
{
    /// <summary>
    /// Functions to assist in the work on GPS DateTimes
    /// </summary>
    public interface IDateTimeFunctions
    {
        /// <summary>
        /// Converts a two digit year into a four digit year
        /// </summary>
        /// <param name="year">The year we want to convert, as a string</param>
        /// <returns>A four digit version fo the passed string</returns>
        int PadDate(string year);

        /// <summary>
        /// Extracts the epoch date and time from the file 
        /// </summary>
        /// <param name="line">A line from the rinex observaiton file, the first line
        /// from the epoch.</param>
        /// <returns>A date time object</returns>
        DateTime? ExtractEpochDateAndTime(string line);

    }
}
