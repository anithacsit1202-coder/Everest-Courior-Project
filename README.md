
# Courier Delivery System

## Overview
This project implements a command-line application in **.NET** to solve the courier delivery estimation problem described in the Everest Engineering coding challenge.

The system calculates:

1. **Delivery cost** for each package with applicable offer discounts.
2. **Estimated delivery time** using a fleet of vehicles with capacity constraints.

The goal of this solution is not only to solve the problem but to demonstrate **clean architecture, SOLID principles, maintainable code, and testability**.

---

# Features

- Delivery cost estimation
- Offer-based discount calculation
- Shipment optimization based on vehicle capacity
- Vehicle scheduling and delivery time estimation
- Command Line Interface (CLI)
- Unit tests using xUnit
- Clean architecture design

---

# Cost Calculation

Delivery cost formula:

DeliveryCost = BaseCost + (Weight × 10) + (Distance × 5)

Offer discounts are applied based on predefined offer rules.

---

# Offer Rules

| Offer Code | Discount | Distance Criteria | Weight Criteria |
|-------------|-----------|------------------|----------------|
| OFR001 | 10% | Distance < 200 | 70–200 |
| OFR002 | 7% | 50–150 | 100–250 |
| OFR003 | 5% | 50–250 | 10–150 |

The offer logic is implemented using the **Strategy Pattern** so new offers can be added without modifying existing logic.

---

# Shipment Optimization Algorithm

The shipment grouping problem is solved using a **subset enumeration (knapsack-style) approach**.

Priority rules:

1. Maximize number of packages
2. If equal → maximize total shipment weight

This ensures optimal usage of vehicle capacity.

Algorithm complexity:

O(2^n)

Since the number of packages per shipment is relatively small, this approach is acceptable for the problem scope.

---

# Vehicle Scheduling

Vehicles are scheduled using **earliest availability first**.

Steps:

1. Select vehicle with earliest available time
2. Assign best shipment group
3. Calculate delivery time
4. Update vehicle availability

Delivery time calculation:

delivery_time = distance / vehicle_speed

Vehicle return time:

round_trip_time = (max_distance / speed) * 2

---

# Architecture

The solution follows **Clean Architecture** principles.

Structure:

src
 ├── CourierService.Console
 ├── CourierService.Domain
 ├── CourierService.Application

### Domain Layer
Contains core entities and business rules.

### Application Layer
Contains services, algorithms, and strategy implementations.

### Console Layer
Handles CLI interaction and input/output.

---

# Design Patterns Used

### Strategy Pattern
Used for implementing flexible offer discount logic.

### Factory Pattern
Used to resolve offer strategies dynamically.

These patterns make the system **extensible and maintainable**.

---

# Engineering Principles

This solution follows:

- SOLID Principles
- Clean Code practices
- Separation of Concerns
- Testable architecture

The goal was to create a **maintainable and extensible system rather than just solving the immediate problem**.

---

# Running the Application

Build the project:

dotnet build

Run the CLI:

dotnet run

---

# Running Tests

Run unit tests using:

dotnet test

Tests cover core business logic such as delivery cost calculation.

---

# Future Improvements

Possible enhancements:

- CLI input parser to match challenge input format
- REST API interface
- Docker containerization
- Improved shipment optimization for larger datasets
- CI/CD pipeline integration

---

# Author

Your Name
