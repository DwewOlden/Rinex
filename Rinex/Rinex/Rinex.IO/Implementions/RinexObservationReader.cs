using Rinex.IO.Constants;
using Rinex.IO.Interface;
using Rinex.IO.Support;
using Rinex.Structures;
using Rinex.Structures.Interfaces;
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
    public class RinexObservationReader : IObservations
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        private string mFilename_;

        /// <summary>
        /// A file support object
        /// </summary>
        private IFileSupport mFileSupport_;

        /// <summary>
        /// An instance of the observation header parser
        /// </summary>
        private IRinexObservationHeaderParser mObservationHeaderParser;

        /// <summary>
        /// The name of the file containing the observation information
        /// </summary>
        public string Filename
        {
            get
            {
                return mFilename_;
            }
            set
            {
                mFilename_ = value;

            }
        }
        
        

        /// <summary>
        /// This should be considered the default constructor for the rinex reader
        /// </summary>
        /// <param name="pFilename">The name of the file</param>
        public RinexObservationReader(IFileSupport pFileSupport)
        {
            mFileSupport_ = pFileSupport;
            mObservationHeaderParser = new RinexObservationHeaderParser();
        }


        /// <summary>
        /// Opens the file and reads the header. The file will be left open ready for the 
        /// observations to be read
        /// </summary>
        /// <param name="pFilename">The name of the file</param>
        /// <returns>True if the file could be read</returns>
        public IObservationHeader ReadObservationFileHeader(string pFilename)
        {
            mFilename_ = pFilename;
            return ReadObservationFileHeader();
        }

        public IObservationHeader ReadObservationFileHeader()
        {
            IObservationHeader lHeader_ = new ObservationHeader();

            string line = string.Empty;
            while (line !=null)
            {
                if (line.Contains(RinexIOConstant.EndOfHeader))
                    continue;

                ParseLine(line,ref lHeader_);
                
                line = mFileSupport_.ReadLine();
            }

            return lHeader_;
        }

        /// <summary>
        /// Parses a line adding the contents to the observation header
        /// </summary>
        /// <param name="line">A string from the header</param>
        /// <param name="observationHeader">The observation header</param>
        private void ParseLine(string line,ref IObservationHeader observationHeader)
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
        }

        /// <summary>
        /// Determines if a file is valie
        /// </summary>
        /// <returns>True if the file details can be found, false if they cannot</returns>
        private bool FileIsValid()
        {
            if (!mFileSupport_.FileExists(mFilename_))
                return false;

            if (!mFileSupport_.GetReader(mFilename_))
                return false;

            return true;
        }
    }
}
