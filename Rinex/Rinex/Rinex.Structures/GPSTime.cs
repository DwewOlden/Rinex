using Rinex.Structures.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// The main operations for the GPSTime.
    /// </summary>
    public class GPSTime : IGPSTime
    {
        /// <summary>
        /// The base of the GPS week and seconds
        /// </summary>
        private DateTime mDateTime_;

        /// <summary>
        /// The GPS Week
        /// </summary>
        private int mGPSWeek_;

        /// <summary>
        /// The GPS Seconds values (in the current GPS Week)
        /// </summary>
        private int mSeconds_;

        /// <summary>
        /// The base of the GPS week and seconds
        /// </summary>
        public DateTime RegularDateTime
        {
            get
            {
                return mDateTime_;
            }

        }

        /// <summary>
        /// The GPS Week
        /// </summary>
        public int GPSWeek
        {
            get
            {
                return mGPSWeek_;
            }
        }

        /// <summary>
        /// The base of the GPS week and seconds
        /// </summary>
        public double GPSSeconds
        {
            get
            {
                return mSeconds_;
            }
        }

        public GPSTime(int pWeek, double pGPSSeconds)
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pYear">The year of the observation</param>
        /// <param name="pMonth">The month of the observation</param>
        /// <param name="pDay">The dat of the observation</param>
        /// <param name="pHour">The hour of the observation</param>
        /// <param name="pMinute">The minute of the observation</param>
        /// <param name="pSecond">The second of the observation</param>
        public GPSTime(int pYear,int pMonth,int pDay,int pHour,int pMinute,double pSecond)
        {
            mDateTime_ = new DateTime(pYear, pMonth, pDay, pHour, pMinute, (int)pSecond);
            CalculateWeekSec();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="pDateTime">A datetime object which will be used to populate the structure</param>
        public GPSTime(DateTime pDateTime):this(pDateTime.Year,pDateTime.Month,pDateTime.Day,pDateTime.Hour,pDateTime.Minute,(double)pDateTime.Second)
        { 
            CalculateWeekSec();
        }

        /// <summary>
        /// Calculate the number of weeks and GPS seconds that have passed since the 'start' date
        /// </summary>
        /// <remarks>The start date is considered the 6th January 1980. When GPS more or less became available for 
        /// non millitary applications.</remarks>
        private void CalculateWeekSec()
        {
            DateTime lStarting = new DateTime(1980, 1, 6);

            TimeSpan t = mDateTime_.Subtract(lStarting);
            int DaysSinceStart = ((int)t.TotalDays);

            // Calculate the number of weeks since the start of the period
            mGPSWeek_ = (int)Math.Floor((double)(DaysSinceStart / RinexConstants.DaysInWeek));

            // Then calculate the number of seconds since the start of the weke
            int dayOfWeek = DaysSinceStart % RinexConstants.DaysInWeek;
            mSeconds_ = mSeconds_ + (mDateTime_.Minute * RinexConstants.MinuteInAHour) + (dayOfWeek * RinexConstants.SecondsInDay) + (mDateTime_.Hour * RinexConstants.SecondsInHour);
        }


    }
}
