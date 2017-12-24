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
            string p1 = pLine.Substring(0, 14);
            string p2 = pLine.Substring(14, 14);
            string p3 = pLine.Substring(28, 42);

            Double.TryParse(p1.Trim(), out double d1);
            Double.TryParse(p2.Trim(), out double d2);
            Double.TryParse(p3.Trim(), out double d3);

            return new Position(d1, d2, d3);
        }

        /// <summary>
        /// Gets the approximate posistion from the header of the observation file
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>The apprxomate position of the reciever</returns>
        public IPosition ParseApproximatePosistion(string pLine)
        {
            string p1 = pLine.Substring(0, 14);
            string p2 = pLine.Substring(14, 14);
            string p3 = pLine.Substring(28, 42);

            Double.TryParse(p1.Trim(), out double d1);
            Double.TryParse(p2.Trim(), out double d2);
            Double.TryParse(p3.Trim(), out double d3);

            return new Position(d1, d2, d3);
        }

        /// <summary>
        /// Extracts the types of signal being recieved by the transmitter
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>An array containing the types of signal being observation</returns>
        public int[] ParseSignalTypes(string pLine)
        {
            string pTypesNumber = pLine.Substring(0, 6).Trim();

            if (!Int32.TryParse(pTypesNumber, out int NumberOfTypes))
                throw new ArgumentOutOfRangeException("numtypes", "unable to determine the number of types");

            int[] types = new int[NumberOfTypes];

            for (int i = 0; i < NumberOfTypes; i++)
            {
                string nextType = pLine.Substring(6 * (i + 2)-2, 2);

                switch (nextType)
                {
                    case "C1":
                        types[i] = (int)SignalType.C1;
                        break;
                    case "C2":
                        types[i] = (int)SignalType.C2;
                        break;
                    case "P1":
                        types[i] = (int)SignalType.P1;
                        break;
                    case "P2":
                        types[i] = (int)SignalType.P2;
                        break;
                    case "L1":
                        types[i] = (int)SignalType.L1;
                        break;
                    case "L2":
                        types[i] = (int)SignalType.L2;
                        break;
                    case "S1":
                        types[i] = (int)SignalType.S1;
                        break;
                    case "S2":
                        types[i] = (int)SignalType.S2;
                        break;
                }
            }

            return types;
        }

        /// <summary>
        /// Extracts the apprximate time of the first observation
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>A time object populated with the information parsed from the observation header</returns>
        public IGPSTime ParseTimeOfFirstObservation(string pLine)
        {
            string lLine = pLine.Substring(0, 42);

            while (lLine.Contains("  "))
                lLine = lLine.Replace("  ", " ");

            if (DateTime.TryParse(lLine, out DateTime d))
                return new GPSTime(d);
            else
                throw new ArgumentOutOfRangeException("firstdate", "unable to extract the date time from the string");
        }
    }

    /// <summary>
    /// The intenral ordering of the signal types
    /// </summary>
    public enum SignalType
    {
        C1 = 0,
        C2 = 1,
        P1 = 2,
        P2 = 3,
        L1 = 4,
        L2 = 5,
        S1 = 6,
        S2 = 7,
        D1 = 8,
        D2 = 9
    }
        
}
