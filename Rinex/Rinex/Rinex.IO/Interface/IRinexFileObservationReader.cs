using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface.RinexObservations
{
    /// <summary>
    /// Contains the functionality that manages the reading of the rinex files.
    /// </summary>
    public interface IRinexFileObservationReader
    {
        /// <summary>
        /// The name of the file containing the observation information
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        /// Reads the contents
        /// </summary>
        /// <param name="Filename">The name of the file</param>
        /// <returns>True if the observation file could be read correctly.</returns>
        bool ReadFile();
    }
}
