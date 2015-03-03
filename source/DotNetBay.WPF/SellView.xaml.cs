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
using DotNetBay.Model;
using Microsoft.Win32;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        public SellView()
        {
            this.InitializeComponent();
        }

        private void BtnAddAction(object sender, RoutedEventArgs e)
        {
            var title = this.TitleBox.Text;
            var desc = this.DescriptionBox.Text;
            var startPrice = this.StartPriceBox.Text;
            var startDate = this.StartDateBox.DisplayDate;
            var endDate = this.EndDateBox.DisplayDate;
            var image = this.ImageBox.Text;

            try
            {
                var auction = new Auction
                {
                    Title = title,
                    Description = desc,
                    StartPrice = Convert.ToDouble(startPrice),
                    StartDateTimeUtc = startDate,
                    EndDateTimeUtc = endDate
                };
            }
            catch (Exception)
            {

                // Configure the message box to be displayed
                const string messageBoxText = "There are errors in your statements, please try again.";
                const string caption = "Error";
                const MessageBoxButton button = MessageBoxButton.OK;
                const MessageBoxImage icon = MessageBoxImage.Warning;

                
                MessageBox.Show(this,messageBoxText, caption, button, icon);

        

            }
        }

        private void BtnSelectImagePath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != true) return;

            var filePath = openFileDialog.FileName;
            this.ImageBox.Text = filePath;
        }

        private void BtnCancelAddAuction(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}