using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    /// <summary>
    /// Structures related to the program header record
    /// </summary>
    public interface IProgramHeader
    {
        /// <summary>
        /// Name of program creating current file 
        /// </summary>
        string ProgramName { get; set; }

        /// <summary>
        /// Name of agency creating current file 
        /// </summary>
        string Agency { get; set; }

        /// <summary>
        /// Date and time of file creation 
        /// </summary>
        string CreationDate { get; set; }
    }
}
