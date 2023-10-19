using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Dynamitey.DynamicObjects;
using Entities;
using Entities.Models;
using Realtor.Repository;

namespace Realtor
{
    public class DataManager
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();

        public string LoginManager(string number, string password)
        {
            var agent =  db.Agents.FirstOrDefault(a => a.Phone == number && a.Password == password);
            if (agent != null)
            {
                AgentIdStorage.AgentId = agent.AgentID;
                return null;
            }
            else
            {
                return "Пользователь не найден";
            }
        }

        public int CountDealInThisDay(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            int dealCountToday = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= today && d.DealDate < tomorrow);           
            if (dealCountToday > 0)
            {
                return dealCountToday;
            }
            else
            {
                return 0;
            }
        }
        public int CountDealInLastDay(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            int dealCountYesterday = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= yesterday && d.DealDate < today);
            if (dealCountYesterday > 0)
            {
                return dealCountYesterday;
            }
            else
            {
                return 0;
            }
        } 
        public int CountDealInThisWeek(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            int dealCountThisWeek = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= startOfWeek && d.DealDate < endOfWeek);
            if (dealCountThisWeek > 0)
            {
                return dealCountThisWeek;
            }
            else
            {
                return 0;
            }
        }
        public int CountDealInLastWeek(Guid agentId)
        {
           
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek - 7);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            int dealCountLastWeek = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= startOfWeek && d.DealDate < endOfWeek);
            if (dealCountLastWeek > 0)
            {
                return dealCountLastWeek;
            }
            else
            {
                return 0;
            }
        }
        public int CountDealInThisMounth(Guid agentId)
        {
           
            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int dealCountThisMonth = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= startOfMonth && d.DealDate < endOfMonth);
            if (dealCountThisMonth > 0)
            {
                return dealCountThisMonth;
            }
            else
            {
                return 0;
            }
        }
        public int CountDealInLastMounth(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month - 1, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int dealCountLastMonth = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= startOfMonth && d.DealDate < endOfMonth);          
            if (dealCountLastMonth > 0)
            {
                return dealCountLastMonth;
            }
            else
            {
                return 0;
            }
        }

        public ObservableCollection<SalesModel> GetAllSalesListForAgent(Guid agentId)
        {
            var agentSales = db.Deals
                .Where(d => d.AgentID == agentId)
                .OrderBy(d => d.DealDate)
                .Select(d => new SalesModel
                {
                    ObjectName = d.Properties.Type,
                    ClientFio = d.Clients.FIO,
                    Date = d.DealDate,
                    Price = d.Price,
                    SaleStatus = d.DealStatus,
                    SaleName = d.DealName,
                    ObjectDescription = d.Properties.Description
                })
                .ToList();
            return new ObservableCollection<SalesModel>(agentSales);
        }

        public string DeleteSale(string saleName)
        {
            var saleToDelete = db.Deals.SingleOrDefault(deal => deal.DealName == saleName);
            if (saleName != null)
            {
                db.Deals.Remove(saleToDelete);
                db.SaveChanges();
                return "Сделка успешно удалена.";
            }
            else
            {
                return "Сделка не найдена.";
            }
        }

        public ObservableCollection<SalesModel> GetInProcessSales(Guid agentId)
        {
            var agentSales = db.Deals
                .Where(d => d.AgentID == agentId && d.DealStatus == "В процессе")
                .OrderBy(d => d.DealDate)
                .Select(d => new SalesModel
                {
                    ObjectName = d.Properties.Type,
                    ClientFio = d.Clients.FIO,
                    Date = d.DealDate,
                    Price = d.Price,
                    SaleStatus = d.DealStatus,
                    SaleName = d.DealName,
                    ObjectDescription = d.Properties.Description
                })
                .ToList();
            return new ObservableCollection<SalesModel>(agentSales);
        }
        public ObservableCollection<SalesModel> GetFinisedSales(Guid agentId)
        {
            var agentSales = db.Deals
                .Where(d => d.AgentID == agentId && d.DealStatus == "Завершено")
                .OrderBy(d => d.DealDate)
                .Select(d => new SalesModel
                {
                    ObjectName = d.Properties.Type,
                    ClientFio = d.Clients.FIO,
                    Date = d.DealDate,
                    Price = d.Price,
                    SaleStatus = d.DealStatus,
                    SaleName = d.DealName,
                    ObjectDescription = d.Properties.Description
                })
                .ToList();
            return new ObservableCollection<SalesModel>(agentSales);
        }

        public List<Entities.Properties> NameSearchProperty(string name)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower())).ToList();
            return objects;
        }

        public List<Entities.Properties> AreaSearchProperies(decimal area)
        {
            var objects = db.Properties.Where(p => p.Area >= area).ToList();
            return objects;
        }
        public List<Entities.Properties> PriceSearchProperies(decimal price)
        {
            var objects = db.Properties.Where(p => p.Price >= price).ToList();
            return objects;
        }
        public List<Entities.Properties> NameAndAreaSearchProperies(string name, decimal area)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower()) && p.Area >= area ).ToList();
            return objects;
        }
        public List<Entities.Properties> NameAndPriceSearchProperies(string name, decimal price)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower()) && p.Price >= price).ToList();
            return objects;
        }
        public List<Entities.Properties> AreaAndPriceSearchProperies(decimal area, decimal price)
        {
            var objects = db.Properties.Where(p => p.Area >=area && p.Price >= price).ToList();
            return objects;
        }
        public List<Entities.Properties> NameAreaAndPriceSearchProperies(string name ,decimal area, decimal price)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower()) && p.Area >=area && p.Price >= price).ToList();
            return objects;
        }

        public List<Entities.Properties> AllProperties()
        {
            var objects = db.Properties.ToList();
            return objects;
        }
    }
}