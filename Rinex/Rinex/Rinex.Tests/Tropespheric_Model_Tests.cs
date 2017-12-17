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


        [TestCase(50,90, -1.1426928054866912e+46)]
        public void TropesphericLoss(double a,double b,double c)
        {
            TropesphericModel m = new TropesphericModel();
            double d = m.CalculateTheLossDueToTropesphere(50, 90);
            Assert.AreEqual(d, c);
        }

        [TestCase(0.001,0, 1.1559230180978775)]
        [TestCase(0.05,0,1.1521500170230865)]
        [TestCase(1.25,2, 0.98900003731250763)]
        [TestCase(4.5,6, 0.60850000381469727)]
        public void Tropesphere_Calculate_Interpolated_Pressure_Value(double pHAsKM,int pIndex,double expected)
        {
            TroposphereModelLookups l = new TroposphereModelLookups();
            int lHeightIndex = l.GetHeightIndex(pHAsKM);
            double outcome = l.CalculateInterpolatedPressure(pHAsKM, pIndex);

            Assert.AreEqual(expected, outcome, 0.0000001);
        }

        

        [TestCase(0.001, 0,11, 0.52089791573584077)]
        [TestCase(0.05, 0,11, 0.51589990779757500)]
        [TestCase(1.25, 2,11, 0.41550005227327347)]
        [TestCase(4.5, 6,11, 0.21149995177984238)]
        public void Tropesphere_Calculate_Interpolated_Range_Value(double pHAsKM, int pIndex,int pIndex2, double expected)
        {
            TroposphereModelLookups l = new TroposphereModelLookups();
            int lHeightIndex = l.GetHeightIndex(pHAsKM);
            double outcome = l.CalculatedInterpolatedRange(pHAsKM, pIndex,pIndex2,90);

            Assert.AreEqual(expected, outcome, 0.0000001);
        }

        [TestCase(10, 1012.0540748359638, 291.08499999999998, 49.681220543442173, 10.334052255602474)]
        [TestCase(25, 1010.2623274086369, 290.98749999999995, 49.206858068884614, 10.172081523193143)]
        [TestCase(50,1007.2817822813439, 290.82499999999999, 48.426297620227089, 9.9076445252252672)]
        [TestCase(100, 1001.3420224900974, 290.50000000000000, 46.902126024056237, 9.3988324342597149)]
        [TestCase(1000, 899.17569895895031, 284.64999999999998, 26.375169160084234, 3.6050083761304177)]
        public void Tropesphere_Calculate_Values_At_Height(double pHeight,double a1,double b1,double c1,double d1)
        {
            double a, b, c, d;
            model_ = new TropesphericModel();
            model_.CalculateValuesAtHeght(pHeight, out a, out b, out c, out d);

            Assert.AreEqual(a1, a,0.0000000001);
            Assert.AreEqual(b1, b, 0.0000000001);
            Assert.AreEqual(c1, c, 0.0000000001);
            Assert.AreEqual(d1, d, 0.0000000001);
        }

        [TestCase(5, 7)]
        [TestCase(1.25, 2)]
        [TestCase(2.1,4)]
        [TestCase(4.5, 6)]
        [TestCase(1.5,3)]
        [TestCase(1.51, 3)]
        public void Tropesphere_Height_Index_1(double pHeight, int Index)
        {
            lookups_ = new TroposphereModelLookups();
            int lIndex = lookups_.GetHeightIndex(pHeight);
            Assert.AreEqual(Index, lIndex);
        }

        [TestCase(61,0)]
        [TestCase(61.1, 0)]
        [TestCase(66, 1)]
        [TestCase(81, 11)]
        [TestCase(79, 9)]
        [TestCase(79.45, 9)]
        public void Tropesphere_Zenith_Index_1(double pZenith,int Index)
        {
            lookups_ = new TroposphereModelLookups();
            int lIndex = lookups_.GetZenithIndex(pZenith);
            Assert.AreEqual(Index, lIndex);
        }
    }
}
