using CoinsAppWPF.Models;
using CoinsAppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public HomePage()
        {
            InitializeComponent();
            DataContext = new HomePageViewModel();
        }

        private void ContentPresenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            var coin = element?.DataContext as CoinSearch;
            App.Navigator.Navigate(new CoinDetailPage(coin));

            var _homeViewModel = DataContext as HomePageViewModel;

            if (_homeViewModel != null )
            {
                _homeViewModel.SearchResults = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _homeViewModel = DataContext as HomePageViewModel;

            if (_homeViewModel != null)
            {
                _homeViewModel.SearchText = "";
                _homeViewModel.SearchResults = null;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Navigator.Navigate(new ConvertCurrencyPage());
        }
    }
}
