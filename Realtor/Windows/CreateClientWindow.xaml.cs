using System;
using System.Windows;
using Entities;
using Realtor.Pages;

namespace Realtor
{
    public partial class CreateClientWindow : Window
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private Clients newClient;
        public CreateClientWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            string fio = FIOTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;

            newClient = new Clients()
            {
                ClientID = Guid.NewGuid(),
                Deals = null,
                Email = email,
                FIO = fio,
                Phone = phone,
                RegistrationDate = DateTime.Today
            };

            db.Clients.Add(newClient);
            try
            {
                db.SaveChanges();
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}