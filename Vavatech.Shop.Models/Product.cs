using System;

namespace Vavatech.Shop.Models
{
    public class Product : Item
    {

        public string Color { get; set; }
        private string DisplayName { get
            {
                return $"{base.ToString()} of color {Color}";
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        protected Product()
        {

        }

        public Product(string name, decimal price, string color, string ean) : base(name, price, ean)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color)); ;
        }
    }
}
