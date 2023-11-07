using System;
using System.Windows;
using Entities;
using Realtor.Pages;
using Realtor.Repository;

namespace Realtor
{
    public partial class CreateClientWindow : Window
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private Clients newClient;
        private Validator validator = new Validator();
        public CreateClientWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            string fio = FIOTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;

            if (FIOTextBox.Text != "" || PhoneTextBox.Text != "" || EmailTextBox.Text != "")
            {
                if (validator.EmailValid(email) == null && validator.PhoneValid(phone) == null)
                {
                    newClient = new Clients()
                    {
                        ClientID = Guid.NewGuid(),
                        AgentID = AgentIdStorage.AgentId,
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
                else
                {
                    MessageBox.Show(validator.EmailValid(email) + "\n или \n" + validator.PhoneValid(phone));
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