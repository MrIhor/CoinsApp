using CoinsAppWPF.Models;
using CoinsAppWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinsAppWPF.ViewModels
{
    class CoinDetailViewModel : ViewModelBase
    {
        private CoinService _coinService;
        private CoinDetails coin;

        public CoinDetails Coin
        {
            get => coin;
            set
            {
                coin = value;
                OnPropertyChanged(nameof(Coin));
            }
        }

        public CoinDetailViewModel(Coin coin)
        {
            _coinService = new CoinService();
            LoadCoin(coin.Id, CancellationToken.None);
        }

        public async void LoadCoin(string? id, CancellationToken cancellationToken)
        {
            var coin = await _coinService.GetSingle(id, cancellationToken);
            Coin = coin;
        }
    }
}
