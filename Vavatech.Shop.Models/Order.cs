using System;
using System.Collections.Generic;
using System.Linq;

namespace Vavatech.Shop.Models
{
    public class Order : Base
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string  OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public Statuses Status { get; set; }
        
        public List<OrderItem> Items { get; set; }

        //[Flags]
        //public enum RoomStatus
        //{
        //    L1 = 2 ^ 3,
        //    L2 = 2 ^ 2,
        //    P = 2 ^ 1,
        //    O = 2 ^ 0,
        //}

        // Typ wyliczeniowy
        public enum Statuses
        {
            Draft,
            Created,
            Canceled,
            Sent,
            Delivered
        }

        public decimal TotalPrice {
            get
            {
                return Items.Sum(i => i.TotalPrice);
            }
        }

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

        protected float TestMethod(int value1, int value2)
        {
            return Convert.ToSingle(value1) / Convert.ToSingle(value2);
        }
    }
}
