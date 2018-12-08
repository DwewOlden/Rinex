using NUnit.Framework;
using Rinex.Support.Helpers;
using Rinex.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Support.Tests
{
    [TestFixture]
    public class DateTimeFunctionTests
    {
        [TestCase("1",2001)]
        [TestCase("99",1999)]
        [TestCase("79", 2079)]
        [TestCase("1", 2001)]
        [TestCase("80", 1980)]
        [TestCase("81", 1981)]
        public void TestFunctions(string input,int output)
        {
            IDateTimeFunctions _functions = new DateTimeFunctions();
            var x = _functions.PadDate(input);

            Assert.AreEqual(output, x);
            
        }
    }
}
