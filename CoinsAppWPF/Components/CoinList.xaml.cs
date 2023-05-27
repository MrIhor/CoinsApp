using CoinsAppWPF.Models;
using CoinsAppWPF.Views;
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

namespace CoinsAppWPF.Components
{
    public partial class CoinList : UserControl
    {
        public CoinList()
        {
            InitializeComponent();
        }

        private void ContentPresenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            var coin = element?.DataContext as Coin;
            App.Navigator.Navigate(new CoinDetailPage(coin));
        }
    }
}
