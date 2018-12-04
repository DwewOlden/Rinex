using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    /// <summary>
    /// Observer and Agency pair
    /// </summary>
    public interface IObserverAgency
    {
        /// <summary>
        /// Name of observer 
        /// </summary>
        string Oberver { get; set; }

        /// <summary>
        /// Name of agency
        /// </summary>
        string Agency { get; set; }
    }
}
