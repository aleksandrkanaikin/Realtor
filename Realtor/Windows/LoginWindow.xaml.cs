using System.Windows;
using System.Windows.Media;

namespace Realtor
{
    public partial class LoginWindow : Window
    {
        private DataManager _manager = new DataManager();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            LoginTxb.Text = "";
            LoginTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void PasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            PasswordTxb.Text = "";
            PasswordTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LogInBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_manager.LoginManager(LoginTxb.Text, PasswordTxb.Text) == null)
            {
                var wind = new MainWindow();
                Hide();
                wind.Show();
                Close();
            }
            else
            {
                MessageBox.Show(_manager.LoginManager(LoginTxb.Text, PasswordTxb.Text));
            }
        }
    }
}