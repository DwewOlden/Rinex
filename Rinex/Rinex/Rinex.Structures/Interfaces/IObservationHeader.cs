using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    public interface IObservationHeader
    {
        DateTime FirstObservation { get; set; }

        IPosition ApproximatePosition { get; set; }

        IPosition AntennaDelta { get; set; }

        IProgramHeader ProgramHeader { get; set; }

        IObserverAgency ObserverAgency { get; set; }

        int[] SignalTypes { get; set; }

        IRinexHeader RinexHeader { get; set; }

        /// <summary>
        /// A string representing the marker
        /// </summary>
        string Marker { get; set; }
    }
}
