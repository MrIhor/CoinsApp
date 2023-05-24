using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsAppWPF.Models
{
    public class MarketData
    {
        [JsonProperty("current_price")]
        public CurrencyList? CurrentPrice { get; set; }
        [JsonProperty("market_cap")]
        public CurrencyList? MarketCap { get; set; }
        [JsonProperty("total_volume")]
        public CurrencyList? TotalVolume { get; set; }
        [JsonProperty("ath")]
        public CurrencyList? ATH { get; set; }
        [JsonProperty("price_change_percentage_1h_in_currency")]
        public CurrencyList? PriceChangePercentageInHour { get; set; }
        [JsonProperty("price_change_24h_in_currency")]
        public CurrencyList? PriceChangePercentageInFullDay { get; set; }
        [JsonProperty("price_change_percentage_7d_in_currency")]
        public CurrencyList? PriceChangePercentageInSevedDays { get; set; }
    }
}
