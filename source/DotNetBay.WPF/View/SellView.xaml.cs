using System;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;
using Microsoft.Win32;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        private SellViewModel viewModel;

        public SellView()
        {
            this.InitializeComponent();
            this.viewModel = new SellViewModel();
            this.DataContext = this.viewModel;
        }
    }
}