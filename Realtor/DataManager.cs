using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using Dynamitey.DynamicObjects;
using Entities;
using Entities.Models;
using Realtor.Repository;

namespace Realtor
{
    public class DataManager
    {
        private RealtyAgencyDBEntities db = new RealtyAgencyDBEntities();
        
        // метод для входа
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
        // метод для получения количества сделок за сегодня
        public int CountDealInThisDay(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            int dealCountToday =
                db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= today && d.DealDate < tomorrow);
            return dealCountToday > 0 ? dealCountToday : 0;
        }
        // метод для получения количества клиентов за сегодня
        public int CountClientsInThisDay(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            int clientsCountToday =
                db.Clients.Count(d => d.AgentID == agentId && d.RegistrationDate >= today && d.RegistrationDate < tomorrow);
            return clientsCountToday > 0 ? clientsCountToday : 0;
        }
        // метод для получения количества сделок за вчерашний день
        public int CountDealInLastDay(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            int dealCountYesterday = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= yesterday && d.DealDate < today);
            return dealCountYesterday > 0 ? dealCountYesterday : 0;
        }
        // метод для получения количества клиентов за вчерашний день
        public int CountClientsInLastDay(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            
            int countClientsYestraday =
                db.Clients.Count(d => d.AgentID == agentId && d.RegistrationDate >= yesterday && d.RegistrationDate < today);
            return countClientsYestraday > 0 ? countClientsYestraday : 0;

        }
        // метод для получения количества сделок за эту неделю
        public int CountDealInThisWeek(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            int dealCountThisWeek = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= startOfWeek && d.DealDate < endOfWeek);
            return dealCountThisWeek > 0 ? dealCountThisWeek : 0;
        }
        // метод для получения количества клиентов за эту неделю
        public int CountClientsInThisWeek(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            int countClientsInThisWeek = db.Clients.Count(d =>
                d.AgentID == agentId && d.RegistrationDate >= startOfWeek && d.RegistrationDate < endOfWeek);
            return countClientsInThisWeek > 0 ? countClientsInThisWeek : 0;
        }
        // метод для получения количества сделок за прошлую неделю
        public int CountDealInLastWeek(Guid agentId)
        {
           
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek - 7);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            int dealCountLastWeek = db.Deals.Count(d => d.AgentID == agentId && d.DealDate >= startOfWeek && d.DealDate < endOfWeek);
            return dealCountLastWeek > 0 ? dealCountLastWeek : 0;
        }
        // метод для получения количества клиентов за прошлую неделю
        public int CountClientsInLastWeek(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek - 7);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            int countClientsInLastWeek = db.Clients.Count(d =>
                d.AgentID == agentId && d.RegistrationDate >= startOfWeek && d.RegistrationDate < endOfWeek);
            return countClientsInLastWeek > 0 ? countClientsInLastWeek : 0;
        }
        // метод для получения количества сделок за этот месяц
        public int CountDealInThisMonth(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int dealCountThisMonth = db.Deals.Count(
                d => d.AgentID == agentId && d.DealDate >= startOfMonth && d.DealDate < endOfMonth);
            return dealCountThisMonth > 0 ? dealCountThisMonth : 0;
        }
        // метод для получения количества клиентов за этот месяц
        public int CountClientsInThisMonth(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int countClientsInThisMonth = db.Clients.Count(d =>
                d.AgentID == agentId && d.RegistrationDate >= startOfMonth && d.RegistrationDate < endOfMonth);
            return countClientsInThisMonth > 0 ? countClientsInThisMonth : 0;
        }
        // метод для получения количества сделок за прошлый месяц
        public int CountDealInLastMonth(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month - 1, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int dealCountLastMonth = db.Deals.Count(d =>
                d.AgentID == agentId && d.DealDate >= startOfMonth && d.DealDate < endOfMonth);
            return dealCountLastMonth > 0 ? dealCountLastMonth : 0;
        }
        // метод для получения количества клиентов за прошлый месяц
        public int CountClientsInLastMonth(Guid agentId)
        {
            DateTime today = DateTime.Today;
            DateTime startOfMonth = new DateTime(today.Year, today.Month - 1, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            int countClientsInLastMonth = db.Clients.Count(d =>
                d.AgentID == agentId && d.RegistrationDate >= startOfMonth && d.RegistrationDate < endOfMonth);
            return countClientsInLastMonth > 0 ? countClientsInLastMonth : 0;
        }

        // метод для получения всех сделок для агента
        public ObservableCollection<SalesModel> GetAllSalesListForAgent(Guid agentId)
        {
            var agentSales = db.Deals
                .Where(d => d.AgentID == agentId)
                .OrderBy(d => d.DealDate)
                .Select(d => new SalesModel
                {
                    SaleId = d.DealID,
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
        // метод для перевода статуса сделки "В процессе"
        public void SaleStatusTransferInProcess(Guid saleId)
        {
            var sale = db.Deals.SingleOrDefault(d => d.DealID == saleId);
            sale.DealStatus = "В процессе";
            db.SaveChanges();
        }
        // метод для перевода статуса сделки "Завершено"
        public void SaleStatusTransferFinished(Guid saleId)
        {
            var sale = db.Deals.SingleOrDefault(d => d.DealID == saleId);
            sale.DealStatus = "Завершено";
            db.SaveChanges();
        }
        // метод для удаления сделки
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
        // метод для получения сделок "В процессе"
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
        // метод для получения сделок "Завершено"
        public ObservableCollection<SalesModel> GetFinishedSales(Guid agentId)
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
        // метод для поиска объектов по имени
        public IEnumerable<Entities.Properties> NameSearchProperty(string name)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower())).ToList();
            return objects;
        }
        // метод для поиска объектов по площади
        public IEnumerable<Entities.Properties> AreaSearchProperties(decimal area)
        {
            var objects = db.Properties.Where(p => p.Area >= area).ToList();
            return objects;
        }
        // метод для поиска объектов по цене
        public IEnumerable<Entities.Properties> PriceSearchProperties(decimal price)
        {
            var objects = db.Properties.Where(p => p.Price >= price).ToList();
            return objects;
        }
        // метод для поиска объектов по имени и площади
        public IEnumerable<Entities.Properties> NameAndAreaSearchProperties(string name, decimal area)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower()) && p.Area >= area ).ToList();
            return objects;
        }
        // метод для поиска объектов по имени и цене
        public IEnumerable<Entities.Properties> NameAndPriceSearchProperties(string name, decimal price)
        {
            var objects = db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower()) && p.Price >= price).ToList();
            return objects;
        }
        // метод для поиска объектов по площади и цене
        public IEnumerable<Entities.Properties> AreaAndPriceSearchProperties(decimal area, decimal price)
        {
            var objects = db.Properties.Where(p => p.Area >=area && p.Price >= price).ToList();
            return objects;
        }
        // метод для поиска объектов по всем параметрам
        public IEnumerable<Entities.Properties> NameAreaAndPriceSearchProperties(string name, decimal area, decimal price)
        {
            var objects = 
                db.Properties.Where(p => p.Description.ToLower().Contains(name.ToLower()) && p.Area >=area && p.Price >= price).ToList();
            return objects;
        }
        // метод для получения всех объектов
        public IEnumerable<Entities.Properties> AllProperties()
        {
            return db.Properties.ToList();;
        }
        // метод для получения всех клиентов
        public ObservableCollection<Clients> GetAllClient()
        {
            return new ObservableCollection<Clients>(db.Clients.ToList());
        }
        // метод для поиска клиента
        public List<Clients> SearchClients(string FIO)
        {
            var searchClients = db.Clients.Where(c => c.FIO.ToLower().Contains(FIO.ToLower())).ToList();
            return searchClients;
        }
    }
}