using CoinsAppWPF.Models;
using CoinsAppWPF.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoinsAppWPF.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private CoinService _coinService;
        public CoinListViewModel CoinListViewModel { get; }
        private string searchText;
        private ObservableCollection<CoinSearch?> searchResults;
        private bool isDropdownOpen;
        public ICommand SearchCommand { get; }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    ExecuteSearch();
                    IsDropdownOpen = !string.IsNullOrEmpty(searchText);
                }
            }
        }

        public ObservableCollection<CoinSearch?> SearchResults
        {
            get { return searchResults; }
            set
            {
                searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }

        public bool IsDropdownOpen
        {
            get { return isDropdownOpen; }
            set
            {
                isDropdownOpen = value;
                OnPropertyChanged(nameof(IsDropdownOpen));
            }
        }

        public HomePageViewModel()
        {
            _coinService = new CoinService();
            CoinListViewModel = new CoinListViewModel();
            SearchCommand = new RelayCommand(ExecuteSearch);
        }

        private async void ExecuteSearch()
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = await _coinService.SearchCoin(searchText, CancellationToken.None);
                SearchResults = new ObservableCollection<CoinSearch?>(result.Coins);
            }
        }
    }
}
