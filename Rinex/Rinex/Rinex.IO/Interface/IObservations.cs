using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface
{
    public interface IObservations
    {
        bool ReadObservationFileHeader();

        string Filename { get; set; }
    }
}
