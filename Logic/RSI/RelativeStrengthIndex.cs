using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.RSI
{
    public class RelativeStrengthIndex
    {
        private static double Calculate(IEnumerable<double> closePrices)
        {
            var prices = closePrices as double[] ?? closePrices.ToArray();

            double sumGain = 0;
            double sumLoss = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var difference = prices[i] - prices[i - 1];
                if (difference >= 0)
                {
                    sumGain += difference;
                }
                else
                {
                    sumLoss -= difference;
                }
            }

            if (sumGain == 0) return 0;
            //if (Math.Abs(sumLoss) < Tolerance) return 100;

            var relativeStrength = sumGain / sumLoss;

            return 100.0 - (100.0 / (1 + relativeStrength));
        }

        public static double[] Calculate(double[] closePrices)
        {
            var prices = closePrices.ToArray();
            int period = 14;
            int resultLength = prices.Length - period + 1;

            var results = new double[resultLength];
            
            for (int i = resultLength-1; i >= 0; i--)
            {
                results[i] = Calculate(prices.Skip(resultLength - i).Take(period));
            }

            return results;
        }
    }
}
