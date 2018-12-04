using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// Structures related to the program header record
    /// </summary>
    public class ProgramHeader : IProgramHeader
    {
        /// <summary>
        /// Name of program creating current file 
        /// </summary>
        public string ProgramName {get;set;}

        /// <summary>
        /// Name of agency creating current file 
        /// </summary>
        public string Agency {get;set;}

        /// <summary>
        /// Date and time of file creation 
        /// </summary>
        public string CreationDate { get; set;}
    }
}
