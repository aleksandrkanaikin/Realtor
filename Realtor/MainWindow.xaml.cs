using System;
using System.Windows;
using Realtor.Pages;

namespace Realtor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void WorkTableBtn_OnClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new WorkTablePage());
        }

        private void SalesBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ClientsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new Clients());
        }

        private void EstateObjectsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ObjectsPage());
        }
    }
}