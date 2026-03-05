
using CourierService.Domain.Entities;
using CourierService.Application.Factories;

namespace CourierService.Application.Services
{
    public class DeliveryCostService
    {
        private readonly OfferStrategyFactory factory = new OfferStrategyFactory();

        public void CalculateCost(Package package, int baseCost)
        {
            decimal cost = baseCost + (package.Weight * 10) + (package.Distance * 5);
            var strategy = factory.GetStrategy(package.OfferCode);
            var discount = strategy.CalculateDiscount(package, cost);

            package.Discount = discount;
            package.TotalCost = cost - discount;
        }
    }
}
