using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.HelperMethods;
using Data;
using Data.DataStructure;

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


            int lastYearData = 240;
            int firstLength = 21;
            int secondLength = 50;
            string stockName = "GARAN";



            List<ResultInfo> resultInfoList = getDecisionResults(lastYearData, firstLength, secondLength, stockName);

            resultInfoList.ForEach(Print);

            Console.WriteLine("OK.");
        }

        private static List<ResultInfo> getDecisionResults(int lastYearData, int firstLength, int secondLength, string stockName)
        {
            List<ResultInfo> resultInfoList = new List<ResultInfo>();
            HistoricalDataBlock[] historicalDataBlock = HelperMethods.GetHistoricalDataBlock(stockName, lastYearData);
            double[] emaFirst = HelperMethods.CalculateEMA(stockName, lastYearData, firstLength);
            double[] emaSecond = HelperMethods.CalculateEMA(stockName, lastYearData, secondLength);
            //double[] emaTrimmedArray = emaFirst.Skip(secondLength - firstLength).ToArray();

            if (emaFirst != null && emaFirst.Length > 0 && emaSecond != null && emaSecond.Length > 0 && historicalDataBlock != null && historicalDataBlock.Length > 0)
            {
                double[] emaTrimmedArray = emaFirst.Skip(secondLength - firstLength).ToArray();
                for (int i = 0; i < emaTrimmedArray.Length; i++)
                {
                    int forwardIndex = i + 1;
                    int decisionProcessIndex = i + 2;
                    if (forwardIndex < emaTrimmedArray.Length && decisionProcessIndex < emaTrimmedArray.Length)
                    {
                        double currentEmaFirstItem = emaTrimmedArray[i];
                        double currentEmaSecondItem = emaSecond[i];
                        double forwardEmaFirstItem = emaTrimmedArray[forwardIndex];
                        double forwardEmaSecondItem = emaSecond[forwardIndex];
                        HistoricalDataBlock historicalDataBlockItem = historicalDataBlock[forwardIndex];

                        if (currentEmaFirstItem - currentEmaSecondItem > 0)
                        {
                            if (!(forwardEmaFirstItem - forwardEmaSecondItem > 0))
                            {
                                resultInfoList.Add(mapResultInfoObject(decisionProcessIndex, Convert.ToDouble(historicalDataBlockItem.LastPrice), historicalDataBlockItem.RecordDate, false));
                            }
                        }
                        else
                        {
                            if (forwardEmaFirstItem - forwardEmaSecondItem > 0)
                            {
                                resultInfoList.Add(mapResultInfoObject(decisionProcessIndex, Convert.ToDouble(historicalDataBlockItem.LastPrice), historicalDataBlockItem.RecordDate, true));
                            }
                        }

                    }

                }
            }

            return resultInfoList;
        }

        private static ResultInfo mapResultInfoObject(int arrayIndex, double lastPrice, DateTime recordDate, bool isBuying)
        {
            ResultInfo resultInfoObj = new ResultInfo();
            resultInfoObj.setArrayIndex(arrayIndex);
            resultInfoObj.setBuyingDecision(isBuying);
            resultInfoObj.setDecisionText(getDecisionText(isBuying));
            resultInfoObj.setLastPrice(lastPrice);
            resultInfoObj.setRecordDate(recordDate);
            return resultInfoObj;
        }

        private static string getDecisionText(bool isBuying)
        {
            if (isBuying) return "BUY";
            else return "SELL";
        }

        private static void Print(ResultInfo s)
        {
            Console.WriteLine("ArrayIndex=" + s.getArrayIndex());
            Console.WriteLine("BuyingDecision=" + s.getBuyingDecision());
            Console.WriteLine("DecisionText=" + s.getDecisionText());
            Console.WriteLine("LastPrice=" + s.getLastPrice());
            Console.WriteLine("RecordDate=" + s.getRecordDate());
        }

    }
}
