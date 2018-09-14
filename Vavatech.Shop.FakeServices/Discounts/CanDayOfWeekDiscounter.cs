using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices.Discounts
{
    public class CanDayOfWeekDiscounter : ICanDiscountStrategy
    {
        private DayOfWeek _day;

        public CanDayOfWeekDiscounter(DayOfWeek day)
        {
            this._day = day;
        }

        public bool CanDiscount(Order order)
        {
            return order.Date.DayOfWeek == _day;
        }
    }
}
