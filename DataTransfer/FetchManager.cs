using Data;
using Data.DataStructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class FetchManager
    {
        public static readonly string BASEURL = "http://finans.mynet.com/borsa/ajaxTarihselVeriler/";
        public static readonly string seperator = "/";
        
        /// <summary>
        /// FetchHistoricalData
        /// </summary>
        /// <param name="symbol">Financial Instrument Symbol</param>
        /// <param name="startDate">Format: YYYY.MM.dd</param>
        public static void FetchHistoricalData(DateTime startDate, DateTime endDate, string symbol, string name, string sector)
        {
            string date = endDate.ToString("yyyy.MM.dd");

            JArray dataArray = JArray.Parse(getData(symbol, date));

            DateTime controlDate = DateTime.MinValue;

            using (InvestmentAnalysisContext context = new InvestmentAnalysisContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;

                foreach (JToken data in dataArray.Children())
                {
                    controlDate = DateTime.Parse(data[5].Value<String>());

                    if (!(controlDate > startDate))
                        break;

                    HistoricalDataBlock historicalDataBlock = context.HistoricalDataBlocks.Where(q => q.Symbol.Equals(symbol) && q.RecordDate == controlDate).SingleOrDefault();

                    if (null == historicalDataBlock)
                    {
                        historicalDataBlock = new HistoricalDataBlock();

                        historicalDataBlock.Symbol = symbol;
                        historicalDataBlock.Name = name;
                        historicalDataBlock.Sector = sector;
                        historicalDataBlock.MinPrice = decimal.Parse(data[1].Value<string>());
                        historicalDataBlock.MaxPrice = decimal.Parse(data[2].Value<string>());
                        historicalDataBlock.LastPrice = decimal.Parse(data[3].Value<string>());
                        historicalDataBlock.Volume = long.Parse(data[4].Value<String>().Remove(data[4].Value<String>().IndexOf(',')).Replace(".", ""));
                        historicalDataBlock.RecordDate = DateTime.Parse(data[5].Value<String>());

                        context.Entry(historicalDataBlock).State = System.Data.Entity.EntityState.Added;
                    }
                }

                context.SaveChanges();
            }

            if (controlDate > startDate)
                FetchHistoricalData(startDate, controlDate, symbol, name, sector);

        }

        private static string getData(string symbol, string date)
        {
            string data = string.Empty;
            string url = BASEURL + symbol + seperator + date;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        data = reader.ReadToEnd();
                    }
                }
            }

            return data;
        }
    }
}
