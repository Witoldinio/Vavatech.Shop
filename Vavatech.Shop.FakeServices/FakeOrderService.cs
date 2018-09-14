using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class FakeOrderService : IOrdersService
    {
        private List<Order> orders;

        public FakeOrderService()
        {
            orders = new List<Order>();
        }

        public void Add(Order entity)
        {
            orders.Add(entity);
        }

        public void Edit(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Order> Get()
        {
            return orders;
        }

        public void Remove(Order entity)
        {
            orders.Remove(entity);
        }

        public List<Order> Search(string query)
        {
            return orders.Where(o => o.OrderNumber.Contains(query)).ToList();
        }
    }
}
