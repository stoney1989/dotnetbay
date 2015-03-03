using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Auction> auctions;

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        }

        public MainWindow()
        {
            this.InitializeComponent();

            var mainRepository = ((App) Application.Current).MainRepository;

            var memberService = new SimpleMemberService(mainRepository);
            var service = new AuctionService(mainRepository, memberService);

            var queryable = service.GetAll();

            this.auctions = new ObservableCollection<Auction>(service.GetAll());


            ((App) Application.Current).AuctionRunner.Auctioneer.BidAccepted +=
                delegate(object sender, ProcessedBidEventArgs args)
                {
                    
                };

            this.DataContext = this;
            
        }

        private void BuyAction(object sender, RoutedEventArgs e)
        {
            var bidView = new BidView((Auction) this.AuctionDataGrid.SelectedItem);
            bidView.ShowDialog(); // Blocking
        }

        private void AddNewAuction(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog(); // Blocking
        }
    }

    public class BooleanToStatusTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool) value) ? "Offen" : "Abgeschlossen";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string) value).Equals("Offen") ? true : false;
        }
    }
}