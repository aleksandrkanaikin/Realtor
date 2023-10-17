using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Entities;
using Entities.Models;

namespace Realtor.Pages
{
    public partial class SalesPage : Page
    {
        private static RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private ObservableCollection<Deals> DealsList;
        private SalesModel salesModel;
        List<SalesModel> salesData = db.Deals
            .Include(d => d.Properties)
            .Include(d => d.Clients)
            .Include(d => d.DealStatus) 
            .Select(d => new SalesModel
            {
                ObjectName = d.Properties.Description,
                ClientFio = d.Clients.FIO,
                Date = d.DealDate,
                Price = d.Price,
                SaleStatus = d.DealStatus,
                SaleName = d.DealName
            })
            .ToList();

        public SalesPage()
        {
            InitializeComponent();
            // salesData теперь содержит список SalesModel, представляющий данные из базы данных
            List<SalesModel> salesList = salesData;
            DealsList = new ObservableCollection<Deals>(db.Deals.ToList());
            SalesListBox.ItemsSource = salesList;
        }

        private void StatusBox_OnSelected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}