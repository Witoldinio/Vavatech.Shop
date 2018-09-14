using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.DbServices
{
    public class DbCustomerService : ICustomersService
    {
        private readonly ShopContext _context;

        public DbCustomerService(ShopContext context)
        {
            _context = context;
        }
        
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }

        public Customer Get(int Id)
        {
            return _context.Customers.Find(Id);
        }

        public List<Customer> Get()
        {
            return _context.Customers
                .Include(c => c.Address)
                .ToList();
        }

        public void Remove(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public List<Customer> Search(string query)
        {
            return _context.Customers.Where(c => c.VatNumber.Contains(query)).ToList();
        }

        public List<Customer> SearchByCountry(string query)
        {
            return _context.Customers.Where(c => c.Address.Country.Contains(query)).ToList();
        }
    }
}
