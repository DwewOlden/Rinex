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
        string Filename { get; set; }

        bool FileExists(string pFilename);

        bool FileExists();

        bool GetReader(string pFilename);

        string ReadLine();

        bool CloseAndDispose();
    }
}
