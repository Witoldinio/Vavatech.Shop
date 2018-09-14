using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.DbServices
{
    public class DbItemService : IItemsService
    {
        private readonly ShopContext _context;

        public DbItemService(ShopContext context)
        {
            _context = context;
        }

        public void Add(Item entity)
        {
            _context.Items.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(Item entity)
        {
            _context.Items.Update(entity);
            _context.SaveChanges();
        }

        public Item Get(int Id)
        {
            return _context.Items.Find(Id);
        }

        public List<Item> Get()
        {
            return _context.Items.ToList();
        }

        public void Remove(Item entity)
        {
            _context.Items.Remove(entity);
            _context.SaveChanges();
        }

        public List<Item> Search(string query)
        {
            return _context.Items.Where(i => i.EAN.Contains(query)).ToList();
        }
    }
}
