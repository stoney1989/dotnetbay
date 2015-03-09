using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Core;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Model;
using DotNetBay.WPF.View;

namespace DotNetBay.WPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<AuctionViewModel> auctions;

        public ObservableCollection<AuctionViewModel> Auctions
        {
            get { return this.auctions; }
        }

        public ICommand OpenSellViewCommand { get; set; }
        public ICommand OpenBidViewCommand { get; set; }

        public MainWindowViewModel()
        {
            var app = Application.Current as App;

            var mainRepository = app.MainRepository;

            var memberService = new SimpleMemberService(mainRepository);
            var service = new AuctionService(mainRepository, memberService);

            var queryable = service.GetAll();

            this.auctions = this.WrapAuctions(queryable);

            this.OpenSellViewCommand = new RelayCommand(this.OpenSellView);
            this.OpenBidViewCommand = new RelayCommand(this.OpenBidView);
        }

        private void OpenBidView(object obj)
        {
            var bidView = new BidView((AuctionViewModel)obj);
            bidView.ShowDialog();
        }

        private void OpenSellView(object obj)
        {

            var app = Application.Current as App;

            var mainRepository = app.MainRepository;

            var memberService = new SimpleMemberService(mainRepository);
            var service = new AuctionService(mainRepository, memberService);

            var sellView = new SellView();
            sellView.Closed += delegate(object sender, EventArgs args)
            {
                this.Auctions.Add(new AuctionViewModel(service.GetAll().Last()));
            };
            sellView.ShowDialog();
        }

        private ObservableCollection<AuctionViewModel> WrapAuctions(IEnumerable<Auction> queryable)
        {
            var auctionViewModels = queryable.ToList().ConvertAll(auction => new AuctionViewModel(auction));
            return new ObservableCollection<AuctionViewModel>(auctionViewModels);
        }
    }
}