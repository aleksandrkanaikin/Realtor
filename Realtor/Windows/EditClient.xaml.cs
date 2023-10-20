using System.Windows;
using Entities;

namespace Realtor.Windows
{
    public partial class EditClient : Window
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private Clients clientForUpdate;
        private Validator validator = new Validator();  
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
            if (validator.EmailValid(EmailTextBox.Text) == null && validator.PhoneValid(PhoneTextBox.Text) == null)
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
            else
            {
                MessageBox.Show(validator.EmailValid(EmailTextBox.Text) + "\n или \n" + 
                                validator.PhoneValid(PhoneTextBox.Text));
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}