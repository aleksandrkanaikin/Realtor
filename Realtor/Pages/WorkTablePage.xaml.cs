using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Navigation;
using Realtor.Repository;

namespace Realtor.Pages
{
    public partial class WorkTablePage : Page
    {
        private DataManager _manager = new DataManager();
        public WorkTablePage()
        {
            InitializeComponent();
            ButtonAutomationPeer bap = new ButtonAutomationPeer(TodayBtn);
            IInvokeProvider iip = bap.GetPattern(PatternInterface.Invoke)
                as IInvokeProvider;
            iip.Invoke();
        }
        
        private SolidColorBrush choiceColor = new SolidColorBrush(Color.FromRgb(255,91,25));
        private SolidColorBrush dontChoiceColorBrush = new SolidColorBrush(Colors.Gray);
        private void MonthBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MonthBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            WeekBtn.BorderThickness = TodayBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            MonthBtn.Foreground = MonthBtn.BorderBrush = choiceColor;
            WeekBtn.Foreground =
                WeekBtn.BorderBrush = TodayBtn.Foreground = TodayBtn.BorderBrush = dontChoiceColorBrush;
            var countDealsInThisMonth = _manager.CountDealInThisMonth(AgentIdStorage.AgentId);
            var countDealsInLastMonth = _manager.CountDealInLastMonth(AgentIdStorage.AgentId);
            var countClientsInThisMonth = _manager.CountClientsInThisMonth(AgentIdStorage.AgentId);
            var countClientsInLastMonth = _manager.CountClientsInLastMonth(AgentIdStorage.AgentId);
            CountSaleInThisSelect.Text = countDealsInThisMonth.ToString();
            CountSaleInLastSelect.Text = countDealsInLastMonth.ToString();
            CountClientsInThisSelect.Text = countClientsInThisMonth.ToString();
            CountClientInLastSelect.Text = countClientsInLastMonth.ToString();
            if (countDealsInThisMonth > countDealsInLastMonth)
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countDealsInLastMonth > countDealsInThisMonth)
            {
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (countClientsInThisMonth > countDealsInLastMonth)
            {
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countClientsInLastMonth > countClientsInThisMonth)
            {
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Red);   
            }
            InThisSelectText.Text = InClientThisSelectText.Text = "В этом месяце";
            InLastSelectText.Text = ClientInLastSelectText.Text = "В прошлом месяце";

        }

        private void WeekBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WeekBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            MonthBtn.BorderThickness = TodayBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            WeekBtn.Foreground = WeekBtn.BorderBrush = choiceColor;
            MonthBtn.Foreground =
                MonthBtn.BorderBrush = TodayBtn.Foreground = TodayBtn.BorderBrush = dontChoiceColorBrush;
            var countDealsInThisWeek = _manager.CountDealInThisWeek(AgentIdStorage.AgentId);
            var countDealsInLastWeek = _manager.CountDealInLastWeek(AgentIdStorage.AgentId);
            var countClientsInThisWeek = _manager.CountClientsInThisWeek(AgentIdStorage.AgentId);
            var countClientsInLastWeek = _manager.CountClientsInLastWeek(AgentIdStorage.AgentId);
            CountSaleInThisSelect.Text = countDealsInThisWeek.ToString();
            CountSaleInLastSelect.Text = countDealsInLastWeek.ToString();
            CountClientsInThisSelect.Text = countClientsInThisWeek.ToString();
            CountClientInLastSelect.Text = countClientsInLastWeek.ToString();
            if (countDealsInThisWeek > countDealsInLastWeek)
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countDealsInLastWeek > countDealsInThisWeek)
            {
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countClientsInThisWeek > countDealsInLastWeek)
            {
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countClientsInLastWeek > countClientsInThisWeek)
            {
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Red);   
            }
            InThisSelectText.Text = InClientThisSelectText.Text = "На этой неделе";
            InLastSelectText.Text= ClientInLastSelectText.Text = "На прошлой неделе";
        }

        private void TodayBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TodayBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            MonthBtn.BorderThickness = WeekBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            TodayBtn.Foreground = TodayBtn.BorderBrush = choiceColor;
            MonthBtn.Foreground =
                MonthBtn.BorderBrush = WeekBtn.Foreground = WeekBtn.BorderBrush = dontChoiceColorBrush;
            var countDealsInThisDay = _manager.CountDealInThisDay(AgentIdStorage.AgentId);
            var countDealsInLastDay = _manager.CountDealInLastDay(AgentIdStorage.AgentId);
            var countClientsInThisDay = _manager.CountClientsInThisDay(AgentIdStorage.AgentId);
            var countClientsInLastDay = _manager.CountClientsInLastDay(AgentIdStorage.AgentId);
            CountSaleInThisSelect.Text = countDealsInThisDay.ToString();
            CountSaleInLastSelect.Text = countDealsInLastDay.ToString();
            CountClientsInThisSelect.Text = countClientsInThisDay.ToString();
            CountClientInLastSelect.Text = countClientsInLastDay.ToString();
            if (countDealsInThisDay > countDealsInLastDay)
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countDealsInLastDay > countDealsInThisDay)
            {
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countClientsInThisDay > countDealsInLastDay)
            {
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countClientsInLastDay > countClientsInThisDay)
            {
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountClientsInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountClientInLastSelect.Foreground = new SolidColorBrush(Colors.Red);   
            }
            InThisSelectText.Text = InClientThisSelectText.Text = "Сегодня";
            InLastSelectText.Text= ClientInLastSelectText.Text = "Вчера";
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            var windLogIn = new LoginWindow();
            var windThis = Window.GetWindow(this);
            if (MessageBox.Show("Вы действительно хотите выйти?", "Пожтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                windLogIn.Show();
                windThis.Close();
            }
        }
    }
}