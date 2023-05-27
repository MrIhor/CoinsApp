using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsAppWPF.Models
{
    public class CoinSearch : ICoin
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        [JsonProperty("thumb")]
        public string? ThumbImage { get; set; }
        [JsonProperty("large")]
        public string? LargeImage { get; set; }
    }
}
