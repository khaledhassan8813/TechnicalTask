Person Data API:-

This .NET 6 API provides unified data from two sources (CSV and SQL) and supports optional filtering by name, phone number, or country. It also supports integration with Angular for displaying the data in a user-friendly format.

Features:-

- Fetch data from a CSV file and a SQL database.
- Map SQL data to a unified model.
- Filter data based on name, phone number, or country.
- RESTful API design.

Prerequisites:-

- .NET 6 SDK: Download .NET 6 SDK
- SQL Server: Ensure your database is running and configured.

API Endpoints:-

- Person Data Endpoint
     (GET) /api/person-data

Fetch unified data from CSV and SQL sources. The data can be optionally filtered by name, phone number, or country.

Query Parameters (Optional):-

- name: Filter by first name or last name.
- phone: Filter by phone number.
- country: Filter by country

Software Structure (onion Architecture):-

src/
├── Controllers/
│   ├── UnifiedDataController.cs      # Handles API requests
├── Models/
│   ├── UnifiedDataModel.cs           # Unified data model
│   ├── PersonDetail.cs               # SQL table model
├── Repositories/
│   ├── CsvRepository.cs              # Handles CSV data access
│   ├── SqlRepository.cs              # Handles SQL data access
├── Services/
│   ├── DataService.cs                # Combines and processes data from repositories
├── appsettings.json                  # Configuration settings

Dependencies:-

- Microsoft.EntityFrameworkCore: For database interactions.
- Microsoft.EntityFrameworkCore.SqlServer: SQL Server provider for EF Core.
- CsvHelper: For parsing CSV files.

Design Patterns:-
- Repository Pattern
- Dependency Injection
- DTO (Data Transfer Object) Pattern
- Factory Pattern

Resourecs:-

- csv file in Resources Folder
----------------------------------------------
HTML Page:

path:
project root

scripts:
- jquery
- ajax
-----------------------------------------------------------------------------
-----------------------------------------------------------------------------

