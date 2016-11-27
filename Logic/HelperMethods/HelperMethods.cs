using Logic.EMA;
using Logic.RSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.HelperMethods
{
    public class HelperMethods
    {
        public static void CalculateEMA()
        {
            int windowLength = 5;
            IList<double> data = new List<double>();
            data.Add(23.83);
            data.Add(23.95);
            data.Add(23.63);
            data.Add(23.82);
            data.Add(23.87);
            ExponentialMovingAverage.CalculateExponentialMovingAverage(data.ToArray(), windowLength);
        }

        public static void CalculateRSI()
        {
            IList<double> closePricesData = new List<double>();
            closePricesData.Add(23.83);
            closePricesData.Add(23.95);
            closePricesData.Add(23.63);
            closePricesData.Add(23.82);
            closePricesData.Add(23.87);
            RelativeStrengthIndex.CalculateRSI(closePricesData.ToArray());
        }
    }
}
