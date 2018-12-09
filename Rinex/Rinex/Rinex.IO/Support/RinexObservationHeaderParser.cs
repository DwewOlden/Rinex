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
            string p3 = pLine.Substring(28, 14);

            Double.TryParse(p1.Trim(), out double d1);
            Double.TryParse(p2.Trim(), out double d2);
            Double.TryParse(p3.Trim(), out double d3);

            return new Position(d1, d2, d3);
        }


        /// <summary>
        /// Extracts the header information 
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>A Rinex File Parser record</returns>
        public IRinexHeader ParseHeaderInformation(string pLine)
        {
            string versionString = pLine.Substring(0, 9).TrimStart();

            IRinexHeader header = new RinexHeader
            {
                FileVersion = Convert.ToDouble(versionString),
                FileType = pLine.Substring(20, 19).Trim(),
                SatelliteSystem = pLine.Substring(40, 19).Trim()
            };

            return header;
        }

        /// <summary>
        /// Parse the marker text
        /// </summary>
        /// <param name="pLine">A line containing the marker text</param>
        /// <returns>The raw marker text</returns>
        public string ParseMarker(string pLine)
        {
            string marker = pLine.Substring(0, 60).TrimStart();
            return marker;
        }

        public IObserverAgency ParseObservationHeader(string pLine)
        {
            string versionString = pLine.Substring(0, 9).TrimStart();

            IObserverAgency header = new ObserverAgency
            {
                Oberver = pLine.Substring(0, 20).Trim(),
                Agency = pLine.Substring(20, 40).Trim(),
            };

            return header;
        }

        /// <summary>
        /// Parse the program header
        /// </summary>
        /// <param name="pLine">A line from the Rinex header</param>
        /// <returns>A instance of the header yexy</returns>
        public IProgramHeader ParseProgramHeader(string pLine)
        {
            string versionString = pLine.Substring(0, 9).TrimStart();

            IProgramHeader header = new ProgramHeader
            {
                ProgramName = pLine.Substring(0, 20),
                Agency = pLine.Substring(20, 19).Trim(),
                CreationDate = pLine.Substring(40, 19).Trim()
            };

            return header;
        }


        /// <summary>
        /// Extracts the types of signal being recieved by the transmitter
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>An array containing the types of signal being observation</returns>
        public int[] ParseSignalTypes(string pLine,out int Count)
        {
            string pTypesNumber = pLine.Substring(0, 6).Trim();

            if (!Int32.TryParse(pTypesNumber, out int NumberOfTypes))
                throw new ArgumentOutOfRangeException("numtypes", "unable to determine the number of types");

            Count = NumberOfTypes;

            int[] types = new int[NumberOfTypes];

            for (int i = 0; i < NumberOfTypes; i++)
            {
                string nextType = pLine.Substring(6 * (i + 2) - 2, 2);

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
        public DateTime ParseObservationDateAndTime(string pLine)
        {
            var dateTime = GetDateTimeFromString(pLine);
            if (!dateTime.HasValue)
                throw new ArgumentOutOfRangeException("firstdate", "unable to extract the date time from the string");

            return dateTime.Value;
        }

        /// <summary>
        /// Extracts the apprximate time of the last observation
        /// </summary>
        /// <param name="pLine">The line to be parsed</param>
        /// <returns>A time object populated with the information parsed from the observation header</returns>
        public DateTime ParseTimeOfLastObservation(string pLine)
        {
            var dateTime = GetDateTimeFromString(pLine);
            if (!dateTime.HasValue)
                throw new ArgumentOutOfRangeException("firstdate", "unable to extract the date time from the string");

            return dateTime.Value;
        }

        /// <summary>
        /// Converts a string into a date time
        /// </summary>
        /// <param name="pLine">A line containing a date time </param>
        /// <returns>A date time extracted from the passed string</returns>
        private DateTime? GetDateTimeFromString(string pLine)
        {
            try
            {
                // Get the data from the string
                string sYear = pLine.Substring(0, 6);
                string sMonth = pLine.Substring(6, 6);
                string sDay = pLine.Substring(12, 6);
                string sHour = pLine.Substring(18, 6);
                string sMinute = pLine.Substring(24, 6);
                string sSeconds = pLine.Substring(30, 13);

                // Convert to the correct (specification) formats
                int iYear = Convert.ToInt32(sYear);
                int iMonth = Convert.ToInt32(sMonth);
                int iDay = Convert.ToInt32(sDay);
                int iHour = Convert.ToInt32(sHour);
                int iMinute = Convert.ToInt32(sMinute);
                double dSeconds = Convert.ToDouble(sSeconds);

                // Convert to a date time
                return new DateTime(iYear, iMonth, iDay, iHour, iMonth, (int)dSeconds);

            } catch (Exception ex)
            {
                return null;
            }
        }

        IRinexObservationHeader IRinexObservationHeaderParser.ParseObservationHeader(string pLine)
        {
            throw new NotImplementedException();
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
