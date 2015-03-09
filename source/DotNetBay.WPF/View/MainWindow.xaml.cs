using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowViewModel mainWindowViewModel;

        public MainWindow()
        {
            this.InitializeComponent();

            this.mainWindowViewModel = new MainWindowViewModel();

            this.DataContext = this.mainWindowViewModel;

        }

    }

}