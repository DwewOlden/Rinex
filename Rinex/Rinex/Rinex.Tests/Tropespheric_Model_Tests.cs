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

        [Test]
        public void Test_1()
        {
            lookups_ = new TroposphereModelLookups();

        }
    }
}
