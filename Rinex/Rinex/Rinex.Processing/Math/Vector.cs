using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Math
{
    /// <summary>
    /// A Vector represents a one dimensional array. In terms of the matrix class it can be a single row or columns
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// The number of elements in the Vector
        /// </summary>
        private int mSize_;

        /// <summary>
        /// The elements in the vector
        /// </summary>
        private double[] mElements_;

        /// <summary>
        /// Default contructor, is passed the size of the vector
        /// </summary>
        /// <param name="pSize">The number of elements in the vector,</param>
        public Vector(int pSize)
        {
            mElements_ = new double[pSize];
        }

        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < mSize_; i++)
                s = s + mElements_[i] + "-> ";

            s = s.Substring(0, s.Length - 3);
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj.GetType() != this.GetType())
                return false;
            else
            {
                // Needs futher work.
                return false;
            }
        }

    }
}
