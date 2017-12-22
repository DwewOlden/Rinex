using Rinex.IO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rinex.IO.Support
{
    public class FileSupport : IFileSupport
    {
        /// <summary>
        /// The reader that gets the information from the file
        /// </summary>
        private StreamReader mReader_;

        /// <summary>
        /// Close the file and dispose of the resources
        /// </summary>
        /// <returns>The outcome of the operation</returns>
        public bool CloseAndDispose()
        {
            try
            {
                mReader_.Close();
                mReader_.Dispose();
                mReader_ = null;
            } catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the name with the passed name exists
        /// </summary>
        /// <param name="pFilename">The name of the file</param>
        /// <returns>True if the file exists, false if it does not</returns>
        public bool FileExists(string pFilename)
        {
            if (System.IO.File.Exists(pFilename))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets a stream at the name of the file
        /// </summary>
        /// <param name="pFilename">The name of the file</param>
        /// <returns>True if the reader can be found</returns>
        public bool GetReader(string pFilename)
        {
            try
            {
                if (FileExists(pFilename))
                    mReader_ = new StreamReader(pFilename);
            } catch (Exception)
            {
                return false;
            }

            return true;
        }

        public string ReadLine()
        {
            return mReader_.ReadLine();         
        }
    }
}
