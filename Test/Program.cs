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

            double[] ema = HelperMethods.CalculateEMA("GARAN", 240, 21);

            Console.WriteLine("OK.");
        }
    }
}
