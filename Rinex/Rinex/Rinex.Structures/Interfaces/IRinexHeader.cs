using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    public interface IRinexHeader
    {
        double FileVersion { get; set; }

        string FileType { get; set; }

        string SatelliteSystem { get; set; }
    }
}
