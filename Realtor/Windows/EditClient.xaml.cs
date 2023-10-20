﻿using System.Windows;
using Entities;

namespace Realtor.Windows
{
    public partial class EditClient : Window
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private Clients clientForUpdate;
        public EditClient(Clients clientForEdit)
        {
            InitializeComponent();
            clientForUpdate = clientForEdit;
            FIOTextBox.Text = clientForEdit.FIO;
            PhoneTextBox.Text = clientForEdit.Phone;
            EmailTextBox.Text = clientForEdit.Email;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var client = db.Clients.Find(clientForUpdate.ClientID);
            if (client != null)
            {
                client.FIO = FIOTextBox.Text;
                client.Phone = PhoneTextBox.Text;
                client.Email = EmailTextBox.Text;
                db.SaveChanges();
            }
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}