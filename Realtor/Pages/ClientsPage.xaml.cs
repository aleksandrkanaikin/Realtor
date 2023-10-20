using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Entities;
using Realtor.Windows;

namespace Realtor.Pages
{
    public partial class ClientsPage : Page
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private DataManager _manager = new DataManager();
        public ClientsPage()
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = _manager.GetAllClient();
        }

        private void ClientSearchTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ClientSearchTxb.Text = "";
            ClientSearchTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            ClientsDataGrid.ItemsSource = _manager.SearchClients(ClientSearchTxb.Text);
            ClientSearchTxb.Text = "Введите ФИО";
            ClientSearchTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void CreateNewClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            Window create = new CreateClientWindow();
            create.ShowDialog();
            ClientsDataGrid.ItemsSource = _manager.GetAllClient();
        }

        private void ClientsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ClientsDataGrid.SelectedItem as Clients;
            if (selectedItem != null)
            {
                Clients itemToEdit = db.Clients.Find(selectedItem.ClientID); 
                if (itemToEdit != null)
                {
                    Window editWind = new EditClient(itemToEdit);
                    editWind.ShowDialog();
                }
            }
            ClientsDataGrid.ItemsSource = _manager.GetAllClient();
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ClientsDataGrid.SelectedItem as Clients;
            if (selectedItem != null)
            {
                Clients itemToDelete = db.Clients.Find(selectedItem.ClientID); 
                if (itemToDelete != null)
                {
                    db.Clients.Remove(itemToDelete);
                    db.SaveChanges();
                }
            }
            ClientsDataGrid.ItemsSource = _manager.GetAllClient();
        }
    }
}