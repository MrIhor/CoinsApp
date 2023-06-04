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
    class ConvertCurrencyViewModel : ViewModelBase
    {
        private CurrencyService _currencyService;
        private ObservableCollection<string> _currencies;
        private string selectedToCurrency = "UAH";
        private string selectedFromCurrency = "USD";
        private string amount = "1";
        private decimal convertedValue;


        public ObservableCollection<string> Currencies
        {
            get { return _currencies;}
            set 
            { 
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }

        public string SelectedToCurrency
        {
            get => selectedToCurrency;
            set
            {
                selectedToCurrency = value;
                OnPropertyChanged(nameof(SelectedToCurrency));
                Convert();
            }
        }

        public string SelectedFromCurrency
        {
            get => selectedFromCurrency;
            set
            {
                selectedFromCurrency = value;
                OnPropertyChanged(nameof(SelectedFromCurrency));
                Convert();
            }
        }

        public string Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
                Convert();
            }
        }

        public decimal ConvertedValue
        {
            get => convertedValue;
            set
            {
                convertedValue = value;
                OnPropertyChanged(nameof(ConvertedValue));
            }
        }

        public ConvertCurrencyViewModel()
        {
            _currencyService = new CurrencyService();
            LoadCurrencies(CancellationToken.None);
            Convert();
        }

        public async void LoadCurrencies(CancellationToken cancellationToken)
        {
            var _currencies = await _currencyService.GetSymbols(cancellationToken);
            Currencies = new ObservableCollection<string>(_currencies);
        }

        public async void Convert()
        {
            decimal parseAmount = decimal.Parse(amount);
            var convertedValue = await _currencyService.Convert(parseAmount, selectedToCurrency, selectedFromCurrency, CancellationToken.None);
            ConvertedValue = convertedValue;
        }
    }
}
