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
    public class Vector: IVector
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
            mSize_ = pSize;
        }

        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < mSize_; i++)
                s = s + mElements_[i] + "-> ";

            s = s.Substring(0, s.Length - 3);
            return s;
        }

        public override int GetHashCode()
        {
            return mSize_ + (int)mElements_[0]; 
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

        /// <summary>
        /// Gets the value at the requested element
        /// </summary>
        /// <param name="pIndex">The index of the element</param>
        /// <returns>The value at the requesed element</returns>
        public double GetValue(int pIndex)
        {
            if (pIndex > (mSize_-1))
                throw new IndexOutOfRangeException("the requested value is greater than the index");

            return mElements_[pIndex];
        }

        /// <summary>
        /// Sets the value at the requested element
        /// </summary>
        /// <param name="pIndex">The index of the element</param>
        /// <param name="pValue">The value of the element at the passed index</param>
        public void SetValue(int pIndex, double pValue)
        {
            if (pIndex > (mSize_ - 1))
                throw new IndexOutOfRangeException("the requested value is greater than the index");

            mElements_[pIndex] = pValue;
        }

        /// <summary>
        /// Returns the sum of all the elements
        /// </summary>
        /// <returns>The sum of all the elements</returns>
        public double Sum()
        {
            double lSum_ = 0;

            // Loop around each element adding the value to the sum
            for (int i = 0; i < mSize_; i++)
                lSum_ = lSum_ + mElements_[i];

            return lSum_;
        }

        /// <summary>
        /// Increase the size of the vector to the passed size, all new members are set to zero
        /// </summary>
        /// <param name="pNewSize">The new of the collection</param>
        public void IncreaseSize(int pNewSize)
        {
            if (pNewSize < mSize_)
                throw new ArgumentOutOfRangeException("vector size", "the size of the new vector is lower than its existing size");

            var lNewArray = mElements_;
            mElements_ = new double[pNewSize];

            for (int i = 0; i < mSize_; i++)
                mElements_[i] = lNewArray[i];

            mSize_ = pNewSize;
        }


        /// <summary>
        /// Decreases the size oof the vector to the passed size
        /// </summary>
        /// <param name="pNewSize">The new size of the vector</param>
        public void DescreaseSize(int pNewSize)
        {
            if (pNewSize > mSize_)
                throw new ArgumentOutOfRangeException("vector size", "the size of the new vector is higher than its existing size");

            var lNewArray = mElements_;
            mElements_ = new double[pNewSize];

            for (int i = 0; i < pNewSize; i++)
                mElements_[i] = lNewArray[i];

            mSize_ = pNewSize;
        }
    }
}
