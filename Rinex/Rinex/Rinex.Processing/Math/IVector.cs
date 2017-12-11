using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinex.Processing.Math
{
    public interface IVector
    {
        double GetValue(int pIndex);

        void SetValue(int pIndex, double pValue);

        double Sum();

        void IncreaseSize(int pNewSize);

        void DescreaseSize(int pNewSize);
    }
}
