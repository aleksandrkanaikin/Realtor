using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Entities;

namespace Realtor.Pages
{
    public partial class ClientsPage : Page
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private ObservableCollection<Clients> ClientsList { get; set; }
        public ClientsPage()
        {
            InitializeComponent();
            ClientsList = new ObservableCollection<Clients>(db.Clients.ToList());
            ClientsDataGrid.ItemsSource = ClientsList;
        }

        private void ClientSearchTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ClientSearchTxb.Text = "";
            ClientSearchTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClientSearchTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ClientSearchTxb.Text = "Введите ФИО";
            ClientSearchTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void CreateNewClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            Window create = new CreateClientWindow();
            create.ShowDialog();
            ClientsList = new ObservableCollection<Clients>(db.Clients.ToList());
            ClientsDataGrid.ItemsSource = ClientsList;
        }
    }
}