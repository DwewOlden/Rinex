using Rinex.IO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rinex.Structures;
using Rinex.Structures.Interfaces;

namespace Rinex.IO.Support
{
    /// <summary>
    /// A helper class that is passed a line from a rinex file corresponding to a valid entry in the
    /// observation header and parses the nessecerilly details from there.
    /// </summary>
    public class RinexObservationHeaderParser : IRinexObservationHeaderParser
    {
        /// <summary>
        /// Parse the antenna delta
        /// </summary>
        /// <param name="pLine">The line to a parsed</param>
        /// <returns>The antenna delta</returns>
        /// <remarks>Strictly speaking this is not a posistion, but for conviniaence we are using the structures</remarks>
        public IPosition ParseAntennaDelta(string pLine)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the approximate posistion from the header of the observation file
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>The apprxomate position of the reciever</returns>
        public IPosition ParseApproximatePosistion(string pLine)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts the types of signal being recieved by the transmitter
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>An array containing the types of signal being observation</returns>
        public string[] ParseSignalTypes(string pLine)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extracts the apprximate time of the first observation
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>A time object populated with the information parsed from the observation header</returns>
        public IGPSTime ParseTimeOfFirstObservation(string pLine)
        {
            throw new NotImplementedException();
        }
    }
}
