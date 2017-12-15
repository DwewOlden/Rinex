using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Structures.Tests.GPS_Time_Tests
{
    [TestFixture]
    public class GPSTimeTests
    {
        [TestCase(1980, 1, 7, 0, 0, 0, 0, 86400)]
        [TestCase(1980, 1, 7, 0, 0, 1, 0, 86401)]
        [TestCase(1980, 1, 7, 0, 2, 10, 0, 86530)]
        [TestCase(1980, 1, 9, 0, 0, 0, 0, 259200)]
        [TestCase(1986, 6, 9, 0, 0, 0, 335, 86400)]
        [TestCase(1986, 6, 9, 18, 34, 3, 335, 153243)]
        [TestCase(2017, 6, 6, 6, 6, 6, 1952, 194766)]
        public void GPS_Test_2(int Year, int Month, int Date, int Hour, int Minute, int Second, int GPSWeek, int GPSSeconds)
        {
            IGPSTime t = new GPSTime(GPSWeek, GPSSeconds);

            Assert.AreEqual(Year, t.RegularDateTime.Year);
            Assert.AreEqual(Month, t.RegularDateTime.Month);
            Assert.AreEqual(Date, t.RegularDateTime.Day);
            Assert.AreEqual(Hour, t.RegularDateTime.Hour);
            Assert.AreEqual(Minute, t.RegularDateTime.Minute);
            Assert.AreEqual(Second, t.RegularDateTime.Second);
        }


        [TestCase(1980,1,7,0,0,0,0,86400)]
        [TestCase(1980, 1, 7, 0, 0, 1, 0, 86401)]
        [TestCase(1980, 1, 7, 0, 2, 10, 0, 86530)]
        [TestCase(1980, 1, 9, 0, 0, 0, 0, 259200)]
        [TestCase(1986, 6, 9, 0, 0, 0, 335, 86400)]
        [TestCase(1986, 6, 9, 18, 34, 3, 335, 153243)]
        [TestCase(2017, 6, 6, 6, 6, 6, 1952, 194766)]
        public void GPS_Test_1(int Year,int Month,int Date,int Hour,int Minute,int Second,int GPSWeek,int GPSSeconds)
        {
            DateTime t1 = new DateTime(Year, Month, Date, Hour, Minute, Second);
            IGPSTime t = new GPSTime(t1);

            Assert.AreEqual(GPSWeek, t.GPSWeek);
            Assert.AreEqual(GPSSeconds, t.GPSSeconds);
        }
    }
}
