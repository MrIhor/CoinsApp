using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
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
    public partial class Layout : Page, IObserver<Page>, ICanGoback
    {
        public Layout()
        {
            InitializeComponent();
            App.Navigator.Subscribe(this);
            App.Navigator.RegisterGoBackHandler(this);
        }

        public void GoBack()
        {
            this.NavigationFrame.GoBack();
        }

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(Page value)
        {
            this.NavigationFrame.Content = value;
        }
    }


    public interface ICanGoback
    {
        void GoBack();
    }
    public class NavigatorService<T> : IObservable<T>, IDisposable
    {

        private readonly Subject<T> _subject = new();
        private WeakReference<ICanGoback>? _canGoback;

        public void Dispose()
        {
            _subject.Dispose();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _subject.Subscribe(observer);
        }

        public void RegisterGoBackHandler(ICanGoback handler)
        {
            _canGoback = new WeakReference<ICanGoback>(handler);
        }


        public void Navigate(T page)
        {
            _subject.OnNext(page);
        }

        public void GoBack()
        {
            if (_canGoback is null) throw new InvalidOperationException();
            _canGoback.TryGetTarget(out ICanGoback? canGoback);
            canGoback?.GoBack();
        }
    }
}
