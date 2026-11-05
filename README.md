# Zella Beauty POS

A point-of-sale (POS) web application for beauty salons, built with **ASP.NET Core Blazor** on **.NET 8**.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor&logoColor=white)
![Status](https://img.shields.io/badge/status-in%20development-orange)

## Overview

Zella Beauty POS aims to simplify day-to-day salon operations: taking payments, managing services and products, and keeping track of sales, all from a fast, browser-based interface.

> **Note:** This project is in early development. The current codebase is the initial Blazor Web App scaffold, and features are being added incrementally.

## Planned Features

- [ ] Service and product catalogue
- [ ] Checkout and billing
- [ ] Customer management
- [ ] Appointment tracking
- [ ] Staff management and commissions
- [ ] Sales reports and daily summaries
- [ ] Authentication and role-based access

## Tech Stack

| Layer     | Technology                                   |
| --------- | -------------------------------------------- |
| Framework | ASP.NET Core 8 (Blazor Web App)              |
| Rendering | Interactive Server                           |
| Language  | C#                                           |

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- A code editor such as Visual Studio, JetBrains Rider, or VS Code

### Installation

```bash
# Clone the repository
git clone https://github.com/Tharumika/Zella-Beauty-POS.git
cd Zella-Beauty-POS/ZellaBeautyPos.Web

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

The app starts at `http://localhost:5203` (or `https://localhost:7215` with the `https` profile).

### Useful commands

```bash
dotnet build            # Build the project
dotnet watch            # Run with hot reload
dotnet test             # Run tests (once a test project is added)
```

## Project Structure

```
Zella-Beauty-POS/
├── README.md
└── ZellaBeautyPos.Web/
    ├── Components/        # Razor components, layouts, and pages
    ├── Properties/        # Launch settings
    ├── wwwroot/           # Static assets (CSS, images, JS)
    ├── Program.cs         # Application entry point and configuration
    └── appsettings.json   # App configuration
```

## Roadmap

1. Define the data model (services, products, customers, sales)
2. Add database support with Entity Framework Core
3. Build the checkout flow
4. Add authentication and roles
5. Add reporting

## Contributing

Contributions, issues, and feature requests are welcome. Feel free to open an issue or submit a pull request.

## License

No license has been chosen yet. Add a `LICENSE` file to define how this project may be used.
