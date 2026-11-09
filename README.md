# Airline Management System
**A Database-Driven Web Platform for Managing Airline Operations**

Airline Management System is an ASP.NET Core MVC web application designed to manage the core operations of an airline. It connects to a MySQL relational database, designed and tested in MySQL Workbench, and provides an interactive web interface for managing flights, aircraft, airports, passengers, tickets, payments, staff, and crew.

The project combines relational database design, SQL query development, backend programming, and web-based user interfaces in one application.

---

## Project Overview

Airlines handle large amounts of interrelated data: flight schedules, fleets, passenger bookings, payments, and personnel. Managing this data reliably requires a well-structured database and a clear interface on top of it.

Airline Management System provides a centralized platform where operational records can be created, viewed, updated, and organized. The database layer enforces data integrity through primary keys, foreign keys, and relationships between tables, while the web layer makes the data easy to work with.

---

## Key Features

### 1. Flight Management
- Create and manage flight records.
- Link flights to aircraft and airports.
- View organized flight listings.

### 2. Aircraft and Airport Management
- Maintain fleet and aircraft details.
- Manage airport records used for flight routes.

### 3. Passenger and Ticket Management
- Register and manage passenger records.
- Issue tickets linked to passengers and flights.

### 4. Payment Tracking
- Store payment records connected to ticket bookings.

### 5. Staff and Crew Management
- Manage airline staff records.
- Maintain crew details and assignments.

### 6. Web Dashboard
- Home page with navigation to every module.
- Dedicated page for each entity (Flights, Aircraft, Airports, Passengers, Tickets, Staff, Crew).
- Responsive layout built with Bootstrap.

---

## Database Design

The database is built as a normalized relational schema and was designed, populated, and tested in **MySQL Workbench**.

| Table | Purpose |
|-------|---------|
| `Aircraft` | Fleet and aircraft information |
| `Airport` | Airport records and locations |
| `Flight` | Flight schedules and routes |
| `Passenger` | Passenger personal details |
| `Ticket` | Bookings linking passengers to flights |
| `Payment` | Payment records for tickets |
| `Staff` | Airline employee records |
| `CrewDetails` | Crew assignments and details |

**Database highlights**
- Primary keys and foreign keys enforce relationships and data consistency.
- Queries were written and tested in MySQL Workbench, including:
  - `JOIN` queries combining flights, airports, tickets, and passengers
  - Aggregate functions such as `COUNT`, `SUM`, and `AVG`
  - `GROUP BY` and `HAVING` for reporting
  - Subqueries for filtered lookups
- Entity Framework Core maps the tables to C# models through `ApplicationDbContext`.

**Example queries**

```sql
-- Number of passengers booked on each flight
SELECT f.FlightId, COUNT(t.TicketId) AS TotalPassengers
FROM Flight f
JOIN Ticket t ON f.FlightId = t.FlightId
GROUP BY f.FlightId;

-- Total revenue collected from payments
SELECT SUM(Amount) AS TotalRevenue
FROM Payment;
```

> Adjust the table and column names above to match your own schema.

---

## Technologies Used

| Layer | Technology |
|-------|-----------|
| Backend | C#, ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core |
| Database | MySQL |
| Database Tool | MySQL Workbench |
| Frontend | Razor Views, HTML5, CSS3, Bootstrap |
| Version Control | Git and GitHub |

---

## Project Structure

```
Airline-System/
│
├── airport/
│   └── airport/
│       ├── Controllers/
│       │   ├── AircraftController.cs
│       │   ├── AirportController.cs
│       │   ├── CrewDetailsController.cs
│       │   ├── FlightController.cs
│       │   ├── HomeController.cs
│       │   ├── PassengerController.cs
│       │   ├── StaffController.cs
│       │   └── TicketController.cs
│       ├── Data/
│       │   └── ApplicationDbContext.cs
│       ├── Models/
│       │   ├── Aircraft.cs
│       │   ├── Airport.cs
│       │   ├── CrewDetails.cs
│       │   ├── Flight.cs
│       │   ├── Passenger.cs
│       │   ├── Payment.cs
│       │   ├── Staff.cs
│       │   └── Ticket.cs
│       ├── Views/
│       ├── wwwroot/
│       ├── appsettings.json
│       └── airport.csproj
│
├── database/            # SQL schema and sample data (recommended)
├── .gitignore
└── README.md
```

---

## Installation and Setup

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/) and MySQL Workbench
- Git

### 1. Clone the Repository
```bash
git clone https://github.com/<your-username>/<your-repository>.git
```

### 2. Navigate to the Project Directory
```bash
cd <your-repository>/airport/airport
```

### 3. Set Up the Database
1. Open **MySQL Workbench** and connect to your MySQL server.
2. Run the SQL script from the `database` folder to create the schema and sample data.

### 4. Configure the Connection String
Update `appsettings.json` with your MySQL credentials:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=airline_db;user=YOUR_USER;password=YOUR_PASSWORD"
}
```

### 5. Restore Dependencies and Run
```bash
dotnet restore
dotnet run
```

### 6. Open the Application
Open the local address shown in the terminal, typically:

```
https://localhost:5001
```

---

## Application Modules

| Route | Purpose |
|-------|---------|
| `/Home` | Landing page and navigation |
| `/Flight` | Flight management |
| `/Aircraft` | Aircraft management |
| `/Airport` | Airport management |
| `/Passenger` | Passenger records |
| `/Ticket` | Ticket booking records |
| `/Staff` | Staff records |
| `/CrewDetails` | Crew details and assignments |

---

## Learning Outcomes

This project demonstrates practical experience with:

- Relational database design and normalization.
- Writing and testing SQL queries in MySQL Workbench.
- Primary key, foreign key, and constraint design.
- ASP.NET Core MVC architecture (Models, Views, Controllers).
- Object-relational mapping with Entity Framework Core.
- Connecting a web application to a MySQL database.
- Building responsive interfaces with Bootstrap.
- Version control with Git and GitHub.

---

## Future Improvements

- Search and filtering for flights and passengers.
- User authentication and role-based access (admin, staff, customer).
- Online seat selection and booking workflow.
- Dashboard with revenue and occupancy charts.
- Stored procedures, views, and triggers for advanced database logic.
- Export of reports to PDF or Excel.

---

## Project Information

- **Project Name:** Airline Management System
- **Category:** Database Management Systems / Web Development
- **Primary Language:** C#
- **Framework:** ASP.NET Core MVC (.NET 8)
- **Database:** MySQL (MySQL Workbench)

---

## Author

Subhan ALI 

Computer Science Student | Software Developer | AI Engineer |

GitHub: @subhanaligrw444-rgb

*Built as an academic software development project to demonstrate relational database design, SQL query development, and full-stack web application development.*
