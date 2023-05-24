using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoinsAppWPF.Models
{
    public class CurrencyList
    {
        [JsonPropertyName("uah")]
        public decimal Uah { get; set; }

        [JsonPropertyName("usd")]
        public decimal Usd { get; set; }

        [JsonPropertyName("eur")]
        public decimal Eur { get; set; }
    }
}
