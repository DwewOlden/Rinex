using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Interfaces
{
    public interface IEphemeris
    {
        /// <summary>
        /// SV Number
        /// </summary>
        int Prn { get; }
        
        /// <summary>
        /// Time Of Clock
        /// </summary>
        IGPSTime Toc { get; }

        /// <summary>
        /// clock correction offset (secs)
        /// </summary>
        double Af0 { get; }

        /// <summary>
        /// clock correction drift (secs/secs)
        /// </summary>
        double Af1 { get; }

        /// <summary>
        /// clock correction drift (secs/secs*secs)
        /// </summary>
        double Af2 { get; }

        /// <summary>
        /// clock correction drift (secs/secs*secs)
        /// </summary>
        double Aode { get; }

        /// <summary>
        /// age of data ephemeris
        /// </summary>
        double Crs { get; }                    

        /// <summary>
        /// mean motion difference
        /// </summary>
        double Delta_n { get; }                

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Mo { get; }                   

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Cuc { get; }                    

        /// <summary>
        /// eccentricity
        /// </summary>
        double E { get; }                     

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Cus { get; }                    

        /// <summary>
        /// square root of semi-major axis
        /// </summary>
        double Sqrt_a { get; }                 

        /// <summary>
        /// Time of ephemeris
        /// </summary>
        double Toe { get; }                    

        /// <summary>
        /// Orbit perturbation parameter
        /// </summary>
        double Cic { get; }                    

        /// <summary>
        /// Right Ascention
        /// </summary>
        double Omega0 { get; }                 

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Cis { get; }                   

        /// <summary>
        /// Inclination
        /// </summary>
        double Io { get; }                     

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Crc { get; }                  

        /// <summary>
        /// argument of perigee
        /// </summary>
        double Omega { get; }                  

        /// <summary>
        /// rate of change of right ascension
        /// </summary>
        double OmegaDot { get; }               

        /// <summary>
        /// rate of change of inclination
        /// </summary>
        double IDot { get; }                   

        /// <summary>
        /// codes on L2
        /// </summary>
        double CodeL2 { get; }                 

        /// <summary>
        /// GPS week number

        /// </summary>
        double GpsWeek { get; }                
        /// <summary>
        /// L2 P-code data flag
        /// </summary>
        double L2Flag { get; }                 

        /// <summary>
        /// satellite accuracy
        /// </summary>
        double Ura { get; }                    

        /// <summary>
        /// satellite health
        /// </summary>
        double SvHealth { get; }               

        /// <summary>
        /// tropospheric group delay
        /// </summary>
        double Tgd { get; }                    

        /// <summary>
        /// age of data - clock
        /// </summary>
        double Aodc { get; }                   

        /// <summary>
        /// Transmission Time Of Message
        /// </summary>
        double Ttom { get; }                 
    }
}
