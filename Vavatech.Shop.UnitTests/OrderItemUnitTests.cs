using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;
using Xunit;

namespace Vavatech.Shop.UnitTests
{
    public class OrderItemUnitTests
    {
        [Fact]
        public void OrderItemUnitTest1()
        {
            Product item = new Product("Product 1", 33.33m, "Red", "ean1");
            OrderItem orderItem = new OrderItem(item, 30);

            Assert.NotEmpty(item.Name);
            Assert.Equal(33.33m, item.Price);
            Assert.Equal("Red", item.Color);
            Assert.Equal("ean1", item.EAN);

            Assert.Equal(item, orderItem.Item);
            Assert.Equal(30, orderItem.Quantity);
            Assert.Equal((33.33m * 30), orderItem.TotalPrice);

            Assert.IsType<Product>(item);
            Assert.IsType<Product>(orderItem.Item);
        }

        [Fact]
        public void OrderItemUnitTest2()
        {
            Service item = new Service("Product 1", 33.33m, "ean1");
            OrderItem orderItem = new OrderItem(item, 30);

            Assert.NotEmpty(item.Name);
            Assert.Equal(33.33m, item.Price);
            Assert.Equal("ean1", item.EAN);

            Assert.Equal(item, orderItem.Item);
            Assert.Equal(30, orderItem.Quantity);
            Assert.Equal((33.33m * 30), orderItem.TotalPrice);

            Assert.IsType<Service>(item);
            Assert.IsType<Service>(orderItem.Item);
        }
    }
}
