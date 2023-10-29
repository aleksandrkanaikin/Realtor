using System.Windows;
using System.Windows.Media;

namespace Realtor
{
    public partial class LoginWindow : Window
    {
        private DataManager _manager = new DataManager();
        private Validator _validator = new Validator();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogInBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_validator.PhoneValid(LoginTxb.Text) == null)
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
            else
            {
                MessageBox.Show(_validator.PhoneValid(LoginTxb.Text));
            }
        }

        #region Texboxes

        private void LoginTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTxb.Text != "Введите номер телефона") return;
            LoginTxb.Text = "";
            LoginTxb.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void PasswordTxb_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTxb.Text != "Введите пароль") return;
            PasswordTxb.Text = "";
            PasswordTxb.Foreground = new SolidColorBrush(Colors.Black);
        }
        
        private void LoginTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTxb.Text != "") return;
            LoginTxb.Text = "Введите номер телефона";
            LoginTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void PasswordTxb_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTxb.Text != "") return;
            PasswordTxb.Text = "Введите пароль";
            PasswordTxb.Foreground = new SolidColorBrush(Colors.Gray);
        }
        #endregion
    }
}