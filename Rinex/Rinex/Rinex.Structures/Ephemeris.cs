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
            set
            {
                Prn_ = value;
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
            set
            {
                Toc_ = value;
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
            set
            {
                Af0_ = value;
            }
        }

        /// <summary>
        /// Clock correction drift (secs/secs)
        /// </summary>
        public double Af1
        {
            get
            {
                return af1_;
            }
            set
            {
                af1_ = value;
            }
        }

        /// <summary>
        /// Clock correction drift (secs/secs*secs)
        /// </summary>
        public double Af2
        {
            get
            {
                return Af2_;
            }
            set
            {
                Af2_ = value;
            }
        }

        /// <summary>
        /// Clock correction drift (secs/secs*secs)
        /// </summary>
        public double Aode
        {
            get
            {
                return Aode_;
            }
            set
            {
                Aode_ = value;
            }
        }

        /// <summary>
        /// Age of data ephemeris
        /// </summary>
        public double Crs
        {
            get
            {
                return Crs_;
            }
            set
            {
                Crs_ = value;
            }
        }

        /// <summary>
        /// Mean motion difference
        /// </summary>
        public double Delta_n
        {
            get
            {
                return delta_n_;
            }
            set
            {
                delta_n_ = value;
            }
        }

        /// <summary>
        /// Orbit perturbation parameter
        /// </summary>
        public double Mo
        {
            get
            {
                return mo_;
            }
            set
            {
                mo_ = value;
            }
        }

        /// <summary>
        /// Orbit perturbation parameter
        /// </summary>
        public double Cuc
        {
            get
            {
                return Cuc_;
            }
            set
            {
                Cuc_ = value;
            }
        }

        /// <summary>
        /// Eccentricity
        /// </summary>
        public double E
        {
            get
            {
                return E_;
            }
            set
            {
                E_ = value;
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
            set
            {
                Cus_ = value;
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
            set
            {
                Sqrt_a_ = value;
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
            set
            {
                Toe_ = value;
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
            set
            {
                Cic_ = value;
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
            set
            {
                Omega0_ = value;
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
            set
            {
                Cis_ = value;
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
            set
            {
                Io_ = value;
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
            set
            {
                Crc_ = value;
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
            set
            {
                Omega_ = value;
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
            set
            {
                OmegaDot_ = value;
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
            set
            {
                IDot_ = value;
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
            set
            {
                CodeL2_ = value;
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
            set
            {
                GpsWeek_ = value;
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
            set
            {
                L2Flag_ = value;
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
            set
            {
                Ura_ = value;
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
            set
            {
                SvHealth_ = value;
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
            set
            {
                Tgd_ = value;
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
            set
            {
                Aodc_ = value;
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
            set
            {
                Ttom_ = value;
            }
        }

        public override string ToString()
        {
            return string.Format("GPS Week:{0} GPS Seconds:{1} Sat:{2}", Toc_.GPSWeek, Toc_.GPSSeconds, Prn_);
        }

        public override int GetHashCode()
        {
            return Toc_.GetHashCode() + Prn_;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj.GetType() != this.GetType())
                return false;
            else
            {
                Ephemeris e = (Ephemeris)obj;
                if ((e.Toc_ == this.Toc_) && (e.Prn_ == this.Prn_))
                    return true;
                else
                    return false;
            }


        }
    }
}
