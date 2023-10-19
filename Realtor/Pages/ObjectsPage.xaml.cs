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
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
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
                ListBox.ItemsSource = _manager.AreaSearchProperies(Convert.ToDecimal(AreaSearchBox.Text));
            }

            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text == "Минимальная площадь" &&
                NameSearchBox.Text == "Поиск")
            {
                ListBox.ItemsSource = _manager.PriceSearchProperies(Convert.ToDecimal(PriseSearchBox.Text));
            } 
            if (PriseSearchBox.Text == "Цена" && AreaSearchBox.Text != "Минимальная площадь" &&
                NameSearchBox.Text != "Поиск")
            {
                ListBox.ItemsSource = _manager.NameAndAreaSearchProperies(NameSearchBox.Text,Convert.ToDecimal(AreaSearchBox.Text));
            }
            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text != "Минимальная площадь" &&
                NameSearchBox.Text == "Поиск")
            {
                ListBox.ItemsSource = _manager.AreaAndPriceSearchProperies(Convert.ToDecimal(AreaSearchBox.Text), Convert.ToDecimal(PriseSearchBox.Text));
            }

            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text == "Минимальная площадь" &&
                NameSearchBox.Text != "Поиск")
            {
                ListBox.ItemsSource =
                    _manager.NameAndPriceSearchProperies(NameSearchBox.Text, Convert.ToDecimal(PriseSearchBox.Text));
            } 
            if (PriseSearchBox.Text != "Цена" && AreaSearchBox.Text != "Минимальная площадь" &&
                NameSearchBox.Text != "Поиск")
            {
                ListBox.ItemsSource =
                    _manager.NameAreaAndPriceSearchProperies(NameSearchBox.Text, Convert.ToDecimal(AreaSearchBox.Text), Convert.ToDecimal(PriseSearchBox.Text));
            }
            else
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
            NameSearchBox.Text = "";
            NameSearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void PriseSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            PriseSearchBox.Text = "";
            PriseSearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void AreaSearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            AreaSearchBox.Text = "";
            AreaSearchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        #endregion
       
    }
}