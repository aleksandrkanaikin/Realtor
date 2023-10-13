using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Entities;

namespace Realtor.Pages
{
    public partial class ObjectsPage : Page
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        public ObjectsPage()
        {
            InitializeComponent();
            ListBox.ItemsSource = db.Properties.ToList();
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}