
using CourierService.Domain.Entities;

namespace CourierService.Domain.Interfaces
{
    public interface IOfferStrategy
    {
        decimal CalculateDiscount(Package package, decimal deliveryCost);
    }
}
