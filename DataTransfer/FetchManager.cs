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
        public static void FetchHistoricalData(string symbol, string name, DateTime startDate, DateTime endDate)
        {
            string date = endDate.ToString("yyyy.MM.dd");

            JArray dataArray = JArray.Parse(getData(symbol, date));

            foreach (JObject dataObject in dataArray.Children<JObject>())
            {
                foreach (JProperty data in dataObject.Properties())
                {
                    HistoricalDataBlock historicalDataBlock = new HistoricalDataBlock();

                    historicalDataBlock.Symbol = symbol;
                    historicalDataBlock.Name = name;



                    throw new NotImplementedException();
                }
            }
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
