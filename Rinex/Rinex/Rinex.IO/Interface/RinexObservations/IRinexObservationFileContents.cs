using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface
{
    public interface IRinexObervationFileContents
    {
        IRinexObservationHeader Header();

        string Filename { get; set; }
    }
}
