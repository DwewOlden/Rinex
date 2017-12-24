using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Tests
{
    [TestFixture]
    public class Observation_Parser_Tests
    {
        [Test]
        public void Test_Types_Parsing_1()
        {
            string line = "     7    L1    L2    C1    P1    P2    D1    D2            # / TYPES OF OBSERV";

            Rinex.IO.Interface.IRinexObservationHeaderParser p = new Rinex.IO.Support.RinexObservationHeaderParser();
            p.ParseSignalTypes(line);

        }
    }
}
