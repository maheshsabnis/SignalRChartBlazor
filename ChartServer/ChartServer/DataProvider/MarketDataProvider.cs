using SharedModels;

namespace ChartServer.DataProvider
{
    public static class MarketDataProvider
    {
        public static List<Market> GetMarketData()
        {
            var random = new Random();
            var marketData = new List<Market>()
            { 
                new Market() { CompanyName = "MS-IT Services", Volume = random.Next(1,900)},
                new Market() { CompanyName = "TS-IT Providers", Volume = random.Next(1,900)},
                new Market() { CompanyName = "LS-SL Sales", Volume = random.Next(1,900)},
                new Market() { CompanyName = "MS-Electronics", Volume = random.Next(1,900)},
                new Market() { CompanyName = "TS-Electrical", Volume = random.Next(1,900)},
                new Market() { CompanyName = "LS-Foods", Volume = random.Next(1,900)},
                new Market() { CompanyName = "MS-Healthcare", Volume = random.Next(1,900)},
                new Market() { CompanyName = "LS-Pharmas", Volume = random.Next(1,900)},
                new Market() { CompanyName = "TS-Healthcare", Volume = random.Next(1,900)}
            };
            return marketData;
        }
    }
}
