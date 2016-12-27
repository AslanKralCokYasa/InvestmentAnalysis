using System;
using System.Collections.Generic;
using System.Linq;
using Logic.HelperMethods;
using Data;
using Data.DataStructure;
using Logic.EMA;

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

            //int lastYearData = 240;
            //int firstLength = 21;
            //int secondLength = 50;
            //string stockName = "GARAN";

            //Console.WriteLine("*********************************************");
            //List<ResultInfo> resultInfoList = getDecisionResults(lastYearData, firstLength, secondLength, stockName);
            //resultInfoList.ForEach(Print);
            //Console.WriteLine("OK.");

            //HelperMethods.CalculateRSI("GARAN", 20);

            EMA("GARAN", 18, 50);
            EMA("GARAN", 19, 50);
            EMA("GARAN", 20, 50);
            EMA("GARAN", 21, 50);
            EMA("GARAN", 22, 50);
            EMA("GARAN", 23, 50);
            EMA("GARAN", 24, 50);
            EMA("GARAN", 25, 50);
        }

        private static List<ResultInfo> getDecisionResults(int lastYearData, int firstLength, int secondLength, string stockName)
        {
            List<ResultInfo> resultInfoList = new List<ResultInfo>();
            HistoricalDataBlock[] historicalDataBlock = HelperMethods.GetHistoricalDataBlock(stockName, lastYearData);
            double[] emaFirst = HelperMethods.CalculateEMA(stockName, lastYearData, firstLength);
            double[] emaSecond = HelperMethods.CalculateEMA(stockName, lastYearData, secondLength);

            if (emaFirst != null && emaFirst.Length > 0 && emaSecond != null && emaSecond.Length > 0 && historicalDataBlock != null && historicalDataBlock.Length > 0)
            {
                double[] emaTrimmedArray = emaFirst.Skip(secondLength - firstLength).ToArray();

                for (int i = 0; i < emaTrimmedArray.Length; i++)
                {
                    Console.WriteLine(emaTrimmedArray[i].ToString("F") + " # " + emaSecond[i].ToString("F") + " # " + ((emaTrimmedArray[i] > emaSecond[i]) ? "+" : "-"));


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
            //Console.WriteLine("ArrayIndex=" + s.getArrayIndex());
            //Console.WriteLine("BuyingDecision=" + s.getBuyingDecision());
            Console.WriteLine("DecisionText=" + s.getDecisionText());
            Console.WriteLine("LastPrice=" + s.getLastPrice());
            Console.WriteLine("RecordDate=" + s.getRecordDate().ToString("yyyy-MM-dd"));
            Console.WriteLine("*********************************************");
        }

        private static void EMA(string symbol, int fasterPeriod, int slowerPeriod, int window = 0)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("SYMBOL = {0}, WINDOW = {1}, FASTER_PERIOD = {2}, SLOWER_PERIOD = {3}",
                symbol, window, fasterPeriod, slowerPeriod);

            HistoricalDataBlock[] historicalDataBlocks = HelperMethods.GetHistoricalDataBlock(symbol, window);
            double[] data = historicalDataBlocks.Select(c => (double)c.LastPrice).ToArray();
            double[] emaFaster = ExponentialMovingAverage.Calculate(data, fasterPeriod).Skip(slowerPeriod - fasterPeriod).ToArray();
            double[] emaSlower = ExponentialMovingAverage.Calculate(data, slowerPeriod);

            Console.WriteLine("BLOCK_LENGTH = {0}, DATA_LENGTH = {1}, EMA_FASTER_LENGTH = {2}, EMA_SLOWER_LENGTH = {3}", 
                historicalDataBlocks.Length, data.Length, emaFaster.Length, emaSlower.Length);

            List<PositionInfo> positionInfoList = new List<PositionInfo>(); 

            string previousSign = string.Empty;
            string currentSign = string.Empty;
            bool longPosition = false;
            bool shortPosition = false;
            bool changePosition = false;
            string positionChangeInfo = string.Empty;

            for (int i = 0; i < emaFaster.Length; i++)
            {
                if      (emaFaster[i] > emaSlower[i])   { currentSign = "+"; }
                else if (emaFaster[i] < emaSlower[i])   { currentSign = "-"; }
                else                                    { currentSign = "="; }

                longPosition = ("-".Equals(previousSign) || "=".Equals(previousSign)) && "+".Equals(currentSign);
                shortPosition = ("+".Equals(previousSign) || "=".Equals(previousSign)) && "-".Equals(currentSign);
                changePosition = longPosition || shortPosition;

                HistoricalDataBlock historicalData = historicalDataBlocks[slowerPeriod + i - 1];

                positionChangeInfo = string.Empty;
                if (changePosition)
                {
                    string type = longPosition ? "LONG" : "SHORT";

                    positionChangeInfo = "*****" + " # " + historicalData.LastPrice.ToString("F") + " # " + type;
                    
                    positionInfoList.Add(new PositionInfo() { Type = type, Date = historicalData.RecordDate, Price = (double)historicalData.LastPrice });
                }

                //Console.WriteLine(historicalData.RecordDate.ToString("yyyy-MM-dd") + " # "
                //    + string.Format("{0:F4}", emaFaster[i]) + " # " + string.Format("{0:F4}", emaSlower[i]) + " # "
                //    + currentSign + " # " + positionChangeInfo);

                previousSign = currentSign;
            }

            Console.WriteLine("*********************************************");
            Console.WriteLine("TOTAL POSITION COUNT: " + positionInfoList.Count);

            if (1 == positionInfoList.Count % 2)
            {
                positionInfoList.RemoveAt(positionInfoList.Count - 1);
            }

            if (positionInfoList.Count > 0)
            {
                double safe = 0.00;
                double price = 0.00;

                for (int i = 0; i < positionInfoList.Count; i++)
                {
                    //Console.WriteLine(positionInfoList[i].ToString());

                    price = positionInfoList[i].Price;

                    if ("SHORT".Equals(positionInfoList[i].Type))
                    {
                        price = (-1) * price;
                    }

                    safe = safe + price;
                }

                Console.WriteLine("TOTAL POSITION PROFIT / LOSS: " + safe);
            }
            
            Console.WriteLine("*********************************************");
        }
    }

    public class PositionInfo
    {
        public string Type;
        public DateTime Date;
        public double Price;

        public override string ToString()
        {
            return this.Date.ToString("yyyy-MM-dd") + " # " + this.Price.ToString("F") + " # " + this.Type;
        }
    }
}
