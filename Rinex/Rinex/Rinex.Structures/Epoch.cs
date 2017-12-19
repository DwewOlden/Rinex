using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// A class that groups the information needed in a GPS epoch together.
    /// </summary>
    public class Epoch:IEpochData
    {
        /// <summary>
        /// Time of epoch record
        /// </summary>
        private IGPSTime Time_;

        /// <summary>
        /// Number of satellites observed
        /// </summary>
        private int numSVs_;

        /// <summary>
        /// Satellite  prefix character G=GPS, R=GLONASS
        /// </summary>
        private char[] crn_;

        /// <summary>
        /// Satellite prn numbers
        /// </summary>
        private int[] prn_;

        /// <summary>
        /// Elevation angles of satellites
        /// </summary>
        private double[] elev_;

        /// <summary>
        /// Tropospheric delay
        /// </summary>
        private double[] trop_;

        /// <summary>
        /// C/A code data for each satellite
        /// </summary>
        private double[] C1_;

        /// <summary>
        /// Loss of lock indicator
        /// </summary>
        private int[] loss_lock_;

        /// <summary>
        /// Satellite coordinates
        /// </summary>
        private IPosition[] satPos_;

        /// <summary>
        /// Satellite clock offsets
        /// </summary>
        private double[] dTs_;

        /// <summary>
        /// Receiver clock offset
        /// </summary>
        private double dTr_;

        /// <summary>
        /// Receiver coordinates
        /// </summary>
        private IPosition recPos_;

        /// <summary>
        /// Time of epoch record
        /// </summary>
        public IGPSTime Time
        {
            get
            {
                return Time_;
            }

            set
            {
                Time_ = value;
            }
        }

        /// <summary>
        /// Number of satellites observed
        /// </summary>
        public int NumberOfSatelittes
        {
            get
            {
                return numSVs_;
            }

            set
            {
                numSVs_ = value;
            }
        }

        /// <summary>
        /// Satellite  prefix character G=GPS, R=GLONASS
        /// </summary>
        public char[] Prefix
        {
            get
            {
                return crn_;
            }

            set
            {
                crn_ = value;
            }
        }

        /// <summary>
        /// Satellite prn numbers
        /// </summary>
        public int[] Prn
        {
            get
            {
                return prn_;
            }
            set
            {
                prn_ = value;
            }
        }

        /// <summary>
        /// Elevation angles of satellites
        /// </summary>
        public double[] Elevation
        {
            get
            {
                return elev_;
            }

            set
            {
                elev_ = value;
            }
        }

        /// <summary>
        /// Tropospheric delay
        /// </summary>
        public double[] TroposphericDelay
        {
            get
            {
                return trop_;
            }

            set
            {
                trop_ = value;
            }
        }

        /// <summary>
        /// C/A code data for each satellite
        /// </summary>
        public double[] C1
        {
            get
            {
                return C1_;
            }

            set
            {
                C1_ = value;
            }
        }

        public int[] LossLock
        {
            get
            {
                return loss_lock_;
            }

            set
            {
                loss_lock_ = value;
            }
        }

        /// <summary>
        /// Satellite clock offsets
        /// </summary>
        public double[] ClockOffsets
        {
            get
            {
                return dTs_;
            }

            set
            {
                dTs_ = value;
            }
        }

        /// <summary>
        /// Receiver clock offset
        /// </summary>
        public double ReceiverOffset
        {
            get
            {
                return dTr_;
            }

            set
            {
                dTr_ = value;
            }
        }

        /// <summary>
        /// Satellite coordinates
        /// </summary>
        public IPosition[] SatelittePosition
        {
            get
            {
                return satPos_;
            }

            set
            {
                satPos_ = value;
            }
        }

        /// <summary>
        /// Receiver coordinates
        /// </summary>
        public IPosition ReceiverPosition
        {
            get
            {
                return recPos_;
            }

            set
            {
                recPos_ = value;
            }
        }

        public override string ToString()
        {
            return string.Format("GPS Week:{0} GPS Seconds:{1} Number Satellites:{2}", Time.GPSWeek, Time.GPSSeconds, numSVs_);
        }

        public override int GetHashCode()
        {
            return Time.GetHashCode() * numSVs_;    
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj.GetType() != this.GetType())
                return false;
            else
            {
                Epoch e = (Epoch)obj;
                if ((e.Time == this.Time) && (e.numSVs_ == this.numSVs_))
                    return true;
                else
                    return false;

            }
        }
    }
}
