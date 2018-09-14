using System;

namespace Vavatech.Shop.Models
{
    public abstract class Item : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string EAN { get; set; }
        public string Discriminator { get; set; }

        public override string ToString()
        {
            return Name;
        }

        protected Item()
        {

        }

        protected Item(int id, string name, decimal price, string ean)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            EAN = ean;
        }
    }
}
