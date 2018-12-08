using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces.ObservationEpochs
{
    public interface IObservationEpochHeader
    {
        /// <summary>
        /// The date and time of the observation
        /// </summary>
        DateTime Time { get; set; }

        /// <summary>
        /// The flag
        /// </summary>
        int Flag { get; set; }

        /// <summary>
        /// The number of satellites in the epoch
        /// </summary>
        int NumberOfSats { get; set; }

        /// <summary>
        /// The Prns Of The Satellites in the Epoch
        /// </summary>
        IEnumerable<int> Prns { get; set; }

        /// <summary>
        /// The clock offset value
        /// </summary>
        double ClockOffSet { get; set; }
    }
}
