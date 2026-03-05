
using Xunit;
using CourierService.Application.Services;
using CourierService.Domain.Entities;

namespace CourierService.Tests
{
    public class DeliveryCostTests
    {
        [Fact]
        public void CostCalculation_ShouldBeCorrect()
        {
            var service = new DeliveryCostService();
            var pkg = new Package("PKG1",10,100,"NA");

            service.CalculateCost(pkg,100);

            Assert.Equal(700,pkg.TotalCost);
        }
    }
}
