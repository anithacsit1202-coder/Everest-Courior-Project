
using CourierService.Domain.Entities;
using CourierService.Domain.Interfaces;

namespace CourierService.Application.Strategies
{
    public class OFR001Strategy : IOfferStrategy
    {
        public decimal CalculateDiscount(Package package, decimal cost)
        {
            if (package.Distance < 200 && package.Weight >= 70 && package.Weight <= 200)
                return cost * 0.10m;
            return 0;
        }
    }
}
