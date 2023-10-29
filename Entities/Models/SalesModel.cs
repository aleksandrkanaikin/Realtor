using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Entities.Annotations;

namespace Entities.Models
{
    public class SalesModel: INotifyPropertyChanged
    {
        private string objectName;
        private string clientFio;
        private Nullable<DateTime> date;
        private Nullable<decimal> price;
        private string saleStatus;
        private string saleName;
        private string objectDescription;
        
        public Guid SaleId { get; set; }
        public string ObjectName
        {
            get { return objectName;}
            set
            {
                objectName = value;
                OnPropertyChanged();
            } 
        }
        public string ClientFio {
            get{ return clientFio; }
            set
            {
                clientFio = value;
            } 
        }
        public Nullable<DateTime> Date
        {
            get { return date;}
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }
        
        public Nullable<decimal> Price
        {
            get { return price;}
            set
            {
                price = value;
                OnPropertyChanged();
            } 
        }
        public string SaleStatus
        {
            get { return saleStatus;}
            set
            {
                saleStatus = value;
                OnPropertyChanged();
            }
        }
        public string SaleName
        {
            get { return saleName;}
            set
            {
                saleName = value;
                OnPropertyChanged();
            }
        }

        public string ObjectDescription
        {
            get { return objectDescription; }
            set
            {
                objectDescription = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}