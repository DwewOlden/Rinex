using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rinex.Processing.Math;

namespace Rinex.Processing.Models
{
    /// <summary>
    /// The following matrix store the information used to calculate the loss 
    /// due to signal transfer througth the atmosphere
    /// </summary>
    /// <remarks>
    /// "Guochang Xu, GPS - Theory, Algorithms and Applications, Springer, 2007"
    /// </remarks>
    public class TroposphereModelLookups :ITroposphericModelMatrix
    {
        /// <summary>
        /// A matrix used to store the height corrections
        /// </summary>
        Matrix mHeightCorrections = new Matrix(8, 1);

        /// <summary>
        /// A Matrix use to store the Pressure corrections
        /// </summary>
        Matrix mPressureCorrections;

        /// <summary>
        /// A Matrix used to store the zenith corrections
        /// </summary>
        Matrix mZenithCorrections;     
        
        /// <summary>
        /// A Matrix used to store the range corrections
        /// </summary>
        Matrix mR;

        /// <summary>
        /// A matrix used to store the height corrections
        /// </summary>
        public IMatrix PressureMatrix
        {
            get
            {
                return mPressureCorrections;
            }
        }

        /// <summary>
        /// A Matrix use to store the Pressure corrections
        /// </summary>
        public IMatrix HeightMatrix
        {
            get
            {
                return mHeightCorrections;
            }
        }

        /// <summary>
        /// A Matrix used to store the zenith corrections
        /// </summary>
        public IMatrix ZentithMatrix
        {
            get
            {
                return mZenithCorrections;
            }
        }

        /// <summary>
        /// A Matrix used to store the range corrections
        /// </summary>
        public IMatrix RangeMatrix
        {
            get
            {
                return mR;
            }
        }

        public TroposphereModelLookups()
        {
            InitalizeMatrix();
            PopulateMatrix();
        }

        /// <summary>
        /// Initalize the matrix to the appropriate size required
        /// </summary>
        private void InitalizeMatrix()
        {
            mHeightCorrections = new Matrix(1, 8);
            mPressureCorrections = new Matrix(1, 8);
            mZenithCorrections = new Matrix(1, 13);
            mR = new Matrix(8, 13);
        }

        /// <summary>
        /// Places the data into the various arrays.
        /// </summary>
        private void PopulateMatrix()
        {
            throw new NotImplementedException();
        }

        
    }
}
