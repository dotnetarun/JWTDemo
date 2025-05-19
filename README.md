# Secure Task Management API
A RESTful API built with .NET 8, showcasing JWT authentication, dependency injection, and the Factory Pattern.

## Features
- JWT-based user authentication (register, login, secure endpoints).
- CRUD operations for tasks, scoped to authenticated users.
- Dependency injection for services, repositories, and authentication.
- Factory Pattern for dynamic repository instantiation (SQL vs. in-memory).
- SQLite database with EF Core.
- Unit tests with xUnit and Moq.
- Swagger UI for API documentation.

## Setup
1. Clone the repo: `git clone <repo-url>`
2. Restore dependencies: `dotnet restore`
3. Update `appsettings.json` with a secure JWT key.
4. Run the app: `dotnet run`
5. Access Swagger UI at `https://localhost:<port>/swagger`

## JWT Implementation
- **Token Generation**: Users receive a JWT upon login, containing user ID and username claims.
- **Token Validation**: Protected endpoints require a valid JWT, verified with a secret key.
- **Security**: Uses BCrypt for password hashing and secure token configuration.
- **DI Integration**: Authentication services are injected, ensuring clean architecture.

## GoF Design Patterns
- **Factory Pattern**: `ITaskRepositoryFactory` dynamically selects repositories.
- Demonstrates encapsulation, DI integration, and testability.
