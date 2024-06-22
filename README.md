# Bulky

Bulky is an MVC project for a bookstore.

## Technologies Used

- **ASP.NET Core 7.0:** The project was implemented using the ASP.NET Core 7.0 framework following the MVC pattern.
- **MySQL:** Uses the MySQL database, which is one of the requirements for its usage.
- **Entity Framework:** The ORM system chosen for the project is Entity Framework.
- **Repository Pattern and Unit of Work:** Applied the repository and unit of work patterns, creating a separate layer for database access.
- **Identity:** Implemented Identity for user control, including the ability to log in via Facebook.
- **Stripe:** Integrated with the Stripe payment system.

## Requirements

- .NET SDK 7.0
- MySQL

## Configuration Instructions

1. Clone the repository:
   git clone https://github.com/AlefT94/Bulky_MVC

2. Configure the MySQL connection string in the appsettings.json file:
  "ConnectionStrings": {
  "DefaultConnection": "Server=your-server;Database=your-database;User=your-username;Password=your-password;"
  }

3. Run the migrations to create the database:
   dotnet ef database update

4. Configure the Stripe payment system by adding your API keys in the appsettings.json file:
   "Stripe": {
  "SecretKey": "your-secret-key",
  "PublishableKey": "your-publishable-key"
  }

5. Run the project:
   dotnet run

## Features
- **Book Management:** Add, edit, view, and delete books from the catalog.
- **User Control:** Authentication and authorization system using Identity, with support for Facebook login.
- **Payment System:** Integration with Stripe for payment processing.
