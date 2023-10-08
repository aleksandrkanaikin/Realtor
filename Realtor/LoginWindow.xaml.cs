using System.Windows;

namespace Realtor
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void PasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void LogInBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var wind = new MainWindow();
            Hide();
            wind.Show();
            Close();
        }
    }
}