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
            PopulateHeightMatrix();
            PopulatePressureMatrix();
            PopulateZenithMatrix();
            PopulateRangeCorrection();
        }

        /// <summary>
        /// Populate the height matrix
        /// </summary>
        private void PopulateHeightMatrix()
        {
            mHeightCorrections.SetValue(0, 0,0);
            mHeightCorrections.SetValue(1, 0,0.5);
            mHeightCorrections.SetValue(2, 0,1);
            mHeightCorrections.SetValue(3, 0,1.5);
            mHeightCorrections.SetValue(4, 0,2);
            mHeightCorrections.SetValue(5, 0,3);
            mHeightCorrections.SetValue(6, 0,4);
            mHeightCorrections.SetValue(7, 0,5);
        }

        /// <summary>
        /// Populate the pressure matrix
        /// </summary>
        private void PopulatePressureMatrix()
        {
            mPressureCorrections.SetValue(0, 0,1.156);
            mPressureCorrections.SetValue(1, 0,1.079);
            mPressureCorrections.SetValue(2, 0,1.006);
            mPressureCorrections.SetValue(3, 0,0.938);
            mPressureCorrections.SetValue(4, 0,0.874);
            mPressureCorrections.SetValue(5, 0,0.757);
            mPressureCorrections.SetValue(6, 0,0.654);
            mPressureCorrections.SetValue(7, 0,0.563);
        }

        /// <summary>
        /// Populate the zenith matrix
        /// </summary>
        private void PopulateZenithMatrix()
        {
            mZenithCorrections.SetValue(0, 0,60);
            mZenithCorrections.SetValue(1, 0,66);
            mZenithCorrections.SetValue(2, 0,70);
            mZenithCorrections.SetValue(3, 0,73);
            mZenithCorrections.SetValue(4, 0,75);
            mZenithCorrections.SetValue(5, 0,76);
            mZenithCorrections.SetValue(6, 0,77);
            mZenithCorrections.SetValue(7, 0,78);
            mZenithCorrections.SetValue(8, 0,78.5);
            mZenithCorrections.SetValue(9, 0,79);
            mZenithCorrections.SetValue(10, 0,79.5);
            mZenithCorrections.SetValue(11, 0,79.75);
            mZenithCorrections.SetValue(12, 0,80);
        }

        /// <summary>
        /// Populates the range matrix
        /// </summary>
        private void PopulateRangeCorrection()
        {
            mR.SetValue(0, 0, 0.003); 
            mR.SetValue(1, 0, 0.006); 
            mR.SetValue(2, 0, 0.012); 
            mR.SetValue(3, 0, 0.020); 
            mR.SetValue(4, 0, 0.031); 
            mR.SetValue(5, 0, 0.039); 
            mR.SetValue(6, 0, 0.050); 
            mR.SetValue(7, 0, 0.065); 
            mR.SetValue(8, 0, 0.075); 
            mR.SetValue(9, 0, 0.087); 
            mR.SetValue(10, 0, 0.102); 
            mR.SetValue(11, 0, 0.111); 
            mR.SetValue(12, 0, 0.121); 

            mR.SetValue(0, 1, 0.003); 
            mR.SetValue(1, 1, 0.006); 
            mR.SetValue(2, 1, 0.011); 
            mR.SetValue(3, 1, 0.018); 
            mR.SetValue(4, 1, 0.028); 
            mR.SetValue(5, 1, 0.035); 
            mR.SetValue(6, 1, 0.045); 
            mR.SetValue(7, 1, 0.059); 
            mR.SetValue(8, 1, 0.068); 
            mR.SetValue(9, 1, 0.079); 
            mR.SetValue(10, 1, 0.093); 
            mR.SetValue(11, 1, 0.101); 
            mR.SetValue(12, 1, 0.110); 

            mR.SetValue(0, 2, 0.002);
            mR.SetValue(1, 2, 005); 
            mR.SetValue(2, 2, 0.010); 
            mR.SetValue(3, 2, 0.017); 
            mR.SetValue(4, 2, 0.025); 
            mR.SetValue(5, 2, 0.032); 
            mR.SetValue(6, 2, 0.041); 
            mR.SetValue(7, 2, 0.054); 
            mR.SetValue(8, 2, 0.062); 
            mR.SetValue(9, 2, 0.072); 
            mR.SetValue(10, 2, 0.085); 
            mR.SetValue(11, 2, 0.092); 
            mR.SetValue(12, 2, 0.100); 

            mR.SetValue(0, 3, 0.002);
            mR.SetValue(1, 3, 0.005);
            mR.SetValue(2, 3, 0.009);
            mR.SetValue(3, 3, 0.015);
            mR.SetValue(4, 3, 0.023);
            mR.SetValue(5, 3, 0.029);
            mR.SetValue(6, 3, 0.037);
            mR.SetValue(7, 3, 0.049);
            mR.SetValue(8, 3, 0.056);
            mR.SetValue(9, 3, 0.065);
            mR.SetValue(10, 3, 0.077);
            mR.SetValue(11, 3, 0.083);
            mR.SetValue(12, 3, 0.091);

            mR.SetValue(0, 4,0.002);  
            mR.SetValue(1, 4,0.004);  
            mR.SetValue(2, 4,0.008);  
            mR.SetValue(3, 4,0.013);  
            mR.SetValue(4, 4,0.021); 
            mR.SetValue(5, 4,0.026);  
            mR.SetValue(6, 4,0.033);  
            mR.SetValue(7, 4,0.044);  
            mR.SetValue(8, 4,0.051);  
            mR.SetValue(9, 4,0.059);  
            mR.SetValue(10, 4,0.070);  
            mR.SetValue(11, 4,0.076);  
            mR.SetValue(12, 4,0.083);

            mR.SetValue(0, 5, 0.002);
            mR.SetValue(1, 5, 0.003);
            mR.SetValue(2, 5, 0.006);
            mR.SetValue(3, 5, 0.011);
            mR.SetValue(4, 5, 0.017);
            mR.SetValue(5, 5, 0.021);
            mR.SetValue(6, 5, 0.027);
            mR.SetValue(7, 5, 0.036);
            mR.SetValue(8, 5, 0.042);
            mR.SetValue(9, 5, 0.049);
            mR.SetValue(10, 5, 0.058);
            mR.SetValue(11, 5, 0.063);
            mR.SetValue(12, 5, 0.068);

            mR.SetValue(0, 6, 0.001); 
            mR.SetValue(1, 6, 0.003);
            mR.SetValue(2, 6, 0.005); 
            mR.SetValue(3, 6, 0.009); 
            mR.SetValue(4, 6, 0.014); 
            mR.SetValue(5, 6, 0.017); 
            mR.SetValue(6, 6, 0.022); 
            mR.SetValue(7, 6, 0.030); 
            mR.SetValue(8, 6, 0.034); 
            mR.SetValue(9, 6, 0.040); 
            mR.SetValue(10, 6, 0.047); 
            mR.SetValue(11, 6, 0.052); 
            mR.SetValue(12, 6, 0.056); 

            mR.SetValue(0, 7, 0.001);
            mR.SetValue(1, 7, 0.002);
            mR.SetValue(2, 7, 0.004);
            mR.SetValue(3, 7, 0.007);
            mR.SetValue(4, 7, 0.011);
            mR.SetValue(5, 7, 0.014);
            mR.SetValue(6, 7, 0.018);
            mR.SetValue(7, 7, 0.024);
            mR.SetValue(8, 7, 0.028);
            mR.SetValue(9, 7, 0.033);
            mR.SetValue(10, 7, 0.039);
            mR.SetValue(11, 7, 0.043);
            mR.SetValue(12, 7, 0.047);

        }
    }
}
