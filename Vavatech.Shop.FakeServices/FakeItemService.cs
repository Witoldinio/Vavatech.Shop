using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class FakeItemService : IItemsService
    {
        private List<Item> items;

        public FakeItemService()
        {
            items = new List<Item>
            {
                new Product(0, "p0", 5, "red", "1234"),
                new Service(id: 1, name: "s0", price: 3, ean: "2345"),
                new Product(2, "p1", 6, "yellow", "3456")
            };
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Edit(Item item)
        {
            throw new NotImplementedException();
        }

        public Item Get(int Id)
        {
            return items.Where(i => i.Id == Id).SingleOrDefault();
        }

        public List<Item> Get()
        {
            return items;
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }

        public List<Item> Search(string query)
        {
            return items.Where(i => i.EAN.Contains(query)).ToList();
        }
    }
}
