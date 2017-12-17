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
    }
}
