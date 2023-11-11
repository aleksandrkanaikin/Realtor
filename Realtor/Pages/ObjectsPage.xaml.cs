using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Dynamitey.DynamicObjects;
using Entities;

namespace Realtor.Pages
{
    public partial class ObjectsPage : Page
    {
        private RealtyAgencyDBEntity db = new RealtyAgencyDBEntity();
        private DataManager _manager = new DataManager();
        public ObjectsPage()
        {
            InitializeComponent();
            ListBox.ItemsSource = _manager.AllProperties();
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NameSearchBox.Text != "Поиск" && AreaSearchBox.Text == "Минимальная площадь" && PriseSearchBox.Text == "Цена")
            {
                ListBox.ItemsSource = _manager.NameSearchProperty(NameSearchBox.Text);
            }
            if (AreaSearchBox.Text != "Минимальная площадь" && NameSearchBox.Text == "Поиск" && PriseSearchBox.Text == "Цена")
            {
                ListBox.ItemsSource = _manager.AreaSearchProperties(Convert.ToDecimal(AreaSearchBox.Text));
            }
            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text == "Минимальная площадь" &&
                NameSearchBox.Text == "Поиск")
            {
                ListBox.ItemsSource = _manager.PriceSearchProperties(Convert.ToDecimal(PriseSearchBox.Text));
            } 
            if (PriseSearchBox.Text == "Цена" && AreaSearchBox.Text != "Минимальная площадь" &&
                NameSearchBox.Text != "Поиск")
            {
                ListBox.ItemsSource = _manager.NameAndAreaSearchProperties(NameSearchBox.Text,Convert.ToDecimal(AreaSearchBox.Text));
            }
            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text != "Минимальная площадь" &&
                NameSearchBox.Text == "Поиск")
            {
                ListBox.ItemsSource = _manager.AreaAndPriceSearchProperties(Convert.ToDecimal(AreaSearchBox.Text), Convert.ToDecimal(PriseSearchBox.Text));
            }
            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text == "Минимальная площадь" &&
                NameSearchBox.Text != "Поиск")
            {
                ListBox.ItemsSource =
                    _manager.NameAndPriceSearchProperties(NameSearchBox.Text, Convert.ToDecimal(PriseSearchBox.Text));
            } 
            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text != "Минимальная площадь" &&
                NameSearchBox.Text != "Поиск")
            {
                ListBox.ItemsSource =
                    _manager.NameAreaAndPriceSearchProperties(NameSearchBox.Text, Convert.ToDecimal(AreaSearchBox.Text), Convert.ToDecimal(PriseSearchBox.Text));
            }
            else if(PriseSearchBox.Text == "Цена" && AreaSearchBox.Text == "Минимальная площадь" &&
                    NameSearchBox.Text == "Поиск")
            {
                ListBox.ItemsSource = _manager.AllProperties();
            }
            NameSearchBox.Text = "Поиск";
            NameSearchBox.Foreground = new SolidColorBrush(Colors.Gray);
            PriseSearchBox.Text = "Цена";
            PriseSearchBox.Foreground = new SolidColorBrush(Colors.Gray);
            AreaSearchBox.Text = "Минимальная площадь";
            AreaSearchBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        #region Texboxes

        private void NameSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if(NameSearchBox.Text != "Поиск") return;
            NameSearchBox.Text = "";
            NameSearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void PriseSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if(PriseSearchBox.Text != "Цена") return;
            PriseSearchBox.Text = "";
            PriseSearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void AreaSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if(AreaSearchBox.Text != "Минимальная площадь") return;
            AreaSearchBox.Text = "";
            AreaSearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }
        
        private void NameSearchBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (NameSearchBox.Text != "") return;
            NameSearchBox.Text = "Поиск";
            NameSearchBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void PriseSearchBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (PriseSearchBox.Text != "") return;
            PriseSearchBox.Text = "Цена";
            PriseSearchBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void AreaSearchBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (AreaSearchBox.Text != "") return;
            AreaSearchBox.Text = "Минимальная площадь";
            AreaSearchBox.Foreground = new SolidColorBrush(Colors.Gray);
        }
        #endregion
    }
}