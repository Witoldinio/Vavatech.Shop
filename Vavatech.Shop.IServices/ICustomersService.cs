using System;
using System.Collections.Generic;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface ICustomersService : IEntitiesService<Customer>, IIsSearchable<Customer>
    {
        List<Customer> SearchByCountry(string query);
    }
}
