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
            mGPSWeek_ = pWeek;
            mSeconds_ = (int)pGPSSeconds;
            CalculateDateTime();
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
            mSeconds_ = mDateTime_.Second + (mDateTime_.Minute * RinexConstants.MinuteInAHour) + (dayOfWeek * RinexConstants.SecondsInDay) + (mDateTime_.Hour * RinexConstants.SecondsInHour);
        }

        /// <summary>
        /// Calculates the date time from the GPS week and seconds.
        /// </summary>
        private void CalculateDateTime()
        {
            int dayOfWeek;
            int hr_, min_, sec_;
            DateTime theDate;

            GetTheDateFromGPSWeek(out dayOfWeek, out theDate);
            CalculateTheTimeOfDay(dayOfWeek, out hr_, out min_, out sec_);

            mDateTime_ = new DateTime(theDate.Year, theDate.Month, theDate.Day, hr_, min_, sec_);
        }

        /// <summary>
        /// Calculate the time of day
        /// </summary>
        /// <param name="dayOfWeek">The day of the week of the GPS period</param>
        /// <param name="hr_">The hour of the day</param>
        /// <param name="min_">The minutes of the hour</param>
        /// <param name="sec_">The seconds of the minute</param>
        private void CalculateTheTimeOfDay(int dayOfWeek, out int hr_, out int min_, out int sec_)
        {
            float secsToday = mSeconds_ - (dayOfWeek * RinexConstants.SecondsInDay);
            hr_ = (int)(Math.Floor(secsToday / 3600));
            int hrsToday = (int)secsToday - (hr_ * RinexConstants.SecondsInHour);
            min_ = (int)(Math.Floor((double)(hrsToday / 60)));
            sec_ = (hrsToday % 60);
        }

        /// <summary>
        /// Gets the date from the GPS weeek
        /// </summary>
        /// <param name="pDayOfWeek">The day of the week</param>
        /// <param name="pDate">The date time</param>
        private void GetTheDateFromGPSWeek(out int pDayOfWeek, out DateTime pDate)
        {
            int daysSinceStart = (mGPSWeek_ * RinexConstants.DaysInWeek) + 6;
            int year_ = (int)Math.Floor(daysSinceStart / 365.25) + 1980;
            int LeapYears = CountNumberOfYears(year_);

            int daysToStartYr = ((year_ - 1980) * 365) + LeapYears;
            int dayOfYear = daysSinceStart - daysToStartYr;
            pDayOfWeek = (int)(Math.Floor((double)((mSeconds_ / RinexConstants.SecondsInDay))));
            dayOfYear += pDayOfWeek;

            pDate = new DateTime(year_, 1, 1).AddDays(dayOfYear - 1);
        }

        /// <summary>
        /// Counts the number of leap years in the passed year
        /// </summary>
        /// <param name="year_">The current year</param>
        /// <returns>The number of years between the passed year and 1980</returns>
        private int CountNumberOfYears(int year_)
        {
            int leapyear = year_ % 4;
            int numleaps = (int)(Math.Floor((float)(year_ - 1980) / 4.0));
            if (leapyear != 0) numleaps++;

            return numleaps;
        }
    }
}
