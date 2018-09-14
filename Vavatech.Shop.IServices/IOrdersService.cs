using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface IOrdersService : IEntitiesService<Order>, IIsSearchable<Order>
    {
    }
}
