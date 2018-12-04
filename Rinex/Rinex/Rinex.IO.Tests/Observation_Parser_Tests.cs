using NUnit.Framework;
using Rinex.Structures.Interfaces;
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
        public void Test_Obervation_Headere_Line()
        {
            string line = "     2.10           O                   G                   RINEX VERSION / TYPE";
            Rinex.IO.Interface.IRinexObservationHeaderParser p = new Rinex.IO.Support.RinexObservationHeaderParser();
            IRinexHeader output = p.ParseHeaderInformation(line);

        }


        [Test]
        public void Test_Types_Parsing_1()
        {
            string line = "     7    L1    L2    C1    P1    P2    D1    D2            # / TYPES OF OBSERV";

            Rinex.IO.Interface.IRinexObservationHeaderParser p = new Rinex.IO.Support.RinexObservationHeaderParser();
            int[] output = p.ParseSignalTypes(line);

            Assert.AreEqual(7, output.Length);
            Assert.AreEqual(4, output[0]);
            Assert.AreEqual(5, output[1]);
            Assert.AreEqual(0, output[2]);
            Assert.AreEqual(2, output[3]);
            Assert.AreEqual(3, output[4]);
        }

        [Test]
        public void Test_Types_Parsing_2()
        {
            string line = "     3    C1    L1    P1                                    # / TYPES OF OBSERV";

            Rinex.IO.Interface.IRinexObservationHeaderParser p = new Rinex.IO.Support.RinexObservationHeaderParser();
            int[] output = p.ParseSignalTypes(line);

            Assert.AreEqual(3, output.Length);
            Assert.AreEqual(0, output[0]);
            Assert.AreEqual(4, output[1]);
            Assert.AreEqual(2, output[2]);
        }

        
    }
}
