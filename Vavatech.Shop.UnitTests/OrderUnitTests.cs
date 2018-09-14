using System;
using Vavatech.Shop.Models;
using Xunit;

namespace Vavatech.Shop.UnitTests
{
    public class OrderUnitTests : Order
    {
        [Fact]
        public void CreateOrderTest1()
        {
            // Arrange -> czêœæ w której produkujemy dane testowe
            Customer customer = new Customer();
            Order order = Order.Create(customer);

            // Acts

            //Asserts -> czêœæw której testujemy wyniki
            Assert.NotNull(order.Customer);
            Assert.Equal(DateTime.Today, order.Date.Date);
            Assert.Equal(Order.Statuses.Draft, order.Status);
        }

        [Fact]
        protected void TestMethod1()
        {
            float expected = 1 / 2f;
            Assert.Equal(expected, base.TestMethod(1, 2));
        }
    }
}
