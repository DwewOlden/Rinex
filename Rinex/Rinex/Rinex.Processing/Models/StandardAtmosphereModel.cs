using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Models
{
    /// <summary>
    /// Some constants used in the standard atmosphere model
    /// </summary>
    public class StandardAtmosphereModel
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
