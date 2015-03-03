using System;
using System.Collections.Generic;

namespace DotNetBay.Model
{
    public class Auction
    {
        public Auction()
        {
            this.Bids = new List<Bid>();
            
        }


        public long id;
        private double startPrice;
        private string title;
        private string description;
        private byte[] image;
        private double currentPrice;
        private DateTime startDateTimeUtc;
        private DateTime endDateTimeUtc;
        private DateTime closeDateTimeUtc;
        private Member seller;
        private Member winner;
        private List<Bid> bids;
        private Bid activeBid;
        private bool isClosed;
        private bool isRunning;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public double StartPrice
        {
            get { return this.startPrice; }
            set
            {
                this.startPrice = value;
                if (value < 1)
                {
                    throw new ApplicationException("Start Price must greater then 0!");
                }
              
                
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Title must not be empty!");
                }
            }
        }

        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value; 
                if (value.Length <3 || value.Length >240)
                {
                    throw new ApplicationException("Length of description must be between 30 and 240 characters!");
                }
               
                
            }
        }


        public byte[] Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        public double CurrentPrice
        {
            get { return this.currentPrice; }
            set { this.currentPrice = value; }
        }

        /// <summary>
        /// Gets or sets the UTC DateTime values to avoid wrong data when serializing the values
        /// </summary>
        public DateTime StartDateTimeUtc
        {
            get { return this.startDateTimeUtc; }
            set
            {
                this.startDateTimeUtc = value;
                if (this.startDateTimeUtc > DateTime.Now)
                {
                    throw new ApplicationException("Start time must not be in the future!");
                }
            
            }
        }

        /// <summary>
        /// Gets or sets the UTC DateTime values to avoid wrong data when serializing the values
        /// </summary>
        public DateTime EndDateTimeUtc
        {
            get { return this.endDateTimeUtc; }
            set
            {
                this.endDateTimeUtc = value;
                if (this.endDateTimeUtc < this.StartDateTimeUtc)
                {
                    throw new ApplicationException("End time must be greater then start time!");
                }
            }
        }

        /// <summary>
        /// Gets or sets the UTC DateTime values to avoid wrong data when serializing the values
        /// </summary>
        public DateTime CloseDateTimeUtc
        {
            get { return this.closeDateTimeUtc; }
            set { this.closeDateTimeUtc = value; }
        }

        public Member Seller
        {
            get { return this.seller; }
            set { this.seller = value; }
        }

        public Member Winner
        {
            get { return this.winner; }
            set { this.winner = value; }
        }

        public List<Bid> Bids
        {
            get { return this.bids; }
            set { this.bids = value; }
        }

        public Bid ActiveBid
        {
            get { return this.activeBid; }
            set { this.activeBid = value; }
        }

        public bool IsClosed
        {
            get { return this.isClosed; }
            set { this.isClosed = value; }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.isRunning = value; }
        }
    }
}