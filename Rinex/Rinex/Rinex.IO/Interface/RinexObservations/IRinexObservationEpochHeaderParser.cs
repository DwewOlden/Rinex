using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface.RinexObservations
{
    /// <summary>
    /// Functionality related to the parsing of the epoch header
    /// </summary>
    public interface IRinexObservationEpochHeaderParser
    {
        /// <summary>
        /// Extracts the record status flag from the epoch header
        /// </summary>
        int ExtractEpochFlag(string line);
    }
}
