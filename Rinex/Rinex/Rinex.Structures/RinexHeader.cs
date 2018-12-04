using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// Implements a rinex header record
    /// </summary>
    public class RinexHeader : IRinexHeader
    {
        /// <summary>
        /// The version of the file
        /// </summary>
        public double FileVersion { get; set; }

        /// <summary>
        /// The Type of File
        /// </summary>
        public string FileType { get;set; }

        /// <summary>
        /// The Satellite system used to record the observarions.
        /// </summary>
        public string SatelliteSystem { get; set ; }

        public RinexHeader()
        {

        }

        public RinexHeader(string pFileVersion, string pType, string pSystem)
        {
            double d = Convert.ToDouble(pFileVersion);
            new RinexHeader(d, pType, pSystem);
        }

        public RinexHeader(double pFileVersion,string pType,string pSystem)
        {
            FileVersion = pFileVersion;
            FileType = pType;
            SatelliteSystem = pSystem;
        }
    }
}
