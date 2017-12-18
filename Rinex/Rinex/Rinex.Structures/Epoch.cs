using Rinex.Structures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures
{
    public class Epoch:IEpochData
    {
        private IGPSTime Time_;
        private int numSVs_;               
        private char[] crn_;    
        private int[] prn_;     
        private double[] elev_;
        private double[] trop_;
        private double[] C1_;
        private int[] loss_lock_;

        private IPosition[] satPos_;
        private double[] dTs_;
        private double dTr_;          
        private IPosition recPos_;

        public IGPSTime Time
        {
            get
            {
                return Time_;
            }
        }

        public int NumberOfSatelittes
        {
            get
            {
                return numSVs_;
            }
        }

        public char[] Prefix
        {
            get
            {
                return crn_;
            }
        }

        public int[] Prn
        {
            get
            {
                return prn_;
            }
        }

        public double[] Elevation
        {
            get
            {
                return elev_;
            }
        }
    
        public double[] TroposphericDelay
        {
            get
            {
                return trop_;
            }
        }

        public double[] C1
        {
            get
            {
                return C1_;
            }
        }

        public int[] LossLock
        {
            get
            {
                return loss_lock_;
            }
        }

        public double[] ClockOffsets
        {
            get
            {
                return dTs_;
            }
        }

        public double ReceiverOffset
        {
            get
            {
                return dTr_;
            }
        }

        public IPosition[] SatelittePosition
        {
            get
            {
                return satPos_;
            }
        }

        public IPosition ReceiverPosition
        {
            get
            {
                return recPos_;
            }
        }
    }
}
