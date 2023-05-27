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

        public CoinDetailViewModel(ICoin coin)
        {
            _coinService = new CoinService();
            LoadCoin(coin, CancellationToken.None);
        }

        public async void LoadCoin(ICoin? coin, CancellationToken cancellationToken)
        {
            var coinDetails = await _coinService.GetSingle(coin.Id, cancellationToken);
            Coin = coinDetails;
        }
    }
}
