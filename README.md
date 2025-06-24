# Cafe Management System

A modern, modular cafe management system built with ASP.NET Core (.NET 9, C# 13), using Razor Pages, Entity Framework Core, and Clean Architecture principles.

## Features

- **Branch Management:** Multiple locations, manager assignment, contact info, and operating hours.
- **Employee Management:** Role-based (Manager, Casher, ServiceEmp), branch assignment, and status tracking.
- **Menu & Product Management:** Categorized products, availability, and stock tracking.
- **Order Processing:** Status tracking (Pending, InProgress, Served, Canceled), itemized orders, and table assignment.
- **Table Management:** Capacity, status (Available, Occupied, Reserved, NeedsCleaning), and order history.
- **Supplier Management:** Contact info, branch relationships, and deal history.
- **API & MVC:** RESTful API and MVC UI for full management.

## Tech Stack

- **.NET 9 / C# 13**
- **Razor Pages** (prioritized)
- **Entity Framework Core** (modular configuration, centralized registration)
- **AutoMapper** (profiles for API and MVC)
- **Dependency Injection** (IOC/Extensions)
- **Clean Architecture** (separation of Domain, Application, Infrastructure, UI)

## Entity Overview

- **Branch:** Location, manager, phone, address, employees, suppliers.
- **Employee:** Name, phone, email, role, branch, hire date.
- **Menu:** Menu name, products.
- **Product:** Name, description, price, stock, category, menu.
- **Order:** Status, total, date, table, items.
- **OrderItem:** Quantity, unit price, notes, product, order.
- **Supplier:** Name, phone, address, branch relationships.
- **Table:** Name, capacity, status, orders.
- **BranchSupplier:** Last deal, deal history, supplier, branch.

## Getting Started

1. **Clone the repository**
2. **Update connection strings** in `Cafe.UI.WEB.MVC2/appsettings.json` and `Cafe.API_/appsettings.json`
3. **Run EF Core migrations** to set up the database
4. **Start the solution** (choose Razor Pages UI or API as needed)

## Phone Number Format

- Must start with 010, 011, 012, or 15
- 11–13 digits

## Project Structure

- `Cafe.Domain` – Core entities and enums
- `Cafe.Infrastructure.EF` – EF Core context and configuration
- `Cafe.Application` – Business logic and DTOs
- `Cafe.UI.WEB.MVC2` – Razor Pages/MVC UI
- `Cafe.API_` – RESTful API
- `Cafe.Infrastructure.Integrations` – HTTP client services

## Notes

- All entity configurations are applied via reflection in `CafeDBContext`.
- Virtual DbSets for testability and extensibility.
- Modular, testable, and ready for production or further extension.

---

For more details, see the source code and comments in each project.