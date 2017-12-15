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
        /// Temprature taken from the standard atmosphere model
        /// </summary>
        private const double Temperature = 18.0;

        /// <summary>
        /// Pressure taken from the standard atmosphere model
        /// </summary>
        private const double Pressure = 1013.25;

        /// <summary>
        /// Humidty taken drom the standard atmosphere mode;
        /// </summary>
        private const double Humidity = 50.0;
    }
}
