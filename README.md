# IdentityService

## Overview
**IdentityService** is a backend service that manages identity and access control for users within an application. This service includes entities related to user roles, departments, and access permissions, supporting various organizational structures and user management needs.

## Features
- **User Management**: Create, read, update, and delete user data.
- **Role-Based Access Control**: Manage roles, permissions, and assign roles to users.
- **Organizational Hierarchy**: Define departments, divisions, and positions.
- **Page Access Control**: Configure access to specific application pages for users based on roles and permissions.

## Entities
The service includes the following main entities:

1. **App** - Represents an application within the organization.
2. **AppApiKey** - Manages API keys associated with applications for secure access.
3. **AppPage** - Defines pages within the application for access control.
4. **BaseEntity** - Base class providing common fields for all entities.
5. **Company** - Represents the company entity, including divisions and departments.
6. **Department** - Defines departments within the company.
7. **Division** - Represents divisions within the company.
8. **Position** - Defines positions within departments or divisions.
9. **Role** - Specifies roles (e.g., Admin, User) within the application.
10. **User** - Manages user-specific details and relationships to other entities.
11. **UserPageAccess** - Controls access permissions for users on specific application pages.
12. **UserPosition** - Links users to specific positions within the organizational hierarchy.
13. **UserRole** - Assigns roles to users to control access and permissions.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (ensure the correct version for your project)
- Database setup (MS SQL Server)

### Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd IdentityService
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Configure your database settings in `appsettings.json` or another configuration file as needed.

### Database Setup
1. Create a database for the service.
2. Run migrations to set up the database schema (if applicable):
   ```bash
   dotnet ef database update
   ```

### Running the Service

To start the service, use the following command:
```bash
dotnet run
```

The service should now be running at `http://localhost:<port>/`.

## Usage

### API Endpoints

- **User Management**: Manage users and their attributes.
  - `GET /api/users` - List all users
  - `POST /api/users` - Create a new user
  - `PUT /api/users/{id}` - Update user details
  - `DELETE /api/users/{id}` - Delete a user

- **Role Management**: Create, assign, and manage roles.
  - `GET /api/roles` - List all roles
  - `POST /api/roles` - Create a new role
  - `PUT /api/roles/{id}` - Update role details
  - `DELETE /api/roles/{id}` - Delete a role

- **Access Control**: Manage page access and permissions.
  - `GET /api/page-access` - Get user access details for pages
  - `POST /api/page-access` - Set page access for users

Refer to the code for further details on additional endpoints and usage patterns.

## Contributing
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes and commit:
   ```bash
   git commit -m "Add feature description"
   ```
4. Push to your branch:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Submit a pull request.

## License
[MIT License]
