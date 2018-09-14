using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class FakeOrderCalculatorService : IOrderCalculator
    {
        ICanDiscountStrategy _canDiscount;
        ICalculateDiscountStrategy _discount;

        public FakeOrderCalculatorService(ICanDiscountStrategy canDiscount, ICalculateDiscountStrategy discount)
        {
            this._canDiscount = canDiscount ?? throw new ArgumentNullException(nameof(canDiscount));
            this._discount = discount ?? throw new ArgumentNullException(nameof(discount));
        }

        public decimal Calculate(Order order)
        {
            if (_canDiscount.CanDiscount(order))
            {
                return order.TotalPrice - _discount.Calculate(order);
            }

            return order.TotalPrice;
        }
    }
}
