using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.HelperMethods;
using Data;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (InvestmentAnalysisContext context = new InvestmentAnalysisContext())
            {
                context.Database.Initialize(false);
            }

            //double[] ema_21 = HelperMethods.CalculateEMA("GARAN", 240, 21);
            //double[] ema_50 = HelperMethods.CalculateEMA("GARAN", 240, 50);

            double[] rsi = HelperMethods.CalculateRSI("GARAN", 14);

            Console.WriteLine("OK.");
        }
    }
}
