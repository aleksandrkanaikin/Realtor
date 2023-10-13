using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Realtor.Pages
{
    public partial class WorkTablePage : Page
    {
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

        }

        private void WeekBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WeekBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            MounthBtn.BorderThickness = TodayBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            WeekBtn.Foreground = WeekBtn.BorderBrush = choiceColor;
            MounthBtn.Foreground =
                MounthBtn.BorderBrush = TodayBtn.Foreground = TodayBtn.BorderBrush = dontChoiceColorBrush;
        }

        private void TodayBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TodayBtn.BorderThickness = new Thickness(0, 0, 0, 3);
            MounthBtn.BorderThickness = WeekBtn.BorderThickness = new Thickness(0, 0, 0, 1);
            TodayBtn.Foreground = TodayBtn.BorderBrush = choiceColor;
            MounthBtn.Foreground =
                MounthBtn.BorderBrush = WeekBtn.Foreground = WeekBtn.BorderBrush = dontChoiceColorBrush;
        }
    }
}