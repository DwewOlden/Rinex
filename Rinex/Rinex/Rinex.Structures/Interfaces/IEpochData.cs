using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    interface IEpochData
    {
        IGPSTime Time { get; }
        int NumberOfSatelittes { get; }
        char[] Prefix { get; }
        int[] Prn { get; }
        double[] Elevation { get; }
        double[] TroposphericDelay { get; }
        double[] C1 { get; }
        int[] LossLock { get; }
        double[] ClockOffsets { get; }
        double ReceiverOffset { get; }

        IPosition[] SatelittePosition { get; }
        IPosition ReceiverPosition { get; }
       


    }
}
