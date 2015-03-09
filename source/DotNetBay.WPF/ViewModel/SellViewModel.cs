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
using Microsoft.Win32;

namespace DotNetBay.WPF.ViewModel
{
    public class SellViewModel : ViewModelBase
    {
        private String title;

        public String Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }


        private String description;

        public String Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                this.OnPropertyChanged("Description");
            }
        }


        private String startPrice;

        public String StartPrice
        {
            get { return this.startPrice; }
            set
            {
                this.startPrice = value;
                this.OnPropertyChanged("StartPrice");
            }
        }

        private String start;

        public String Start
        {
            get { return this.start; }
            set
            {
                this.start = value;
                this.OnPropertyChanged("Start");
            }
        }

        private String end;

        public String End
        {
            get { return this.end; }
            set
            {
                this.end = value;
                this.OnPropertyChanged("End");
            }
        }


        private String image;

        public String Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
                this.OnPropertyChanged("Image");
            }
        }


        public ICommand AddAuctionCommand { get; set; }
        public ICommand CancelAddAuctionCommand { get; set; }

        public ICommand ChooseImageCommand { get; set; }

        public SellViewModel()
        {
            this.AddAuctionCommand = new RelayCommand(this.AddAuction);
            this.CancelAddAuctionCommand = new RelayCommand(this.CancelAddAuction);
            this.ChooseImageCommand = new RelayCommand(this.ChooseImage);
        }

        private void ChooseImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != true) return;

            var filePath = openFileDialog.FileName;
            this.Image = filePath;
        }


        private void CancelAddAuction(object obj)
        {
            ((SellView)obj).Close();
        }

        private void AddAuction(object obj)
        {
            var app = Application.Current as App;

            Console.WriteLine(this.Start);
            Console.WriteLine(this.End);


            try
            {
                var auction = new Auction
                {
                    Title = this.Title,
                    Description = this.Description,
                    StartPrice = Convert.ToDouble(this.StartPrice),
                    StartDateTimeUtc = Convert.ToDateTime(this.Start).ToUniversalTime(),
                    EndDateTimeUtc = Convert.ToDateTime(this.End).ToUniversalTime(),
                    IsRunning = true,
                    Seller = new SimpleMemberService(app.MainRepository).GetCurrentMember()
                };

                var memberService = new SimpleMemberService(app.MainRepository);
                var service = new AuctionService(app.MainRepository, memberService);
                service.Save(auction);



                ((SellView)obj).Close();

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);

                const string messageBoxText = "There are errors in your statements, please try again.";
                const string caption = "Error";
                const MessageBoxButton button = MessageBoxButton.OK;
                const MessageBoxImage icon = MessageBoxImage.Warning;


                MessageBox.Show(messageBoxText, caption, button, icon);



            }
        }
    }
}