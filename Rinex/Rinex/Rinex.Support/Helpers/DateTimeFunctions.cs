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
        /// Extracts the epoch date and time from the file 
        /// </summary>
        /// <param name="line">A line from the rinex observaiton file, the first line
        /// from the epoch.</param>
        /// <returns>A date time object</returns>
        public DateTime? ExtractEpochDateAndTime(string line)
        {
            try
            {
                string sYear = line.Substring(1, 2);
                string sMonth = line.Substring(4, 2);
                string sDay = line.Substring(7, 2);
                string sHour = line.Substring(10, 2);
                string sMinute = line.Substring(13, 2);
                string sSeconds = line.Substring(15, 11);

                int iYear = PadDate(sYear);
                int iMonth = Convert.ToInt32(sMonth);
                int iDay = Convert.ToInt32(sDay);
                int iHour = Convert.ToInt32(sHour);
                int iMinute = Convert.ToInt32(sMinute);

                double dSeconds = Convert.ToDouble(sSeconds);
                int iSeconds = (int)dSeconds;

                DateTime dateTime = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSeconds);
                return dateTime;

            } catch (Exception)
            {
                return null;
            }

        }

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
