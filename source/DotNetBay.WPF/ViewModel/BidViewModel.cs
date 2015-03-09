using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.View;

namespace DotNetBay.WPF.ViewModel
{
    public class BidViewModel : ViewModelBase
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public String StartPrice { get; set; }

        public String CurrentPrice { get; set; }


        public String YourBid { get; set; }

        public AuctionViewModel Auction { get; set; }

        public ICommand PlaceBidCommand { get; set; }

        public ICommand CancelPlaceBidCommand { get; set; }

        public BidViewModel(AuctionViewModel auctionViewModel)
        {
            this.Auction = auctionViewModel;
            this.PlaceBidCommand = new RelayCommand(this.PlaceBid);
            this.CancelPlaceBidCommand = new RelayCommand((obj) => ((BidView)obj).Close());
        }

        private void PlaceBid(object obj)
        {
            this.Auction.PlaceBid(this.YourBid);
        }
    }
}