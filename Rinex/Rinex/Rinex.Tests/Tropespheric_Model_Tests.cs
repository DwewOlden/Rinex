using NUnit.Framework;
using Rinex.Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Tests
{
    [TestFixture]
    public class Tropespheric_Model_Tests
    {
        private TropesphericModel model_;
        private TroposphereModelLookups lookups_;
        
        [TestCase(5, 7)]
        [TestCase(1.25, 2)]
        [TestCase(2.1,4)]
        [TestCase(4.5, 6)]
        [TestCase(1.5,3)]
        [TestCase(1.51, 3)]
        public void Tropesphere_Height_Index_4(double pHeight, int Index)
        {
            lookups_ = new TroposphereModelLookups();
            int lIndex = lookups_.GetHeightIndex(pHeight);
            Assert.AreEqual(Index, lIndex);
        }

        [TestCase(61,0)]
        [TestCase(61.1, 0)]
        [TestCase(66, 1)]
        [TestCase(81, 12)]
        [TestCase(79, 9)]
        [TestCase(79.45, 9)]
        public void Tropesphere_Zenith_Index_1(double pZenith,int Index)
        {
            lookups_ = new TroposphereModelLookups();
            int lIndex = lookups_.GetZenithIndex(pZenith);
            Assert.AreEqual(Index, lIndex);
        }
    }
}
