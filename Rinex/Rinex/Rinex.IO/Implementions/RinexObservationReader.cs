using Rinex.IO.Interface;
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
        }


        /// <summary>
        /// Opens the file and reads the header. The file will be left open ready for the 
        /// observations to be read
        /// </summary>
        /// <param name="pFilename">The name of the file</param>
        /// <returns>True if the file could be read</returns>
        public bool ReadObservationFileHeader(string pFilename)
        {
            mFilename_ = pFilename;
            return ReadObservationFileHeader();
        }

        public bool ReadObservationFileHeader()
        {
            if (!mFileSupport_.FileExists(mFilename_))
                return false;

            if (!mFileSupport_.GetReader(mFilename_))
                return false;


        }
    }
}
