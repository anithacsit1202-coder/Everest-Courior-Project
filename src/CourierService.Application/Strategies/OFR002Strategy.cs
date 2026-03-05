
using CourierService.Domain.Entities;
using CourierService.Domain.Interfaces;

namespace CourierService.Application.Strategies
{
    public class OFR002Strategy : IOfferStrategy
    {
        public decimal CalculateDiscount(Package package, decimal cost)
        {
            if (package.Distance >= 50 && package.Distance <= 150 &&
                package.Weight >= 100 && package.Weight <= 250)
                return cost * 0.07m;
            return 0;
        }
    }
}
