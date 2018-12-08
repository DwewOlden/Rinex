using Rinex.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Support.Helpers
{
    /// <summary>
    /// Functions to assist in the work on GPS DateTimes
    /// </summary>
    public class DateTimeFunctions : IDateTimeFunctions
    {
        /// <summary>
        /// Converts a two digit year into a four digit year
        /// </summary>
        /// <param name="year">The year we want to convert, as a string</param>
        /// <returns>A four digit version fo the passed string</returns>
        /// <remarks>The format is specified is the rinex documention, and only applies to two
        /// digit years specified in the epoch</remarks>
        public int PadDate(string year)
        {
            string trimmed = year.Trim();
            if (trimmed.Length <=2)
            {
                int iYear = Convert.ToInt32(trimmed);

                if (iYear >= 80 && iYear <= 99)
                    return iYear + 1900;

                if (iYear >= 0 && iYear <= 79)
                    return iYear + 2000;

                return iYear;
                
            }
            else
                return Convert.ToInt32(year);

        }
    }
}
