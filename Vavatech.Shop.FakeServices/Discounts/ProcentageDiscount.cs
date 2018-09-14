using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices.Discounts
{
    public class ProcentageDiscount : ICalculateDiscountStrategy
    {
        private decimal _discount;

        public ProcentageDiscount(decimal discount)
        {
            _discount = discount;
        }

        public decimal Calculate(Order order)
        {
            return order.TotalPrice * _discount;
        }
    }
}
