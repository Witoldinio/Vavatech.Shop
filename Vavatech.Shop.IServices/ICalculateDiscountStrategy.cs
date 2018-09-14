using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public interface ICalculateDiscountStrategy
    {
        decimal Calculate(Order order);
    }
}
