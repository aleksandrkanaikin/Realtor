using System.Windows;
using System.Windows.Controls;
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
        }
        
        private SolidColorBrush choiceColor = new SolidColorBrush(Color.FromRgb(255,91,25));
        private SolidColorBrush dontChoiceColorBrush = new SolidColorBrush(Colors.Gray);
        private void MounthBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MounthBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            WeekBtn.BorderThickness = TodayBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            MounthBtn.Foreground = MounthBtn.BorderBrush = choiceColor;
            WeekBtn.Foreground =
                WeekBtn.BorderBrush = TodayBtn.Foreground = TodayBtn.BorderBrush = dontChoiceColorBrush;
            var countDealsInThisMounth = _manager.CountDealInThisMounth(AgentIdStorage.AgentId);
            var countDealsInLastMounth = _manager.CountDealInLastMounth(AgentIdStorage.AgentId);
            CountSaleInThisSelect.Text = countDealsInThisMounth.ToString();
            CountSaleInLastSelect.Text = countDealsInLastMounth.ToString();
            if (countDealsInThisMounth > countDealsInLastMounth)
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (countDealsInLastMounth > countDealsInThisMounth)
            {
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                CountSaleInThisSelect.Foreground = new SolidColorBrush(Colors.Green);
                CountSaleInLastSelect.Foreground = new SolidColorBrush(Colors.Red);
            }
            InThisSelectText.Text = "В этом месяце";
            InLastSelectText.Text = "В прошлом месяце";

        }

        private void WeekBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WeekBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            MounthBtn.BorderThickness = TodayBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            WeekBtn.Foreground = WeekBtn.BorderBrush = choiceColor;
            MounthBtn.Foreground =
                MounthBtn.BorderBrush = TodayBtn.Foreground = TodayBtn.BorderBrush = dontChoiceColorBrush;
            var countDealsInThisWeek = _manager.CountDealInThisWeek(AgentIdStorage.AgentId);
            var countDealsInLastWeek = _manager.CountDealInLastWeek(AgentIdStorage.AgentId);
            CountSaleInThisSelect.Text = countDealsInThisWeek.ToString();
            CountSaleInLastSelect.Text = countDealsInLastWeek.ToString();
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
            InThisSelectText.Text = "На этой неделе";
            InLastSelectText.Text = "На прошлой неделе";
        }

        private void TodayBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TodayBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            MounthBtn.BorderThickness = WeekBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            TodayBtn.Foreground = TodayBtn.BorderBrush = choiceColor;
            MounthBtn.Foreground =
                MounthBtn.BorderBrush = WeekBtn.Foreground = WeekBtn.BorderBrush = dontChoiceColorBrush;
            var countDealsInThisDay = _manager.CountDealInThisDay(AgentIdStorage.AgentId);
            var countDealsInLastDay = _manager.CountDealInLastDay(AgentIdStorage.AgentId);
            CountSaleInThisSelect.Text = countDealsInThisDay.ToString();
            CountSaleInLastSelect.Text = countDealsInLastDay.ToString();
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
            InThisSelectText.Text = "Сегодня";
            InLastSelectText.Text = "Вчера";
        }
    }
}