using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Core;
using DotNetBay.Model;
using System.Windows;

namespace DotNetBay.WPF.ViewModel
{
    public class AuctionViewModel : ViewModelBase
    {


        private String title;

        private bool status;

        private String start;

        private String end;

        private String startPrice;

        private String currentPrice;

        private int bids;

        private String seller;

        private String currentWinner;

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public string Start
        {
            get { return this.start; }
            set
            {
                this.start = value;
                this.OnPropertyChanged("Start");
            }
        }

        public bool Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                this.OnPropertyChanged("Status");
            }
        }

        public string StartPrice
        {
            get { return this.startPrice; }
            set
            {
                this.startPrice = value;
                this.OnPropertyChanged("StartPrice");
            }
        }

        public string CurrentPrice
        {
            get { return this.currentPrice; }
            set
            {
                this.currentPrice = value;
                this.OnPropertyChanged("CurrentPrice");
            }
        }

        public string End
        {
            get { return this.end; }
            set
            {
                this.end = value;
                this.OnPropertyChanged("End");
            }
        }

        public String Seller
        {
            get { return this.seller; }
            set
            {
                this.seller = value;
                this.OnPropertyChanged("Seller");
            }
        }

        public int Bids
        {
            get { return this.bids; }
            set
            {
                this.bids = value;
                this.OnPropertyChanged("Bids");
            }
        }

        public String CurrentWinner
        {
            get { return this.currentWinner; }
            set
            {
                this.currentWinner = value;
                this.OnPropertyChanged("CurrentWinner");
            }
        }

        public Auction Auction { get; set; }
        public AuctionViewModel(Auction auction)
        {
            this.Auction = auction;
            this.Update();

        }

        private void Update()
        {
            this.Title = this.Auction.Title;
            this.Status = this.Auction.IsRunning;
            this.Start = this.Auction.StartDateTimeUtc.ToString();
            this.End = this.Auction.EndDateTimeUtc.ToString();
            this.StartPrice = this.Auction.StartPrice.ToString();
            this.CurrentPrice = this.Auction.CurrentPrice.ToString();
            this.Bids = this.Auction.Bids.Count;
            this.Seller = this.Auction.Seller.DisplayName;
            if (this.Auction.Winner != null) this.CurrentWinner = this.Auction.Winner.DisplayName;
        }

        public void PlaceBid(string yourBid)
        {
            try
            {
                var bidAsDouble = Convert.ToDouble(yourBid);

                var app = Application.Current as App;

                var memberService = new SimpleMemberService(app.MainRepository);
                var service = new AuctionService(app.MainRepository, memberService);

                var bid = service.PlaceBid(memberService.GetCurrentMember(), this.Auction, bidAsDouble);


                service.Save(this.Auction);
                this.Update();


            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
        }
    }
}