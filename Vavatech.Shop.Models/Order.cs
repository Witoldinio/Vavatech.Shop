using System;
using System.Collections.Generic;
using System.Linq;

namespace Vavatech.Shop.Models
{
    public class Order : Base
    {
        private static int counter = 0;

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string  OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public List<OrderItem> Items { get; set; }

        public override string ToString()
        {
            string result = $"---------------------\nId: {Id} - #: {OrderNumber} - Customer: {Customer} - Date: {Date}\n";
            if (Items.Any())
            {
                foreach (OrderItem item in Items)
                {
                    result += item;
                }
            }
            else
            {
                result += "No products yet.";
            }
            return result;
        }

        protected Order()
        {

        }

        public Order(Customer customer)
        {
            if (null == customer)
            {
                throw new Exception("Niepoprawny klient.");
            }

            Customer = customer;
            Date = DateTime.Now;
            Id = counter++;
            OrderNumber = $"{Date.Year}/{Date.Month}/{Id + 1}";
            Items = new List<OrderItem>();
        }

        public static Order Create(Customer customer)
        {
            return new Order(customer);
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
