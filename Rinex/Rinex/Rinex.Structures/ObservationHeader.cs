using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    public class ObservationHeader : IRinexObservationHeader
    {

        
        public IProgramHeader ProgramHeader { get; set; }


        public IObserverAgency ObserverAgency { get; set; }

        /// <summary>
        /// The date and time of the first observation
        /// </summary>
        public DateTime FirstObservation { get; set; }

        /// <summary>
        /// The approximate first position
        /// </summary>
        public IPosition ApproximatePosition { get; set; }

        /// <summary>
        /// The approximate antenna delta (offset)
        /// </summary>
        public IPosition AntennaDelta { get; set; }

        /// <summary>
        /// A list of signal types
        /// </summary>
        public int[] SignalTypes { get; set; }

        /// <summary>
        /// Information from the rinex file
        /// </summary>
        public IRinexHeader RinexHeader { get; set;  }

        /// <summary>
        /// A string representing the marker
        /// </summary>
        public string Marker { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObservationHeader()
        {

        }

        public ObservationHeader(DateTime pDateTime,IPosition pApproximate,IPosition pDelta)
        {
            FirstObservation = pDateTime;
            AntennaDelta = pDelta;
            ApproximatePosition = pApproximate;
        }

        public override int GetHashCode()
        {
            return (int)FirstObservation.TimeOfDay.Ticks;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj.GetType() != this.GetType())
                return false;
            else
            {
                ObservationHeader h = (ObservationHeader)obj;
                if ((h.FirstObservation == this.FirstObservation) && (h.AntennaDelta == this.AntennaDelta) && (h.ApproximatePosition == this.ApproximatePosition))
                    return true;
                else
                    return false;
            }
        }

        public override string ToString()
        {
            return string.Format("First Date:{0} Approximate:{1} Antenna:{2}", FirstObservation.ToString(), ApproximatePosition.ToString(), AntennaDelta.ToString());
        }
    }
}
