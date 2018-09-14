using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }
}
