﻿using Rinex.Structures;
using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface
{
    public interface IRinexObservationParser
    {
        string[] ParseSignalTypes(string pLine);

        IGPSTime ParseTimeOfFirstObservation(string pLine);

        IPosition ParseApproximatePosistion(string pLine);

        IPosition ParseAntennaDelta(string pLine);
    }
}
