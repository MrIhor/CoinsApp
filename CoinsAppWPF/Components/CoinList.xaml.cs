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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var coin = button?.DataContext as Coin;
            App.Navigator.Navigate(new CoinDetailPage(coin));
        }
    }
}
