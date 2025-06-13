# CafatriaOnionArch 🍽️

A modern cafeteria management system built with .NET Core using Clean Architecture.

## 🌟 What's This Project About?
This is a cafeteria management system that is  a digital system that helps manage food orders, menu items, and cafeteria operations.

## 🔧 Technology We're Using
- **.NET Core 9 - Our main framework
- **Entity Framework Core** - For working with the database
- **SQL Server** - Where we store all our data
- **Swagger** - To test and document our APIs

## 🏗️ Project Structure Explained Simply
Our project is organized like an onion (that's why it's called Onion Architecture!). Here's how it works:

```
CafatriaOnionArch/
├── Core (The Center of our Onion 🎯)
│   ├── Domain (All our basic building blocks)
│   └── Application (Our business rules)
├── Infrastructure (How we talk to external stuff 🔌)
└── API (How users interact with our system 🌐)
```

### What Each Part Does

#### 1. Core (Domain & Application)
- **Domain**: Contains the basic stuff like:
  - What a Menu Item is
  - What an Order looks like
  - What a Customer is

- **Application**: Contains the rules like:
  - How to place an order
  - How to update menu items
  - How to calculate prices

#### 2. Infrastructure
- Handles database operations
- Manages external services
- Deals with file storage

#### 3. API
- Receives requests from users
- Sends back responses
- Handles web-related stuff

## 🚀 Getting Started

### Prerequisites
1. Visual Studio 2022 or VS Code
2. .NET 9 SDK
3. SQL Server

### How to Run the Project
1. Clone the repository
```bash
git clone https://github.com/kareem-zarif/CafatriaOnionArch.git
```

2. Open the solution in Visual Studio

3. Update the database connection string in `appsettings.json`

4. Run these commands in Package Manager Console:
```bash
dotnet ef database update
dotnet run
```

5. Open your browser and go to: `https://localhost:5001/swagger`

## 📝 Basic Concepts Used

### What is Clean Architecture?
Think of it like a well-organized kitchen:
- Every tool has its place
- Chefs (core logic) don't need to know about the dining room (UI)
- Everything is organized in a way that makes sense

### Key Principles We Follow
1. **Keep Things Simple**: Each piece of code does one job
2. **Independence**: Different parts can be changed without breaking others
3. **Easy Testing**: We can test each part separately

## 🔄 How Data Flows
1. User makes a request (like ordering food)
2. API receives the request
3. Application layer processes it
4. Domain rules are checked
5. Infrastructure saves the data
6. Response goes back to user

## 👩‍💻 Common Tasks Examples

### Adding a New Menu Item
```csharp
public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
```

### Creating an Order
```csharp
public class Order
{
    public int Id { get; set; }
    public List<MenuItem> Items { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
```

## 🤝 How to Contribute
1. Fork the repository
2. Create your feature branch
3. Make your changes
4. Submit a pull request

## 🆘 Need Help?
- Check the [Wiki](https://github.com/kareem-zarif/CafatriaOnionArch/wiki)
- Create an issue
- Ask in discussions

## 📚 Learning Resources
- [Clean Architecture Basics](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [Entity Framework Tutorial](https://learn.microsoft.com/en-us/ef/core/)
- [.NET Core Basics](https://dotnet.microsoft.com/learn)

Remember: It's okay to ask questions! We were all beginners once. 😊
