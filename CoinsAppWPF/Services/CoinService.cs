using CoinsAppWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinsAppWPF.Services
{
    public class CoinService : ICoinService
    {
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://api.coingecko.com/api/v3/")
        };

        async Task<T?> GetAsync<T>(string resourseName, CancellationToken cancellationToken)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourseName);
            requestMessage.Headers.Add("User-Agent", "PostmanRuntime/7.32.2");

            var response = await _client.SendAsync(requestMessage, cancellationToken);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public Task<List<Coin>?> GetAllCoins(CancellationToken cancellationToken, string? currency = "uah")
        {
            string coinsMarketUrl = $"coins/markets?vs_currency={currency}&per_page=10&page=1&sparkline=false";
            return GetAsync<List<Coin>>(coinsMarketUrl, cancellationToken);
        }

        public Task<CoinDetails?> GetSingle(string? id, CancellationToken cancellationToken)
        {
            string coinUrl = $"coins/{id}?localization=false";
            return GetAsync<CoinDetails>(coinUrl, cancellationToken);
        }

        public Task<PriceData?> GetCoinMarketChart(string? id, CancellationToken cancellationToken, string currency = "uah", int days = 1)
        {
            string coinPricesUrl = $"coins/{id}/market_chart?vs_currency={currency}&days={days}";
            return GetAsync<PriceData>(coinPricesUrl, cancellationToken);
        }

        public Task<CoinSearch?> SearchCoin(string? searchString, CancellationToken cancellationToken)
        {
            string coinSearchUrl = $"search?query={searchString}";
            return GetAsync<CoinSearch>(coinSearchUrl, cancellationToken);
        }

        public Task<List<string>?> GetCurrencies(CancellationToken cancellationToken)
        {
            string currenciesUrl = "simple/supported_vs_currencies";
            return GetAsync<List<string>?>(currenciesUrl, cancellationToken);
        }
    }
}
