using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoinsAppWPF.Models
{
    public class CoinDetails
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        [JsonProperty("market_cap_rank")]
        public int? Rank { get; set; }
        [JsonProperty("market_data")]
        public MarketData? MarketData { get; set; }
        [JsonProperty("last_updated")]
        public string? LastUpdated { get; set; }
    }
}
