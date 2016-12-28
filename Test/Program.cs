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
            GetProfitGainLossInfo();
        }

        public static ProfitGainLoss GetProfitGainLossInfo()
        {
            using (InvestmentAnalysisContext context = new InvestmentAnalysisContext())
            {
                context.Database.Initialize(false);
            }


            HistoricalDataBlock[] historicalData = HelperMethods.GetHistoricalDataBlock("GARAN");

            PeriodInfo _maxProfitPeriodInfo = new PeriodInfo { ProfitOrLoss = 0.00 };
            PeriodInfo _maxLossPeriodInfo = new PeriodInfo { ProfitOrLoss = 0.00 };

            double safe = 0.00;

            for (int fasterPeriod = 5; fasterPeriod < 31; fasterPeriod++)
            {
                for (int slowerPeriod = 8; slowerPeriod < 61; slowerPeriod++)
                {
                    if (fasterPeriod + 2 > slowerPeriod)
                        continue;
                    TotalTransactionInfo _totalTransactionInfo = GetTotalTransactionInfo("GARAN", historicalData, fasterPeriod, slowerPeriod);
                    safe = _totalTransactionInfo.safe;

                    if (safe > _maxProfitPeriodInfo.ProfitOrLoss)
                    {
                        _maxProfitPeriodInfo.FasterPeriod = fasterPeriod;
                        _maxProfitPeriodInfo.SlowerPeriod = slowerPeriod;
                        _maxProfitPeriodInfo.ProfitOrLoss = safe;
                        _maxProfitPeriodInfo.totalTransactionInfo = _totalTransactionInfo;
                    }

                    if (safe < _maxLossPeriodInfo.ProfitOrLoss)
                    {
                        _maxLossPeriodInfo.FasterPeriod = fasterPeriod;
                        _maxLossPeriodInfo.SlowerPeriod = slowerPeriod;
                        _maxLossPeriodInfo.ProfitOrLoss = safe;
                        _maxLossPeriodInfo.totalTransactionInfo = _totalTransactionInfo;
                    }
                }
            }

            Console.WriteLine(_maxLossPeriodInfo.ToString());
            Console.WriteLine(_maxLossPeriodInfo.ToString());

            return new ProfitGainLoss { maxProfitPeriodInfo = _maxLossPeriodInfo, maxLossPeriodInfo = _maxLossPeriodInfo };
        }

        private static TotalTransactionInfo GetTotalTransactionInfo(string symbol, HistoricalDataBlock[] historicalDataBlocks, int fasterPeriod, int slowerPeriod, int window = 0)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("SYMBOL = {0}, WINDOW = {1}, FASTER_PERIOD = {2}, SLOWER_PERIOD = {3}",
                symbol, window, fasterPeriod, slowerPeriod);

            //HistoricalDataBlock[] historicalDataBlocks = HelperMethods.GetHistoricalDataBlock(symbol, window);
            double[] data = historicalDataBlocks.Select(c => (double)c.LastPrice).ToArray();
            double[] emaFaster = ExponentialMovingAverage.Calculate(data, fasterPeriod).Skip(slowerPeriod - fasterPeriod).ToArray();
            double[] emaSlower = ExponentialMovingAverage.Calculate(data, slowerPeriod);

            //Console.WriteLine("BLOCK_LENGTH = {0}, DATA_LENGTH = {1}, EMA_FASTER_LENGTH = {2}, EMA_SLOWER_LENGTH = {3}", 
            //    historicalDataBlocks.Length, data.Length, emaFaster.Length, emaSlower.Length);

            List<PositionInfo> _positionInfoList = new List<PositionInfo>(); 

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

                    _positionInfoList.Add(new PositionInfo() { Type = type, Date = historicalData.RecordDate, Price = (double)historicalData.LastPrice });
                }

                //Console.WriteLine(historicalData.RecordDate.ToString("yyyy-MM-dd") + " # "
                //    + string.Format("{0:F4}", emaFaster[i]) + " # " + string.Format("{0:F4}", emaSlower[i]) + " # "
                //    + currentSign + " # " + positionChangeInfo);

                previousSign = currentSign;
            }

            //Console.WriteLine("*********************************************");
            Console.WriteLine("TOTAL POSITION COUNT: " + _positionInfoList.Count);

            double _safe = 0.00;

            if (1 == _positionInfoList.Count % 2)
            {
                _positionInfoList.RemoveAt(_positionInfoList.Count - 1);
            }

            if (_positionInfoList.Count > 0)
            {
                double price = 0.00;

                for (int i = 0; i < _positionInfoList.Count; i++)
                {
                    //Console.WriteLine(positionInfoList[i].ToString());

                    price = _positionInfoList[i].Price;

                    if ("SHORT".Equals(_positionInfoList[i].Type))
                    {
                        price = (-1) * price;
                    }

                    _safe = _safe + price;
                }

                Console.WriteLine("TOTAL POSITION PROFIT / LOSS: " + _safe);
            }

            return new TotalTransactionInfo { safe = _safe, positionInfoList = _positionInfoList, ratio = (((_safe) / (_positionInfoList[0].Price * 100)).ToString("F")) };

            //TotalTransactionInfo totalTransactionInfo = new TotalTransactionInfo();
            //x.positionInfoList = _positionInfoList;
            //x.safe = _safe;
            //x.ratio = (((_safe) / (_positionInfoList[0].Price * 100)).ToString("F")) ;
           

            //return _safe;

            //Console.WriteLine("*********************************************");
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

    public class PeriodInfo
    {
        public int FasterPeriod;
        public int SlowerPeriod;
        public double ProfitOrLoss;
        public TotalTransactionInfo totalTransactionInfo;

        public override string ToString()
        {
            return "......................"
                + "FasterPeriod: " + this.FasterPeriod
                + "SlowerPeriod: " + this.SlowerPeriod
                + "ProfitOrLoss: " + this.ProfitOrLoss
                + ".......................";
        }
    }

    public class TotalTransactionInfo
    {
        public List<PositionInfo> positionInfoList;
        public double safe;
        public string ratio;
    }

    public class ProfitGainLoss
    {
        public PeriodInfo maxProfitPeriodInfo;
        public PeriodInfo maxLossPeriodInfo;

    }
}
