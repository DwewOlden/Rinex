using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Models
{
    /// <summary>
    /// Calculates the loss due to the signal travelling througth the tropesphere
    /// </summary>
    /// <remarks>"Guochang Xu, GPS - Theory, Algorithms and Applications, Springer, 2007"</remarks>
    public class TropesphericModel
    {
        /// <summary>
        /// Contains the values used when interpolating the values
        /// </summary>
        TroposphereModelLookups mLookups_;

        public TropesphericModel()
        {
            mLookups_ = new TroposphereModelLookups();
        }

        /// <summary>
        /// Calculates the loss due to signal having to travel througth the tropesphere
        /// </summary>
        /// <param name="pHeight">The height above sea level of the receiver</param>
        /// <param name="pZenith">The zenith of the location</param>
        /// <returns>The loss of the signal (measured in terms of the delay in time) due to the travel througth the tropesphere </returns>
        double CalculateTheLossDueToTropesphere(double pHeight, double pZenith)
        {
            double lHeight = CleanHeight(pHeight);

            // Correct the pressure value at the height
            CalculateValuesAtHeght(lHeight, out double lPressureAtHeight, out double lTempratureAtHeight, out double lHumidityAtHeight, out double lWaterPressureAtHeight);
            double lHeightInKilometers = CalculateHeightAsKilometers(lHeight);

            int lHeightPointer = mLookups_.GetHeightIndex(lHeightInKilometers);
            int lZenithPointer = mLookups_.GetZenithIndex(pZenith);

            double lInterpolatedPressureValue = mLookups_.CalculateInterpolatedPressure(lHeightInKilometers, lHeightPointer);
            double lInterpolatedRangeValue = 0;

            if (pZenith > 60)
                lInterpolatedRangeValue = mLookups_.CalculatedInterpolatedRange(lHeightInKilometers, lHeightPointer, lZenithPointer, pZenith);
            
            double lZenithInRadians = (pZenith * (System.Math.PI / 180));
            double lTropesphericCorrection = lPressureAtHeight + (((1255 / lTempratureAtHeight) + 0.05) *lWaterPressureAtHeight) -
                                      (lInterpolatedPressureValue * System.Math.Tan(lZenithInRadians) * System.Math.Tan(lZenithInRadians));

            lTropesphericCorrection *= (0.002277 / System.Math.Cos(lZenithInRadians));
            lTropesphericCorrection += lInterpolatedRangeValue;

            return lTropesphericCorrection;
        }

        /// <summary>
        /// Cleans the height if it is beyond certain extremes
        /// </summary>
        /// <param name="pHeight">The uncleaned height</param>
        /// <returns>The cleaned height</returns>
        private double CleanHeight(double pHeight)
        {
            if (pHeight < 0.0)
                return 0.0;
            if (pHeight > 5000.0)
                return 5000.0;

            // If the height within the set limits then its OK, but we want to 
            // return it as KM
            return pHeight;
        }

        /// <summary>
        /// Convert the height in meters to Kilometers, keeping the limits 
        /// </summary>
        /// <param name="pHeight">The height to be converted</param>
        /// <returns>The height as kilometers</returns>
        private double CalculateHeightAsKilometers(double pHeight)
        {
            if (pHeight < 0)
                return 0;
            else if (pHeight > 5000)
                return 5;
            else
                return (pHeight / 1000);
        }

        /// <summary>
        /// Calculates the values at the passed height based on the passed constants
        /// </summary>
        /// <param name="pHeight">The current height</param>
        /// <param name="pPressureAtHeight">The calcuates pressure at the passed height</param>
        /// <param name="pTempratureAtHeight">The calculated pressure at the passed height</param>
        /// <param name="pHumidityAtHeight">The calculated humidity at the passed height</param>
        /// <param name="pWaterVapourPressure">The calculated water pressure at the passed height</param>
        public void CalculateValuesAtHeght(double pHeight, out double pPressureAtHeight, out double pTempratureAtHeight, out double pHumidityAtHeight, out double pWaterVapourPressure)
        {
            pPressureAtHeight = StandardAtmosphereModel.Pressure * System.Math.Pow(((1 - 2.26E-05 * pHeight)), 5.225);
            pTempratureAtHeight = (StandardAtmosphereModel.Temperature - (pHeight * 0.0065)) + 273.15;
            pHumidityAtHeight = StandardAtmosphereModel.Humidity * System.Math.Exp(-6.396E-04 * pHeight);

            // water vapour pressure
            pWaterVapourPressure = (pHumidityAtHeight / 100.0) *System.Math.Exp(-37.2465 + (0.213166 * pTempratureAtHeight) -
                              (0.000256908 * pTempratureAtHeight * pTempratureAtHeight));
        }
    }
}
