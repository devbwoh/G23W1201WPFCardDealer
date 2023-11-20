using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace G23W1201WPFCardDealer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public CardViewModel vm = new CardViewModel();

        public MainWindow() {
            InitializeComponent();

            this.DataContext = vm;
        }

        private void OnDeal(object sender, RoutedEventArgs e) {
            vm.Shuffle();
        }
    }
}
