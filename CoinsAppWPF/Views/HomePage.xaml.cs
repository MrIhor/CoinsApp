using CoinsAppWPF.Models;
using CoinsAppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoinsAppWPF.Views
{
    public partial class HomePage : UserControl
    {
        private HomePageViewModel _homeViewModel;
        public HomePage()
        {
            InitializeComponent();
            DataContext = new HomePageViewModel();
            _homeViewModel = new HomePageViewModel();
        }

        private void ContentPresenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            var coin = element?.DataContext as CoinSearch;
            App.Navigator.Navigate(new CoinDetailPage(coin));

            if (_homeViewModel != null )
            {
                _homeViewModel.SearchText = "";
                _homeViewModel.SearchResults = null;
            }
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            _homeViewModel.IsDropdownOpen = false;
        }
    }
}
