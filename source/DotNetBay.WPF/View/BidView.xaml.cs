using System;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {


        private BidViewModel bidViewModel;

        public BidView(AuctionViewModel auctionViewModel)
        {
            this.InitializeComponent();
            this.bidViewModel = new BidViewModel(auctionViewModel);
            this.DataContext = this.bidViewModel;
        }
    }
}