using CoinsAppWPF.Models;
using CoinsAppWPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinsAppWPF.ViewModels
{
    public class CoinListViewModel : ViewModelBase
    {
        private CoinService _coinService;
        private ObservableCollection<Coin?> _coinListItemViewModels;
        private string _selectedCurrency = "usd";
        private ObservableCollection<string> _currencyList;
        public ObservableCollection<string> Currency
        {
            get
            {
                return _currencyList;
            }

            set
            {
                _currencyList = value;
                OnPropertyChanged(nameof(Currency));
            }
        }

        public string SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
                LoadCoins(CancellationToken.None, SelectedCurrency);
            }
        }

        public ObservableCollection<Coin?> CoinList
        {
            get { return _coinListItemViewModels; }
            set
            {
                _coinListItemViewModels = value;
                OnPropertyChanged(nameof(CoinList));
            }
        }

        public CoinListViewModel()
        {
            _coinService = new CoinService();
            LoadCurrencies(CancellationToken.None);
            LoadCoins(CancellationToken.None, "usd");
        }

        public async void LoadCoins(CancellationToken cancellationToken, string currency = "usd")
        {
            var _coinListItemViewModels = await _coinService.GetAllCoins(cancellationToken, currency);
            CoinList = new ObservableCollection<Coin?>(_coinListItemViewModels);
        }

        public async void LoadCurrencies(CancellationToken cancellationToken)
        {
            var _currencyList = await _coinService.GetCoinCurrencies(cancellationToken);
            Currency = new ObservableCollection<string>(_currencyList);
        }
    }
}
