
using CourierService.Domain.Entities;
using CourierService.Domain.Interfaces;

namespace CourierService.Application.Strategies
{
    public class OFR003Strategy : IOfferStrategy
    {
        public decimal CalculateDiscount(Package package, decimal cost)
        {
            if (package.Distance >= 50 && package.Distance <= 250 &&
                package.Weight >= 10 && package.Weight <= 150)
                return cost * 0.05m;
            return 0;
        }
    }
}
