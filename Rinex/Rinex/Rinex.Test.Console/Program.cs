using Rinex.IO.Interface;
using Rinex.IO.Interface.RinexObservations;
using Rinex.IO.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string observationFilename = "c:\\temp\\Rinex\\Test\\aTest.97o";

            IRinexFileObservationReader reader = new Rinex.IO.Implementions.RinexObservationReader(new FileSupport());
            reader.Filename = observationFilename;
            reader.ReadFile();

        }
    }
}
