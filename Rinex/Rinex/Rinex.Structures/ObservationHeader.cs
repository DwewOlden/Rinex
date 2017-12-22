using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    public class ObservationHeader : IObservationHeader
    {
        /// <summary>
        /// The date and time of the first observation
        /// </summary>
        private DateTime mFirst_;

        /// <summary>
        /// The approximate first position
        /// </summary>
        private IPosition mApprox_;

        /// <summary>
        /// The approximate antenna delta (offset)
        /// </summary>
        private IPosition mDelta_;

        /// <summary>
        /// The date and time of the first observation
        /// </summary>
        public DateTime FirstObservation
        {
            get
            {
                return mFirst_;
            }
            set
            {
                mFirst_ = value;
            }
        }

        /// <summary>
        /// The approximate first position
        /// </summary>
        public IPosition ApproximatePosition
        {
            get
            {
                return mApprox_;
            }

            set
            {
                mApprox_ = value;
            }
        }

        /// <summary>
        /// The approximate antenna delta (offset)
        /// </summary>
        public IPosition AntennaDelta
        {
            get
            {
                return mDelta_;
            }
            set
            {
                mDelta_ = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObservationHeader()
        {

        }

        public ObservationHeader(DateTime pDateTime,IPosition pApproximate,IPosition pDelta)
        {
            mFirst_ = pDateTime;
            mDelta_ = pDelta;
            mApprox_ = pApproximate;
        }

        public override int GetHashCode()
        {
            return (int)mFirst_.TimeOfDay.Ticks;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj.GetType() != this.GetType())
                return false;
            else
            {
                ObservationHeader h = (ObservationHeader)obj;
                if ((h.mFirst_ == this.mFirst_) && (h.mDelta_ == this.mDelta_) && (h.mApprox_ == this.mApprox_))
                    return true;
                else
                    return false;
            }
        }

        public override string ToString()
        {
            return string.Format("First Date:{0} Approximate:{1} Antenna:{2}", mFirst_.ToString(), mApprox_.ToString(), mDelta_.ToString());
        }
    }
}
