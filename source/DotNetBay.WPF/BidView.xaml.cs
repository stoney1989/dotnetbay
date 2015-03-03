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
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        public Auction Auction { get; set; }

        public BidView(Auction auction)
        {
            this.Auction = auction;
            this.DataContext = auction;
            this.InitializeComponent();
        }

        private void BtnPlaceBid(object sender, RoutedEventArgs e)
        {
            var bid = this.YourBidBox.Text;

            try
            {

                var bidAsDouble = Convert.ToDouble(bid);

                var app = Application.Current as App;

                var memberService = new SimpleMemberService(app.MainRepository); 
                var service = new AuctionService(app.MainRepository, memberService);

                service.PlaceBid(memberService.GetCurrentMember(),this.Auction,bidAsDouble);

            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void BtnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}