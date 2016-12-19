using System;
using DataTransfer;
using Data;
using System.Diagnostics;

namespace DataFetch
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (InvestmentAnalysisContext context = new InvestmentAnalysisContext())
            {
                context.Database.Initialize(false);
            }

            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = new DateTime(2016, 12, 31);

            Stopwatch stopwatchLocal = null;

            Console.WriteLine("START");
            
            //Console.WriteLine("GARAN..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(new DateTime(2016, 12, 1), new DateTime(2016, 12, 31), "GARAN", "TÜRKİYE GARANTİ BANKASI A.Ş.", "Bankacılık");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("HALKB..");
            stopwatchLocal = new Stopwatch(); stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2007, 5, 31), "HALKB", "TÜRKİYE HALK BANKASI A.Ş.", "Bankacılık");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("AKBNK..");
            //stopwatchLocal = new Stopwatch(); stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "AKBNK", "AKBANK T.A.Ş.", "Bankacılık");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("VAKBN..");
            stopwatchLocal = new Stopwatch(); stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2005, 11, 30), "VAKBN", "TÜRKİYE VAKIFLAR BANKASI T.A.O.", "Bankacılık");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ISCTR..");
            //stopwatchLocal = new Stopwatch(); stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "ISCTR", "TÜRKİYE İŞ BANKASI A.Ş.", "Bankacılık");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("YKBNK..");
            //stopwatchLocal = new Stopwatch(); stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "YKBNK", "YAPI VE KREDİ BANKASI A.Ş.", "Bankacılık");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            Console.WriteLine("LOGO..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2000, 5, 30), "LOGO", "LOGO YAZILIM SANAYİ VE TİCARET A.Ş.", "Bilişim ve Teknoloji");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("NETAS..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "NETAS", "NETAŞ TELEKOMÜNİKASYON A.Ş.", "Bilişim ve Teknoloji");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            //Console.WriteLine("SISE..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, new DateTime(2006, 1, 31), "SISE", "TÜRKİYE ŞİŞE VE CAM FABRİKALARI A.Ş", "Cam ve Porselen");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("TRKCM..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "TRKCM", "TRAKYA CAM SANAYİİ A.Ş.", "Cam ve Porselen");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ARCLK..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "ARCLK", "ARÇELİK A.Ş.", "Dayanıklı Tüketim Malları");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("VESBE..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2006, 4, 30), "VESBE", "VESTEL BEYAZ EŞYA SANAYİ VE TİCARET A.Ş.", "Dayanıklı Tüketim Malları");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("VESTL..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "VESTL", "VESTEL ELEKTRONİK SANAYİ VE TİCARET A.Ş.", "Dayanıklı Tüketim Malları");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ADEL..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "ADEL", "ADEL KALEMCİLİK TİCARET VE SANAYİ A.Ş.", "Diğer İmalat");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            Console.WriteLine("EKGYO..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2010, 12, 31), "EKGYO", "ENKA İNŞAAT VE SANAYİ A.Ş.", "Gayrimenkul Yatırım Ortaklıkları");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            Console.WriteLine("CCOLA..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2006, 5, 31), "CCOLA", "COCA - COLA İÇECEK A.Ş.", "Gıda ve İçecek");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ULKER..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "ULKER", "ÜLKER BİSKÜVİ SANAYİ A.Ş.", "Gıda ve İçecek");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            //Console.WriteLine("DOHOL..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "DOHOL", "DOĞAN ŞİRKETLER GRUBU HOLDİNG A.Ş.", "Holding");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ECZYT..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, new DateTime(2000, 7, 31), "ECZYT", "ECZACIBAŞI YATIRIM HOLDİNG ORTAKLIĞI A.Ş.", "Holding");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("KCHOL..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "KCHOL", "KOÇ HOLDİNG A.Ş.", "Holding");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("SAHOL..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "SAHOL", "HACI ÖMER SABANCI HOLDİNG A.Ş.", "Holding");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TKFEN..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2007, 11, 30), "TKFEN", "TEKFEN HOLDİNG A.Ş.", "Holding");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ENKAI..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "ENKAI", "ENKA İNŞAAT VE SANAYİ A.Ş.", "İnşaat ve Bayındırlık");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            //Console.WriteLine("KARTN..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "KARTN", "KARTONSAN KARTON SANAYİ VE TİCARET A.Ş.", "Kağıt, Ambalaj, Matbaacılık ve Yayın");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("AKSA..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "AKSA", "AKSA AKRİLİK KİMYA SANAYİİ A.Ş.", "Kimya, Petrol ve Plastik");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("PETKM..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "PETKM", "PETKİM PETROKİMYA HOLDİNG A.Ş.", "Kimya, Petrol ve Plastik");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("SODA..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2000, 4, 30), "SODA", "SODA SANAYİİ A.Ş.", "Kimya, Petrol ve Plastik");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("TUPRS..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "TUPRS", "TÜPRAŞ-TÜRKİYE PETROL RAFİNERİLERİ A.Ş.", "Kimya, Petrol ve Plastik");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("KOZAL..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2010, 2, 28), "KOZAL", "KOZA ALTIN İŞLETMELERİ A.Ş.", "Madencilik");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("EREGL..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "EREGL", "EREĞLİ DEMİR VE ÇELİK FABRİKALARI T.A.Ş.", "Metal Ana Sanayi");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("DOAS..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2004, 6, 30), "DOAS", "DOĞUŞ OTOMOTİV SERVİS VE TİCARET A.Ş.", "Otomotiv Sanayii");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("FROTO..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, new DateTime(2014, 12, 31), "FROTO", "FORD OTOMOTİV SANAYİ A.Ş.", "Otomotiv Sanayii");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            //Console.WriteLine("OTKAR..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "OTKAR", "OTOKAR OTOMOTİV VE SAVUNMA SANAYİ A.Ş.", "Otomotiv Sanayii");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TMSN..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2012, 12, 31), "TMSN", "TÜMOSAN MOTOR VE TRAKTÖR SANAYİ A.Ş", "Otomotiv Sanayii");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("TOASO..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "TOASO", "TOFAŞ TÜRK OTOMOBİL FABRİKASI A.Ş.", "Otomotiv Sanayii");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TTRAK..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2004, 6, 30), "TTRAK", "TÜRK TRAKTÖR VE ZİRAAT MAKİNELERİ A.Ş.", "Otomotiv Sanayii");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("BRISA..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "BRISA", "BRİSA BRIDGESTONE SABANCI LASTİK SANAYİ VE TİCARET A.Ş.", "Otomotiv Yan Sanayi");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("EGEEN..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "EGEEN", "EGE ENDÜSTRİ VE TİCARET A.Ş.", "Otomotiv Yan Sanayi");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("GOODY..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "GOODY", "GOODYEAR LASTİKLERİ T.A.Ş.", "Otomotiv Yan Sanayi");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("PARSN..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2000, 1, 31), "PARSN", "PARSAN MAKİNA PARÇALARI SANAYİİ A.Ş", "Otomotiv Yan Sanayi");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("BIMAS..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2005, 7, 31), "BIMAS", "BİM BİRLEŞİK MAĞAZALAR A.Ş.", "Perakende Ticaret");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("MGROS..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "MGROS", "MİGROS TİCARET A.Ş.", "Perakende Ticaret");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TKNSA..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2012, 5, 31), "TKNSA", "TEKNOSA İÇ VE DIŞ TİCARET A.Ş.", "Perakende Ticaret");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("ASELS..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "ASELS", "ASELSAN ELEKTRONİK SANAYİ VE TİCARET A.Ş.", "Savunma Sanayii");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("GUBRF..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "GUBRF", "GÜBRE FABRİKALARI T.A.Ş.", "Tarım, Ormancılık ve Hayvancılık");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("PGSUS..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2013, 4, 30), "PGSUS", "PEGASUS HAVA TAŞIMACILIĞI A.Ş.", "Ulaştırma ve Haberleşme");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TAVHL..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2007, 2, 28), "TAVHL", "TAV HAVALİMANLARI HOLDİNG A.Ş.", "Ulaştırma ve Haberleşme");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TCELL..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2000, 7, 31), "TCELL", "TURKCELL İLETİŞİM HİZMETLERİ A.Ş.", "Ulaştırma ve Haberleşme");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            //Console.WriteLine("THYAO..");
            //stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            //FetchManager.FetchHistoricalData(startDate, endDate, "THYAO", "TÜRK HAVA YOLLARI A.O.", "Ulaştırma ve Haberleşme");
            //stopwatchLocal.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);

            Console.WriteLine("TTKOM..");
            stopwatchLocal = new Stopwatch();stopwatchLocal.Start();
            FetchManager.FetchHistoricalData(startDate, new DateTime(2008, 5, 31), "TTKOM", "TÜRK TELEKOMÜNİKASYON A.Ş.", "Ulaştırma ve Haberleşme");
            stopwatchLocal.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatchLocal.Elapsed);
            
            Console.WriteLine("END");
        }
    }
}
