using Rinex.IO.Constants;
using Rinex.IO.Interface;
using Rinex.IO.Interface.RinexObservations;
using Rinex.IO.Support;
using Rinex.Structures;
using Rinex.Structures.Interfaces;
using Rinex.Structures.Interfaces.ObservationEpochs;
using Rinex.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Implementions
{
    /// <summary>
    /// Reads the information from the rinex observation file
    /// </summary>
    public class RinexObservationReader : IRinexFileObservationReader
    {
        /// <summary>
        /// An instance of the date time functions
        /// </summary>
        IDateTimeFunctions mDateTimeFunctions;


        /// <summary>
        /// The name of the file containing the observation information
        /// </summary>
        public string Filename { get;set;}

        /// <summary>
        /// A file support object
        /// </summary>
        private IFileSupport mFileSupport_;

        /// <summary>
        /// An instance of the observation header parser
        /// </summary>
        private IRinexObservationHeaderParser mObservationHeaderParser;

        /// <summary>
        /// This should be considered the default constructor for the rinex reader
        /// </summary>
        /// <param name="pFilename">The name of the file</param>
        public RinexObservationReader(IFileSupport pFileSupport,IDateTimeFunctions pDateTimeFunctions)
        {
            mFileSupport_ = pFileSupport;
            mDateTimeFunctions = pDateTimeFunctions;
            mObservationHeaderParser = new RinexObservationHeaderParser();
        }

        /// <summary>
        /// Reads the contents from the file.
        /// </summary>
        /// <returns>True if the file could be read succesfully.</returns>
        public bool ReadFile()
        {
            mFileSupport_.Filename = Filename;
            if (!FileIsValid())
                throw new ArgumentException("filename", "there is an issue with file, check it exists at specified path");

            var header_ = ReadObservationFileHeader();

            var body_ = ReaderObservationBodies();


            return true;
        }

        /// <summary>
        /// Reads the observation epoch records
        /// </summary>
        /// <returns></returns>
        private object ReaderObservationBodies()
        {
            string line = mFileSupport_.ReadLine();
            while (line != null)
            {
                var epochHeader = ProcessEpochHeader(line);
                
                line = mFileSupport_.ReadLine();
            }

            return null;
        }

        /// <summary>
        /// Extracts information from the epoch header
        /// </summary>
        /// <param name="line">A string containing the epoch header</param>
        /// <returns>A populated epoch observation header</returns>
        private IObservationEpochHeader ProcessEpochHeader(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentException("line", "the line was empty, was expecting a epoch header");

            DateTime? epochTime = mDateTimeFunctions.ExtractEpochDateAndTime(line);
            if (!epochTime.HasValue)
                throw new ArgumentException("line", "unable to extract the epoch header from the line");

            











            return null;





        }


        /// <summary>
        /// Opens the file and reads the header. The file will be left open ready for the 
        /// observations to be read
        /// </summary>
        /// <returns>True if the file could be read</returns>
        private IRinexObservationHeader ReadObservationFileHeader()
        {
            IRinexObservationHeader lHeader_ = new ObservationHeader();

            string line = mFileSupport_.ReadLine();
            while (line != null)
            {
                if (line.Contains(RinexIOConstant.EndOfHeader))
                    break;

                ParseHeaderLine(line, ref lHeader_);

                line = mFileSupport_.ReadLine();
            }

            return lHeader_;
            
        }


        /// <summary>
        /// Parses a line adding the contents to the observation header
        /// </summary>
        /// <param name="line">A string from the header</param>
        /// <param name="observationHeader">The observation header</param>
        private void ParseHeaderLine(string line, ref IRinexObservationHeader observationHeader)
        {
            if (line.Contains(RinexIOConstant.AntennaDelta))
                observationHeader.AntennaDelta = mObservationHeaderParser.ParseAntennaDelta(line);

            if (line.Contains(RinexIOConstant.ApproximatePosition))
                observationHeader.ApproximatePosition = mObservationHeaderParser.ParseApproximatePosistion(line);

            if (line.Contains(RinexIOConstant.MarkerName))
                observationHeader.Marker = mObservationHeaderParser.ParseMarker(line);

            if (line.Contains(RinexIOConstant.ObserverationTypes))
                observationHeader.SignalTypes = mObservationHeaderParser.ParseSignalTypes(line);

            if (line.Contains(RinexIOConstant.ProgramInformation))
                observationHeader.ProgramHeader = mObservationHeaderParser.ParseProgramHeader(line);

            if (line.Contains(RinexIOConstant.RinexVersion))
                observationHeader.RinexHeader = mObservationHeaderParser.ParseHeaderInformation(line);

            if (line.Contains(RinexIOConstant.TimeOfFirstObservation))
                observationHeader.FirstObservation = mObservationHeaderParser.ParseObservationDateAndTime(line);

            if (line.Contains(RinexIOConstant.TimeOfLastObservation))
                observationHeader.LastObservation = mObservationHeaderParser.ParseObservationDateAndTime(line);
        }

        /// <summary>
        /// Determines if a file is valie
        /// </summary>
        /// <returns>True if the file details can be found, false if they cannot</returns>
        private bool FileIsValid()
        {
            if (!mFileSupport_.FileExists(Filename))
                return false;

            if (!mFileSupport_.GetReader(Filename))
                return false;

            return true;
        }
    }
}
