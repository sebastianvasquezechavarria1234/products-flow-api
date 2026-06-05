# 🛒 Products REST API — ASP.NET Core Web API

> A clean and efficient **RESTful API** built with **ASP.NET Core 8** and **Entity Framework Core** for full product management (CRUD) with dynamic sorting support, connected to **SQL Server** and documented with **Swagger/OpenAPI**.

---

## 📋 Table of Contents

- [✨ Features](#-features)
- [🛠️ Tech Stack](#️-tech-stack)
- [📁 Project Structure](#-project-structure)
- [🚀 Getting Started](#-getting-started)
- [🔌 API Endpoints](#-api-endpoints)
- [🗄️ Database Setup](#️-database-setup)
- [📖 Swagger Documentation](#-swagger-documentation)
- [🤝 Contributing](#-contributing)

---

## ✨ Features

- ✅ **Full CRUD** operations for Products
- 🔃 **Dynamic sorting** by Name (`Nombre`) or Price (`Precio`) in ascending/descending order
- 🗄️ **SQL Server** integration via Entity Framework Core
- 📄 **Swagger UI** for interactive API documentation
- 🔒 **Authorization middleware** ready to extend
- ⚡ Built on **.NET 8** — the latest LTS release

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|---|---|---|
| 🟣 ASP.NET Core | 8.0 | Web framework |
| 🗃️ Entity Framework Core | 9.0.6 | ORM / Database access |
| 🏢 SQL Server | Latest | Relational database |
| 📄 Swashbuckle (Swagger) | 6.6.2 | API documentation |
| 🔧 EF Core Tools | 9.0.6 | Migrations management |

---

## 📁 Project Structure

```
WebApi/
├── 📂 Context/
│   └── ApplicationDbContext.cs      # EF Core DbContext
├── 📂 Controllers/
│   ├── ProductsController.cs        # Main CRUD controller
│   └── WeatherForecastController.cs # Default scaffold controller
├── 📂 Models/
│   └── Product.cs                   # Product entity
├── 📂 Migrations/
│   └── ...                          # EF Core auto-generated migrations
├── 📂 Properties/
│   └── launchSettings.json          # Launch profiles
├── Program.cs                       # Application entry point & DI setup
├── appsettings.json                 # App configuration (connection string)
├── appsettings.Development.json     # Dev-specific overrides
└── WebApi.csproj                    # Project dependencies
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### 1️⃣ Clone the repository

```bash
git clone https://github.com/sebastianvasquezechavarria1234/breef.git
cd breef
```

### 2️⃣ Configure the connection string

Open `WebApi/appsettings.json` and update the connection string with your SQL Server credentials:

```json
{
  "ConnectionStrings": {
    "conexion": "Server=YOUR_SERVER;Database=ProductsDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3️⃣ Apply database migrations

```bash
dotnet ef database update
```

### 4️⃣ Run the application

```bash
dotnet run
```

The API will be available at:
- 🌐 `https://localhost:7XXX` (HTTPS)
- 🌐 `http://localhost:5XXX` (HTTP)

---

## 🔌 API Endpoints

Base URL: `/api/Products`

| Method | Endpoint | Description |
|--------|----------|-------------|
| 📥 `GET` | `/api/Products` | Get all products (with optional sorting) |
| 📥 `GET` | `/api/Products/{id}` | Get a product by ID |
| 📤 `POST` | `/api/Products` | Create a new product |
| ✏️ `PUT` | `/api/Products/{id}` | Update an existing product |
| 🗑️ `DELETE` | `/api/Products/{id}` | Delete a product by ID |

### 🔃 Sorting Query Parameters

The `GET /api/Products` endpoint supports dynamic sorting:

| Parameter | Values | Default |
|-----------|--------|---------|
| `sortBy` | `Nombre`, `Precio` | `Nombre` |
| `sortOrder` | `asc`, `desc` | `asc` |

**Example requests:**

```http
GET /api/Products?sortBy=Precio&sortOrder=desc
GET /api/Products?sortBy=Nombre&sortOrder=asc
```

### 📦 Product Model

```json
{
  "id": 1,
  "nombre": "Laptop",
  "precio": 1500,
  "stock": 10
}
```

| Field | Type | Description |
|-------|------|-------------|
| `id` | `int` | Auto-generated primary key |
| `nombre` | `string` | Product name |
| `precio` | `int` | Product price |
| `stock` | `int` | Available stock units |

---

## 🗄️ Database Setup

The project uses **Entity Framework Core Code-First** approach with migrations.

```bash
# Add a new migration
dotnet ef migrations add <MigrationName>

# Apply migrations to the database
dotnet ef database update

# Remove last migration (if not applied)
dotnet ef migrations remove
```

---

## 📖 Swagger Documentation

When running in **Development** mode, Swagger UI is automatically available at:

```
https://localhost:{PORT}/swagger
```

This provides an interactive interface to test all API endpoints directly from the browser without any external tools. 🎉

---

## 🤝 Contributing

1. 🍴 Fork the repository
2. 🌿 Create your feature branch: `git checkout -b feature/AmazingFeature`
3. 💾 Commit your changes: `git commit -m 'Add some AmazingFeature'`
4. 📤 Push to the branch: `git push origin feature/AmazingFeature`
5. 🔁 Open a Pull Request

---

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

<div align="center">

Made with ❤️ using **ASP.NET Core 8** + **Entity Framework Core** + **SQL Server**

⭐ If you found this project helpful, please give it a star!

</div>
