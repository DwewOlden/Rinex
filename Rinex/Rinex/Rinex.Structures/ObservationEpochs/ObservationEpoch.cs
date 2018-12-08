using Rinex.Structures.Interfaces.ObservationEpochs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.ObservationEpochs
{
    /// <summary>
    /// Data retireived from the epoch header in the observation
    /// </summary>
    public class ObservationEpoch : IObservationEpochHeader
    {
        /// <summary>
        /// The date and time 
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The flag value from the records
        /// </summary>
        public int Flag { get; set;  }

        /// <summary>
        /// The number of satellites in the observation header epoch
        /// </summary>
        public int NumberOfSats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// The Prns of the satellites in the epoch header
        /// </summary>
        public IEnumerable<int> Prns { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// The clock offset in the epoch header
        /// </summary>
        public double ClockOffSet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
