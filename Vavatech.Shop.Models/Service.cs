namespace Vavatech.Shop.Models
{
    public class Service : Item
    {
        private string DisplayName
        {
            get
            {
                return $"{base.ToString()} of Id {Id}";
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public Service()
        {

        }

        public Service(int id, string name, decimal price, string ean) : base(id, name, price, ean)
        {
        }
    }
}
