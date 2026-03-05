
using System;
using System.Collections.Generic;
using System.Linq;
using CourierService.Domain.Entities;

namespace CourierService.Application.Services
{
    public class DeliveryTimeService
    {
        public void CalculateDeliveryTimes(List<Package> packages, List<Vehicle> vehicles)
        {
            var remaining = new List<Package>(packages);

            while (remaining.Any())
            {
                var vehicle = vehicles.OrderBy(v => v.AvailableAt).First();

                var shipment = SelectShipment(remaining, vehicle.MaxLoad);

                foreach (var pkg in shipment)
                {
                    double time = (double)pkg.Distance / vehicle.Speed;
                    pkg.DeliveryTime = vehicle.AvailableAt + time;
                }

                double maxDistance = shipment.Max(p => p.Distance);
                double roundTrip = (maxDistance / (double)vehicle.Speed) * 2;
                vehicle.AvailableAt += roundTrip;

                foreach (var p in shipment)
                    remaining.Remove(p);
            }
        }

        private List<Package> SelectShipment(List<Package> packages, int maxLoad)
        {
            List<Package> best = new List<Package>();
            int n = packages.Count;

            for (int mask = 1; mask < (1 << n); mask++)
            {
                var combo = new List<Package>();
                int weight = 0;

                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        combo.Add(packages[i]);
                        weight += packages[i].Weight;
                    }
                }

                if (weight <= maxLoad)
                {
                    if (combo.Count > best.Count ||
                       (combo.Count == best.Count &&
                        combo.Sum(p => p.Weight) > best.Sum(p => p.Weight)))
                    {
                        best = combo;
                    }
                }
            }

            if (!best.Any())
                best.Add(packages.OrderByDescending(p => p.Weight).First());

            return best;
        }
    }
}
