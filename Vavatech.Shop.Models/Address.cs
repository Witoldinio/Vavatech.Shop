namespace Vavatech.Shop.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Local { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Street} {Building} {Local}, {Zip} {City}, {District} {Country}";
        }
    }
}
