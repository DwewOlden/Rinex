using NUnit.Framework;
using Rinex.IO.Interface.RinexObservations;
using Rinex.IO.Support;
using Rinex.Structures.Interfaces;
using Rinex.Support.Helpers;
using Rinex.Support.Interfaces;
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
        public void Test_Epoch_Header_Prn_Parser()
        {
            string line = " 97 10 24 14  2 45.0000000  0  7 17 27 26  2 10 13 19                0.000044137";
            int Count = 7;

            IRinexObservationEpochHeaderParser p = new RinexObservationEpochHeaderParser();
            var output = p.ParseSatellitePrns(line,Count);

            IEnumerable<int> expected = new List<int> { 17, 27, 26, 2, 10, 13, 19 };
            
            CollectionAssert.AreEquivalent(expected, output);
        }


        [Test]
        public void Test_Epoch_Header_Flag_Parser()
        {
            string line = " 97 10 24 14  2 45.0000000  0  7 17 27 26  2 10 13 19                0.000044137";

            IRinexObservationEpochHeaderParser p = new RinexObservationEpochHeaderParser();
            int output = p.ExtractEpochFlag(line);
            int expected = 0;

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void Test_Epoch_Header_SatCount_Parser()
        {
            string line = " 97 10 24 14  2 45.0000000  0  7 17 27 26  2 10 13 19                0.000044137";

            IRinexObservationEpochHeaderParser p = new RinexObservationEpochHeaderParser();
            int output = p.ParseSatelliteCount(line);
            int expected = 7;

            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Test_Epoch_Header_Date_Parse()
        {
            string line = " 97 10 24 14  2 45.0000000  0  7 17 27 26  2 10 13 19                0.000044137";

            IDateTimeFunctions p = new DateTimeFunctions();
            DateTime? output = p.ExtractEpochDateAndTime(line);

            DateTime expected = new DateTime(1997, 10, 24, 14, 2, 45);

            Assert.AreEqual(true, output.HasValue);
            Assert.AreEqual(expected, output);
        }


        [Test]
        public void Test_Program_Header_Line()
        {
            string line = "Fastrax Rinex v 1.10                                        PGM / RUN BY / DATE ";
            Rinex.IO.Interface.IRinexObservationHeaderParser p = new Rinex.IO.Support.RinexObservationHeaderParser();
            IProgramHeader output = p.ParseProgramHeader(line);
        }


        [Test]
        public void Test_Obervation_Header_Line()
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
