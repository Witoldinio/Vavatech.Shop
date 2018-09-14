using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.FakeServices.Discounts;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Xunit;

namespace Vavatech.Shop.UnitTests
{
    public class OrderCalculatorUnitTests
    {
        [Fact]
        public void test1()
        {
            Customer customer = new Customer();
            Order order = Order.Create(customer);

            Faker<Product> fakerProduct = new Faker<Product>()
                .StrictMode(true)
                .Ignore(p => p.Id)
                .RuleFor(p => p.Name, r => r.Commerce.ProductName())
                .RuleFor(p => p.Color, r => r.Commerce.Color())
                .RuleFor(p => p.Price, r => 10)
                .RuleFor(p => p.EAN, r => r.Finance.Iban());

            Faker<Service> fakerService = new Faker<Service>()
                .StrictMode(true)
                .Ignore(s => s.Id)
                .RuleFor(s => s.Name, r => r.Commerce.ProductName())
                .RuleFor(s => s.Price, r => 10)
                .RuleFor(s => s.EAN, r => r.Finance.Iban());
            
            Random random = new Random();
            for (int i = 0; i < 200; i++)
            {
                if (0 == random.Next(0, 100) % 2)
                {
                    order.AddItem(new OrderItem(fakerProduct.Generate(), 30));
                }
                else
                {
                    order.AddItem(new OrderItem(fakerService.Generate(), 30));
                }
            }

            ICanDiscountStrategy canDiscount = new CanDayOfWeekDiscounter(DayOfWeek.Friday);
            ICalculateDiscountStrategy discount = new ProcentageDiscount(0.1m);

            IOrderCalculator calculator = new FakeOrderCalculatorService(canDiscount, discount);
            Assert.Equal(200 * 30 * 10, calculator.Calculate(order));

            Assert.Equal(200 * 30 * 10, calculator.Calculate(order));
        }
    }
}
