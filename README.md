# 🚗 Car Rental System | מערכת השכרת רכבים

> **ASP.NET Core Web API | MySQL | Entity Framework Core | Clean Architecture**

---

## 🇬🇧 English

### Overview

A RESTful Web API for managing a car rental business. Built with ASP.NET Core following a clean layered architecture pattern, using MySQL as the database and Entity Framework Core for data access.

### Features

- Full CRUD for Customers, Vehicles, Rentals and Payments
- Clean 3-layer architecture (API → Services → DAL)
- Generic Repository and Service patterns (`IRepository<T>`, `IService<T>`)
- DTO-based data transfer using AutoMapper
- MySQL database with Entity Framework Core (Pomelo)
- API documentation via Scalar UI

### Project Structure

```
Car-Rental/
│
├── Car-Rental/              # API Layer – Controllers, Program.cs
│   └── Controllers/
│       ├── CustomersController.cs
│       ├── VehiclesController.cs
│       ├── RentalsController.cs
│       └── PaymentsController.cs
│
├── Services/                # Business Logic Layer
│   ├── Interfaces/
│   │   └── IService.cs      # Generic interface
│   ├── Classes/
│   │   ├── CustomerService.cs
│   │   ├── VehiclesService.cs
│   │   ├── RentalsService.cs
│   │   └── PaymentsService.cs
│   ├── DTOs/
│   │   ├── CustomerDTO.cs
│   │   ├── VehicleDTO.cs
│   │   ├── RentalDTO.cs
│   │   └── PaymentDTO.cs
│   └── Mapping/
│       └── MappingProfile.cs
│
├── DAL/                     # Data Access Layer
│   ├── Entities/
│   │   ├── Customer.cs
│   │   ├── Vehicle.cs
│   │   ├── Rental.cs
│   │   └── Payment.cs
│   ├── Interfaces/
│   │   └── IRepository.cs   # Generic interface
│   ├── Repositories/
│   │   ├── CustomerRepository.cs
│   │   ├── VehicleRepository.cs
│   │   ├── RentalRepository.cs
│   │   └── PaymentRepository.cs
│   └── Data/
│       └── AppDbContext.cs
│
└── Infrastructure/          # Shared DTOs and Extensions
    ├── DTOs/
    └── Extensions/
        └── DependencyInjection.cs
```

### Architecture

```
Client
  ↓
API (Controllers)
  ↓  uses IService<DTO>
Services (Business Logic)
  ↓  uses IRepository<Entity>
DAL (Repositories + AppDbContext)
  ↓
MySQL Database
```

### Data Model

| Entity | Fields |
|--------|--------|
| Customer | Id, FullName, Email, Phone |
| Vehicle | Id, Manufacturer, Model, Year, LicensePlate, DailyPrice |
| Rental | Id, CustomerId, CarId, StartDate, EndDate |
| Payment | Id, RentalId, Amount, PaymentDate |

### Prerequisites

- .NET 9.0 SDK
- MySQL Server (local)
- Visual Studio 2022 / 2026

### Getting Started

**1. Clone the repository:**
```bash
git clone https://github.com/s0583232209/Car-Rental.git
```

**2. Set up the database — run in MySQL Workbench:**
```sql
CREATE DATABASE car_rental;
CREATE USER 'caruser'@'localhost' IDENTIFIED BY '1234';
GRANT ALL PRIVILEGES ON car_rental.* TO 'caruser'@'localhost';
FLUSH PRIVILEGES;
```

**3. Update `appsettings.json`:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=car_rental;User=caruser;Password=1234;"
  }
}
```

**4. Run the project:**
```bash
dotnet run --project Car-Rental
```

**5. Open the API docs:**
```
http://localhost:5266/scalar/v1
```

### API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/customers` | Get all customers |
| GET | `/api/customers/{id}` | Get customer by ID |
| POST | `/api/customers` | Create new customer |
| PUT | `/api/customers/{id}` | Update customer |
| DELETE | `/api/customers/{id}` | Delete customer |
| GET | `/api/vehicles` | Get all vehicles |
| GET | `/api/vehicles/{id}` | Get vehicle by ID |
| POST | `/api/vehicles` | Add new vehicle |
| PUT | `/api/vehicles/{id}` | Update vehicle |
| DELETE | `/api/vehicles/{id}` | Delete vehicle |
| GET | `/api/rentals` | Get all rentals |
| POST | `/api/rentals` | Open new rental |
| PUT | `/api/rentals/{id}` | Close rental (calculates price) |
| GET | `/api/payments` | Get all payments |
| POST | `/api/payments` | Record a payment |

### Technologies

| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET Core | 9.0 | Web API framework |
| Entity Framework Core | 8.0 | ORM |
| Pomelo.EntityFrameworkCore.MySql | 8.0 | MySQL provider |
| AutoMapper | 12.0.1 | Object mapping |
| Scalar.AspNetCore | latest | API documentation |
| MySQL | 8.x | Database |

---

---

## 🇮🇱 עברית

### סקירה כללית

ממשק API מסוג REST לניהול עסק השכרת רכבים. נבנה עם ASP.NET Core תוך שמירה על ארכיטקטורה נקייה בשכבות, תוך שימוש ב-MySQL כבסיס נתונים ו-Entity Framework Core לגישה לנתונים.

### פונקציונליות

