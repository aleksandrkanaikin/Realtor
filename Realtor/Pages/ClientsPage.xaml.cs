using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Realtor.Pages
{
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void ClientSearchTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ClientSearchTxb.Text = "";
            ClientSearchTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ClientSearchTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ClientSearchTxb.Text = "Введите ФИО";
            ClientSearchTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }
    }
}