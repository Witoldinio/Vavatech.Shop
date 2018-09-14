using System;
using System.Linq;
using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Bogus;

namespace Vavatech.Shop.FakeServices
{
    public class FakeCustomerService : ICustomersService
    {
        private List<Customer> customers;

        public FakeCustomerService()
        {
            Faker<Address> fakeAddress = new Faker<Address>()
                .StrictMode(true)   // alert if some member ommited in rules
                .Ignore(a => a.Id)
                .RuleFor(a => a.Street, r => r.Address.StreetName())
                .RuleFor(a => a.Building, r => r.Address.BuildingNumber())
                .RuleFor(a => a.Local, r => r.Address.BuildingNumber())
                .RuleFor(a => a.Zip, r => r.Address.ZipCode())
                .RuleFor(a => a.City, r => r.Address.City())
                .RuleFor(a => a.District, r => r.Address.State())
                .RuleFor(a => a.Country, r => r.Address.Country());

            Faker<Customer> faker = new Faker<Customer>()
                .StrictMode(true)   // alert if some member ommited in rules
                .Ignore(c => c.Id)
                .RuleFor(c => c.FirstName, r => r.Person.FirstName)
                .RuleFor(c => c.LastName, r => r.Person.LastName)
                .RuleFor(c => c.VatNumber, r => r.Finance.Iban())
                .RuleFor(c => c.Address, r => fakeAddress.Generate())
                .RuleFor(c => c.Name, r => r.Company.CompanyName())
                .FinishWith((f, customer) => Console.WriteLine($"created customer {customer}"));

            customers = faker.Generate(100);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }

        public void Edit(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int Id)
        {
            return customers.Where(c => c.Id == Id).SingleOrDefault();
        }
        
        public List<Customer> Search(string query)
        {
            return customers.Where(c => c.VatNumber.Contains(query)).ToList();
        }

        public List<Customer> SearchByCountry(string query)
        {
            return customers.Where(c => c.Address.Country.Contains(query)).ToList();
        }
    }
}
