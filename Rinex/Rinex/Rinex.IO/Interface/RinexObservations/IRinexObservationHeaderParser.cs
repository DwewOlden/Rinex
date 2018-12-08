using Rinex.Structures;
using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface
{
    public interface IRinexObservationHeaderParser
    {
        int[] ParseSignalTypes(string pLine);

        DateTime ParseObservationDateAndTime(string pLine);

        IPosition ParseApproximatePosistion(string pLine);

        IPosition ParseAntennaDelta(string pLine);

        IRinexHeader ParseHeaderInformation(string pLine);

        IProgramHeader ParseProgramHeader(string pLine);

        string ParseMarker(string pLine);

        IRinexObservationHeader ParseObservationHeader(string pLine);
    }
}
