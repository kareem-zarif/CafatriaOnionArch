# Cafe Management System

A modern, modular cafe management system built with ASP.NET Core (.NET 9, C# 13), using API, MVC, Entity Framework Core, and Clean Architecture principles.

---

## 🌱 A Beginner-Friendly Guide: From Request DTO to Response DTO

 a simple, friendly journey through how your data flows in this system—from the moment a user makes a request, to the response they receive.

## Project Structure

- `Cafe.Domain` – Core entities and rules
- `Cafe.Domain.Shared` – Enums to be Shared Cross All layers
- `Cafe.Infrastructure.EF` – Database access and configuration
- `Cafe.Application` – Business logic and DTOs
- `Cafe.UI.WEB.MVC2` – Razor Pages UI
- `Cafe.API_` – RESTful API
- `Cafe.Infrastructure.Integrations` – External services

### 1. **The Request: Starting with a Request DTO**

When a user interacts with the website (for example, submitting a form to create a new order), their input is packaged into a **Request DTO** (Data Transfer Object).  
- **Why?** DTOs keep your code clean and safe by only exposing the data you need, and hiding everything else and make Server-Side Validation.

### 2. **Application Layer: The Brains of the Operation**

The Request DTO is sent to the **Application Layer**.  
- **What happens here?**  
  - Business rules are applied (e.g., "Is the table available? allowed age of Student? , Minimum age of Employee?").
  - The Application Layer uses **Services** and **Handlers** to process the request.
  - It talks to the **Infrastructure Layer** to fetch or save data.

### 3. **Infrastructure Layer: Talking to the Database**

The Application Layer never talks to the database directly. Instead, it uses **UnitOfWork** and **Repositories** to talk **DbContext** from the **Infrastructure Layer**.  
- **Why?**  
  - This separation makes your code easier to test and change.
  - You can swap out the database or add new data sources without changing your business logic (Can Change To Mongo in simple changes😊).

### 4. **Core/Domain Layer: The Heart of Your Business**

At the center is the **Core (Domain) Layer**.  
- **What’s here?**  
  - Your main business entities (like `Order`, `Product`, `Employee`).
  - Business rules and logic that never change, no matter how the app grows (Database Validation rules by DataNotation or FluentApi).

### 5. **Back to the User: Response DTO**

After processing, the Application Layer creates a **Response DTO**.  
- **Why?**  
  - It sends only the necessary data back to the user, keeping things secure and efficient.
  -You can test Response By PostMan Tool!
	
### 5. **Instead of Api : You can return MVC ViewModel**

After processing, the Application Layer creates a **Response MVC ViewModel**.  
- **Why?**  
  - It sends only the necessary data back to the View, keeping things secure and efficient.
  - You can See You Live View 😊!
---

## 🚀 Why This Approach?

- **Scalable:**  
  - You can add new features (like mobile apps or APIs) without rewriting your core logic.
- **Maintainable:**  
  - Each layer has a single responsibility, so bugs are easier to find and fix.
- **Testable:**  
  - You can test each part (like Application Layer alone) without needing a real database.
- **Clean Code:**  
  - Using DTOs, layers, and dependency injection keeps your code organized and easy to read.

---

## 🛣️ Example Trip: Creating an Order

1. **User fills out an order form** (Razor Page).
2. **Form data becomes a `CreateOrderRequestDto`.**
3. **Application Layer** receives the DTO, checks business rules.
4. **Infrastructure Layer** saves the order using Entity Framework Core.
5. **Application Layer** builds a `CreateOrderResponseDto` with order details.
6. **User sees a confirmation page** with their order info.

---

## 💡 Best Practices Used Here

- **DTOs** for safe, clear data transfer.
- **Separation of Concerns:** Each layer does one job.
- **Dependency Injection:** Makes code flexible and testable.
- **Entity Framework Core:** Modern, efficient data access.
- **MVC:** Simple web UI.

---


## Tech Stack

- **.NET 9 / C# 13**
- **MVC** (prioritized)
- **Entity Framework Core** (modular configuration, centralized registration)
- **AutoMapper** (profiles for API and MVC)
- **Dependency Injection** (IOC/Extensions)
- **Clean Architecture** (separation of Domain, Application, Infrastructure, UI)
---
## 🧩 SOLID Principles in This Project

This project is designed with the SOLID principles in mind, making it easy to understand, extend, and maintain. Here’s how each principle is reflected in the code:

### S — Single Responsibility Principle
Each class and layer has one clear job:
- **DbContext** (`CafeDBContext`) only manages database access.
- **DTOs** are just for data transfer.
- **Services/Handlers** in the Application Layer handle business logic.
- **Repositories** manage data operations.

### O — Open/Closed Principle
The system is open for extension but closed for modification:
- You can add new features (like new entities or business rules) by creating new classes or methods, without changing existing code.
- Entity configurations are applied via reflection, so you can add new configurations without editing the core context.

### L — Liskov Substitution Principle
You can replace base types with derived types without breaking the app:
- **DbContext** and **DbSet** are used as `virtual`, so you can mock or extend them for testing or new features.
- Interfaces and abstractions are used for services and repositories.

### I — Interface Segregation Principle
Interfaces are small and focused:
- Each interface (like repository interfaces) contains only the methods relevant to its purpose, so classes only implement what they need.

### D — Dependency Inversion Principle
High-level modules do not depend on low-level modules:
- The Application Layer depends on abstractions (interfaces), not concrete implementations.
- Dependency Injection is used throughout (see `IOC/Extensions.cs`), making it easy to swap implementations (e.g., change the database or add caching).

---

**In summary:**  
By following SOLID, this project is easy to read, test, extend, and maintain—perfect for both learning and real-world development!

## Getting Started

1. **Clone the repository** (Choose BackBranch1 branch not main , as it has last updates , Master waits Merge)
2. **Update connection strings** in `Cafe.UI.WEB.MVC2/appsettings.json` and `Cafe.API_/appsettings.json`
3. **Run EF Core migrations** to set up the database
4. **Start the solution** (choose MVC or API as needed)


## Notes

- All entity configurations are applied via reflection in `CafeDBContext`.
- Virtual DbSets for testability and extensibility.
- Modular, testable, and ready for production or further extension.

---
## Features

- **Branch Management:** Multiple locations, manager assignment, contact info, and operating hours.
- **Employee Management:** Role-based (Manager, Casher, ServiceEmp), branch assignment, and status tracking.
- **Menu & Product Management:** Categorized products, availability, and stock tracking.
- **Order Processing:** Status tracking (Pending, InProgress, Served, Canceled), itemized orders, and table assignment.
- **Table Management:** Capacity, status (Available, Occupied, Reserved, NeedsCleaning), and order history.
- **Supplier Management:** Contact info, branch relationships, and deal history.
- **API & MVC:** RESTful API and MVC UI for full management.

