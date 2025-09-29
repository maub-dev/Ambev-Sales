# Developer Evaluation Project

`READ CAREFULLY`

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop) installed and running
- Visual Studio 2022 or higher (or any compatible IDE)

## Instructions
1. **Clone the repository**\
git clone https://github.com/maub-dev/Ambev-Sales.git

2. **Open the solution in Visual Studio**\
Open Ambev.DeveloperEvaluation.sln.

3. **Configure the database connection**\
Open appsettings.json
Change the connection string from: "Server=ambev_developer_evaluation_database" to: "Server=localhost"

4. **Update the database**\
Run the following command in the terminal:
dotnet ef database update --project Ambev.DeveloperEvaluation.ORM --startup-project Ambev.DeveloperEvaluation.WebApi -v
This command will apply all migrations and create the required database schema in your local PostgreSQL instance.

5. **Restore the original connection string**\
After the database has been updated, revert the Server value in appsettings.json back to: "Server=ambev_developer_evaluation_database"

6. **Run the application**\
Start the Web API project. You can use Visual Studio's debugger.
This will automatically open your browser in Swagger. it will allow you to explore and test all available endpoints.

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)
