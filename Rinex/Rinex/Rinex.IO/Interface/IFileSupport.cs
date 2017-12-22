using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.IO.Interface
{
    public interface IFileSupport
    {
        bool FileExists(string pFilename);

        bool GetReader(string pFilename);

        bool ReadLine(out string pLine);

        bool CloseAndDispose();
    }
}
