using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    interface IEpochData
    {
        IGPSTime Time { get; set; }
        int NumberOfSatelittes { get; set; }
        char[] Prefix { get; set; }
        int[] Prn { get; set; }
        double[] Elevation { get; set; }
        double[] TroposphericDelay { get; set; }
        double[] C1 { get; set; }
        int[] LossLock { get; set; }
        double[] ClockOffsets { get; set; }
        double ReceiverOffset { get; set; }

        IPosition[] SatelittePosition { get; set; }
        IPosition ReceiverPosition { get; set; }
       


    }
}
