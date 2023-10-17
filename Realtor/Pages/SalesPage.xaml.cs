using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Entities;
using Entities.Models;
using Realtor.Repository;

namespace Realtor.Pages
{
    public partial class SalesPage : Page
    {
        private static RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private DataManager _manager = new DataManager();

        public SalesPage()
        {
            InitializeComponent();
            SalesListBox.ItemsSource = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);
        }

        private void SalesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Border.Visibility = Visibility.Visible;
        }

        private void StatusBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}