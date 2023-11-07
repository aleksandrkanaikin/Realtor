using System;
using System.Linq;
using System.Windows;
using Entities;
using Realtor.Repository;

namespace Realtor.Windows
{
    public partial class CreateNewSale : Window
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        public CreateNewSale()
        {
            InitializeComponent();
            ObjectsBox.ItemsSource = db.Properties.ToList();
            ClientsBox.ItemsSource = db.Clients.ToList();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selectProperty = ObjectsBox.SelectedItem as Entities.Properties;
            Entities.Properties property = db.Properties.Find(selectProperty.PropertyID);
            var selectClient = ClientsBox.SelectedItem as Clients;
            if (SaleNameTextBox.Text != "" || BudgetTextBox.Text != "" ||
                ClientsBox.SelectedItem != null || ObjectsBox.SelectedItem != null)
            {
                Clients client = db.Clients.Find(selectClient.ClientID);
                {
                    var newDeal = new Deals()
                    {
                        DealID = Guid.NewGuid(),
                        AgentID = AgentIdStorage.AgentId,
                        PropertyID = property.PropertyID,
                        ClientID = client.ClientID,
                        DealDate = DateTime.Now,
                        DealStatus = "В процессе",
                        DealName = SaleNameTextBox.Text,
                        Price = Convert.ToDecimal(BudgetTextBox.Text)
                    };
                    db.Deals.Add(newDeal);
                    db.SaveChanges();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}