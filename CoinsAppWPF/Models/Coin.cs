using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoinsAppWPF.Models
{
    public class Coin
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        [JsonProperty("current_price")]
        public string? CurrentPrice { get; set; }
        [JsonProperty("market_cap_rank")]
        public string? MarketCapRank { get; set; }
        [JsonProperty("market_cap")]
        public string? MarketCap { get; set; }
        [JsonProperty("total_volume")]
        public string? TotalVolume { get; set; }
        [JsonProperty("circulating_supply")]
        public string? CirculatingSupply { get; set; }
        [JsonProperty("last_updated")]
        public string? LastUpdated { get; set; }
    }
}
