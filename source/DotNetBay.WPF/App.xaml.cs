using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.FileStorage;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IMainRepository mainRepository;

        public IMainRepository MainRepository
        {
            get { return this.mainRepository; }
        }

        private readonly AuctionRunner auctionRunner;

        public IAuctionRunner AuctionRunner
        {
            get { return this.auctionRunner; }
        }

        public App()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            this.mainRepository = new FileSystemMainRepository(result);
            this.InitDemoData();  
            this.auctionRunner = new AuctionRunner(this.mainRepository);
            this.auctionRunner.Start();
       
        }

        private void InitDemoData()
        {
            var memberService = new SimpleMemberService(this.mainRepository);
            var service = new AuctionService(this.mainRepository, memberService);
            
            if (!service.GetAll().Any())
            {
             
                var me = memberService.GetCurrentMember();
                service.Save(new Auction
                {
                    Title = "My First Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 800,
                    Description = "My First Description",
                    Seller = me,
                    IsRunning = true,
                    IsClosed = false
                });

                var p = new Member();

                service.Save(new Auction
                {
                    Title = "My Second Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 234,
                    Description = "My Second Description",
                    Seller = me ,
                    IsRunning = true,
                    IsClosed = false
                });

                var p2 = new Member();

                service.Save(new Auction
                {
                    Title = "My Third Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 3453,
                    Description = "My Third Description",
                    Seller = me,
                    IsRunning = false,
                    IsClosed = true
                });
            }
        }
    }
}