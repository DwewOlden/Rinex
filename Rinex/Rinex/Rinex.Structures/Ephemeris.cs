using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    public class Ephemeris : IEphemeris
    {
        private int Prn_;
        private IGPSTime Toc_;
        private double Af0_;
        private double af1_;
        private double Af2_;
        private double Aode_;
        private double Crs_;
        private double delta_n_;
        private double mo_;
        private double Cuc_;
        private double E_;
        private double Cus_;
        private double Sqrt_a_;
        private double Tgd_;
        private double Aodc_;
        private double Ttom_;
        private double SvHealth_;
        private double Omega_;
        private double Ura_;
        private double L2Flag_;
        private double GpsWeek_;
        private double CodeL2_;
        private double IDot_;
        private double OmegaDot_;
        private double Io_;
        private double Cis_;
        private double Omega0_;
        private double Cic_;
        private double Toe_;
        private double Crc_;


        /// <summary>
        /// SV Number
        /// </summary>
        public int Prn
        {
            get
            {
                return Prn_;
            }
        }

        /// <summary>
        /// Time Of Clock
        /// </summary>
        public IGPSTime Toc
        {
            get
            {
                return Toc_;
            }
        }

        /// <summary>
        /// Clock correction offset (secs)
        /// </summary>
        public double Af0
        {
            get
            {
                return Af0_;
            }
        }

        /// <summary>
        /// clock correction drift (secs/secs)
        /// </summary>
        public double Af1
        {
            get
            {
                return af1_;
            }
        }

        /// <summary>
        /// clock correction drift (secs/secs*secs)
        /// </summary>
        public double Af2
        {
            get
            {
                return Af2_;
            }
        }

        /// <summary>
        /// clock correction drift (secs/secs*secs)
        /// </summary>
        public double Aode
        {
            get
            {
                return Aode_;
            }
        }

        /// <summary>
        /// age of data ephemeris
        /// </summary>
        public double Crs
        {
            get
            {
                return Crs_;
            }
        }

        /// <summary>
        /// mean motion difference
        /// </summary>
        public double Delta_n
        {
            get
            {
                return delta_n_;
            }
        }

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        public double Mo
        {
            get
            {
                return mo_;
            }
        }

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        public double Cuc
        {
            get
            {
                return Cuc_;
            }
        }

        /// <summary>
        /// eccentricity
        /// </summary>
        public double E
        {
            get
            {
                return E_;
            }
        }

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        public double Cus
        {
            get
            {
                return Cus_;
            }
        }
        
        /// <summary>
        /// square root of semi-major axis
        /// </summary>
        public double Sqrt_a
        {
            get
            {
                return Sqrt_a_;
            }
        }

        /// <summary>
        /// Time of ephemeris
        /// </summary>
        public double Toe
        {
            get
            {
                return Toe_;
            }
        }

        /// <summary>
        /// Orbit perturbation parameter
        /// </summary>
        public double Cic
        {
            get
            {
                return Cic_;
            }
        }

        /// <summary>
        /// Right Ascention
        /// </summary>
        public double Omega0
        {
            get
            {
                return Omega0_;
            }
        }

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        public double Cis
        {
            get
            {
                return Cis_;
            }
        }

        /// <summary>
        /// Inclination
        /// </summary>
        public double Io
        {
            get
            {
                return Io_;
            }
        }

        /// <summary>
        /// orbit perturbation parameter
        /// </summary>
        public double Crc
        {
            get
            {
                return Crc_;
            }
        }

        /// <summary>
        /// argument of perigee
        /// </summary>
        public double Omega
        {
            get
            {
                return Omega_;
            }
        }

        /// <summary>
        /// rate of change of right ascension
        /// </summary>
        public double OmegaDot
        {
            get
            {
                return OmegaDot_;
            }
        }

        /// <summary>
        /// rate of change of inclination
        /// </summary>
        public double IDot
        {
            get
            {
                return IDot_;
            }

        }

        /// <summary>
        /// codes on L2
        /// </summary>
        public double CodeL2
        {
            get
            {
                return CodeL2_;
            }
        }

        /// <summary>
        /// GPS week number
        /// </summary>
        public double GpsWeek
        {
            get
            {
                return GpsWeek_;
            }
        }

        /// <summary>
        /// L2 P-code data flag
        /// </summary>
        public double L2Flag
        {
            get
            {
                return L2Flag_;
            }
        }

        /// <summary>
        /// satellite accuracy
        /// </summary>
        public double Ura
        {
            get
            {
                return Ura_;
            }
        }

        /// <summary>
        /// satellite health
        /// </summary>
        public double SvHealth
        {
            get
            {
                return SvHealth_;
            }
        }

        /// <summary>
        /// tropospheric group delay
        /// </summary>
        public double Tgd
        {
            get
            {
                return Tgd_;
            }
        }

        /// <summary>
        /// age of data - clock
        /// </summary>
        public double Aodc
        {
            get
            {
                return Aodc_;
            }
        }

        /// <summary>
        /// Transmission Time Of Message
        /// </summary>
        public double Ttom
        {
            get
            {
                return Ttom_;
            }
        }
    }
}
