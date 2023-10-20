using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Entities;
using Entities.Models;
using MaterialDesignThemes.Wpf;
using Realtor.Repository;
using Realtor.Windows;

namespace Realtor.Pages
{
    public partial class SalesPage : Page
    {
        private static RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        private DataManager _manager = new DataManager();
        private ObservableCollection<SalesModel> salesList;
        private SalesModel selectSale = new SalesModel();

        public SalesPage()
        {
            InitializeComponent();
            salesList = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);
            SalesListBox.ItemsSource = salesList;
        }

        private void SalesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SalesListBox.SelectedItem is SalesModel sale)
            {
                SaleDescription.Visibility = Visibility.Visible;
                selectSale = sale;
                SaleName.Text = sale.SaleName;
                SaleDate.Text = sale.Date.ToString();
                //SelectedSaleStatus.SelectedValue = sale.saleStatus;
                SalePrice.Text = sale.Price.ToString();
                ClientFio.Text = sale.ClientFio;
                ObjectDescription.Text = sale.ObjectDescription;
            }

        }
        
        //Доработать Фильтрацию по статусу сделки
        private void StatusFilterBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem) StatusFilterBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();
            if (selectedValue == "Все")
            {
                SalesListBox.ItemsSource = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);
            }
            if(selectedValue == "В процессе")
            {
                SalesListBox.ItemsSource = _manager.GetInProcessSales(AgentIdStorage.AgentId);
            }

            if (selectedValue == "Завершено")
            {
                SalesListBox.ItemsSource = _manager.GetFinisedSales(AgentIdStorage.AgentId);
            }
        }
        //Доработать перевод статуса сделки
        private void SelectedSaleStatus_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void DeleteSale_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_manager.DeleteSale(selectSale.SaleName));
            SalesListBox.ItemsSource = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);
        }

        private void CreateNewSaleButton_OnClick(object sender, RoutedEventArgs e)
        {
            var createNewSale = new CreateNewSale();
            createNewSale.ShowDialog();
            SalesListBox.ItemsSource = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);
        }
    }
}