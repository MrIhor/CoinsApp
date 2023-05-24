using CoinsAppWPF.ViewModels;
using CoinsAppWPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoinsAppWPF
{
    public partial class App : Application
    {
        public static NavigatorService<Page> Navigator = new NavigatorService<Page>();

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();

            base.OnStartup(e);
        }
    }
}
