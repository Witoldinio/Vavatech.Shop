namespace Vavatech.Shop.Models
{
    public class Customer : Base 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        
        public Customer()
        {

        }

        public Customer(int id, string name)
        {
            Id = id;
            FirstName = name;
        }

        public string DisplayName {
            get
            {
                return $"{Id} - {FirstName} {LastName} - {VatNumber} - {Address}";
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
