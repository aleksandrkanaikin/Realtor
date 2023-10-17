using System;
using System.Collections;

namespace Entities.Models
{
    public class SalesModel
    {
        public string ObjectName { get; set; }
        public string ClientFio { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string SaleStatus { get; set; }
        public string SaleName { get; set; }
        
    }
}