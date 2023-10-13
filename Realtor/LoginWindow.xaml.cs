using System.Windows;
using System.Windows.Media;

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
            var wind = new MainWindow();
            Hide();
            wind.Show();
            Close();
        }
    }
}