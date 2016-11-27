﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EMA
{
    public class ExponentialMovingAverage
    {
        public static double[] CalculateExponentialMovingAverage(double[] data, int window)
        {
            if (data.Length < window)
                return null;

            int diff = data.Length - window;
            double[] newdata = data.Take(window).ToArray();
            double factor = CalculateFactor(window);
            double sma = Average(newdata);

            IList<double> result = new List<double>();
            result.Add(Math.Round(sma, 2));

            for (int i = 0; i < diff; i++)
            {
                double prev = result[result.Count - 1];
                double price = data[window + i];
                double next = factor * (price - prev) + prev;
                result.Add(Math.Round(next, 2));
            }

            return result.ToArray();
        }

        private static double Sum(double[] data)
        {
            double sum = 0;

            foreach (var d in data)
            {
                sum += d;
            }

            return sum;
        }

        private static double Average(double[] data)
        {
            if (data.Length == 0)
                return 0;

            return Sum(data) / data.Length;
        }

        private static double CalculateFactor(int days)
        {
            if (days < 0)
                return 0;

            return 2.0 / (days + 1);
        }
    }
}