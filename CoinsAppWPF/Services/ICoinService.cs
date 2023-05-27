using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoinsAppWPF.Models;

namespace CoinsAppWPF.Services
{
    public interface ICoinService
    {
        Task<List<Coin>?> GetAllCoins(CancellationToken cancellationToken, string? currency);
        Task<CoinDetails?> GetSingle(string? id, CancellationToken cancellationToken);
        Task<PriceData?> GetCoinMarketChart(string? id, CancellationToken cancellationToken, string currency, int days);
        Task<CoinListSearch?> SearchCoin(string? searchString, CancellationToken cancellationToken);
        Task<List<string>?> GetCurrencies(CancellationToken cancellationToken);
    }
}
