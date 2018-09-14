using System;

namespace Vavatech.Shop.Models
{
    public class OrderItem : Base
    {
        private static int counter = 0;

        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal TotalPrice => Quantity * Price;
        
        public override string ToString()
        {
            return $"ID: {Id} - Name: {Item.Name} EAN: {Item.EAN} - Quantity: {Quantity} - Item price: {Price} vs Price: {Item.Price} - Total: {TotalPrice}\n";
        }

        protected OrderItem()
        {

        }

        public OrderItem(Item item, int quantity)
        {
            if (null == item)
            {
                throw new Exception("Nieprawidłowy item.");
            }
            Item = item;
            Quantity = quantity;
            Id = counter++;
            Price = item.Price;
        }
    }
}
