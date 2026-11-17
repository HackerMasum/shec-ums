# ShEC UMS

**Design and Development of ShEC UMS: A Modular Cross-Platform University Management System Using .NET MAUI and Clean Architecture**

ShEC UMS is a modular university management platform initially designed for Shyamoli Engineering College, with an architecture intended to support future expansion to multiple institutions.

> **Development status:** Early development. The solution structure, database infrastructure, initial Student domain model, repository, migration, and domain tests are in place.

## Technology Stack

- .NET 10 and C#
- .NET MAUI
- ASP.NET Core Web API
- Clean Architecture
- Entity Framework Core
- PostgreSQL and Npgsql
- xUnit
- Git and GitHub

## Architecture

```text
ShEC UMS
├── src/
│   ├── ShEC.UMS.Api/
│   ├── ShEC.UMS.App/
│   ├── ShEC.UMS.Application/
│   ├── ShEC.UMS.Domain/
│   └── ShEC.UMS.Infrastructure/
├── tests/
│   └── ShEC.UMS.Domain.Tests/
├── docs/
└── ShEC.UMS.sln
```

The backend follows Clean Architecture and a modular-monolith approach.

- **Domain:** Core entities and business rules.
- **Application:** Use cases and abstractions.
- **Infrastructure:** Database access, EF Core configurations, migrations, and repositories.
- **API:** HTTP endpoints and application entry point.
- **App:** Cross-platform .NET MAUI client.
- **Tests:** Automated domain tests.

## Current Implementation

- [x] Initial .NET solution and project structure
- [x] Clean Architecture project separation
- [x] ASP.NET Core API foundation
- [x] PostgreSQL and EF Core infrastructure
- [x] Student domain entity and validation
- [x] Student repository abstraction and implementation
- [x] Initial Student database migration
- [x] Domain unit tests
- [x] API health endpoint
- [x] Database connectivity health endpoint

## Planned Development

- [ ] Student application service and REST endpoints
- [ ] Student management workflows
- [ ] Authentication and authorization
- [ ] Academic programs, departments, semesters, and courses
- [ ] Student enrollment
- [ ] Attendance management
- [ ] Assessments and results
- [ ] Fees and payment management
- [ ] Admit-card approval workflow
- [ ] Notices and announcements
- [ ] Reporting and audit logs
- [ ] Blazor web client
- [ ] Integration testing and deployment

## Development Setup

Requirements:

- .NET 10 SDK
- Visual Studio with .NET MAUI support
- Required .NET MAUI workloads
- PostgreSQL
- Git

Clone:

```bash
git clone https://github.com/HackerMasum/shec-ums.git
cd shec-ums
```

Restore and build:

```powershell
dotnet restore ShEC.UMS.sln
dotnet build ShEC.UMS.sln
dotnet test ShEC.UMS.sln
```

## Database Configuration

Configure the `ConnectionStrings:ShECUms` connection string using .NET user secrets or an environment variable. Never commit credentials.

Example environment variable:

```text
ConnectionStrings__ShECUms=Host=localhost;Port=5432;Database=shec_ums;Username=postgres;Password=YOUR_PASSWORD
```

Run the API:

```powershell
dotnet run --project src/ShEC.UMS.Api
```

Health endpoints:

- `/health`
- `/health/database`

## Continuous Integration

GitHub Actions validates backend builds and domain tests on pushes and pull requests. The workflow targets backend projects separately from the MAUI platform workloads.

## Security

- Never commit passwords, API keys, or tokens.
- Keep local development settings out of source control.
- Use secure secret storage for deployment.
- Review dependencies and security updates regularly.

## Project Information

- **Project:** ShEC UMS
- **Repository:** https://github.com/HackerMasum/shec-ums
- **Client:** .NET MAUI
- **Backend:** ASP.NET Core Web API
- **Database:** PostgreSQL
- **Architecture:** Clean Architecture / Modular Monolith

*ShEC UMS is an evolving academic software engineering project. Planned features are not necessarily implemented.*