- CRUD מלא עבור לקוחות, רכבים, השכרות ותשלומים
- ארכיטקטורה נקייה בשלוש שכבות (API ← Services ← DAL)
- תבניות Repository ו-Service גנריות (`IRepository<T>`, `IService<T>`)
- העברת נתונים באמצעות DTOs ו-AutoMapper
- בסיס נתונים MySQL עם Entity Framework Core (Pomelo)
- תיעוד API דרך ממשק Scalar

### מבנה הפרויקט

```
Car-Rental/
│
├── Car-Rental/              # שכבת API – Controllers, Program.cs
│   └── Controllers/
│       ├── CustomersController.cs
│       ├── VehiclesController.cs
│       ├── RentalsController.cs
│       └── PaymentsController.cs
│
├── Services/                # שכבת לוגיקה עסקית
│   ├── Interfaces/
│   │   └── IService.cs      # ממשק גנרי אחד לכל השירותים
│   ├── Classes/
│   │   ├── CustomerService.cs
│   │   ├── VehiclesService.cs
│   │   ├── RentalsService.cs
│   │   └── PaymentsService.cs
│   ├── DTOs/
│   │   ├── CustomerDTO.cs
│   │   ├── VehicleDTO.cs
│   │   ├── RentalDTO.cs
│   │   └── PaymentDTO.cs
│   └── Mapping/
│       └── MappingProfile.cs
│
├── DAL/                     # שכבת גישה לנתונים
│   ├── Entities/
│   │   ├── Customer.cs
│   │   ├── Vehicle.cs
│   │   ├── Rental.cs
│   │   └── Payment.cs
│   ├── Interfaces/
│   │   └── IRepository.cs   # ממשק גנרי אחד לכל ה-Repositories
│   ├── Repositories/
│   │   ├── CustomerRepository.cs
│   │   ├── VehicleRepository.cs
│   │   ├── RentalRepository.cs
│   │   └── PaymentRepository.cs
│   └── Data/
│       └── AppDbContext.cs
│
└── Infrastructure/          # DTOs משותפים ו-Extensions
    ├── DTOs/
    └── Extensions/
        └── DependencyInjection.cs
```

### ארכיטקטורה

```
לקוח (Client)
  ↓
API (Controllers)         ← מקבל/מחזיר DTOs
  ↓  משתמש ב IService<DTO>
Services (לוגיקה עסקית)   ← ממיר בין DTO ל-Entity
  ↓  משתמש ב IRepository<Entity>
DAL (Repositories)        ← גישה ישירה ל-DB
  ↓
MySQL Database
```

### מודל הנתונים

| Entity | שדות |
|--------|------|
| Customer (לקוח) | Id, FullName, Email, Phone |
| Vehicle (רכב) | Id, Manufacturer, Model, Year, LicensePlate, DailyPrice |
| Rental (השכרה) | Id, CustomerId, CarId, StartDate, EndDate |
| Payment (תשלום) | Id, RentalId, Amount, PaymentDate |

### דרישות מקדימות

- .NET 9.0 SDK
- MySQL Server (מקומי)
- Visual Studio 2022 / 2026

### הוראות הפעלה

**1. שכפלי את הריפוזיטורי:**
```bash
git clone https://github.com/s0583232209/Car-Rental.git
```

**2. הקמי את בסיס הנתונים — הריצי ב-MySQL Workbench:**
```sql
CREATE DATABASE car_rental;
CREATE USER 'caruser'@'localhost' IDENTIFIED BY '1234';
GRANT ALL PRIVILEGES ON car_rental.* TO 'caruser'@'localhost';
FLUSH PRIVILEGES;
```

**3. עדכני את `appsettings.json`:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=car_rental;User=caruser;Password=1234;"
  }
}
```

**4. הריצי את הפרויקט:**
```bash
dotnet run --project Car-Rental
```

**5. פתחי את תיעוד ה-API:**
```
http://localhost:5266/scalar/v1
```

### נקודות קצה של ה-API

| Method | Endpoint | תיאור |
|--------|----------|-------|
| GET | `/api/customers` | קבלת כל הלקוחות |
| GET | `/api/customers/{id}` | קבלת לקוח לפי ID |
| POST | `/api/customers` | יצירת לקוח חדש |
| PUT | `/api/customers/{id}` | עדכון לקוח |
| DELETE | `/api/customers/{id}` | מחיקת לקוח |
| GET | `/api/vehicles` | קבלת כל הרכבים |
| GET | `/api/vehicles/{id}` | קבלת רכב לפי ID |
| POST | `/api/vehicles` | הוספת רכב חדש |
| PUT | `/api/vehicles/{id}` | עדכון רכב |
| DELETE | `/api/vehicles/{id}` | מחיקת רכב |
| GET | `/api/rentals` | קבלת כל ההשכרות |
| POST | `/api/rentals` | פתיחת השכרה חדשה |
| PUT | `/api/rentals/{id}` | סגירת השכרה (חישוב מחיר) |
| GET | `/api/payments` | קבלת כל התשלומים |
| POST | `/api/payments` | תיעוד תשלום |

### טכנולוגיות

| טכנולוגיה | גרסה | מטרה |
|------------|------|------|
| ASP.NET Core | 9.0 | מסגרת Web API |
| Entity Framework Core | 8.0 | ORM |
| Pomelo.EntityFrameworkCore.MySql | 8.0 | ספק MySQL |
| AutoMapper | 12.0.1 | מיפוי אובייקטים |
| Scalar.AspNetCore | עדכני | תיעוד API |
| MySQL | 8.x | בסיס נתונים |

---

*פרויקט סיום קורס C# ו-ASP.NET Core*
