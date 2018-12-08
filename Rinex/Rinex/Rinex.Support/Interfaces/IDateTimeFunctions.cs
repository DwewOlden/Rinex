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

    }
}
