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
        private SalesModel selectSale = new SalesModel();

        public SalesPage()
        {
            InitializeComponent();
            StatusFilterBox.SelectedItem = AllItem;
            SalesListBox.ItemsSource = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);;
        }

        private void SalesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SalesListBox.SelectedItem is SalesModel sale)
            {
                SaleDescription.Visibility = Visibility.Visible;
                selectSale = sale;
                SaleName.Text = sale.SaleName;
                SaleDate.Text = sale.Date.ToString();
                if (sale.SaleStatus == "В процессе")
                    SelectedSaleStatus.SelectedItem = InProcessSelectedSale;
                if (sale.SaleStatus == "Завершено")
                    SelectedSaleStatus.SelectedItem = FinishedSelectedSale;
                SalePrice.Text = sale.Price.ToString();
                ClientFio.Text = sale.ClientFio;
                ObjectDescription.Text = sale.ObjectDescription;
            }
            else
            {
                SaleDescription.Visibility = Visibility.Hidden;
            }
        }
        
        private void StatusFilterBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem) StatusFilterBox.SelectedItem;
            // string selectedValue = selectedItem.Content.ToString();
            if (selectedItem ==  AllItem)
            {
                SalesListBox.ItemsSource = _manager.GetAllSalesListForAgent(AgentIdStorage.AgentId);
            }
            if(selectedItem == InProcessItem)
            {
                SalesListBox.ItemsSource = _manager.GetInProcessSales(AgentIdStorage.AgentId);
            }
            if (selectedItem == FinishedItem)
            {
                SalesListBox.ItemsSource = _manager.GetFinishedSales(AgentIdStorage.AgentId);
            }
        }
        private void SelectedSaleStatus_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedSaleStatus.SelectedItem == InProcessSelectedSale)
            {
                selectSale.SaleStatus = "В процессе";
                _manager.SaleStatusTransferInProcess(selectSale.SaleId);
            }
            else if (SelectedSaleStatus.SelectedItem == FinishedSelectedSale)
            {
                selectSale.SaleStatus = "Завершено";
                _manager.SaleStatusTransferFinished(selectSale.SaleId);
            }
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