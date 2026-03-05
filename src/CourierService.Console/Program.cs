
using System;
using System.Collections.Generic;
using CourierService.Domain.Entities;
using CourierService.Application.Services;

namespace CourierService.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int baseCost = 100;

            var packages = new List<Package>
            {
                new Package("PKG1",50,30,"OFR001"),
                new Package("PKG2",75,125,"OFR008"),
                new Package("PKG3",175,100,"OFR003"),
                new Package("PKG4",110,60,"OFR002"),
                new Package("PKG5",155,95,"NA")
            };

            var vehicles = new List<Vehicle>
            {
                new Vehicle(1,70,200),
                new Vehicle(2,70,200)
            };

            var costService = new DeliveryCostService();

            foreach (var p in packages)
                costService.CalculateCost(p, baseCost);

            var deliveryService = new DeliveryTimeService();
            deliveryService.CalculateDeliveryTimes(packages, vehicles);

            foreach (var p in packages)
            {
                Console.WriteLine($"{p.Id} {p.Discount} {p.TotalCost} {Math.Round(p.DeliveryTime,2)}");
            }
        }
    }
