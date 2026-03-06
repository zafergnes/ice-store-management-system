# Ice Store Management System

## Overview
This project is a C# Windows Forms application designed for managing an ice store. It provides a user-friendly interface for managing stock, sales, and customer information.

## Project Structure
```
IceStoreManagementSystem/
├── IceStoreManagementSystem.sln         # Solution file
├── IceStoreManagementSystem/            # Main application
│   ├── Program.cs                       # Entry point
│   ├── MainForm.cs                      # Main application form
│   ├── ...                              # Other forms and classes
└── Database/                             # Database scripts
    └── IceStoreDB.sql                   # SQL script for database
```

## Features
- **User Authentication**: Secure login for users.
- **Inventory Management**: Add, update, and delete ice products.
- **Sales Tracking**: Record sales transactions and generate reports.
- **Customer Management**: Maintain customer records and purchase history.
- **Data Visualization**: Display charts for sales analysis.

## Requirements
- .NET Framework 4.7 or higher
- Visual Studio 2019 or higher
- SQL Server for database management (Express edition is sufficient)

## Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/zafergnes/ice-store-management-system.git
   ```
2. Open the solution file in Visual Studio.
3. Restore NuGet packages if prompted.
4. Create the database using `IceStoreDB.sql` script in SQL Server.
5. Update the connection string in the application for database access.

## Usage
- Run the application from Visual Studio or the executable file.
- Use the login screen to authenticate.
- Navigate through the application to manage inventory, sales, and customers.

## Database
- The application uses a SQL Server database to store data related to ice products, sales, and customers. The structure can be modified through the `IceStoreDB.sql` script.

## UI Components
- **MainForm**: The central hub of the application with navigation options.
- **ProductForm**: For managing ice products.
- **SalesForm**: For recording and viewing sales transactions.
- **CustomerForm**: For managing customer information.

## Development
- Follow best practices for coding in C#.
- Ensure to test all components before deployment.
- Keep dependencies updated and ensure compatibility with latest .NET versions.

## Contributions
Contributions to improve this project are welcome. Feel free to fork the repo and submit a pull request!