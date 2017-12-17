using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// Stores the base location information as a X Y and Z.
    /// </summary>
    /// <remarks>Eventually this will represent the Lat,lon and height of the receiver</remarks>
    public class Position : IPosition
    {
        /// <summary>
        /// The x position of the location
        /// </summary>
        private double mX_;

        /// <summary>
        /// The y position of the locations
        /// </summary>
        private double mY_;

        /// <summary>
        /// The height of the location
        /// </summary>
        private double mZ_;

        /// <summary>
        /// The x position of the location
        /// </summary>
        public double X
        {
            get
            {
                return mX_;
            }
        }

        /// <summary>
        /// The y position of the locations
        /// </summary>
        public double Y
        {
            get
            {
                return mY_;
            }
        }

        /// <summary>
        /// The height of the location
        /// </summary>
        public double Z
        {
            get
            {
                return mZ_;
            }
        }

        /// <summary>
        /// Returns true if the location is centered at point 0.
        /// </summary>
        public bool IsZero
        {
            get
            {
                if (mX_ == 0 && mY_ == 0 && mZ_ == 0)
                    return true;
                else
                    return false;
            }
        }

        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pX">The x position of the location</param>
        /// <param name="pY">The y position of the locations</param>
        /// <param name="pZ">The height of the location</param>
        public Position(double pX,double pY,double pZ)
        {
            mX_ = pX;
            mY_ = pY;
            mZ_ = pZ;
        }

        public Position(Position p)
        {
            mX_ = p.mX_;
            mY_ = p.mY_;
            mZ_ = p.mZ_;
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", mX_, mY_, mZ_);
        }

        public override int GetHashCode()
        {
            return (int)mX_;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (this.GetType() != obj.GetType())
                return false;
            else
            {
                Position p = (Position)obj;
                if ((this.mX_ != p.mX_) && (this.mY_ != p.mY_) && (this.mZ_ != p.mZ_))
                    return false;
                else
                    return true;

            }
        }
    }
}
