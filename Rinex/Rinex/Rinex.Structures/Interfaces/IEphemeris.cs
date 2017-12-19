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
        int Prn { get; set; }
        
        /// <summary>
        /// Time Of Clock
        /// </summary>
        IGPSTime Toc { get; set; }

        /// <summary>
        /// clock correction offset (secs)
        /// </summary>
        double Af0 { get; set; }

        /// <summary>
        /// clock correction drift (secs/secs)
        /// </summary>
        double Af1 { get; set; }

        /// <summary>
        /// clock correction drift (secs/secs*secs)
        /// </summary>
        double Af2 { get; set; }

        /// <summary>
        /// clock correction drift (secs/secs*secs)
        /// </summary>
        double Aode { get; set; }

        /// <summary>
        /// age of data ephemeris
        /// </summary>
        double Crs { get; set; }                    

        /// <summary>
        /// mean motion difference
        /// </summary>
        double Delta_n { get; set; }                

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Mo { get; set; }                   

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Cuc { get; set; }                    

        /// <summary>
        /// eccentricity
        /// </summary>
        double E { get; set; }                     

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Cus { get; set; }                    

        /// <summary>
        /// square root of semi-major axis
        /// </summary>
        double Sqrt_a { get; set; }                 

        /// <summary>
        /// Time of ephemeris
        /// </summary>
        double Toe { get; set; }                    

        /// <summary>
        /// Orbit perturbation parameter
        /// </summary>
        double Cic { get; set; }                    

        /// <summary>
        /// Right Ascention
        /// </summary>
        double Omega0 { get; set; }                 

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Cis { get; set; }                   

        /// <summary>
        /// Inclination
        /// </summary>
        double Io { get; set; }                     

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        double Crc { get; set; }                  

        /// <summary>
        /// argument of perigee
        /// </summary>
        double Omega { get; set; }                  

        /// <summary>
        /// rate of change of right ascension
        /// </summary>
        double OmegaDot { get; set; }               

        /// <summary>
        /// rate of change of inclination
        /// </summary>
        double IDot { get; set; }                   

        /// <summary>
        /// codes on L2
        /// </summary>
        double CodeL2 { get; set; }                 

        /// <summary>
        /// GPS week number

        /// </summary>
        double GpsWeek { get; set; }                
        /// <summary>
        /// L2 P-code data flag
        /// </summary>
        double L2Flag { get; set; }                 

        /// <summary>
        /// satellite accuracy
        /// </summary>
        double Ura { get; set; }                    

        /// <summary>
        /// satellite health
        /// </summary>
        double SvHealth { get; set; }               

        /// <summary>
        /// tropospheric group delay
        /// </summary>
        double Tgd { get; set; }                    

        /// <summary>
        /// age of data - clock
        /// </summary>
        double Aodc { get; set; }                   

        /// <summary>
        /// Transmission Time Of Message
        /// </summary>
        double Ttom { get; set; }                 
    }
}
