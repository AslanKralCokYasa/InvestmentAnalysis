using Data;
using Data.DataStructure;
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
        public static double[] CalculateEMA()
        {
            int period = 10;

            IList<double> data = new List<double>();
            data.Add(22.27);
            data.Add(22.19);
            data.Add(22.08);
            data.Add(22.17);
            data.Add(22.18);
            data.Add(22.13);
            data.Add(22.23);
            data.Add(22.43);
            data.Add(22.24);
            data.Add(22.29);
            data.Add(22.15);
            data.Add(22.39);
            data.Add(22.38);
            data.Add(22.61);

            return ExponentialMovingAverage.Calculate(data.ToArray(), period);
        }

        public static void CalculateRSI()
        {
            IList<double> closePricesData = new List<double>();
            closePricesData.Add(23.83);
            closePricesData.Add(23.95);
            closePricesData.Add(23.63);
            closePricesData.Add(23.82);
            closePricesData.Add(23.87);
            RelativeStrengthIndex.Calculate(closePricesData.ToArray());
        }

        public static double[] CalculateEMA(string symbol, int window, int period)
        {
            double[] closePrices = null;

            using (InvestmentAnalysisContext context = new InvestmentAnalysisContext())
            {
                closePrices = context.HistoricalDataBlocks
                    .Where(q => q.Symbol.Equals(symbol))
                    .OrderByDescending(q => q.RecordDate)
                    .Take(window)
                    .Select(c => (double) c.LastPrice)
                    .ToArray();
            }

            return ExponentialMovingAverage.Calculate(closePrices, period);
        }

        public static double[] CalculateRSI(string symbol, int window)
        {
            double[] closePrices = null;

            using (InvestmentAnalysisContext context = new InvestmentAnalysisContext())
            {
                closePrices = context.HistoricalDataBlocks
                    .Where(q => q.Symbol.Equals(symbol))
                    .OrderByDescending(q => q.RecordDate)
                    .Take(window)
                    .Select(c => (double)c.LastPrice)
                    .ToArray();
            }

            return RelativeStrengthIndex.Calculate(closePrices.Reverse().ToArray());
        }
    }
}
