using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    /// <summary>
    /// Observer and Agency pair
    /// </summary>
    public class ObserverAgency : IObserverAgency
    {
        /// <summary>
        /// Name of observer 
        /// </summary>
        public string Oberver { get; set;}

        /// <summary>
        /// Name of agency
        /// </summary>
        public string Agency { get; set;}
    }
}
