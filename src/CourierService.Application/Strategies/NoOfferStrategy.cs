
using CourierService.Domain.Entities;
using CourierService.Domain.Interfaces;

namespace CourierService.Application.Strategies
{
    public class NoOfferStrategy : IOfferStrategy
    {
        public decimal CalculateDiscount(Package package, decimal cost)
        {
            return 0;
        }
    }
}
