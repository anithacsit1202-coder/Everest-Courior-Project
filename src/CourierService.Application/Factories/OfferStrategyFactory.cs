
using CourierService.Domain.Interfaces;
using CourierService.Application.Strategies;

namespace CourierService.Application.Factories
{
    public class OfferStrategyFactory
    {
        public IOfferStrategy GetStrategy(string code)
        {
            return code switch
            {
                "OFR001" => new OFR001Strategy(),
                "OFR002" => new OFR002Strategy(),
                "OFR003" => new OFR003Strategy(),
                _ => new NoOfferStrategy()
            };
        }
    }
}
