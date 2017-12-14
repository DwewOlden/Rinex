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
        /// The year of the observation
        /// </summary>
        private int mYear_;

        /// <summary>
        /// The month of the observation
        /// </summary>
        private int mMonth_;

        /// <summary>
        /// The day of the observation
        /// </summary>
        private int mDay_;

        /// <summary>
        /// The hour of the observation
        /// </summary>
        private int mHour_;

        /// <summary>
        /// The minute of the observation
        /// </summary>
        private int mMinute_;

        /// <summary>
        /// The day of the year
        /// </summary>
        private int mDayOfYear_;

        /// <summary>
        /// The seconds interval
        /// </summary>
        private double mSeconds_;

        /// <summary>
        /// The GPS seconds interval
        /// </summary>
        private double mGPSSeconds_;

        /// <summary>
        /// The week of the observation
        /// </summary>
        private int mWeek_;

        /// <summary>
        /// The year of the observation
        /// </summary>
        public int Year
        {
            get
            {
                return mYear_;
            }
        }

        /// <summary>
        /// The month of the observation
        /// </summary>
        public int Month
        {
            get
            {
                return mMonth_;
            }
        }

        /// <summary>
        /// The day of the observation
        /// </summary>
        public int Day
        {
            get
            {
                return mDay_;
            }
        }

        /// <summary>
        /// The hour of the observation
        /// </summary>
        public int Hour
        {
            get
            {
                return mHour_;
            }
        }

        /// <summary>
        /// The minute of the observation
        /// </summary>
        public int Minute
        {
            get
            {
                return mMinute_;
            }
        }

        /// <summary>
        /// The day of the year of the observation
        /// </summary>
        public int DayOfYear
        {
            get
            {
                return mDayOfYear_;
            }
        }

        /// <summary>
        /// The seconds interval
        /// </summary>
        public double Seconds
        {
            get
            {
                return mSeconds_;
            }
        }

        /// <summary>
        /// The GPS seconds interval
        /// </summary>
        public double GPSSeconds
        {
            get
            {
                return mGPSSeconds_;
            }
        }

        /// <summary>
        /// The week of the observaion
        /// </summary>
        public int Week
        {
            get
            {
                return mWeek_;
            }
        }


        /// <summary>
        /// Checks if all the required values are zero
        /// </summary>
        /// <remarks>Another reason why we didnt use DateTime and extend it.</remarks>
        public bool IsZero
        {
            get
            {
                if ((mYear_ == 0) && (mMonth_ == 0) && (mDay_ == 0) && (mHour_ == 0) && (mMinute_ == 0) && (mSeconds_ == 0.0) && (mWeek_ == 0) && (mGPSSeconds_ == 0.0))
                    return true;
                else
                    return false;
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
            // Populate the local values with those passed
            mYear_ = pYear;
            mMonth_ = pMonth;
            mDay_ = pDay;
            mHour_ = pHour;
            mMinute_ = pMinute;
            mSeconds_ = pSecond;

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
            DateTime lCurrent = new DateTime(mYear_, mMonth_, mDay_);
            DateTime lStarting = new DateTime(1980, 1, 6);

            TimeSpan t = lCurrent.Subtract(lStarting);
            int DaysSinceStart = ((int)t.TotalDays);

            // Calculate the number of weeks since the start of the period
            mWeek_ = (int)Math.Floor((double)(DaysSinceStart / RinexConstants.DaysInWeek));

            // Then calculate the number of seconds since the start of the weke
            int dayOfWeek = DaysSinceStart % RinexConstants.DaysInWeek;
            mGPSSeconds_ = mSeconds_ + (mMinute_ * RinexConstants.MinuteInAHour) + (dayOfWeek * RinexConstants.SecondsInDay) + (mHour_ * RinexConstants.SecondsInHour);
        }


    }
}
